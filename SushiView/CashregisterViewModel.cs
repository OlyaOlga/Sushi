using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SushiEntityFramework;

namespace SushiView
{

    public class CashRegisterViewModel :
    INotifyPropertyChanged
    {
        private CashRegisterModel cashRegister;
        private List<SushiItem> menuList;
        private ObservableCollection<Order> currentOrder;
        private CashRegister cashRegisterWindow;
        public CashRegisterViewModel(CashRegister cashRegistertWin, CashRegisterModel paramCashRegisterModel)
        {
            cashRegisterWindow = cashRegistertWin;
            CashRegister = paramCashRegisterModel;
            MenuList = CashRegister.ReadMenu();
            CurrentOrder = new ObservableCollection<Order>();
            AddOrderItemCommand = new RelayCommand(AddOrderItem, CanMakeOrder);
            CancelAllCommand = new RelayCommand(CancelAll);
            SaveAllCommand = new RelayCommand(SaveAll);
        }

        public List<SushiItem> MenuList
        {
            get { return menuList; }
            set
            {
                menuList = value;
                OnPropertyChanged(nameof(MenuList));
            }
        }

        public ObservableCollection<Order> CurrentOrder
        {
            get
            {
                return currentOrder;
            }
            set
            {
                currentOrder = value;
                OnPropertyChanged(nameof(CurrentOrder));
            }
        }

        public CashRegisterModel CashRegister
        {
            get { return cashRegister; }
            set
            {
                cashRegister = value;
                OnPropertyChanged(nameof(CashRegister));
            }
        }

        public ICommand AddOrderItemCommand { get; set; }
        public ICommand SaveAllCommand { get; set; }
        public ICommand CancelAllCommand { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void AddOrderItem(object parameter)
        {
            int index = (int)parameter;
            CurrentOrder.Add(new Order() { SushiName = MenuList[index].Name,  SushiPrice = MenuList[index].Price});
            OnPropertyChanged(nameof(CurrentOrder));
        }
        private bool CanMakeOrder(object parameter)
        {
            if (parameter == null)
            {
                return false;
            }
            int index = (int)parameter;
            return (index != -1);
        }

        private void CancelAll(object parameter)
        {
            cashRegisterWindow.Close();
        }

        private void SaveAll(object parameter)
        {
            cashRegister.AddListOfItems(CurrentOrder.ToList());
            cashRegisterWindow.Close();
        }
    }
}
