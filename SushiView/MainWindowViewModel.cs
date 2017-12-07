using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SushiEntityFramework;
using SushiEntityFramework.Annotations;

namespace SushiView
{
    public class MainWindowViewModel:
    INotifyPropertyChanged
    {
        private MainWindow mainWindow;
        private CashRegisterModel cashRegisterModel;
        private double totalSum;
        public MainWindowViewModel(MainWindow paramMainWindow)
        {
            mainWindow = paramMainWindow;
            cashRegisterModel = new CashRegisterModel();
            OpenInputWindowCommand = new RelayCommand(OpenInputWindow);
            TotalSum = cashRegisterModel.CountTotalSum();
        }

        private CashRegisterViewModel cashRegisterViewModel;

        public double TotalSum
        {
            get
            {
                return totalSum;
            }
            set
            {
                totalSum = value;
                OnPropertyChanged(nameof(TotalSum));
            }
        }

        public ICommand OpenInputWindowCommand { get; set; }

        private void OpenInputWindow(object parameter)
        {
            CashRegister cashRegister = new CashRegister();
            CashRegisterViewModel crvm = new CashRegisterViewModel(cashRegister, cashRegisterModel);
            cashRegister.DataContext = crvm;
            cashRegister.ShowDialog();
            TotalSum = cashRegisterModel.CountTotalSum();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
