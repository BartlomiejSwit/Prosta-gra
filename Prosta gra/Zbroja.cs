using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prosta_gra
{
    public abstract class Zbroja
    {
        public string Nazwa { get; set; }
        public int Cena { get; set; }
        public int Obrona { get; set; }
        public int PoziomZużycia { get; set; }

        public abstract int ModyfikujObrazenia(int obrazenia);

        public void Zuzycie()
        {
            PoziomZużycia++;
            if (PoziomZużycia >= 100 && Obrona >1)
            {
                Obrona--;
            }


        }


    }
}
