﻿using System;
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
    /// Lógica de interacción para Promotor.xaml
    /// </summary>
    public partial class Promotor : Window
    {
        public Promotor()
        {
            InitializeComponent();
        }

        private void btn_atrasPromotor_Click(object sender, RoutedEventArgs e)
        {
            Localidad localidad = new Localidad();
            localidad.Show();
            Close();
        }

        private void btn_siguientePromotor_Click(object sender, RoutedEventArgs e)
        {
            Cliente cliente = new Cliente();
            cliente.Show();
            Close();
        }

        private void btn_menuPromotor_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Close();
        }
    }
}
