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
using System.IO;

namespace DecisiMaratonaApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dati GestioneDati;
        public MainWindow()
        {
            InitializeComponent();
            GestioneDati = new Dati();
            DgElencoDati.ItemsSource = GestioneDati.CollezioneDati;
        }

        private void BtnTempo_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnLeggiFile_Click(object sender, RoutedEventArgs e)
        {
            GestioneDati.LeggiDaFile();
            DgElencoDati.Items.Refresh();
        }


    }
}
