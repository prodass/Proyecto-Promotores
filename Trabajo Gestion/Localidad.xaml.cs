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
    /// Lógica de interacción para Localidad.xaml
    /// </summary>
    public partial class Localidad : Window
    {
        public Localidad()
        {
            InitializeComponent();
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
    }
}
