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
    /// Lógica de interacción para ConsultasPromotor.xaml
    /// </summary>
    public partial class ConsultasPromotor : Window
    {
        SqlConnection sqlConnection;

        public ConsultasPromotor()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Trabajo_Gestion.Properties.Settings.ProyectoGestionConnectionString"].ConnectionString;

            sqlConnection = new SqlConnection(connectionString);

            InitializeComponent();
            ConsultaB();
            ConsultaD();
            ConsultaE();
        }
        private void ConsultaB()
        {
            string consulta = "select Promotor.PromotorID as ID, Promotor.Nombre, COUNT(Cliente.IdPromotor) as Clientes from Promotor inner join Cliente on PromotorID = Cliente.IdPromotor GROUP BY Promotor.Nombre, Promotor.PromotorID";

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(consulta, sqlConnection);

            DataTable promotorConsultaATabla = new DataTable(); //Creamos este datatable que nos va a permitir almacenar datos de tablas en un objeto (6to paso)
            sqlDataAdapter.Fill(promotorConsultaATabla);
            dg_consultaA.ItemsSource = promotorConsultaATabla.DefaultView;
        }

        private void ConsultaD()
        {
            string consulta = "select top 1 Promotor.PromotorID as ID, Promotor.Nombre, COUNT(Cliente.IdPromotor) as Clientes from Promotor inner join Cliente on PromotorID = Cliente.IdPromotor GROUP BY Promotor.Nombre, Promotor.PromotorID";

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(consulta, sqlConnection);

            DataTable promotorConsultaDTabla = new DataTable(); //Creamos este datatable que nos va a permitir almacenar datos de tablas en un objeto (6to paso)
            sqlDataAdapter.Fill(promotorConsultaDTabla);
            dg_consultaD.ItemsSource = promotorConsultaDTabla.DefaultView;
        }
        private void ConsultaE()
        {
            string consulta = "select Promotor.PromotorID as ID, Promotor.Nombre, SUM(Cliente.Saldo) as Clientes from Promotor inner join Cliente on PromotorID = Cliente.IdPromotor GROUP BY Promotor.Nombre, Promotor.PromotorID";

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(consulta, sqlConnection);

            DataTable promotorConsultaETabla = new DataTable(); //Creamos este datatable que nos va a permitir almacenar datos de tablas en un objeto (6to paso)
            sqlDataAdapter.Fill(promotorConsultaETabla);
            dg_consultaE.ItemsSource = promotorConsultaETabla.DefaultView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Promotor promotor = new Promotor();
            promotor.Show();
            Close();
        }
    }
}
