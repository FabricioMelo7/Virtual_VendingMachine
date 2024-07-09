using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualVendingMachine.Models;

namespace VirtualVendingMachine.ViewModels
{
    public class MainViewModel
    {
        readonly string defaultMessage = "Use the Keypad to choose a product";

        public SlotsViewModel SlotsViewModel { get; set; }
        public InventoryModel InventoryModel { get; set; }
        public KeyPadViewModel KeyPadViewModel { get; set; }

        public MainViewModel()
        {
            InventoryModel = new InventoryModel();
            SlotsViewModel = new SlotsViewModel(InventoryModel.ProductList);
            KeyPadViewModel = new KeyPadViewModel();
        }
    }
}
