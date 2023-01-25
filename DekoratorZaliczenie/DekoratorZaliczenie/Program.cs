using DekoratorZaliczenie;

namespace DecoratorZaliczenie
{
    //Projekt zaliczeniowy
    //Michał Roman 205858
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Witaj w naszej aplikacji. Znajdziemy dla ciebie najkorzystniejsze oferty!");
            Console.WriteLine("Podaj długość trasy w kilometrach: ");
            string? Trasa = Console.ReadLine();
            Console.WriteLine("Podaj posiadany rodzaj subskrybcji (F/S/E): ");
            string? Subskrybcja = Console.ReadLine();
            try
            {
                int DlugoscTrasy = int.Parse(Trasa);
                if (DlugoscTrasy < 0)
                {
                    Console.WriteLine("Długość trasy musi być dodatnia!");
                }
                else
                {
                    RideInfo ri = new RideInfo();
                    switch (Subskrybcja)
                    {
                        case "F":
                            FreeDecorator fd = new FreeDecorator(ri);
                            Console.WriteLine(fd.PodajDanePrzejazdu(DlugoscTrasy));
                            break;
                        case "S":
                            SmallCompanyDecorator scd = new SmallCompanyDecorator(ri);
                            Console.WriteLine(scd.PodajDanePrzejazdu(DlugoscTrasy));
                            break;
                        case "E":
                            SmallCompanyDecorator scd1 = new SmallCompanyDecorator(ri);
                            EnterpriseDecorator ed = new EnterpriseDecorator(scd1);
                            Console.WriteLine(ed.PodajDanePrzejazdu(DlugoscTrasy));
                            break;
                        default:
                            Console.WriteLine("Nie ma takiego typu subskrybcji!");
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Proszę podać poprawne dane!");
            }

        }
    }
}
