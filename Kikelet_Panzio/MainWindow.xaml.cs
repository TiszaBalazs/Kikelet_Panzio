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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kikelet_Panzio
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Szoba> szobak = new List<Szoba>();
        public MainWindow()
        {
            InitializeComponent();
            CbxSzobaszam.Items.Add("1");
            CbxSzobaszam.Items.Add("2");
            CbxSzobaszam.Items.Add("3");
            CbxSzobaszam.Items.Add("4");
            CbxSzobaszam.Items.Add("5");
            CbxSzobaszam.Items.Add("6");
            CbxFerohely.Items.Add("2");
            CbxFerohely.Items.Add("3");
            CbxFerohely.Items.Add("4");
            DgrSzobaAdat.ItemsSource = szobak;



        }

        private void BtnMentes_Click(object sender, RoutedEventArgs e)
        {
            szobak.Add(new Szoba(int.Parse(CbxSzobaszam.Text), int.Parse(CbxFerohely.Text), int.Parse(TbxAr.Text)));
            DgrSzobaAdat.Items.Refresh();
            
            MessageBox.Show("Sikeres mentés!");
        }
        private void Kiir(string fileName)
        {
            StreamWriter kimenet = new StreamWriter(fileName);
            foreach (var sor in szobak)
            {
                kimenet.WriteLine(sor);
            }
            kimenet.Close();

        }
            private void CbxFerohely_SelectionChanged(object sender, SelectionChangedEventArgs e)
            { 

                if (CbxFerohely.SelectedItem == "2")
                {
                    TbxAr.Text = "12000";
                }
                else if (CbxFerohely.SelectedItem == "3")
                {
                    TbxAr.Text = "18000";
                }
                else
                {
                    TbxAr.Text = "24000";
                }

            }
              private void BtnKovetkezo_Click(object sender, RoutedEventArgs e)
              {

             
              }

        private void BtnAllomanybamentes_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Mentés állományba";
            sfd.DefaultExt = "txt";
            sfd.Filter = "Text files (*txt)|*.txt";
            sfd.FileName = "Szoba.txt";
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

        private void Regisztracio_Click(object sender, RoutedEventArgs e)
        {
            Regisztracio ujregisztracio = new Regisztracio();
            ujregisztracio.ShowDialog();

        }
    } 
}
