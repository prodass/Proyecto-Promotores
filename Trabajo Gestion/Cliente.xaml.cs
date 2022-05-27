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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Trabajo_Gestion
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class Cliente : Window
    {
        public Cliente()
        {
            InitializeComponent();
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
