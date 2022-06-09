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
    /// Lógica de interacción para LocalidadesConsulta.xaml
    /// </summary>
    public partial class LocalidadesConsulta : Window
    {
        SqlConnection sqlConnection;
        public LocalidadesConsulta()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Trabajo_Gestion.Properties.Settings.ProyectoGestionConnectionString"].ConnectionString;

            sqlConnection = new SqlConnection(connectionString);

            InitializeComponent();
            ConsultaC();
        }
        private void ConsultaC()
        {
            string consulta = "select LocalidadID as ID, Localidad.Nombre from Localidad left join Cliente on LocalidadID = Cliente.IdLocalidad where Cliente.IdLocalidad is null";

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(consulta, sqlConnection);

            DataTable promotorConsultaCTabla = new DataTable(); //Creamos este datatable que nos va a permitir almacenar datos de tablas en un objeto (6to paso)
            sqlDataAdapter.Fill(promotorConsultaCTabla);
            dg_consultaC.ItemsSource = promotorConsultaCTabla.DefaultView;
        }

        private void btn_volver_Click(object sender, RoutedEventArgs e)
        {
            Localidad localidad = new Localidad();
            localidad.Show();
            Close();
        }
    }
}
