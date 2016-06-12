using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProjekt
{
    public abstract class Osoba : IComparable
    {
        public virtual string Nazwisko { get; set; }
        public virtual string Imie { get; set; }
        public int Telefon { get; set; }

        public int CompareTo(object obj)
        {
            int retVal = Nazwisko.CompareTo(obj);
            if (retVal == 0) return Imie.CompareTo(obj);
            return retVal;
        }
    }
}
