using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfProjekt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Pracownik> ListaPracownikow { get; set; }
        public ObservableCollection<Student> ListaStudentow { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            ListaPracownikow = new ObservableCollection<Pracownik>();
            ListaStudentow = new ObservableCollection<Student>();
        }

        private void rbpracownik_Checked(object sender, RoutedEventArgs e)
        {
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

        private void rbstudent_Checked(object sender, RoutedEventArgs e)
        {
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (rbpracownik.IsChecked == true)
                {
                    string imie = tbimie.Text;
                    string nazwisko = tbnazwisko.Text;
                    int telefon = Convert.ToInt32(tbtelefon.Text);
                    Stanowisko stanowisko = (Stanowisko)Enum.Parse(typeof(Stanowisko), cb4.Text);
                    string tytul = tb5.Text;
                    double pensja = Convert.ToDouble(tb6.Text);
                    Pracownik pracownik = new Pracownik(imie, nazwisko, telefon, tytul, stanowisko, pensja);
                    ListaPracownikow.Add(pracownik);
                }
                else if (rbstudent.IsChecked == true)
                {
                    string imie = tbimie.Text;
                    string nazwisko = tbnazwisko.Text;
                    int telefon = Convert.ToInt32(tbtelefon.Text);
                    Kierunek kierunek = (Kierunek)Enum.Parse(typeof(Kierunek), cb4.Text);
                    int index = Convert.ToInt32(tb5.Text);
                    Student student = new Student(imie, nazwisko, telefon, kierunek,index);
                    ListaStudentow.Add(student);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
