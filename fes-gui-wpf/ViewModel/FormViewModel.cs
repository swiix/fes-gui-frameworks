using System.Windows;
using fes_gui_wpf.Model;
using fes_gui_wpf.Utils;

namespace fes_gui_wpf.ViewModel
{
    public class FormViewModel
    {
        private string _visibility;
        private readonly MainViewModel _mainViewModel;

        public string Visibility
        {       
            get
            {
                return _visibility;
            }
            set
            {
                _visibility = value;
            }
        }

        public string Vorname { get; set; }
        public string Name { get; set; }
        public string Alter { get; set; }
        public string Strasse { get; set; }
        public string Ort { get; set; }
        public string Plz { get; set; }

        public DelegateCommand SpeichernCommand { get; set; }

        public FormViewModel(MainViewModel mainViewModel)
        {
            Visibility = "Visible";
            SpeichernCommand = new DelegateCommand(() => Speichern());
            _mainViewModel = mainViewModel;
        }

        private void Speichern()
        {
            var personen = _mainViewModel.Personen;

            // Auslesen aus der Form, Person der Liste hinzufügen
            _mainViewModel.Personen.Add(new Person(Vorname ,Name,
                new Adresse(Plz, Ort, Strasse)));

            // Debug Liste
            _mainViewModel.Personen.Add(new Person("Carl", "Reinecken",
                new Adresse("123", "Carlsberg", "Heinekesttr.")));

            // Listen Ausgabe
            string text = "";
            foreach(Person person in personen)
            {
                text += person + "\n\n";
            }
            MessageBox.Show(text);
        }
    }
}
