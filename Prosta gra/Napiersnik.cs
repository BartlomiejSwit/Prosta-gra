using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prosta_gra
{
    public class Napiersnik : Zbroja
    {
        public Napiersnik(string nazwa, int cena, int obrona, int poziomZuzycia)
        {
            Nazwa = nazwa;
            Cena = cena;
            Obrona = obrona;
            PoziomZużycia = poziomZuzycia;
        }
        public override int ModyfikujObrazenia(int obrazenia)
        {
            Zuzycie();
            obrazenia -= Obrona;
            if(obrazenia < 0)
            {
                obrazenia = 0;
            }

            return obrazenia;
        }

    }
}
