using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Xml.Serialization;
using VirtualVendingMachine.Enums;

namespace VirtualVendingMachine.Models
{
    [Serializable]
    [XmlInclude(typeof(GameModel))]
    [XmlInclude(typeof(DrinksModel))]
    [XmlInclude(typeof(FoodModel))]
    public class ProductModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public double UniqueID { get; set; }

        [XmlIgnore]
        public ProductShape ProductShape { get; set; }

        [XmlIgnore]
        public ProductType ProductType { get; set; }

        [XmlIgnore]
        private string _Name;
        [XmlIgnore]
        public string Name
        {
            get => _Name;
            set
            {
                _Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        [XmlIgnore]
        private SolidColorBrush _Color;
        [XmlIgnore]
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
