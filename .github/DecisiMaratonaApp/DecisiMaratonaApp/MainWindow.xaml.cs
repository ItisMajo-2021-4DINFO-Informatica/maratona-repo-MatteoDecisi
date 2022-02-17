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
            string Durata = "";
            string NomeAtleta = TxtNomeAtleta.Text;
            string Citta = TxtCitta.Text;
            lblTesto.Content = GestioneDati.DurataMaratona(Durata, NomeAtleta, Citta);
        }

        private void BtnLeggiFile_Click(object sender, RoutedEventArgs e)
        {
            GestioneDati.LeggiDaFile();
            DgElencoDati.Items.Refresh();
        }

        private void BtnCercaPartecipantiTappa_Click(object sender, RoutedEventArgs e)
        {
            string Citta = TxtCitta.Text;
            lblTesto.Content =  GestioneDati.CercaPartecipanti(Citta);
        }

        private void BtnAggiungi_Click(object sender, RoutedEventArgs e)
        {
            string NomeAtleta = TxtNomeAtletaDaAggiungere.Text;
            string Societa = TxtSocietaDaAggiungere.Text;
            int Durata = int.Parse(TxtDurataDaAggiungere.Text);
            string Citta = TxtCittaDaAggiungere.Text;

            var documento = new Dato();
            documento.NomeAtleta = NomeAtleta;
            documento.Societa = Societa;
            documento.Durata = Durata;
            documento.Citta = Citta;


            GestioneDati.AggiungiDocumento(documento);

            DgElencoDati.Items.Refresh();
            GestioneDati.Salva();
        }

        private void TxtCitta_GotFocus(object sender, RoutedEventArgs e)
        {
            TxtCitta.Text = "";
        }

        private void TxtNomeAtleta_GotFocus(object sender, RoutedEventArgs e)
        {
            TxtNomeAtleta.Text = "";
        }

        private void TxtNomeAtletaDaAggiungere_GotFocus(object sender, RoutedEventArgs e)
        {
            TxtNomeAtletaDaAggiungere.Text = "";
        }

        private void TxtSocietaDaAggiungere_GotFocus(object sender, RoutedEventArgs e)
        {
            TxtSocietaDaAggiungere.Text = "";
        }

        private void TxtDurataDaAggiungere_GotFocus(object sender, RoutedEventArgs e)
        {
            TxtDurataDaAggiungere.Text = "";
        }

        private void TxtCittaDaAggiungere_GotFocus(object sender, RoutedEventArgs e)
        {
            TxtCittaDaAggiungere.Text = "";
        }

        private void BtnAnalizza_Click(object sender, RoutedEventArgs e)
        {
            string NomeAtleta = TxtNomeAtleta.Text;
            string Citta = TxtCitta.Text;
        }
    }
}
