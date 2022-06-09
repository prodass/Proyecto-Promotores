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
    /// Lógica de interacción para Provincia.xaml
    /// </summary>
    public partial class Provincia : Window
    {
        SqlConnection sqlConnection;
        public Provincia()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Trabajo_Gestion.Properties.Settings.ProyectoGestionConnectionString"].ConnectionString;

            sqlConnection = new SqlConnection(connectionString); 

            InitializeComponent();
            MostrarProvincias();
        }
        private void MostrarProvincias()
        {
            try
            {
                string consulta = "select * from Provincia"; //Creo la consulta (4to paso)

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(consulta, sqlConnection); //Creo el adaptador (adapta el codigo c# al codigo sql) (5to paso)

                using (sqlDataAdapter)
                {
                    DataTable provinciaTabla = new DataTable(); //Creamos este datatable que nos va a permitir almacenar datos de tablas en un objeto (6to paso)
                    sqlDataAdapter.Fill(provinciaTabla); //Este metodo sirve para ejecutar el adaptador. (7)

                    lbox_provincias.DisplayMemberPath = "Nombre"; //Aca estamos haciendo que en la list box muestre solo la parte de los nombres de la tabla (8)
                    lbox_provincias.SelectedValuePath = "ProvinciaID"; //Esto es lo que buscaria al hacerle click a cada pestana digamos (9)
                    lbox_provincias.ItemsSource = provinciaTabla.DefaultView; //Sirve para darle el formato a nuestra tabla (10)
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Muestra de provincia");
            }
            finally
            {
                tbox_idProvincia.Clear();
                tbox_nombreProvincia.Clear();
            }
        }
        private void MostrarDetalles()
        {
            try
            {
                string consulta = "select * from Provincia where ProvinciaID = @Id";

                SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                using (sqlDataAdapter)
                {
                    sqlCommand.Parameters.AddWithValue("@Id", lbox_provincias.SelectedValue);

                    DataTable provinciasDescTabla = new DataTable(); //Creamos este datatable que nos va a permitir almacenar datos de tablas en un objeto (6to paso)
                    sqlDataAdapter.Fill(provinciasDescTabla); //Este metodo sirve para ejecutar el adaptador. (7)

                    lbox_provinciasDetalles.DisplayMemberPath = "Descripcion"; //Aca estamos haciendo que en la list box muestre solo la parte de los nombres de la tabla (8)
                    lbox_provinciasDetalles.SelectedValuePath = "ProvinciaID"; //Esto es lo que buscaria al hacerle click a cada pestana digamos (9)
                    lbox_provinciasDetalles.ItemsSource = provinciasDescTabla.DefaultView; //Sirve para darle el formato a nuestra tabla (10)
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString(), "Mostrar detalles");
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        private void btn_agregarProvincias_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string consulta = "insert into Provincia (ProvinciaID,Nombre,Descripcion) values (@Id, @Nombre, @Descripcion)";
                SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);
                sqlConnection.Open();
                if (tbox_idProvincia.Text != "")
                {
                    var res = MessageBox.Show($"Desea agregar a {tbox_nombreProvincia.Text} a la lista de provincias?", "Alta de provincias", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    switch (res)
                    {
                        case System.Windows.Forms.DialogResult.Yes:
                            sqlCommand.Parameters.AddWithValue("@Id", tbox_idProvincia.Text);
                            sqlCommand.Parameters.AddWithValue("@Nombre", tbox_nombreProvincia.Text);
                            sqlCommand.Parameters.AddWithValue("@Descripcion", tbox_Descripcion.Text);
                            sqlCommand.ExecuteScalar();
                            Thread.Sleep(1000);
                            MessageBox.Show($"Se ha dado de alta a {tbox_nombreProvincia.Text} correctamente!", "Alta de provincia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case System.Windows.Forms.DialogResult.No:
                            MessageBox.Show($"Se no se ha dado de alta a {tbox_nombreProvincia.Text}!", "Alta de provincia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    MessageBox.Show($"Usted necesita completar los campos correspondientes!", "Alta de provincia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            catch (Exception e2)
            {
                //MessageBox.Show(e2.ToString(), "Alta de promotor");
            }
            finally
            {
                sqlConnection.Close();
                MostrarProvincias();
                tbox_nombreProvincia.Clear();
                tbox_Descripcion.Clear();
                tbox_idProvincia.Clear();
            }
        }
        private void btn_borrarProvincias_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string consulta = "delete from Provincia where ProvinciaID = @Id";
                SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);
                sqlConnection.Open();
                
                if (lbox_provincias.SelectedValuePath != null) //NO FUNCIONA
                 {
                    var res = MessageBox.Show("Desea eliminar a la provincia seleccionada de la lista?", "Alta de provincia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    switch (res)
                    {
                        case System.Windows.Forms.DialogResult.Yes:
                            sqlCommand.Parameters.AddWithValue("@Id", lbox_provincias.SelectedValue);
                            sqlCommand.ExecuteScalar();
                            Thread.Sleep(1000);
                            MessageBox.Show($"Se ha eliminado a la provincia correctamente!", "Alta de provincia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case System.Windows.Forms.DialogResult.No:
                            MessageBox.Show($"No se ha eliminado a la provincia seleccionada!", "Alta de provincia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    MessageBox.Show($"Usted necesita completar los campos correspondientes!", "Alta de provincia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception l)
            {
                //MessageBox.Show(l.ToString(), "Eliminar provincia");
            }
            finally
            {
                sqlConnection.Close();
                MostrarProvincias();
            }
        }
        private void btn_actualizarProvincias_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string consulta = "update Provincia set Nombre = @Nombre, Descripcion = @Descripcion where ProvinciaID = @Id";

                SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);
                sqlConnection.Open();

                if (tbox_idProvincia.Text != "")
                {
                    var res = MessageBox.Show("Esta seguro que desea actualizar la provincia seleccionada?", "Alta de provincia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    switch (res)
                    {
                        case System.Windows.Forms.DialogResult.Yes:
                            sqlCommand.Parameters.AddWithValue("@Nombre", tbox_nombreProvincia.Text);
                            sqlCommand.Parameters.AddWithValue("@Descripcion", tbox_Descripcion.Text);
                            sqlCommand.Parameters.AddWithValue("@Id", lbox_provincias.SelectedValue);
                            sqlCommand.ExecuteScalar();
                            Thread.Sleep(1000);
                            MessageBox.Show($"Se ha actualizado a la provincia correctamente!", "Alta de promotor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case System.Windows.Forms.DialogResult.No:
                            MessageBox.Show($"No se ha actualizado la provincia seleccionada!", "Alta de promotor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    MessageBox.Show($"Usted necesita completar los campos correspondientes!", "Alta de provincia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception e3)
            {
                MessageBox.Show(e3.ToString(), "Actualizacion de provincias");
            }
            finally
            {
                sqlConnection.Close();
                MostrarProvincias();
                tbox_nombreProvincia.Clear();
                tbox_Descripcion.Clear();
                tbox_idProvincia.Clear();
            }
        }
        private void btn_atrasProvincias_Click(object sender, RoutedEventArgs e)
        {
            Cliente cliente = new Cliente();
            cliente.Show();
            Close();
        }
        private void btn_siguienteProvincias_Click(object sender, RoutedEventArgs e)
        {
            Localidad localidad = new Localidad();
            localidad.Show();
            Close();
        }
        private void btn_menuProvincias_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Close();
        }
        private void lbox_provincias_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MostrarDetalles();
        }
    }
}
