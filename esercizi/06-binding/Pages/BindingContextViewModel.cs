using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioBinding.Pages
{
    public class BindingContextViewModel : INotifyPropertyChanged
    {
        private int counter;

        public BindingContextViewModel()
        {
            var timer = Application.Current.Dispatcher.CreateTimer();
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += IncrementCounter;
            timer.Start();
        }

        private void IncrementCounter(object sender, EventArgs e)
        {
            Counter++;
        }

        public int Counter
        {
            get
            {
                return counter;
            }

            set
            {
                counter = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Counter)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
