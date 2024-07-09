using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace VirtualVendingMachine.Models
{
    [Serializable]
    public class SlotModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ProductModel Product { get; set; }

        private int _RemainingItemCount;
        public int RemainingItemCount
        {
            get => _RemainingItemCount;
            set
            {
                _RemainingItemCount = value;
                OnPropertyChanged(nameof(RemainingItemCount));
                OnPropertyChanged(nameof(CountText));
            }
        }

        [XmlIgnore]
        public string CountText
        {
            get => RemainingItemCount <= 0 ? "EMPTY" : $"{RemainingItemCount} Available";
        }

        [XmlIgnore]
        private string _SlotID;
        [XmlIgnore]
        public string SlotID
        {
            get => _SlotID;
            set
            {
                _SlotID = value;
                OnPropertyChanged(nameof(SlotID));
            }
        }        

        public SlotModel(ProductModel product, string ID)
        {
            Product = product;
            RemainingItemCount = 10;
            SlotID = ID;
        }

        public SlotModel() { }
    }
}
