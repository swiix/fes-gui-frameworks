using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using fes_gui_wpf.Model;

// #TODO
// [ ] DataTableView auslagern in seperate View

namespace fes_gui_wpf.ViewModel
{
    public class MainViewModel
    {
        public FormViewModel FormViewModel { get; set; }
        public ObservableCollection<Person> Personen { get; set; }

        // "@" bedeut das special Character nicht beachtet werden z.B \n \r \b \\
        public string DateiPfad = @"Personen.csv";

        public MainViewModel()
        {
            // View
            FormViewModel = new FormViewModel(this);

            // Listen
            Personen = new ObservableCollection<Person>();

            // Lese aus Datei -> Lade Personen-Daten, wenn Datei verfügbar
            leseDatei(DateiPfad);
        }

        /// <summary>
        /// liest die mitgegebene Datei ein und aktuallisiert die Personen Liste
        /// </summary>
        /// <param name="dateiPfad"></param>
        private void leseDatei(string dateiPfad)
        {
            if(File.Exists(dateiPfad))
            {
                StreamReader streamReader = new StreamReader(dateiPfad);
                
                // Datei Zeile für zeile auslesen, Daten als Objekt anlegen und der PersonenListe hinzufügen.
                while(streamReader.Peek() >= 0)
                {
                    char sperator = ';';
                    // einlesen der Zeile und dekodierung zu einem String Array
                    string[] personData = streamReader.ReadLine().Split(sperator);

                    string vorname = personData[0];
                    string nachname = personData[1];
                    string strasse = personData[2];
                    string ort = personData[3];
                    string plz = personData[4];

                    Personen.Add(new Person(vorname, nachname, new Adresse(plz, ort, strasse)));
                }
                streamReader.Close();
            }
        }
    }
}
