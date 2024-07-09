using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using VirtualVendingMachine.Custom_EventArgs;
using VirtualVendingMachine.Enums;
using VirtualVendingMachine.Models;
using VirtualVendingMachine.Utils;

namespace VirtualVendingMachine.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        readonly string defaultMessage = "Use the Keypad to choose a product";

        public SlotsViewModel SlotsViewModel { get; set; }
        public InventoryModel InventoryModel { get; set; }
        public KeyPadViewModel KeyPadViewModel { get; set; }

        private string _VendingMachineText;
        public string VendingMachineText
        {
            get
            {
                if(_VendingMachineText == string.Empty || KeyPadViewModel.KeyPadDisplayText == string.Empty && KeyPadViewModel.IsKeyPadEnabled)
                {
                    return defaultMessage;
                }

                return _VendingMachineText;
            }

            set
            {
                _VendingMachineText = value;
                OnPropertyChanged(nameof(VendingMachineText));
            }
        }

        public bool IsSortByNameDescending;
        public bool IsSortByTypeDescending;

        public SortState currentSort = SortState.None;

        public ICommand SortByNameCommand { get; }
        public ICommand SortByTypeCommand { get; }

        public MainViewModel()
        {
            InventoryModel = new InventoryModel();
            SlotsViewModel = new SlotsViewModel(InventoryModel.ProductList);
            KeyPadViewModel = new KeyPadViewModel();

            SortByNameCommand = new RelayCommand<KeyModel>(SortByName);
            SortByTypeCommand = new RelayCommand<KeyModel>(SortByType);
            KeyPadViewModel.AcceptButtonPressed += OnAcceptKeyPressed;
        }

        private void SortByType(KeyModel? key)
        {
            ListSortDirection direction = !IsSortByTypeDescending ? ListSortDirection.Ascending : ListSortDirection.Descending;
            currentSort = IsSortByTypeDescending ? SortState.ProductTypeDescending : SortState.ProductTypeAscending;
            ApplyProductTypeGrouping("Product.ProductType", "Product.ProductType", direction);
            IsSortByTypeDescending = !IsSortByTypeDescending;
        }

        private void ApplyProductTypeGrouping(string sortPropertyName, string groupPropertyName, ListSortDirection sortDirection)
        {
            ClearSortingAndGrouping();
            SlotsViewModel.SlotsCollectionView.GroupDescriptions.Add(new PropertyGroupDescription(groupPropertyName));
            SlotsViewModel.SlotsCollectionView.SortDescriptions.Add(new SortDescription(sortPropertyName, sortDirection));
            SlotsViewModel.SlotsCollectionView.View.Refresh();
        }


        private void SortByName(KeyModel? model)
        {
            ListSortDirection direction = !IsSortByNameDescending ? ListSortDirection.Ascending : ListSortDirection.Descending;
            currentSort = IsSortByNameDescending ? SortState.ProductNameDescending : SortState.ProductNameAscending;
            ApplyProductNameSorting("Product.Name", direction);
            IsSortByNameDescending = !IsSortByNameDescending;
        }

        private void ApplyProductNameSorting(string sortPropertyName, ListSortDirection sortDirection)
        {
            ClearSortingAndGrouping();
            SlotsViewModel.SlotsCollectionView.SortDescriptions.Add(new SortDescription(sortPropertyName, sortDirection));
            SlotsViewModel.SlotsCollectionView.View.Refresh();
        }

        private void ClearSortingAndGrouping()
        {
            SlotsViewModel.SlotsCollectionView.GroupDescriptions.Clear();
            SlotsViewModel.SlotsCollectionView.SortDescriptions.Clear();
        }

        public void OnAcceptKeyPressed(object sender, KeyPadSelectionEventArgs e)
        {
            if(!Utilities.IsRequestedIdValid(KeyPadViewModel.EnteredKeys, SlotsViewModel.SlotList))
            {
                KeyPadViewModel.IsErrorState = true;
                KeyPadViewModel.IsKeyPadEnabled = false;
                return; 
            }

            KeyPadViewModel.IsKeyPadEnabled = false;
            string productID = Utilities.ProductEntered(SlotsViewModel.SlotList, e.Entries).SlotID;
            SlotModel slotViewModel = SlotsViewModel.SlotList.FirstOrDefault(slot => slot.SlotID == productID);
            KeyPadViewModel.EnteredKeys.Clear();
            DispensingSequence(slotViewModel);
        }

        private async void DispensingSequence(SlotModel? slot)
        {
            if(slot == null)
            {
                return;
            }

            if(slot.RemainingItemCount == 0)
            {
                KeyPadViewModel.IsErrorState = true;
                return;
            }

            slot.RemainingItemCount--;
            KeyPadViewModel.KeyPadDisplayText = string.Empty;

            //CountDown
            VendingMachineText = "Dispensing, Please Wait...";
            await Task.Delay(5000);
            CommandManager.InvalidateRequerySuggested();
            ResetKeyPad();
        }

        private void ResetKeyPad()
        {
            VendingMachineText = string.Empty;
            KeyPadViewModel.ClearEnteredKeys(null);
        }

        ~MainViewModel()
        {
            KeyPadViewModel.AcceptButtonPressed -= OnAcceptKeyPressed;
        }
    }
}
