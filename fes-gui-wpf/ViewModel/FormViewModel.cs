using System.Windows;
using fes_gui_wpf.Model;
using fes_gui_wpf.Utils;
using System.Collections.ObjectModel;
using System.IO;
using System;

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

            // neue Person erstellen
            Person neuePerson = new Person(Vorname, Name, new Adresse(Plz, Ort, Strasse));
            // Person zur Liste hinzufügen
            personen.Add(neuePerson);
            fuegeZurDateiHinzu(neuePerson);
        }

        // Person in Datei schreiben
        private void fuegeZurDateiHinzu(Person neuePerson)
        {
            var fileWriter = new StreamWriter(_mainViewModel.DateiName ,true); //Append = true;
            fileWriter.WriteLine(getCsvFormat(neuePerson));
            fileWriter.Close();
        }

        private string getCsvFormat(Person person)
        {
            string output = "";
            string sperator = ";";

            string[] data =  { person.Vorname,
                                person.Nachname,
                                person.Adresse.Strasse,
                                person.Adresse.Ort,
                                person.Adresse.Plz};
            // String wird zusammengeführt aus Array data
            foreach(string d in data)
            {
                output += d + sperator;
            }

            return output;
        }
    }
}
