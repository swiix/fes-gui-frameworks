using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fes_gui_wpf.ViewModel
{
    public class MainViewModel
    {
        public FormViewModel FormViewModel { get; set; }

        public MainViewModel()
        {
            FormViewModel = new FormViewModel(this);
        }
    }
}
