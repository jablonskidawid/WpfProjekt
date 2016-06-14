using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace WpfProjekt
{
    public partial class MainWindow : Window
    {
        public enum Stanowisko { Dyrektor, Wykładowca, Prac_Techniczny, Administracja, Dziekanat, Księgowość }
        public enum Kierunek { Filozofia, Matematyka, Architektura, Mechanika }
        Listy listy = new Listy();

        public MainWindow()
        {
            InitializeComponent();
            dgPracownicy.ItemsSource = listy.ListaPracownikow;
            dgStudenci.ItemsSource = listy.ListaStudentow;
            cbKierunek.ItemsSource = Enum.GetValues(typeof(Kierunek));
            cbStanowisko.ItemsSource = Enum.GetValues(typeof(Stanowisko));
            cb4.Visibility = Visibility.Hidden;
            label4.Visibility = Visibility.Hidden;
            label5.Visibility = Visibility.Hidden;
            tb5.Visibility = Visibility.Hidden;
            label6.Visibility = Visibility.Hidden;
            tb6.Visibility = Visibility.Hidden;
        }
        /*
         * Zaznaczenie RadioButtona "pracownik" przy dodawaniu nowej osoby
         */
        private void rbpracownik_Checked(object sender, RoutedEventArgs e)
        {
            tb5.Text = "";
            tb6.Text = "";
            cb4.Text = "";
            cb4.Visibility = Visibility.Visible;
            label4.Visibility = Visibility.Visible;
            label5.Visibility = Visibility.Visible;
            tb5.Visibility = Visibility.Visible;
            tb6.Visibility = Visibility.Visible;
            label4.Content = "Stanowisko";
            label5.Content = "Tutuł naukowy";
            label6.Content = "Pensja";
            label6.Visibility = Visibility.Visible;
            cb4.ItemsSource = Enum.GetValues(typeof(Stanowisko));

        }
        /*
         * Zaznaczenie RadioButtona "student" przy dodawaniu nowej osoby
         */
        private void rbstudent_Checked(object sender, RoutedEventArgs e)
        {
            tb5.Text = "";
            tb6.Text = "";
            cb4.Text = "";
            cb4.Visibility = Visibility.Visible;
            label4.Visibility = Visibility.Visible;
            label5.Visibility = Visibility.Visible;
            tb5.Visibility = Visibility.Visible;
            tb6.Visibility = Visibility.Visible;
            label4.Content = "Kierunek";
            label5.Content = "Numer indeksu";
            label6.Visibility = Visibility.Hidden;
            tb6.Visibility = Visibility.Hidden;
            cb4.ItemsSource = Enum.GetValues(typeof(Kierunek));
        }
        /*
         * Wciśniecie przycisku "dodaj nową osobę" w zakładce dodawania
         * Osbługa różnych wyjątków
         */
        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((rbstudent.IsChecked == false) && (rbpracownik.IsChecked == false))
                {
                    Exception brakWyboru = new Exception("Musisz wybrać typ osoby!");
                    throw brakWyboru;
                }
                if (String.IsNullOrEmpty(tbimie.Text))
                {
                    Exception pusteImie = new Exception("Musisz podać imię!");
                    throw pusteImie;
                }
                if (String.IsNullOrEmpty(tbnazwisko.Text))
                {
                    Exception pusteNazwisko = new Exception("Musisz podać Nazwisko!");
                    throw pusteNazwisko;
                }
                if (String.IsNullOrEmpty(tbtelefon.Text))
                {
                    Exception pusteTelefon = new Exception("Musisz podać Numer telefonu!");
                    throw pusteTelefon;
                }
                if ((String.IsNullOrEmpty(cb4.Text)) || (String.IsNullOrEmpty(tb5.Text)))
                {
                    Exception pusteKierunek = new Exception("Musisz wybrać Kierunek i podać numer indeksu!");
                    throw pusteKierunek;
                }
                if ((rbpracownik.IsChecked == true) && ((String.IsNullOrEmpty(tb6.Text))))
                {
                    Exception pusteIndex = new Exception("Musisz podać pensję!");
                    throw pusteIndex;
                }
                if (rbpracownik.IsChecked == true)
                {
                    string imie = tbimie.Text;
                    string nazwisko = tbnazwisko.Text;
                    int telefon = Convert.ToInt32(tbtelefon.Text);
                    Stanowisko stanowisko = (Stanowisko)Enum.Parse(typeof(Stanowisko), cb4.Text);
                    string tytul = tb5.Text;
                    double pensja = Convert.ToDouble(tb6.Text);
                    Pracownik pracownik = new Pracownik(imie, nazwisko, telefon, tytul, stanowisko, pensja);
                    listy.Dodaj(pracownik);
                    MessageBox.Show("Dodano do listy pracowników");
                }
                else if (rbstudent.IsChecked == true)
                {
                    string imie = tbimie.Text;
                    string nazwisko = tbnazwisko.Text;
                    int telefon = Convert.ToInt32(tbtelefon.Text);
                    Kierunek kierunek = (Kierunek)Enum.Parse(typeof(Kierunek), cb4.Text);
                    int index = Convert.ToInt32(tb5.Text);
                    Student student = new Student(imie, nazwisko, telefon, kierunek, index);
                    listy.Dodaj(student);
                    MessageBox.Show("Dodano do listy studentów");
                }
                Czysc();
            }
            catch (FormatException)
            {
                if (rbstudent.IsChecked == true)
                    MessageBox.Show("Podaj poprawny numer telefonu i indeksu");
                if (rbpracownik.IsChecked == true)
                    MessageBox.Show("Podaj poprawny numer telefonu i pensję");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Koniec_Click(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(0);
        }
        /*
         * Kliknięcie przycisku "zapisz do xml"
         */
        private void Zapisz_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Osoby";
            dlg.DefaultExt = ".xml";
            dlg.Filter = "XML documents (.xml)|*.xml";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                string filePath = dlg.FileName;
                ListyDoPliku(filePath);
            }
        }
        /*
         * Serializacja danych do XML
         */
        private void ListyDoPliku(string filePath)
        {
            using (var sw = new StreamWriter(filePath))
            {
                var serializer = new XmlSerializer(typeof(Listy));
                serializer.Serialize(sw, listy);
            }
        }
        /*
         * Kliknięcie przycisku "wczytaj z xml"
         */
        private void Wczytaj_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".xml";
            dlg.Filter = "XML documents (.xml)|*.xml";

            Nullable<bool> result = dlg.ShowDialog();
            string filename = "";
            if (result == true)
            {
                filename = dlg.FileName;
            }
            if (File.Exists(filename))
            {
                ZPlikuDoListy(filename);
            }
            else
            {
                MessageBox.Show("Nie ma takiego pliku!");
            }
        }
        /*
         * Deserializacja danych z XML
         */
        private void ZPlikuDoListy(string filename)
        {
            try
            {
                using (var sr = new StreamReader(filename))
                {
                    var deserializer = new XmlSerializer(typeof(Listy));
                    Listy tmpList = (Listy)deserializer.Deserialize(sr);
                    foreach (var item in tmpList.ListaPracownikow)
                    {
                        listy.Dodaj(item);
                    }
                    foreach (var item in tmpList.ListaStudentow)
                    {
                        listy.Dodaj(item);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Niepoprawne dane w pliku!");
            }

        }
        /*
         * Kliknięcie przycisku "wyczysc pola" w zakładce dodawania
         * Czyszczenie pól
         */
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Czysc();
        }
        private void Czysc()
        {
            tbimie.Text = "";
            tbnazwisko.Text = "";
            tbtelefon.Text = "";
            tb5.Text = "";
            tb6.Text = "";
            cb4.Text = "";
            rbpracownik.IsChecked = false;
            rbstudent.IsChecked = false;
            cb4.Visibility = Visibility.Hidden;
            label4.Visibility = Visibility.Hidden;
            label5.Visibility = Visibility.Hidden;
            tb5.Visibility = Visibility.Hidden;
            label6.Visibility = Visibility.Hidden;
            tb6.Visibility = Visibility.Hidden;
        }
        /*
         * Kliknięcie przycisku "export studentow do txt"
         */
        private void ExportStudentow_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Studenci";
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Pliki txt (.txt)|*.txt";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                string filePath = dlg.FileName;

                using (var sw = new StreamWriter(filePath))
                {
                    foreach (var item in listy.ListaStudentow)
                    {
                        sw.WriteLine(item.Wypisz());
                    }
                }
            }
        }
        /*
         * Kliknięcie przycisku "export studentow do txt"
         */
        private void ExportPracownikow_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Pracownicy";
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Pliki txt (.txt)|*.txt";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                string filePath = dlg.FileName;
                using (var sw = new StreamWriter(filePath))
                {
                    foreach (var item in listy.ListaPracownikow)
                    {
                        sw.WriteLine(item.Wypisz());
                    }
                }
            }
        }
    }
}