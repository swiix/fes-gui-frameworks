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

            fuegeZurDateiHinzu(neuePerson, _mainViewModel.DateiPfad);

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

        /// <summary>
        /// Fügt Daten eines Personen Objekts in eine Datei( siehe _mainViewModel.DateiName )
        /// </summary>
        /// <param name="Person">Personen Objekt</param>
        private void fuegeZurDateiHinzu(Person person, string dateiPfad)
        {
            var fileWriter = new StreamWriter(dateiPfad, true); //Append = true;
            fileWriter.WriteLine(getCsvFormat(person));
            fileWriter.Close();
        }

        /// <summary>
        /// Convertiert das Personen Objekt als String mit einem CSV Typischen Seperator
        /// </summary>
        /// <param name="person">Personen Objekt</param>
        /// <param name="seperator">Trennstrich für Output. Default ist ";" CSV Typisch</param>
        /// <returns></returns>
        private string getCsvFormat(Person person, string seperator = ";")
        {
            string output = "";

            string[] data =  { person.Vorname,
                                person.Nachname,
                                person.Adresse.Strasse,
                                person.Adresse.Ort,
                                person.Adresse.Plz};
            // String wird zusammengeführt aus Array data
            foreach(string d in data)
            {
                output += d + seperator;
            }

            return output;
        }
    }
}
