using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using fes_gui_wpf.Utils;

namespace fes_gui_wpf.ViewModel
{
    public class FormViewModel
    {
        public string Visibility { get; set; }
        public DelegateCommand SpeichernCommand { get; set; }

        public FormViewModel(MainViewModel mainViewModel)
        {
            Visibility = "Visible";
            SpeichernCommand = new DelegateCommand(() => Speichern());
        }

        private void Speichern()
        {
            MessageBox.Show("huhu");
        }
    }
}
