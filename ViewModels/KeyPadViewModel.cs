using System.ComponentModel;
using System.Windows.Input;
using VirtualVendingMachine.Custom_EventArgs;
using VirtualVendingMachine.Models;
using VirtualVendingMachine.Utils;

namespace VirtualVendingMachine.ViewModels
{
    public class KeyPadViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        readonly int _requiredPressedKeyCount = 2;

        public readonly string ErrorMessage = "ERROR";

        public List<KeyModel> KeysList { get; set; }
        public KeyModel AcceptKey { get; set; }
        public KeyModel DeleteKey { get; set; }

        public List<KeyModel> EnteredKeys { get; set; }

        private bool _IsErrorState;
        public bool IsErrorState
        {
            get => _IsErrorState;
            set
            {
                _IsErrorState = value;
                OnPropertyChanged(nameof(IsErrorState));
            }
        }

        private bool _IsDeleteButtonEnabled;
        public bool IsDeleteButtonEnabled
        {
            get
            {
                _IsDeleteButtonEnabled = EnteredKeys.Any();
                return _IsDeleteButtonEnabled;
            }
            set
            {
                _IsDeleteButtonEnabled = value;
                OnPropertyChanged(nameof(IsDeleteButtonEnabled));
            }
        }

        public bool IsKeyPadEnabled = true;

        private bool _IsAcceptButtonEnabled;
        public bool IsAcceptButtonEnabled
        {
            get => _IsAcceptButtonEnabled;
            set
            {
                _IsAcceptButtonEnabled = value;
                OnPropertyChanged(nameof(IsAcceptButtonEnabled));
            }
        }

        public ICommand SelectNumberCommand { get; }
        public ICommand AcceptInputCommand { get; }
        public ICommand DeleteInputCommand { get; }
        public ICommand KeyBoardNumberInputCommand { get; }

        public delegate void AcceptButtonPressedEventHandler(object sender, KeyPadSelectionEventArgs e);
        public event AcceptButtonPressedEventHandler AcceptButtonPressed;

        private string _KeyPadDisplayText;
        public string KeyPadDisplayText
        {
            get => _KeyPadDisplayText;
            set
            {
                _KeyPadDisplayText = value;
                OnPropertyChanged(nameof(KeyPadDisplayText));
                OnPropertyChanged(nameof(IsDeleteButtonEnabled));
            }
        }

        public KeyPadViewModel()
        {
            AcceptKey = new KeyModel("#");
            DeleteKey = new KeyModel("?");
            EnteredKeys = new List<KeyModel>();
            SelectNumberCommand = new RelayCommand<KeyModel>(SelectNumber, CanSelectNumber);
            AcceptInputCommand = new RelayCommand<KeyModel>(AcceptInput, CanAcceptInput);
            DeleteInputCommand = new RelayCommand<KeyModel>(ClearEnteredKeys, CanClearEnteredKeys);
            KeyBoardNumberInputCommand = new RelayCommand<System.Windows.Input.Key>(KeyboardNumberInput);
            CommandManager.InvalidateRequerySuggested();
            PopulateNumericalButtons();
        }

        private void PopulateNumericalButtons()
        {
            KeysList = new List<KeyModel>();

            for (int i = 0; i < 9; i++)
            {
                KeysList.Add(new KeyModel(i));
            }
        }

        private bool CanClearEnteredKeys(KeyModel? key)
        {
            return IsDeleteButtonEnabled;
        }

        public void ClearEnteredKeys(KeyModel? key)
        {
            EnteredKeys.Clear();
            KeyPadDisplayText = string.Empty;
            IsKeyPadEnabled = true;
            IsErrorState = false;
        }

        private bool CanAcceptInput(KeyModel? key)
        {
            if (EnteredKeys.Count == _requiredPressedKeyCount && IsKeyPadEnabled)
            {
                IsAcceptButtonEnabled = true;
                return true;
            }
            else
            {
                IsAcceptButtonEnabled = false;
                return false;
            }
        }

        private void AcceptInput(KeyModel? key)
        {
            AcceptButtonPressed?.Invoke(this, new KeyPadSelectionEventArgs { Entries = EnteredKeys });
        }

        private bool CanSelectNumber(KeyModel? key)
        {
            return EnteredKeys.Count < _requiredPressedKeyCount && IsKeyPadEnabled;
        }

        private void SelectNumber(KeyModel? key)
        {
            if (CanSelectNumber(key))
            {
                EnteredKeys.Add(key);
                KeyPadDisplayText = string.Join(" ", EnteredKeys.Select(k => k.Entry));
            }
        }

        public void KeyboardNumberInput(System.Windows.Input.Key key)
        {
            switch (key)
            {
                case System.Windows.Input.Key.NumPad0:
                case System.Windows.Input.Key.D0:
                    SelectNumber(new KeyModel(0));
                    break;

                case System.Windows.Input.Key.NumPad1:
                case System.Windows.Input.Key.D1:
                    SelectNumber(new KeyModel(1));
                    break;

                case System.Windows.Input.Key.NumPad2:
                case System.Windows.Input.Key.D2:
                    SelectNumber(new KeyModel(2));
                    break;

                case System.Windows.Input.Key.NumPad3:
                case System.Windows.Input.Key.D3:
                    SelectNumber(new KeyModel(3));
                    break;

                case System.Windows.Input.Key.NumPad4:
                case System.Windows.Input.Key.D4:
                    SelectNumber(new KeyModel(4));
                    break;

                case System.Windows.Input.Key.NumPad5:
                case System.Windows.Input.Key.D5:
                    SelectNumber(new KeyModel(5));
                    break;

                case System.Windows.Input.Key.NumPad6:
                case System.Windows.Input.Key.D6:
                    SelectNumber(new KeyModel(6));
                    break;

                case System.Windows.Input.Key.NumPad7:
                case System.Windows.Input.Key.D7:
                    SelectNumber(new KeyModel(7));
                    break;

                case System.Windows.Input.Key.NumPad8:
                case System.Windows.Input.Key.D8:
                    SelectNumber(new KeyModel(8));
                    break;
            }
        }
    }
}
