using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
                lbox_clientes.SelectedValuePath = "Id"; //Esto es lo que buscaria al hacerle click a cada pestana digamos (9)
                lbox_clientes.ItemsSource = clienteTabla.DefaultView; //Sirve para darle el formato a nuestra tabla (10)
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
    }
}
