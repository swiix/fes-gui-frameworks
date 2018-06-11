using System.Windows;
using fes_gui_wpf.Model;
using fes_gui_wpf.Utils;
using System.Collections.ObjectModel;
namespace fes_gui_wpf.ViewModel
{
    public class FormViewModel
    {
        private readonly MainViewModel _mainViewModel;

        // Deklaration für die Daten, welche eingetippt werden
        public string Vorname { get; set; }
        public string Name { get; set; }
        public string Alter { get; set; }
        public string Strasse { get; set; }
        public string Ort { get; set; }
        public string Plz { get; set; }

        // Pointer für die Methode Speichern()
        public DelegateCommand SpeichernCommand { get; set; }

        /// <summary>
        /// Konstruktor der Klasse FormViewModel
        /// </summary>
        /// <param name="mainViewModel"></param>
        public FormViewModel(MainViewModel mainViewModel)
        {
            SpeichernCommand = new DelegateCommand(() => Speichern());
            _mainViewModel = mainViewModel;
        }

        /// <summary>
        /// Fügt der Liste MainViewModel.Personen hinzu
        /// Speichert diese Werte in Datei
        /// </summary>
        private void Speichern()
        {
            ObservableCollection<Person> personen = _mainViewModel.Personen;
            // TODO? Validierung?
            // Auslesen aus der Form, Person der Liste hinzufügen
            _mainViewModel.Personen.Add(new Person(Vorname ,Name,
                new Adresse(Plz, Ort, Strasse)));
        }
    }
}
