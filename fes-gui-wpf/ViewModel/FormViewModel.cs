using System.Windows;
using fes_gui_wpf.Model;
using fes_gui_wpf.Utils;
using System.Collections.ObjectModel;
namespace fes_gui_wpf.ViewModel
{
    public class FormViewModel
    {
        private readonly MainViewModel _mainViewModel;

        
        public string Vorname { get; set; }
        public string Name { get; set; }
        public string Alter { get; set; }
        public string Strasse { get; set; }
        public string Ort { get; set; }
        public string Plz { get; set; }

        public DelegateCommand SpeichernCommand { get; set; }

        public FormViewModel(MainViewModel mainViewModel)
        {
            SpeichernCommand = new DelegateCommand(() => Speichern());
            _mainViewModel = mainViewModel;
        }

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
