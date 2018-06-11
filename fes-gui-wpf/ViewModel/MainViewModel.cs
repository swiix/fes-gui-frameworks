using System.Collections.ObjectModel;
using fes_gui_wpf.Model;

// #TODO
// [ ] DataTableView auslagern in seperate View

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

            // Debug Liste
            Personen.Add(new Person("Carl" ,"Reinecken" ,
                new Adresse("123" ,"Carlsberg" ,"Heinekesttr.")));

        }

    }
}
