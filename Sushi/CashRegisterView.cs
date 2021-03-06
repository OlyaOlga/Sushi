﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ConsoleSushi;

namespace Sushi
{
    public class CashRegisterView
    {
        public CashRegister cashRegister { get; set; }

        public MainWindow mainWindow { get; set; }

        public OrderSushi orderSushi { get; set; }

        public CashRegisterView()
        {
            cashRegister = new CashRegister();
            MenuChangeItemPriceCommand = new MenuCommand(this, new Action<int>(ChangeMenuItemPrice));
            MenuItemDeleteCommand = new MenuCommand(this, RemoveMenuItem);
            MovePriceCommand = new MenuCommand(this, MoveEnteredPrice);
            CancelEnteringPriceCommand = new MenuCommand(this, CancelEnteringPrice);
            DoOrderCommand = new MenuCommand(this, AddCurrentItemToOrder);
            DeleteCurrentOrderItemCommand = new MenuCommand(this, DeleteCurrentOrderItem);
            ChangeOrderCommand = new MenuCommand(this, ChangeCurrentOrder);
            SaveAllCommand = new MyInputWindowCommand(SaveAll);
            CancelAllCommand = new MyInputWindowCommand(CancelAll);
        }

        public ICommand MenuChangeItemPriceCommand { get; }

        public ICommand MenuItemDeleteCommand { get; }

        public ICommand MovePriceCommand { get; }

        public ICommand CancelEnteringPriceCommand { get;}

        public ICommand DoOrderCommand { get; }

        public ICommand ChangeOrderCommand { get; }

        public ICommand DeleteCurrentOrderItemCommand { get; }

        public ICommand SaveAllCommand { get; }

        public ICommand CancelAllCommand { get; }
    
        public void RemoveMenuItem(int index)
        {
            cashRegister.Menu.RemoveItem(cashRegister.Menu.AllPossibleItems[index]);
        }

        public void ChangeMenuItemPrice(int index)
        {
            orderSushi.EnteredValueStackPannel.Visibility = Visibility.Visible;
        }

        public void MoveEnteredPrice(int index)
        {
            double newPrice;
            if (double.TryParse(orderSushi.EnteredValueTextBox.Text, out newPrice))
            {
                orderSushi.listView.SelectedIndex = -1;
                cashRegister.Menu.AllPossibleItems[index].ChangePrice(newPrice);
                orderSushi.EnteredValueStackPannel.Visibility = Visibility.Hidden;
            }
            orderSushi.EnteredValueTextBox.Text = string.Empty;
        }

        public void CancelEnteringPrice(int index)
        {
            orderSushi.listView.SelectedIndex = -1;
            orderSushi.EnteredValueTextBox.Text = string.Empty;
            orderSushi.EnteredValueStackPannel.Visibility = Visibility.Hidden;
        }

        public void AddCurrentItemToOrder(int index)
        {
            InputValueWindow currInputWind = new InputValueWindow(this);
            currInputWind.ShowDialog();
            if (Q != null)
            {
                SushiItem itemToAdd = new SushiItem(cashRegister.Menu.AllPossibleItems[index].Name,
                cashRegister.Menu.AllPossibleItems[index].Price);
                cashRegister.CurrentSushiOrder.OrderSomething(itemToAdd,(uint)Q);
            }
        }

        public uint? Q { get; set; }//quantity

        public void DeleteCurrentOrderItem(int index)
        {
            cashRegister.CurrentSushiOrder.Order.Remove(cashRegister.CurrentSushiOrder.Order[index]);
            Console.WriteLine(index);
        }

        public void ChangeCurrentOrder(int index)
        {
            InputValueWindow currInputWind = new InputValueWindow(this);
            currInputWind.ShowDialog();
            if (Q != null)
            {
                cashRegister.CurrentSushiOrder.ChangeOrder(cashRegister.CurrentSushiOrder.Order[index], (uint)Q);
            }
        }

        public void SaveAll()
        {
            cashRegister.SaveData(cashRegister.CurrentSushiOrder);
            CancelAll();
        }

        public void CancelAll()
        {
            cashRegister.ClearData(cashRegister.CurrentSushiOrder);
            orderSushi.Close();
        }
    }
}
