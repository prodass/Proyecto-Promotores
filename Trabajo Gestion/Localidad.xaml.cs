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
    /// Lógica de interacción para Localidad.xaml
    /// </summary>
    public partial class Localidad : Window
    {
        SqlConnection sqlConnection;
        public Localidad()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Trabajo_Gestion.Properties.Settings.ProyectoGestionConnectionString"].ConnectionString;

            sqlConnection = new SqlConnection(connectionString);

            InitializeComponent();
            MostrarLocalidades();
            MostrarID();
        }

        private void MostrarLocalidades()
        {
            string consulta = "select * from Localidad"; //Creo la consulta (4to paso)

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(consulta, sqlConnection); //Creo el adaptador (adapta el codigo c# al codigo sql) (5to paso)

            using (sqlDataAdapter)
            {
                DataTable localidadesTabla = new DataTable(); //Creamos este datatable que nos va a permitir almacenar datos de tablas en un objeto (6to paso)
                sqlDataAdapter.Fill(localidadesTabla); //Este metodo sirve para ejecutar el adaptador. (7)

                lbox_localidades.DisplayMemberPath = "Nombre"; //Aca estamos haciendo que en la list box muestre solo la parte de los nombres de la tabla (8)
                lbox_localidades.SelectedValuePath = "LocalidadID"; //Esto es lo que buscaria al hacerle click a cada pestana digamos (9)
                lbox_localidades.ItemsSource = localidadesTabla.DefaultView; //Sirve para darle el formato a nuestra tabla (10)
            }
        }
        private void MostrarDetalles()
        {
            try
            {
                string consulta = "select * from Localidad where LocalidadID = @Id";

                SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                using (sqlDataAdapter)
                {
                    sqlCommand.Parameters.AddWithValue("@Id", lbox_localidades.SelectedValue);

                    DataTable localidadDescTabla = new DataTable(); //Creamos este datatable que nos va a permitir almacenar datos de tablas en un objeto (6to paso)
                    sqlDataAdapter.Fill(localidadDescTabla); //Este metodo sirve para ejecutar el adaptador. (7)

                    lbox_localidadesDetalles.DisplayMemberPath = "Descripcion"; //Aca estamos haciendo que en la list box muestre solo la parte de los nombres de la tabla (8)
                    lbox_localidadesDetalles.SelectedValuePath = "LocalidadID"; //Esto es lo que buscaria al hacerle click a cada pestana digamos (9)
                    lbox_localidadesDetalles.ItemsSource = localidadDescTabla.DefaultView; //Sirve para darle el formato a nuestra tabla (10)
                }
            }
            catch (Exception e1)
            {
                // MessageBox.Show(e1.ToString(),"Muestra de descripciones");
            }
        }
        private void MostrarID()
        {
            
            string consulta = "select * from Provincia";
            try
            {
                sqlConnection.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(consulta, sqlConnection);

                using (sqlDataAdapter)
                {
                    DataTable localidadesDGTabla = new DataTable(); //Creamos este datatable que nos va a permitir almacenar datos de tablas en un objeto (6to paso)
                    sqlDataAdapter.Fill(localidadesDGTabla); //Este metodo sirve para ejecutar el adaptador. (7)

                    cb_provinciaID.DisplayMemberPath = "Nombre"; //Aca estamos haciendo que en la list box muestre solo la parte de los nombres de la tabla (8)
                    cb_provinciaID.SelectedValuePath = "ProvinciaID"; //Esto es lo que buscaria al hacerle click a cada pestana digamos (9)
                    cb_provinciaID.ItemsSource = localidadesDGTabla.DefaultView; //Sirve para darle el formato a nuestra tabla (10)
                }
            }
            finally
            {
                sqlConnection.Close();
            }
            
        }
        
        private void lbox_localidades_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MostrarDetalles();
        }
        private void btn_agregarLocalidades_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string consulta = "insert into Localidad (LocalidadID,Nombre,Descripcion,IdProvincia) values (@Id, @Nombre, @Descripcion, @Provincia)";
                SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);
                sqlConnection.Open();

                var res = MessageBox.Show("Desea agregar la localidad ingresada?", "Alta de localidad", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                switch (res)
                {
                    case System.Windows.Forms.DialogResult.Yes:
                        sqlCommand.Parameters.AddWithValue("@Id", tbox_idLocalidad.Text);
                        sqlCommand.Parameters.AddWithValue("@Nombre", tbox_nombreLocalidad.Text);
                        sqlCommand.Parameters.AddWithValue("@Descripcion", tbox_Descripcion.Text);
                        sqlCommand.Parameters.AddWithValue("@Provincia", cb_provinciaID.SelectedValue);
                        sqlCommand.ExecuteScalar();
                        Thread.Sleep(1000);
                        MessageBox.Show($"Se ha agregado la localidad correctamente!", "Alta de localidad", MessageBoxButtons.OK,MessageBoxIcon.Information);
                        break;
                    case System.Windows.Forms.DialogResult.No:
                        MessageBox.Show($"No se ha agregado la localidad ingresada!", "Alta de localidad", MessageBoxButtons.OK,MessageBoxIcon.Error);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Alta de localidad");
            }
            finally
            {
                sqlConnection.Close();
                MostrarLocalidades();
                tbox_nombreLocalidad.Clear();
                tbox_Descripcion.Clear();
                tbox_idLocalidad.Clear();
                cb_provinciaID.SelectedIndex = -1;
            }
        }
        private void btn_atrasLocalidades_Click(object sender, RoutedEventArgs e)
        {
            Provincia provincia = new Provincia();
            provincia.Show();
            Close();
        }
        private void btn_siguienteLocalidades_Click(object sender, RoutedEventArgs e)
        {
            Promotor promotor = new Promotor();
            promotor.Show();
            Close();
        }
        private void btn_menuLocalidades_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Close();
        }

        private void btn_actualizarLocalidades_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string consulta = "update Localidad set Nombre = @Nombre, Descripcion = @Descripcion, IdProvincia = @Provincia where LocalidadID = @Id";

                SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);
                sqlConnection.Open();

                var res = MessageBox.Show("Esta seguro que desea actualizar la localidad seleccionada?", "Alta de localidad", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                switch (res)
                {
                    case System.Windows.Forms.DialogResult.Yes:
                        sqlCommand.Parameters.AddWithValue("@Nombre", tbox_nombreLocalidad.Text);
                        sqlCommand.Parameters.AddWithValue("@Descripcion", tbox_Descripcion.Text);
                        sqlCommand.Parameters.AddWithValue("@Provincia", cb_provinciaID.SelectedValue);
                        sqlCommand.Parameters.AddWithValue("@Id", lbox_localidades.SelectedValue);
                        sqlCommand.ExecuteScalar();
                        Thread.Sleep(1000);
                        MessageBox.Show($"Se ha actualizado la localidad correctamente!", "Alta de localidad", MessageBoxButtons.OK,MessageBoxIcon.Information);
                        break;
                    case System.Windows.Forms.DialogResult.No:
                        MessageBox.Show($"No se ha actualizado la localidad seleccionada!", "Alta de localidad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception e3)
            {
                MessageBox.Show(e3.ToString(), "Actualizacion de localidad");
            }
            finally
            {
                sqlConnection.Close();
                MostrarLocalidades();
                tbox_nombreLocalidad.Clear();
                tbox_Descripcion.Clear();
                tbox_idLocalidad.Clear();
                cb_provinciaID.SelectedIndex = -1;
            }
        }

        private void btn_borrarLocalidades_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string consulta = "delete from Localidad where LocalidadID = @Id";
                SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);
                sqlConnection.Open();

                var res = MessageBox.Show("Desea eliminar la localidad seleccionada de la lista?", "Alta de localidad", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                switch (res)
                {
                    case System.Windows.Forms.DialogResult.Yes:
                        sqlCommand.Parameters.AddWithValue("@Id", lbox_localidades.SelectedValue);
                        sqlCommand.ExecuteScalar();
                        Thread.Sleep(1000);
                        MessageBox.Show($"Se ha eliminado la localidad correctamente!", "Alta de localidad", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case System.Windows.Forms.DialogResult.No:
                        MessageBox.Show($"No se ha eliminado la localidad seleccionada!", "Alta de localidad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Eliminar localidad");
            }
            finally
            {
                sqlConnection.Close();
                MostrarLocalidades();
            }
        }

        private void btn_consultas_Click(object sender, RoutedEventArgs e)
        {
            LocalidadesConsulta localidadesConsulta = new LocalidadesConsulta();
            localidadesConsulta.Show();
            Close();
        }
    }
}
