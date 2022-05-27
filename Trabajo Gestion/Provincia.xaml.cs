using System;
using System.Collections.Generic;
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
        public Provincia()
        {
            InitializeComponent();
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
