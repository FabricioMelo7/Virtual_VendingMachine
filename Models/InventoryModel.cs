using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using VirtualVendingMachine.Enums;

namespace VirtualVendingMachine.Models
{
    public class InventoryModel
    {
        public List<ProductModel> ProductList { get; set; }

        public InventoryModel() 
        {
            ProductList = new List<ProductModel>();
            ReloadStock();
        }

        public void ReloadStock()
        {
            ProductList.Clear();

            ProductList.Add(new GameModel(0.0, ProductType.ComputerGames, ProductShape.SquareRoundTop, "GTA", Brushes.Yellow, 18, 1, 10, ProductGenres.Online));
            ProductList.Add(new GameModel(0.1, ProductType.ComputerGames, ProductShape.SquareRoundTop, "ACK", Brushes.Purple, 12, 1, null, ProductGenres.Adventure));
            ProductList.Add(new GameModel(0.2, ProductType.ComputerGames, ProductShape.SquareRoundTop, "Rayman", Brushes.Cyan, 7, 1, null, ProductGenres.Platform));
            ProductList.Add(new GameModel(0.3, ProductType.BoardGames, ProductShape.SquareRoundBottom, "Jenga", Brushes.Brown, 3, 2, 6, ProductGenres.Dexterity));
            ProductList.Add(new GameModel(0.4, ProductType.BoardGames, ProductShape.SquareRoundBottom, "Monopoly", Brushes.Plum, 7, 2, 4, ProductGenres.Family));
            ProductList.Add(new GameModel(0.5, ProductType.BoardGames, ProductShape.SquareRoundBottom, "CATAN", Brushes.Pink, 7, 2, 4, ProductGenres.EuroGames));

            ProductList.Add(new DrinksModel(1.0, ProductType.Cans, ProductShape.Square, "Coca-Cola", 0.0, Brushes.Red, 330));
            ProductList.Add(new DrinksModel(1.1, ProductType.Cans, ProductShape.Square, "Fanta", 0.0, Brushes.Orange, 150));
            ProductList.Add(new DrinksModel(1.2, ProductType.Cans, ProductShape.Square, "Sprite", 0.0, Brushes.White, 330));
            ProductList.Add(new DrinksModel(1.3, ProductType.Cans, ProductShape.Square, "Beer", 5.5, Brushes.Yellow, 330));
            ProductList.Add(new DrinksModel(1.4, ProductType.Bottles, ProductShape.Circle, "Still Water", 0.0, Brushes.Blue, 500));
            ProductList.Add(new DrinksModel(1.5, ProductType.Bottles, ProductShape.Circle, "Fanta", 0.0, Brushes.Orange, 500));
            ProductList.Add(new DrinksModel(1.6, ProductType.Bottles, ProductShape.Circle, "Wine", 12.5, Brushes.White, 750));
            ProductList.Add(new DrinksModel(1.7, ProductType.Bottles, ProductShape.Circle, "Sparkling Water", 0.0, Brushes.Blue, 500));

            ProductList.Add(new FoodModel(2.0, ProductType.Crisps, ProductShape.RoundedSquare, "Chilli", Brushes.DarkRed, 75));
            ProductList.Add(new FoodModel(2.1, ProductType.Crisps, ProductShape.RoundedSquare, "Cheese", Brushes.Green, 32.5));
            ProductList.Add(new FoodModel(2.2, ProductType.Crisps, ProductShape.RoundedSquare, "Bacon", Brushes.Brown, 50));
            ProductList.Add(new FoodModel(2.3, ProductType.Chocolate, ProductShape.Hexagon, "Mars", Brushes.Red, 58));
            ProductList.Add(new FoodModel(2.4, ProductType.Chocolate, ProductShape.Hexagon, "Mars", Brushes.Red, 94));
            ProductList.Add(new FoodModel(2.5, ProductType.Chocolate, ProductShape.Hexagon, "Bounty", Brushes.Blue, 57));
        }
    }
}
