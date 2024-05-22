using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kikelet_Panzio
{
    public class Szoba
    {
        int szam;
        int ferohely;
        int ar;

        public Szoba(int szam, int ferohely, int ar)
        {
            Szam = szam;
            Ferohely = ferohely;
            Ar = ar;
        }
        public Szoba(string sor)
        {
            string[] adatok = sor.Split(';');
            Szam = int.Parse(adatok[0]);
            Ferohely = int.Parse(adatok[1]);
            Ar = int.Parse((adatok[2]));
        }

        public int Szam { get => szam; set => szam = value; }
        public int Ferohely { get => ferohely; set => ferohely = value; }
        public int Ar { get => ar; set => ar = value; }

        public override string ToString()
        {
            return $"{szam};{ferohely};{ar}";
        }
    }
}
