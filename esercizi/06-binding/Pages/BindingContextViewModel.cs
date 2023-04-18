﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioBinding.Pages
{
    public class BindingContextViewModel : INotifyPropertyChanged
    {
        public BindingContextViewModel()
        {
            Fotocellula = new FotocellulaViewModel();

            var timer = Application.Current.Dispatcher.CreateTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += IncrementCounter;
            timer.Start();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public FotocellulaViewModel Fotocellula { get; }

        private void IncrementCounter(object sender, EventArgs e)
        {
            Counter++;
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
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsLow)));
                }
            }
        }

        public bool IsLow
        {
            get
            {
                return Counter < 20;
            }
        }
    }
}
