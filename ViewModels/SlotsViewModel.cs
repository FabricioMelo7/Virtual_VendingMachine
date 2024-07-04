using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Data;
using VirtualVendingMachine.Models;

namespace VirtualVendingMachine.ViewModels
{
    public class SlotsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        readonly List<ProductModel> _productsList;

        public int Rows { get; } = 5;
        public int Columns { get; } = 4;

        private List<SlotModel> _slotList;
        public List<SlotModel> SlotList
        {
            get => _slotList;
            set
            {
                _slotList = value;
                OnPropertyChanged(nameof(SlotList));
            }
        }

        public CollectionViewSource SlotsCollectionView { get; }

        public SlotsViewModel(List<ProductModel> productsList)
        {
            SlotList = new List<SlotModel>();
            _productsList = productsList;
            FillSlotList();

            SlotsCollectionView = new CollectionViewSource
            {
                Source = SlotList
            };
        }

        public SlotsViewModel() { }

        private void FillSlotList()
        {
            List<string> ids = GenerateIDs();
            SlotList.Clear();

           PopulateSlotList(ids);
        }

        private List<string> GenerateIDs()
        {
            List<string> availableIDs = new List<string>();

            for(int row = 0; row < Rows; row++)
            {
                for(int col = 0; col < Columns ; col++)
                {
                    availableIDs.Add($"{row} {col}");
                }
            }

            return availableIDs;
        }

        private void PopulateSlotList(List<string> ids)
        {
            for (int i = 0; i < _productsList.Count; i++)
            {
                SlotModel slot = new SlotModel(_productsList.ElementAt(i), ids[i]);
                SlotList.Add(slot);
            }
        }        
    }
}
