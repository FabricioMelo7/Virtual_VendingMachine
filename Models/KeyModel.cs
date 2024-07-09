using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualVendingMachine.Models
{
    public class KeyModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _Entry;
        public string Entry
        {
            get => _Entry;
            set
            {
                _Entry = value;
                OnPropertyChanged(nameof(Entry));
            }
        }

        public KeyModel(string entry)
        {
            Entry = entry;
        }

        public KeyModel(int entry) : this(entry.ToString())
        {
        }

        public KeyModel() { }
    }
}
