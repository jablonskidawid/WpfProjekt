using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProjekt
{
    /*
     * Klasa, która reprezentuje obiekty przechowujące studentów i pracowników w listach.
     * Wykorzystano tutaj kolekcje generyczne.
     */
    public class Listy
    {
        public ObservableCollection<Pracownik> ListaPracownikow { get; set; }
        public ObservableCollection<Student> ListaStudentow { get; set; }
        public Listy()
        {
            ListaPracownikow = new ObservableCollection<Pracownik>();
            ListaStudentow = new ObservableCollection<Student>();
        }


        /*
         * Zastosowanie polimorfizmu:
         */
        public void Dodaj(Student student)
        {
            ListaStudentow.Add(student);
        }
        public void Dodaj(Pracownik student)
        {
            ListaPracownikow.Add(student);
        }
    }
}