using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WpfProjekt.MainWindow;

namespace WpfProjekt
{
    
    public class Pracownik : Osoba, IPrintable
    {
        public Stanowisko Stanowisko { get; set; }
        public double Pensja { get; set; }
        public string Tytul { get; set; }
        public Pracownik() { }
        public Pracownik(string imie, string nazwisko, int telefon, string tytul, Stanowisko stanowisko, double pensja)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            Tytul = tytul;
            Stanowisko = stanowisko;
            Pensja = pensja;
            Telefon = telefon;
        }

        public string Wypisz()
        {
            string retVal = Stanowisko + " " + Tytul + " " + Imie + " " + Nazwisko + "\nTelefon: " + Telefon + "\n";
            return retVal;
        }
    }
}
