using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Kikelet_Panzio
{
    internal class Regisztracioful
    {
        string azonosito;
        string nev;
        string email;
        DateTime szuletesidatum;
        bool vip;
       


        public Regisztracioful(string azonosito, string nev, string email, DateTime szuletesidatum, bool vip)
        {
            Azonosito = azonosito;
            Nev = nev;
            Email = email;
            Szuletesidatum = szuletesidatum;
            Vip = vip;
        }
        public Regisztracioful(string sor) 
        {
            string[] adatok = sor.Split(';');
            azonosito = adatok[0];
            nev = adatok[1];
            email = adatok[2];
            szuletesidatum = DateTime.Parse(adatok[3]);
            vip =bool.Parse(adatok[4]);
        }
        public override string ToString()
        {
            return $"{azonosito};{nev};{email};{szuletesidatum};{vip}";
        }

        public string Azonosito { get => azonosito; set => azonosito = value; }
        public string Nev { get => nev; set => nev = value; }
        public string Email { get => email; set => email = value; }
        public DateTime Szuletesidatum { get => szuletesidatum; set => szuletesidatum = value; }
        public bool Vip { get => vip; set => vip = value; }
         
    }
    /// <summary>
    /// Interaction logic for Regisztracio.xaml
    /// </summary>
    public partial class Regisztracio : Window
    {
        List<Regisztracioful>regisztraltak = new List<Regisztracioful>();
        public Regisztracio()
        {
            InitializeComponent();
           
            DgrRegi.ItemsSource = regisztraltak;
        }

        private void BtnRegisztralas_Click(object sender, RoutedEventArgs e)
        {

            if (TbxNev.Text == string.Empty)
            {
                MessageBox.Show("Adja meg a nevét!");
            }
            else if (TbxSzuDatum.Text == string.Empty)
            {
                MessageBox.Show("Adja meg a születési dátumát!");
            }
            else if (TbxEmail.Text == string.Empty)
            {
                MessageBox.Show("Adja meg az email címét!");
            }
            else {
                TbkAzonosito.Text = TbxNev.Text.ToString() + DateTime.Now.ToString();
                DgrRegi.Items.Refresh();
                regisztraltak.Add(new Regisztracioful(TbkAzonosito.Text, TbxNev.Text, TbxEmail.Text, DateTime.Parse(TbxSzuDatum.Text), (CkBVip.IsChecked.Value)));

                DgrRegi.Items.Refresh();
                MessageBox.Show("Sikeres regisztráció");
                if (CkBVip.IsChecked == true)
                {
                    MessageBox.Show("Ön VIP kedvezményre jogosult ( 3% ), emellett negyedévente hírlevelet is kap panziónktól!");
                }
                TbxNev.Text = string.Empty;
                TbkAzonosito.Text = string.Empty;
                TbxEmail.Text = string.Empty;
                TbxSzuDatum.Text = string.Empty;
                CkBVip.IsChecked = false;
            }
            

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            
        }
        private void Kiir(string fileName)
        {
            StreamWriter kimenet = new StreamWriter(fileName);
            foreach (var sor in regisztraltak)
            {
                kimenet.WriteLine(sor);
            }
            kimenet.Close();

        }

        private void BtnAllomanyba_Mentes_Click(object sender, RoutedEventArgs e)
        {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Title = "Mentés állományba";
                sfd.DefaultExt = "txt";
                sfd.Filter = "Text files (*txt)|*.txt";
                sfd.FileName = "Regisztracio.txt";
                sfd.ShowDialog();
                if (sfd.FileName != "")
                {
                    Kiir(sfd.FileName);
                }
                else
                {
                    MessageBox.Show("Nincs kiválaszotott állomány");
                }

            
        }
    }
}
