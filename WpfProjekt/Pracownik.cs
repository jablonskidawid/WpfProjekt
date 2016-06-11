using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProjekt
{
    public enum Stanowisko { Dyrektor, Wykładowca, Prac_Techniczny, Administracja, Dziekanat, Księgowość}
    public class Pracownik:Osoba
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


    }
}
