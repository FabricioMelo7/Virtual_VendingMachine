using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using VirtualVendingMachine.Enums;

namespace VirtualVendingMachine.Models
{
    public class GameModel : ProductModel
    {
        public ProductGenres Genre {  get; set; }

        private int _AgeRating;
        public int AgeRating
        {
            get  => _AgeRating;
            set
            {
                _AgeRating = value;
                OnPropertyChanged(nameof(AgeRating));
                OnPropertyChanged(nameof(PEGI_AgeRating));
            }
        }

        public string PEGI_AgeRating
        {
            get => $"{AgeRating}+";
        }

        private int? _MaxPlayers;
        public int? MaxPlayers
        {
            get => _MaxPlayers;
            set
            {
                _MaxPlayers = value;
                OnPropertyChanged(nameof(MaxPlayers));
            }
        }

        private int _MinPlayers;
        public int MinPlayers
        {
            get => _MinPlayers;
            set
            {
                _MinPlayers = value;
                OnPropertyChanged(nameof(MinPlayers));
                OnPropertyChanged(nameof(NumberOfPlayers));
            }
        }
       
        public string NumberOfPlayers
        {
            get
            {
                if(MaxPlayers == null)
                {
                    return "SinglePlayer";
                }

                return $"{MinPlayers} - {MaxPlayers}";
            }
        }

        public GameModel(double uniqueID, ProductType type, ProductShape shape, string name, SolidColorBrush color, int ageRating, int minPlayers, int? maxPlayers, ProductGenres genres) : base(uniqueID, shape, type, name, color)
        {
            Genre = genres;
            AgeRating = ageRating;
            MinPlayers = minPlayers;
            MaxPlayers = maxPlayers;
        }

        public GameModel() { }
    }
}
