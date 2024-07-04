using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using VirtualVendingMachine.Enums;

namespace VirtualVendingMachine.Models
{
    public class FoodModel : ProductModel
    {
        private double _Size;
        public double Size
        {
            get => _Size;
            set
            {
                _Size = value;
                OnPropertyChanged(nameof(Size));
                OnPropertyChanged(nameof(SizeDisplay));
            }
        }

        public virtual string SizeDisplay
        {
            get => Size < 1000 ? $"{Size}g" : $"{Size / 1000}kg";
        }

        public FoodModel(double uniqueID, ProductType type, ProductShape shape, string name, SolidColorBrush color, double size) :base(uniqueID, shape, type, name, color)
        {  
            Size = size;
        }

        public FoodModel() { }
    }
}
