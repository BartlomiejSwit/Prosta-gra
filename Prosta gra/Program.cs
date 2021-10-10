using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prosta_gra
{
    class Program
    {
        private static Bohater _bohater;
        private static List<IBron> _bronie;
        private static List<Zbroja> _zbroje;

        static void Main(string[] args)
        {
            //string nazwaPostaci;
            StworzBron();
            ObslugalMenu();

            //Console.ReadLine();
          
        }

        static void StworzBron()
        {
            Dane dane = new Dane();
            //_bronie = new List<IBron>(); //stara obsługa listy
            //_zbroje = new List<Zbroja>(); //stara obsługa listy
            _bronie = dane.WczytajBronie();
            _zbroje = dane.WczytajZbroje();


            //Bron bron = new Bron("wyjbany miecz bezlitości", 3, 4);
            //_bronie.Add(bron);

            //_bronie.Add(new Bron("Kocia łapa", 10, 6));
            //_bronie.Add(new Bron("Piorun", 1, 100));
            //_bronie.Add(new Bron("Mśćciel", 15, 10));
            //_bronie.Add(new BronDwureczna("Dwuręczny kieł", 15, 4));

            //_zbroje.Add(new Tarcza("Tarcza z Tyłka", 10, 10, 0));
            //_zbroje.Add(new Tarcza("Klapa od Sieciento", 25, 50, 0));

            //_zbroje.Add(new Tarcza // Kreator pierwszy szybszy "Jeżei kreator jest w klasie ten nie działa"
            //{
            //    Nazwa = "Tarcza z tyłka",
            //    Cena = 10,
            //    Obrona = 10,
            //    PoziomZużycia = 0
            //});

            //_zbroje.Add(new Napiersnik("Stylowe Bikini", 8, 15, 0));
            //_zbroje.Add(new Napiersnik("Niemiecki Nudysta", 25, 20, 0));

            //Napiersnik napiersnik = new Napiersnik(); // kreator drugi z uzyciem przez tworzenie nowego obiektu "Jeżei kreator jest w klasie ten nie działa"
            //napiersnik.Nazwa = "Stanik mocy";
            //napiersnik.Cena = 8;
            //napiersnik.Obrona = 15;
            //napiersnik.PoziomZużycia = 0;
            //_zbroje.Add(napiersnik);

        }
        static void ObslugalMenu()
        {
            Console.Clear();
            Console.WriteLine("Mpja Pierwsza Gra");
            Console.WriteLine("1. Nowa Gra");
            Console.WriteLine("2. Wczytaj grę");
            Console.WriteLine("3. Wyjście");

            string opcja = Console.ReadLine();
            if (opcja == "1")
            {
                TworzeniePostaci();
            }
            else if (opcja == "2")
            {

            }
            else
            {
                Console.Clear();
                Console.Write("Dziękuje za grę");
                return;
            }

            while (opcja != "5")
            {
                DalszeMenu();
                opcja = Console.ReadLine();
                if (opcja == "0")
                {
                    _bohater.PokazaniePostaci();
                }
                else if (opcja == "1")
                {
                    IdzNaWyprawe();
                }
                else if (opcja == "2")
                {
                    _bohater.Odpoczynek();
                }
                else if (opcja == "3")
                {
                    Console.WriteLine("Opcja chwilowo Niedostępna");
                }
                else if (opcja == "4")
                {
                    Sklep();
                }
                else
                {
                                        
                }
                _bohater.Przegrana();
                Console.WriteLine();
                Console.WriteLine("Naciśnij Enter Aby Kontynułować..........");
                Console.ReadLine();

            }
            
        }

        static void DalszeMenu()
        {
            Console.Clear();
            Console.WriteLine("Menu Gry");
            Console.WriteLine("0. Zobacz Postać");
            Console.WriteLine("1. Idz Na Wyprawę");
            Console.WriteLine("2. Odpocznij");
            Console.WriteLine("3. Ekwipunek");
            Console.WriteLine("4. Sklep");
            Console.WriteLine("5. Zakończ Grę");

        }

        static void TworzeniePostaci()
        {
            Console.Clear();
            Console.Write("Podaj nazwę postaci ");
            string imie = Console.ReadLine();
            _bohater = new Bohater(imie);

        }
        static void IdzNaWyprawe()
        {
            Console.Clear();
            Console.WriteLine("Wyruszyłeś na wyprawę");

            bool wynikWalki = Walka();

            if (wynikWalki)
            {
                BonusyZaZwyciestwo();
            }
              
        
        }
        static bool Walka()
        {
            Random Losuj = new Random();
            int zyciePrzeciwnika = Losuj.Next(8, 12);
            //int dmgBroni = _bohater.NoszonaBron.ModyfikatorObrazen; //Dodanie obrażen z broni

            while (_bohater.PosiadaneZycie > 0)
            {
                int obrazenia = _bohater.NoszonaBron.ObliczObrazenia();
                int obrazeniaZadane = Losuj.Next(obrazenia-2, obrazenia+2); //+ dmgBroni; //Dodanie obrażen z broni
                zyciePrzeciwnika -= obrazeniaZadane;

                if (zyciePrzeciwnika <= 0)
                    return true;

                int obrazeniaOtrzymane = Losuj.Next(0, 4);
                _bohater.PosiadaneZycie -= obrazeniaOtrzymane;
                
            }
            return false;


        }
        static void BonusyZaZwyciestwo()
        {

        }
        static void Sklep()
        {
            Console.Clear();
            int licznik = 1;
            Console.WriteLine("Uzbrojenie:");
            foreach (IBron bron in _bronie)
            {
                if(bron is Bron)
                {
                    Console.WriteLine("Bron jednoręczne:");
                    Console.WriteLine(licznik + ". " + bron.Nazwa + " Cena: " + bron.Cena + " Obrażenia: " + bron.ModyfikatorObrazen);
                    licznik++;
                }
                else
                {
                    Console.WriteLine("Bron Dwuręczne:");
                    Console.WriteLine(licznik + ". " + bron.Nazwa + " Cena: " + bron.Cena + " Obrażenia: " + bron.ModyfikatorObrazen);
                    licznik++;
                }

            }
            Console.WriteLine("Obrona:");
            foreach (Zbroja zbroja in _zbroje)
            {
                if (zbroja is Tarcza)
                {
                    Console.WriteLine("Tarcze:");
                    Console.WriteLine(licznik + ". " + zbroja.Nazwa + " Cena: " + zbroja.Cena + " Obrona: " + zbroja.Obrona);
                    licznik++;
                }
                else
                {
                    Console.WriteLine("Napierśniki");
                    Console.WriteLine(licznik + ". " + zbroja.Nazwa + " Cena: " + zbroja.Cena + " Obrona: " + zbroja.Obrona);
                    licznik++;
                }

            }
            //for(int nrBroni = 0; nrBroni < _bronie.Count; nrBroni++)  // Inny zapisz pętli powyżej działa tak samo
            //{
            //    Console.WriteLine((nrBroni + 1) + ". " + _bronie[nrBroni].Nazwa);
            //}
            Console.WriteLine("Twoja Sakwa zawiera: " + _bohater.Sakwa + " złota");

            Console.Write("Wybierz broń którą chcesz kupić. ");
            string odczyt = Console.ReadLine();

            if (odczyt != "")  // Jeżeli nic się nie wybierze wywalało, Poprawione
            {
                int opcja = int.Parse(odczyt);
                if(opcja <= _bronie.Count)
                {
                    IBron wybranaBron = _bronie[opcja - 1];
                    _bohater.KupBron(wybranaBron);
                }
                else
                {
                    opcja -= _bronie.Count;
                    Zbroja wybranaZbroja = _zbroje[opcja - 1];
                    if(wybranaZbroja is Tarcza)
                    {
                        bool mozliwoscZalozenia = _bohater.NoszonaBron.MozliwoscNoszeniaTarczy;
                        if (mozliwoscZalozenia == true)
                        {
                            //_bohater.NoszonaTarcza = wybranaZbroja as Tarcza;//Zutowanie obie są poprawne
                            _bohater.KupZbroje(wybranaZbroja);
                        }
                        else
                        {
                            Console.WriteLine("Przykro mi masz bron dwureczną, nie możesz nosić tarczy");
                        }
                    }
                    else
                    {
                        //_bohater.NoszonyNapiersnik = (Napiersnik)wybranaZbroja;//Zutowanie obie są poprawne
                        _bohater.KupZbroje(wybranaZbroja);
                    }

                }

            }
            else
            {
                Console.WriteLine("Nie dokonałeś zakupów.");
            }


        }


    }

    

}
