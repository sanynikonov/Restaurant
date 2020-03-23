using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace TRPZ
{
    public class OrderedDishWithAmount : INotifyPropertyChanged
    {
        public Dish OrderedDish { get; set; }

        private int amount = 1;
        public int Amount
        {
            get { return amount; }
            set
            {
                amount = value;
                OnPropertyChanged(nameof(Amount));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
