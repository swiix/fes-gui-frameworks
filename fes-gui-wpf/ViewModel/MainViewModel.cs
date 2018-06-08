using System.Collections.ObjectModel;
using fes_gui_wpf.Model;

namespace fes_gui_wpf.ViewModel
{
    public class MainViewModel
    {
        public FormViewModel FormViewModel { get; set; }
        public ObservableCollection<Person> Personen { get; set; }

        public MainViewModel()
        {
            // View
            FormViewModel = new FormViewModel(this);

            // Listen
            Personen = new ObservableCollection<Person>();
        }

    }
}
