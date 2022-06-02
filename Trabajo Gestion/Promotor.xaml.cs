using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MessageBox = System.Windows.Forms.MessageBox;

namespace Trabajo_Gestion
{
    /// <summary>
    /// Lógica de interacción para Promotor.xaml
    /// </summary>
    public partial class Promotor : Window
    {
        SqlConnection sqlConnection; //Instanciamos la clase SqlConnection (2do paso) (sirve para la conexion)

        public Promotor()
        {
            //Aca declaramos la propiedad connectionString (1er paso)
            string connectionString = ConfigurationManager.ConnectionStrings["Trabajo_Gestion.Properties.Settings.ProyectoGestionConnectionString"].ConnectionString;

            sqlConnection = new SqlConnection(connectionString); //Inicializamos la conexion (3er paso)

            InitializeComponent();
            MostrarPromotores();
        }

        private void MostrarPromotores()
        {
            try
            {
                string consulta = "select * from Promotor"; //Creo la consulta (4to paso)

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(consulta, sqlConnection); //Creo el adaptador (adapta el codigo c# al codigo sql) (5to paso)

                DataTable promotorTabla = new DataTable(); //Creamos este datatable que nos va a permitir almacenar datos de tablas en un objeto (6to paso)
                sqlDataAdapter.Fill(promotorTabla); //Este metodo sirve para ejecutar el adaptador. (7)

                using (sqlDataAdapter)
                {
                    lbox_promotores.DisplayMemberPath = "Nombre"; //Aca estamos haciendo que en la list box muestre solo la parte de los nombres de la tabla (8)
                    lbox_promotores.SelectedValuePath = "PromotorID"; //Esto es lo que buscaria al hacerle click a cada pestana digamos (9)
                    lbox_promotores.ItemsSource = promotorTabla.DefaultView; //Sirve para darle el formato a nuestra tabla (10)
                }
            }
            catch (Exception e0)
            {
                MessageBox.Show(e0.ToString(),"Muestra de promotores");
            }
        }
        private void MostrarDescripciones()
        {
            try
            {
                string consulta = "select * from Promotor where PromotorID = @Id";

                SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                using (sqlDataAdapter)
                {
                    sqlCommand.Parameters.AddWithValue("@Id", lbox_promotores.SelectedValue);

                    DataTable promotorDescTabla = new DataTable(); //Creamos este datatable que nos va a permitir almacenar datos de tablas en un objeto (6to paso)
                    sqlDataAdapter.Fill(promotorDescTabla); //Este metodo sirve para ejecutar el adaptador. (7)

                    lbox_promotoresDetalles.DisplayMemberPath = "Descripcion"; //Aca estamos haciendo que en la list box muestre solo la parte de los nombres de la tabla (8)
                    lbox_promotoresDetalles.SelectedValuePath = "PromotorID"; //Esto es lo que buscaria al hacerle click a cada pestana digamos (9)
                    lbox_promotoresDetalles.ItemsSource = promotorDescTabla.DefaultView; //Sirve para darle el formato a nuestra tabla (10)
                }
            }
            catch (Exception e1)
            {
               // MessageBox.Show(e1.ToString(),"Muestra de descripciones");
            }
        }
        private void btn_agregarPromotor_Click(object sender, RoutedEventArgs e) 
        {
            try
            {
                string consulta = "insert into Promotor (PromotorID,Nombre,Descripcion) values (@Id, @Nombre, @Descripcion)";
                SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);
                sqlConnection.Open();

                var res = MessageBox.Show("Desea agregar a " + tbox_nombrePromotor.Text + " a la lista de promotores?", "Alta de promotor", MessageBoxButtons.YesNo);
                switch (res)
                {
                    case System.Windows.Forms.DialogResult.Yes:
                        sqlCommand.Parameters.AddWithValue("@Id", tbox_idPromotor.Text);
                        sqlCommand.Parameters.AddWithValue("@Nombre", tbox_nombrePromotor.Text);
                        sqlCommand.Parameters.AddWithValue("@Descripcion", tbox_descripcion.Text);
                        sqlCommand.ExecuteScalar();
                        Thread.Sleep(1000);
                        MessageBox.Show($"Se ha dado de alta a {tbox_nombrePromotor.Text} correctamente!", "Alta de promotor");
                        break;
                    case System.Windows.Forms.DialogResult.No:
                        MessageBox.Show($"Se no se ha dado de alta al promotor {tbox_nombrePromotor.Text}!", "Alta de promotor");
                        break;
                    default:
                        break;
                }
            }
            catch (Exception e2)
            {
               MessageBox.Show(e2.ToString(), "Alta de promotor");
            }
            finally
            {
                sqlConnection.Close();
                MostrarPromotores();
                tbox_nombrePromotor.Clear();
                tbox_descripcion.Clear();
                tbox_idPromotor.Clear();
            }
        }

        private void btn_borrarPromotor_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string consulta = "delete from Promotor where PromotorID = @Id";
                SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);
                sqlConnection.Open();

                var res = MessageBox.Show("Desea eliminar al promotor seleccionado de la lista?", "Alta de promotor", MessageBoxButtons.YesNo);
                switch (res)
                {
                    case System.Windows.Forms.DialogResult.Yes:
                        sqlCommand.Parameters.AddWithValue("@Id", lbox_promotores.SelectedValue);
                        sqlCommand.ExecuteScalar();
                        Thread.Sleep(1000);
                        MessageBox.Show($"Se ha eliminado al promotor correctamente!", "Alta de promotor");
                        break;
                    case System.Windows.Forms.DialogResult.No:
                        MessageBox.Show($"Se no se ha eliminado al promotor seleccionado!", "Alta de promotor");
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Eliminar promotor");
            }
            finally
            {
                sqlConnection.Close();
                MostrarPromotores();
            }
        }

        private void btn_actualizarPromotor_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                string consulta = "update Promotor set Nombre = @Nombre, Descripcion = @Descripcion where PromotorID = @IdS";

                SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);
                sqlConnection.Open();

                var res = MessageBox.Show("Esta seguro que desea actualizar al promotor seleccionado?", "Alta de promotor", MessageBoxButtons.YesNo);
                switch (res)
                {
                    case System.Windows.Forms.DialogResult.Yes:
                        sqlCommand.Parameters.AddWithValue("@Nombre", tbox_nombrePromotor.Text);
                        sqlCommand.Parameters.AddWithValue("@Descripcion", tbox_descripcion.Text);
                        sqlCommand.Parameters.AddWithValue("@IdS", tbox_idPromotor.Text);
                        sqlCommand.ExecuteScalar();
                        Thread.Sleep(1000);
                        MessageBox.Show($"Se ha actualizado al promotor correctamente!", "Alta de promotor");
                        break;
                    case System.Windows.Forms.DialogResult.No:
                        MessageBox.Show($"No se ha actualizado al promotor seleccionado!", "Alta de promotor");
                        break;
                    default:
                        break;
                }


                
            
            }
            catch (Exception e3)
            {
                MessageBox.Show(e3.ToString(),"Actualizacion de promotores");
            }
            finally
            {
                sqlConnection.Close();
                MostrarPromotores();
                tbox_nombrePromotor.Clear();
                tbox_descripcion.Clear();
                tbox_idPromotor.Clear();
            }
            
        }

        private void lbox_promotores_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MostrarDescripciones();
            
        }

        private void btn_atrasPromotor_Click(object sender, RoutedEventArgs e)
        {
            Localidad localidad = new Localidad();
            localidad.Show();
            Close();
        }

        private void btn_siguientePromotor_Click(object sender, RoutedEventArgs e)
        {
            Cliente cliente = new Cliente();
            cliente.Show();
            Close();
        }

        private void btn_menuPromotor_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Close();
        }

        private void btn_consultasPromotor_Click(object sender, RoutedEventArgs e)
        {
            ConsultasPromotor consultas = new ConsultasPromotor();
            consultas.Show();
            Close();
        }
    }
}
