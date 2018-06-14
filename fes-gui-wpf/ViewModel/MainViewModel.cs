using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using fes_gui_wpf.Model;

namespace fes_gui_wpf.ViewModel
{
    public class MainViewModel
    {
        public CsvController CsvController;

        public FormViewModel FormViewModel { get; set; }
        public ObservableCollection<Person> Personen { get; set; }

        // "@" Notation bedeut das Special Character nicht beachtet werden z.B \n \r \b \\
        public string DateiPfad = @"Personen.csv";
        /// <summary>
        /// 
        /// </summary>
        public MainViewModel()
        {
            // Utils
            CsvController = new CsvController(DateiPfad);            

            // Listen
            Personen = new ObservableCollection<Person>();

            // View
            FormViewModel = new FormViewModel(this, CsvController);

            // Lese aus Datei -> Lade Personen-Daten, wenn Datei verfügbar
            CsvController.leseDatei(Personen);
        }

    }
}
