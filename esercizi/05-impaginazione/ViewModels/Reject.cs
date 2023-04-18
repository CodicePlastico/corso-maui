using System;
using System.ComponentModel;

namespace EsercizioImpaginazione.ViewModels
{
    public class Reject : INotifyPropertyChanged
    {
        public string Reason { get; set; }

        private int counter = 0;

        public event PropertyChangedEventHandler PropertyChanged;

        public int Counter {
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
