using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DekoratorZaliczenie
{
    //Projekt zaliczeniowy
    //Michał Roman 205858
    internal class RideInfo : IComponent
    {

        public string PodajDanePrzejazdu(int trasa)
        {
            Random r = new Random();
            double cena = trasa * (r.NextDouble() * 3.5 + 1.5);
            return "Cena trasy wyniesie:" + Math.Round(cena, 2);
        }
    }
}
