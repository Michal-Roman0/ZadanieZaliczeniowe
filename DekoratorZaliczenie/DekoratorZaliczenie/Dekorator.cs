using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DekoratorZaliczenie
{
    //Projekt zaliczeniowy
    //Michał Roman 205858
    internal class Dekorator : IComponent
    {
        protected IComponent wrapee;

        public Dekorator(IComponent wrapee)
        {
            this.wrapee = wrapee;
        }

        public string PodajDanePrzejazdu(int trasa)
        {
            return wrapee.PodajDanePrzejazdu(trasa);
        }
    }
    internal class FreeDecorator : Dekorator
    {
        public FreeDecorator(IComponent wrapee) : base(wrapee){}
        public new string PodajDanePrzejazdu(int trasa)
        {
            string infoPrzejazd = wrapee.PodajDanePrzejazdu(trasa);
            return infoPrzejazd + "PLN\nKup tanie bilety na koncert Country w Mrągowie! Kowbojski kapelusz obowiązkowy.";
        }

    }
    internal class SmallCompanyDecorator : Dekorator
    {
        public SmallCompanyDecorator(IComponent wrapee) : base(wrapee) { }
        public new string PodajDanePrzejazdu(int trasa)
        {
            string infoPrzejazd = wrapee.PodajDanePrzejazdu(trasa);
            Random r = new Random();
            double roznicaOdRynkowej = (r.NextDouble() * 0.5) * trasa;
            return infoPrzejazd + "PLN\nCena różni się od średniej rynkowej o: " + Math.Round(roznicaOdRynkowej,2) + "PLN";
        }
    }
    internal class EnterpriseDecorator : Dekorator
    {
        public EnterpriseDecorator(IComponent wrapee) : base(wrapee) { }
        public new string PodajDanePrzejazdu(int trasa)
        {
            string infoPrzejazd = wrapee.PodajDanePrzejazdu(trasa);
            double optymalnaCena = double.Parse(infoPrzejazd.Substring(20)) * 0.8;
            return infoPrzejazd + "PLN\nTrasę można zoptymalizować, aby jej koszt wyniósł: " + optymalnaCena + "PLN";
        }
    }
}
