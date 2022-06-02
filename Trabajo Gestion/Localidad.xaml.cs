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
                lbox_localidades.SelectedValuePath = "Id"; //Esto es lo que buscaria al hacerle click a cada pestana digamos (9)
                lbox_localidades.ItemsSource = localidadesTabla.DefaultView; //Sirve para darle el formato a nuestra tabla (10)
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

        private void MostrarProvinciasAsociadas()
        {
            string consulta = "select * from Provincia inner join Localidad on Provincia.Id = Localidad.IdProvincia where Provincia.Id = @Id";

            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

            using (sqlDataAdapter)
            {
                sqlCommand.Parameters.AddWithValue("@Id", lbox_localidades.SelectedValue);

                DataTable localidadesProvTabla = new DataTable();
                sqlDataAdapter.Fill(localidadesProvTabla);

                lbox_localidadesDetalles.DisplayMemberPath = "Provincia.Nombre";
                lbox_localidadesDetalles.DisplayMemberPath = "Id";
                lbox_localidadesDetalles.ItemsSource = localidadesProvTabla.DefaultView;
            }
        }
        
        private void lbox_localidades_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MostrarProvinciasAsociadas();
        }
    }
}
