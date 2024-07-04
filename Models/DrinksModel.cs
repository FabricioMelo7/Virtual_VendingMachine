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
    public class DrinksModel : ProductModel
    {
        private double _AlcoholLevel;
        public double AlcoholLevel
        {
            get => _AlcoholLevel;
            set
            {
                _AlcoholLevel = value;
                OnPropertyChanged(nameof(AlcoholLevel));
                OnPropertyChanged(nameof(AlcoholLevelDisplay));
            }
        }

        public string AlcoholLevelDisplay
        {
            get => $"{AlcoholLevel}%";
        }

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

        public string SizeDisplay
        {
            get
            {
               return Size < 1000 ? $"{Size}ml" : $"{Size / 1000}ltr";                    
            }            
        }

        public DrinksModel(double uniqueID, ProductType type, ProductShape shape, string name, double alcLevel, SolidColorBrush color, double size) :base(uniqueID, shape, type, name, color) 
        {
            AlcoholLevel = alcLevel;
            Size = size;
        }

        public DrinksModel() { }
    }
}
