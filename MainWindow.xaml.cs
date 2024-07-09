using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VirtualVendingMachine.ViewModels;

namespace VirtualVendingMachine
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            MainViewModel main = (MainViewModel)DataContext;

            switch (e.Key)
            {
                case System.Windows.Input.Key.Enter:
                    main.KeyPadViewModel.AcceptInputCommand.Execute(null);
                    break;

                case System.Windows.Input.Key.Escape:
                    main.KeyPadViewModel.DeleteInputCommand.Execute(null);
                    break;

                default:
                    main.KeyPadViewModel.KeyBoardNumberInputCommand.Execute(e.Key);
                    break;
            }
        }
    }
}