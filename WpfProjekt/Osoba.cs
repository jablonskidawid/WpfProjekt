using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProjekt
{
    /*
     * Abstrakcyjna klasa, z której dziedziczą student i pracownik
     */
    public abstract class Osoba
    {
        public virtual string Nazwisko { get; set; }
        public virtual string Imie { get; set; }
        public virtual int Telefon { get; set; }
    }
}
