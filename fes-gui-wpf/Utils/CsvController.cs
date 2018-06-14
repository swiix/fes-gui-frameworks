using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using fes_gui_wpf.Model;

namespace fes_gui_wpf
{
    /// <summary>
    /// CsvController ist für das Lesen und Schreiben von Csv Datei zuständlig.
    /// Bezogen auf Objekte vom Typ <Person>
    /// </summary>
    public class CsvController
    {
        private StreamWriter _fileWriter;
        private StreamReader _fileReader;

        private string _dataiPfad;

        /// <summary>
        /// Öffnet Streams(Reader/Writer)
        /// </summary>
        /// <param name="dateiPfad"></param>
        public CsvController(string dateiPfad)
        {
            _dataiPfad = dateiPfad;
        }

        /// <summary>
        /// Fügt Daten eines Personen Objekts in eine Datei( siehe _mainViewModel.DateiName )
        /// </summary>
        /// <param name="Person">Personen Objekt</param>
        public void fuegeZurDateiHinzu(Person person)
        {
            try
            {
                _fileWriter = new StreamWriter(_dataiPfad, true); //Append = true;
                _fileWriter.WriteLine(getCsvFormat(person));
                _fileWriter.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
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
                output += d.Trim() + seperator;
            }

            return output;
        }


        /// <summary>
        /// liest die mitgegebene Datei ein und aktuallisiert die Personen Liste
        /// </summary>
        /// <param name="personenListe">Referenz der PersonenListe</param>
        public void leseDatei(ObservableCollection<Person> personenListe)
        {
            if(File.Exists(_dataiPfad))
            {
                try
                {
                    _fileReader = new StreamReader(_dataiPfad);
                    // Datei Zeile für zeile auslesen, Daten als Objekt anlegen und der PersonenListe hinzufügen.
                    while(_fileReader.Peek() >= 0)
                    {
                        char sperator = ';';
                        // einlesen der Zeile und dekodierung zu einem String Array
                        string[] personData = _fileReader.ReadLine().Split(sperator);

                        string vorname = personData[0];
                        string nachname = personData[1];
                        string strasse = personData[2];
                        string ort = personData[3];
                        string plz = personData[4];

                        personenListe.Add(new Person(vorname, nachname, new Adresse(plz, ort, strasse)));
                    }
                    _fileReader.Close();
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }
    }
}