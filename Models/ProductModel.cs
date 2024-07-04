using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using VirtualVendingMachine.Enums;

namespace VirtualVendingMachine.Models
{
    public class ProductModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public double UniqueID { get; set; } 
        
        public ProductShape ProductShape { get; set; }

        public ProductType ProductType { get; set; }

        private string _Name;
        public string Name
        {
            get => _Name;
            set
            {
                _Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private SolidColorBrush _Color;
        public SolidColorBrush Color
        {
            get => _Color;
            set
            {
                _Color = value;
                OnPropertyChanged(nameof(Color));
            }
        }

        public ProductModel(double uniqueID, ProductShape productShape, ProductType productType, string name, SolidColorBrush color)
        {
            UniqueID = uniqueID;
            ProductShape = productShape;
            ProductType = productType;
            Name = name;
            Color = color;           
        }

        public ProductModel() { }
    }

}
