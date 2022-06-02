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
        }
        private void ConsultaB()
        {
            string consulta = "select Promotor.Nombre, COUNT(Cliente.IdPromotor) as A from Promotor inner join Cliente on PromotorID = Cliente.IdPromotor GROUP BY Promotor.Nombre";

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(consulta, sqlConnection);

            DataTable promotorConsultaTabla = new DataTable(); //Creamos este datatable que nos va a permitir almacenar datos de tablas en un objeto (6to paso)
            sqlDataAdapter.Fill(promotorConsultaTabla);

            using (sqlDataAdapter)
            {
                /*string nombre = promotorConsultaTabla.;
                lbox_consultab.Items.Add(); //Aca estamos haciendo que en la list box muestre solo la parte de los nombres de la tabla (8)
                lbox_consultab.Items.Add("A"); //Aca estamos haciendo que en la list box muestre solo la parte de los nombres de la tabla (8)
                lbox_consultab.SelectedValuePath = "PromotorID"; //Esto es lo que buscaria al hacerle click a cada pestana digamos (9)
                //lbox_consultab.ItemsSource = promotorConsultaTabla.DefaultView; //Sirve para darle el formato a nuestra tabla (10)*/
            }
        }

        
    }
}
