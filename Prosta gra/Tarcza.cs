using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prosta_gra
{
     public class Tarcza : Zbroja
    {
        public Tarcza(string nazwa, int cena, int obrona, int poziomZuzycia)
        {
            Nazwa = nazwa;
            Cena = cena;
            Obrona = obrona;
            PoziomZużycia = poziomZuzycia;
        }
        public override int ModyfikujObrazenia(int obrazenia)
        {
            Zuzycie();
            Random losowanie = new Random();
            if (losowanie.Next(0, 3) == 1)
            {
                return 0;
            }

            obrazenia -= Obrona;
            if (obrazenia < 0)
            {
                obrazenia = 0;
            }

            return obrazenia;



        }
    }
}
