using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Prosta_gra
{
    public class Dane
    {
        public List<IBron> WczytajBronie()
        {
            var bronie = new List<IBron>();
            using(StreamReader reader = new StreamReader("bronie.txt"))
            {
                string linia;
                while ((linia = reader.ReadLine()) != null)
                {
                    var odczyt = linia.Split(';');
                    bronie.Add(new Bron(odczyt[0], int.Parse(odczyt[1]), int.Parse(odczyt[2])));
                }
            }

            using(StreamReader reader = new StreamReader("bronieDwureczne.txt"))
            {
                string linia = reader.ReadLine();
                while (linia != null)
                {
                    string[] odczyt = linia.Split(';');
                    string nazwa = odczyt[0];
                    int cena = int.Parse(odczyt[1]);
                    int obrazenia = int.Parse(odczyt[2]);
                    bronie.Add(new BronDwureczna(nazwa, cena, obrazenia));
                    linia = reader.ReadLine();
                }
            }
            return bronie;
        }
        public List<Zbroja> WczytajZbroje()
        {
            var zbroja = new List<Zbroja>();
            using(StreamReader reader = new StreamReader("Tarcze.txt"))
            {
                string linia;
                while ((linia = reader.ReadLine()) != null)
                {
                    var odczyt = linia.Split(';');
                    zbroja.Add(new Tarcza(odczyt[0], int.Parse(odczyt[1]), int.Parse(odczyt[2]), int.Parse(odczyt[3])));
                }
            }
            using(StreamReader reader = new StreamReader("napiersniki.txt"))
            {
                string linia;
                while ((linia = reader.ReadLine()) != null)
                {
                    var odczyt = linia.Split(';');
                    zbroja.Add(new Napiersnik(odczyt[0], int.Parse(odczyt[1]), int.Parse(odczyt[2]), int.Parse(odczyt[3])));
                }
            }
            return zbroja;
        }
    }
}
