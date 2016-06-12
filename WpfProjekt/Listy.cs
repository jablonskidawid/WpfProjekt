using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProjekt
{
    public class Listy
    {
        public ObservableCollection<Pracownik> ListaPracownikow { get; set; }
        public ObservableCollection<Student> ListaStudentow { get; set; }

        public Listy()
        {
            ListaPracownikow = new ObservableCollection<Pracownik>();
            ListaStudentow = new ObservableCollection<Student>();
        }
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