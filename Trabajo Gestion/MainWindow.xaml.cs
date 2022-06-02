using System;
using System.Collections.Generic;
using System.Configuration;
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
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_promotor_Click(object sender, RoutedEventArgs e)
        {
            Promotor promotor = new Promotor();
            promotor.Show();
            Close();
        }

        private void btn_cliente_Click(object sender, RoutedEventArgs e)
        {
            Cliente cliente = new Cliente();
            cliente.Show();
            Close();
        }

        private void btn_provincia_Click(object sender, RoutedEventArgs e)
        {
            Provincia provincia = new Provincia();
            provincia.Show();
            Close();
        }

        private void btn_localidad_Click(object sender, RoutedEventArgs e)
        {
            Localidad localidad = new Localidad();
            localidad.Show();
            Close();
        }
    }
}
