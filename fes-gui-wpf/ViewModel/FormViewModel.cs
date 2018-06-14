using System.Windows;
using fes_gui_wpf.Model;
using fes_gui_wpf.Utils;
using System.Collections.ObjectModel;
using System.IO;
using System;

namespace fes_gui_wpf.ViewModel
{
    public class FormViewModel : Notifier
    {
        private readonly MainViewModel _mainViewModel;

        // Deklaration für die Daten, welche eingetippt werden
        public string Vorname { get; set; }
        public string Name { get; set; }
        public string Alter { get; set; }
        public string Strasse { get; set; }
        public string Ort { get; set; }
        public string Plz { get; set; }

        // CsvController
        private CsvController _csvController;

        // Pointer für die Methode Speichern()
        public DelegateCommand SpeichernCommand { get; set; }

        /// <summary>
        /// Konstruktor der Klasse FormViewModel
        /// </summary>
        /// <param name="mainViewModel"></param>
        public FormViewModel(MainViewModel mainViewModel, CsvController CsvController)
        {
            SpeichernCommand = new DelegateCommand(() => Speichern());
            _csvController = CsvController;
            _mainViewModel = mainViewModel;
        }

        /// <summary>
        /// Fügt der Liste MainViewModel.Personen hinzu
        /// Speichert diese Werte in Datei
        /// </summary>
        private void Speichern()
        {
            // Validierung, weil wir finden, dass sonst ein Eintrag keinen Sinn macht und kein Anwendungszweck besitzt.
            if(String.IsNullOrWhiteSpace(Vorname) || String.IsNullOrWhiteSpace(Name))
            {
                MessageBox.Show("Vorname und Nachname sind Pflichtfelder!");
                return;
            }

            ObservableCollection<Person> personen = _mainViewModel.Personen;
            // Auslesen aus der Form, Person der Liste hinzufügen
            Person neuePerson = new Person(Vorname, Name, new Adresse(Plz, Ort, Strasse));
            // Person zur Liste hinzufügen
            personen.Add(neuePerson);

            _csvController.fuegeZurDateiHinzu(neuePerson);

            FormReset();

        }

        /// <summary>
        /// Setzt alle Form Einträge auf Default zurück und gibt dem GUI bescheid(OnPropertyChanged)
        /// </summary>
        private void FormReset()
        {
            Name = "";
            OnPropertyChanged("Name");
            Vorname = "";
            OnPropertyChanged("Vorname");
            Strasse = "";
            OnPropertyChanged("Strasse");
            Ort = "";
            OnPropertyChanged("Ort");
            Plz = "";
            OnPropertyChanged("Plz");
        }
    }
}
