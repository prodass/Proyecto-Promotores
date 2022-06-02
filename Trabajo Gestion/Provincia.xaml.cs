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
using System.Windows.Shapes;

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
            string consulta = "select * from Provincia"; //Creo la consulta (4to paso)

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(consulta, sqlConnection); //Creo el adaptador (adapta el codigo c# al codigo sql) (5to paso)

            using (sqlDataAdapter)
            {
                DataTable provinciaTabla = new DataTable(); //Creamos este datatable que nos va a permitir almacenar datos de tablas en un objeto (6to paso)
                sqlDataAdapter.Fill(provinciaTabla); //Este metodo sirve para ejecutar el adaptador. (7)

                lbox_provincias.DisplayMemberPath = "Nombre"; //Aca estamos haciendo que en la list box muestre solo la parte de los nombres de la tabla (8)
                lbox_provincias.SelectedValuePath = "Id"; //Esto es lo que buscaria al hacerle click a cada pestana digamos (9)
                lbox_provincias.ItemsSource = provinciaTabla.DefaultView; //Sirve para darle el formato a nuestra tabla (10)
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
    }
}
