using System.ComponentModel;

namespace fes_gui_wpf.Utils
{
    /// <summary>
    /// Klasse welche es vereinfacht INotifyPropertyChanged zu implementieren
    /// @Bekkaoui OnPropertyChanged ist ein Event, welches dem GUI bescheidgibt, dass sich im Code etwas geändert hat
    /// und der Content aktuallisert werden soll
    /// </summary>
    public class Notifier : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
