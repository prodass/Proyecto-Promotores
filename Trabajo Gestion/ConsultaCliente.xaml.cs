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
    /// Lógica de interacción para ConsultaCliente.xaml
    /// </summary>
    public partial class ConsultaCliente : Window
    {
        SqlConnection sqlConnection;
        public ConsultaCliente()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Trabajo_Gestion.Properties.Settings.ProyectoGestionConnectionString"].ConnectionString;

            sqlConnection = new SqlConnection(connectionString);

            InitializeComponent();
            ConsultaA();
            ConsultaF();
        }

        private void ConsultaA()
        {
            string consulta = "select ClienteID as ID, Cliente.Nombre, Cliente.Domicilio, Localidad.Nombre as Localidad, Provincia.Nombre as Provincia from Cliente inner join Localidad on CLiente.IdLocalidad = LocalidadID inner join Provincia on Localidad.IdProvincia = ProvinciaID";

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(consulta, sqlConnection);

            DataTable promotorConsultaATabla = new DataTable(); //Creamos este datatable que nos va a permitir almacenar datos de tablas en un objeto (6to paso)
            sqlDataAdapter.Fill(promotorConsultaATabla);
            dg_consultaA.ItemsSource = promotorConsultaATabla.DefaultView;
        }
        private void ConsultaF()
        {
            string consulta = "select ClienteId as ID, Nombre, Saldo from Cliente where Saldo > 1000";

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(consulta, sqlConnection);

            DataTable promotorConsultaFTabla = new DataTable(); //Creamos este datatable que nos va a permitir almacenar datos de tablas en un objeto (6to paso)
            sqlDataAdapter.Fill(promotorConsultaFTabla);
            dg_consultaF.ItemsSource = promotorConsultaFTabla.DefaultView;
        }

        private void btn_volver_Click(object sender, RoutedEventArgs e)
        {
            Cliente cliente = new Cliente();
            cliente.Show();
            Close();
        }
    }
}
