using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProjekt
{
    public enum KierunekEnum { Filozofia, Matematyka, Architektura, Mechanika }
    public class Student : Osoba, IComparable
    {
        public int Index { get; set; }
        public KierunekEnum Kierunek { get; set; }
        public Student() { }
        public Student(string imie, string nazwisko, int telefon, KierunekEnum kierunek, int index)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            Kierunek = kierunek;
            Index = index;
            Telefon = telefon;
        }

        public new int CompareTo(object obj)
        {
            return Index.CompareTo(obj);
        }
    }
}
