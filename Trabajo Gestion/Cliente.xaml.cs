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
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class Cliente : Window
    {
        SqlConnection sqlConnection;
        public Cliente()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Trabajo_Gestion.Properties.Settings.ProyectoGestionConnectionString"].ConnectionString;
            sqlConnection = new SqlConnection(connectionString);

            InitializeComponent();
            MostrarClientes();
            LocalidadesCB();
            PromotorCB();
        }

        private void MostrarClientes()
        {
            string consulta = "select * from Cliente"; //Creo la consulta (4to paso)

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(consulta, sqlConnection); //Creo el adaptador (adapta el codigo c# al codigo sql) (5to paso)

            using (sqlDataAdapter)
            {
                DataTable clienteTabla = new DataTable(); //Creamos este datatable que nos va a permitir almacenar datos de tablas en un objeto (6to paso)
                sqlDataAdapter.Fill(clienteTabla); //Este metodo sirve para ejecutar el adaptador. (7)

                lbox_clientes.DisplayMemberPath = "Nombre"; //Aca estamos haciendo que en la list box muestre solo la parte de los nombres de la tabla (8)
                lbox_clientes.SelectedValuePath = "ClienteID"; //Esto es lo que buscaria al hacerle click a cada pestana digamos (9)
                lbox_clientes.ItemsSource = clienteTabla.DefaultView; //Sirve para darle el formato a nuestra tabla (10)
            }
        }
        private void MostrarDetalles()
        {
            try
            {
                string consulta = "select * from Cliente where ClienteID = @Id";

                SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                using (sqlDataAdapter)
                {
                    sqlCommand.Parameters.AddWithValue("@Id", lbox_clientes.SelectedValue);

                    DataTable clientesDescTabla = new DataTable(); //Creamos este datatable que nos va a permitir almacenar datos de tablas en un objeto (6to paso)
                    sqlDataAdapter.Fill(clientesDescTabla); //Este metodo sirve para ejecutar el adaptador. (7)

                    lbox_clientesDetalles.DisplayMemberPath = "Descripcion"; //Aca estamos haciendo que en la list box muestre solo la parte de los nombres de la tabla (8)
                    lbox_clientesDetalles.SelectedValuePath = "ClienteID"; //Esto es lo que buscaria al hacerle click a cada pestana digamos (9)
                    lbox_clientesDetalles.ItemsSource = clientesDescTabla.DefaultView; //Sirve para darle el formato a nuestra tabla (10)
                }
            }
            catch (Exception e1)
            {
                // MessageBox.Show(e1.ToString(),"Muestra de descripciones");
            }
        }
        private void LocalidadesCB()
        {
            string consulta = "select * from Localidad";
            try
            {
                sqlConnection.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(consulta, sqlConnection);

                using (sqlDataAdapter)
                {
                    DataTable localidadesDGTabla = new DataTable(); //Creamos este datatable que nos va a permitir almacenar datos de tablas en un objeto (6to paso)
                    sqlDataAdapter.Fill(localidadesDGTabla); //Este metodo sirve para ejecutar el adaptador. (7)

                    cb_localidadID.DisplayMemberPath = "Nombre"; //Aca estamos haciendo que en la list box muestre solo la parte de los nombres de la tabla (8)
                    cb_localidadID.SelectedValuePath = "LocalidadID"; //Esto es lo que buscaria al hacerle click a cada pestana digamos (9)
                    cb_localidadID.ItemsSource = localidadesDGTabla.DefaultView; //Sirve para darle el formato a nuestra tabla (10)
                }
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        private void PromotorCB()
        {
            string consulta = "select * from Promotor";
            try
            {
                sqlConnection.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(consulta, sqlConnection);

                using (sqlDataAdapter)
                {
                    DataTable promotorDGTabla = new DataTable(); //Creamos este datatable que nos va a permitir almacenar datos de tablas en un objeto (6to paso)
                    sqlDataAdapter.Fill(promotorDGTabla); //Este metodo sirve para ejecutar el adaptador. (7)

                    cb_promotorID.DisplayMemberPath = "Nombre"; //Aca estamos haciendo que en la list box muestre solo la parte de los nombres de la tabla (8)
                    cb_promotorID.SelectedValuePath = "PromotorID"; //Esto es lo que buscaria al hacerle click a cada pestana digamos (9)
                    cb_promotorID.ItemsSource = promotorDGTabla.DefaultView; //Sirve para darle el formato a nuestra tabla (10)
                }
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        private void btn_borrarClientes_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string consulta = "delete from Cliente where ClienteID = @Id";
                SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);
                sqlConnection.Open();

                var res = MessageBox.Show("Desea eliminar al cliente seleccionado de la lista?", "Alta de cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                switch (res)
                {
                    case System.Windows.Forms.DialogResult.Yes:
                        sqlCommand.Parameters.AddWithValue("@Id", lbox_clientes.SelectedValue);
                        sqlCommand.ExecuteScalar();
                        Thread.Sleep(1000);
                        MessageBox.Show($"Se ha eliminado al cliente correctamente!", "Alta de cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case System.Windows.Forms.DialogResult.No:
                        MessageBox.Show($"No se ha eliminado al cliente seleccionado!", "Alta de cliente", MessageBoxButtons.OK,MessageBoxIcon.Error);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Eliminar cliente");
            }
            finally
            {
                sqlConnection.Close();
                MostrarClientes();
            }
        }
        private void btn_agregarClientes_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string consulta = "insert into Cliente (ClienteID,Nombre,Domicilio,IdLocalidad,IdPromotor,Saldo,Descripcion) values (@Id, @Nombre, @Domicilio, @Localidad, @Promotor, @Saldo, @Descripcion)";
                SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);
                sqlConnection.Open();

                var res = MessageBox.Show($"Desea agregar al cliente {tbox_nombreCliente.Text} a la lista?", "Alta de cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                switch (res)
                {
                    case System.Windows.Forms.DialogResult.Yes:
                        sqlCommand.Parameters.AddWithValue("@Id", tbox_idCliente.Text);
                        sqlCommand.Parameters.AddWithValue("@Nombre", tbox_nombreCliente.Text);
                        sqlCommand.Parameters.AddWithValue("@Domicilio", tbox_domicilioCliente.Text);
                        sqlCommand.Parameters.AddWithValue("@Localidad", cb_localidadID.SelectedValue);
                        sqlCommand.Parameters.AddWithValue("@Promotor", cb_promotorID.SelectedValue);
                        sqlCommand.Parameters.AddWithValue("@Saldo", tbox_saldoCliente.Text);
                        sqlCommand.Parameters.AddWithValue("@Descripcion", tbox_Descripcion.Text);
                        sqlCommand.ExecuteScalar();
                        Thread.Sleep(1000);
                        MessageBox.Show($"Se ha agregado al cliente correctamente!", "Alta de cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case System.Windows.Forms.DialogResult.No:
                        MessageBox.Show($"No se ha agregado al cliente seleccionado!", "Alta de cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Alta de cliente");
            }
            finally
            {
                sqlConnection.Close();
                MostrarClientes();
                tbox_idCliente.Clear();
                tbox_nombreCliente.Clear();
                tbox_domicilioCliente.Clear();
                cb_localidadID.SelectedIndex = -1;
                cb_promotorID.SelectedIndex = -1;
                tbox_saldoCliente.Clear();
                tbox_Descripcion.Clear();
            }
        }
        private void btn_atrasCliente_Click(object sender, RoutedEventArgs e)
        {
            Promotor promotor = new Promotor();
            promotor.Show();
            Close();
        }
        private void btn_siguienteCliente_Click(object sender, RoutedEventArgs e)
        {
            Provincia provincia = new Provincia();
            provincia.Show();
            Close();
        }
        private void btn_menuCliente_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
        private void lbox_clientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MostrarDetalles();
        }
        private void btn_actualizarCliente_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                string consulta = "update Cliente set Nombre = @Nombre, Domicilio = @Domicilio, IdLocalidad = @Localidad, IdPromotor = @Promotor, Descripcion = @Descripcion, Saldo = @Saldo where ClienteID = @Id";

                SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);
                sqlConnection.Open();

                var res = MessageBox.Show("Esta seguro que desea actualizar el cliente seleccionado?", "Alta de cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                switch (res)
                {
                    case System.Windows.Forms.DialogResult.Yes:
                        sqlCommand.Parameters.AddWithValue("@Id", lbox_clientes.SelectedValue);
                        sqlCommand.Parameters.AddWithValue("@Nombre", tbox_nombreCliente.Text);
                        sqlCommand.Parameters.AddWithValue("@Domicilio", tbox_domicilioCliente.Text);
                        sqlCommand.Parameters.AddWithValue("@Localidad", cb_localidadID.SelectedValue);
                        sqlCommand.Parameters.AddWithValue("@Promotor", cb_promotorID.SelectedValue);
                        sqlCommand.Parameters.AddWithValue("@Saldo", tbox_saldoCliente.Text);
                        sqlCommand.Parameters.AddWithValue("@Descripcion", tbox_Descripcion.Text);
                        sqlCommand.ExecuteScalar();
                        Thread.Sleep(1000);
                        MessageBox.Show($"Se ha actualizado al cliente correctamente!", "Alta de cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case System.Windows.Forms.DialogResult.No:
                        MessageBox.Show($"No se ha actualizado al cliente seleccionado!", "Alta de cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception e3)
            {
                MessageBox.Show(e3.ToString(), "Actualizacion de cliente");
            }
            finally
            {
                sqlConnection.Close();
                MostrarClientes();
                tbox_nombreCliente.Clear();
                tbox_Descripcion.Clear();
                tbox_domicilioCliente.Clear();
                tbox_saldoCliente.Clear();
                tbox_idCliente.Clear();
                cb_localidadID.SelectedIndex = -1;
                cb_promotorID.SelectedIndex = -1;
            }
        }

        private void btn_consultas_Click(object sender, RoutedEventArgs e)
        {
            ConsultaCliente consultaCliente = new ConsultaCliente();
            consultaCliente.Show();
            Close();
        }
    }
}

