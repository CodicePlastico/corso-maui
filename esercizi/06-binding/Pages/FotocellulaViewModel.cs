using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioBinding.Pages
{
    public class FotocellulaViewModel : INotifyPropertyChanged
    {
        public FotocellulaViewModel()
        {
            var timer = Application.Current.Dispatcher.CreateTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += IncrementCounter;
            timer.Start();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void IncrementCounter(object sender, EventArgs e)
        {
            Counter += 10;
        }

        private int counter = 0;
        public int Counter
        {
            get
            {
                return counter;
            }

            set
            {
                if (counter != value)
                { 
                    counter = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Counter)));
                }
            }
        }
    }
}
