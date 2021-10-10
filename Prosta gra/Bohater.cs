using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prosta_gra
{
    public class Bohater
    {
        public string Imie { get; set; }
        public int MaksymalneZycie { get; set; }
        public int PosiadaneZycie { get; set; }
        public int Obrazenia { get; set; }
        public int Level { get; set; }
        public int PunktyDoswiadczenia { get; set; }
        public int Sakwa { get; set; }
        public IBron NoszonaBron { get; private set; }
        public Napiersnik NoszonyNapiersnik { get; set; }
        public Tarcza NoszonaTarcza { get; set; }


        public Bohater(string imie)
        {
            Imie = imie;
            MaksymalneZycie = 10;
            PosiadaneZycie = 10;
            Level = 1;
            PunktyDoswiadczenia = 0;
            Sakwa = 100;
            //NoszonaBron = new Bron("Patyk", 1, 1);

        } 


        public void Przegrana()
        {
            if (PosiadaneZycie <= 0)
            {
                PosiadaneZycie = 1;
                Console.WriteLine("Przegrałeś.... Ale nie załamuj się żyjesz, pozostało ci 1 życia");
            }

        }
        public void Odpoczynek()
        {
            Console.WriteLine("Zrobiłeś sobie szałas, toje życie zwiększa się o 1");
            PosiadaneZycie++;
            if (MaksymalneZycie < PosiadaneZycie)
                PosiadaneZycie = MaksymalneZycie;
        }
        public void PokazaniePostaci()
        {
            Console.WriteLine(Imie + " LvL: " + Level);
            Console.WriteLine("Życie: " + PosiadaneZycie + " / " + MaksymalneZycie);
            Console.WriteLine("W Sakwie masz: " + Sakwa + " złota");
            if (NoszonaBron != null)
                Console.WriteLine("Posiadasz Broń: " + NoszonaBron.Nazwa + " - Obrażenia: " + NoszonaBron.ModyfikatorObrazen);
            if (NoszonaTarcza != null)
                Console.WriteLine("Posoadasz Tarczę: " + NoszonaTarcza.Nazwa + " - Obrona: " + NoszonaTarcza.Obrona);
            if (NoszonyNapiersnik != null)
                Console.WriteLine("Posiadasz Napierśnik: " + NoszonyNapiersnik.Nazwa + " - Obrona: " + NoszonyNapiersnik.Obrona);

        }
        public void KupBron(IBron bron)
        {
            if (bron.Cena <= Sakwa)
            {
                Sakwa -= bron.Cena;
                NoszonaBron = bron;
                Console.WriteLine("Posiadasz teraz: " + bron.Nazwa);
            }
            else
            {
                Console.WriteLine("nie steć cię na tą broń.");
            }

        }
        public void KupZbroje(Zbroja zbroja)
        {
            if (zbroja.Cena<= Sakwa)
            {
                Sakwa -= zbroja.Cena;
                if(zbroja is Tarcza)
                {
                    NoszonaTarcza = zbroja as Tarcza;
                    Console.WriteLine("Posiadaz teraz: " + zbroja.Nazwa);
                }
                else
                {
                    NoszonyNapiersnik = zbroja as Napiersnik;
                    Console.WriteLine("Posiadasz teraz: " + zbroja.Nazwa);
                }

            }
            else
            {
                Console.WriteLine("Nie stać cię na tą zbroję.");
            }

        }

    }
}
