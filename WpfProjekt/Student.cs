using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WpfProjekt.MainWindow;

namespace WpfProjekt
{
    public class Student : Osoba, IPrintable
    {
        public int Index { get; set; }
        public Kierunek Kierunek { get; set; }
        public Student() { }
        public Student(string imie, string nazwisko, int telefon, Kierunek kierunek, int index)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            Kierunek = kierunek;
            Index = index;
            Telefon = telefon;
        }
        public string Wypisz()
        {
            string retVal = Imie + " " + Nazwisko + "\nNumer indeksu: " + Index + "\nTelefon: " + Telefon + "\n";
            return retVal;
        }
    }
}
