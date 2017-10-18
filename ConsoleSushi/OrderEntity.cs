using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ConsoleSushi.Annotations;

namespace ConsoleSushi
{
    public class OrderEntity<T> :
        INotifyPropertyChanged
        where T : IItem
    {
        private T _value;
        private uint _quantity;

        public T Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                OnPropertyChanged("Value");
            }
        }

        public uint Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                _quantity = value;
                OnPropertyChanged("Quantity");
            }
        }

        public OrderEntity()
        {
        }
        public OrderEntity(T value, uint quantity)
        {
            Value = value;
            Quantity = quantity;
        }

        public override string ToString()
        {
            return $"{Value}, quantity: {Quantity}";
        }

        public override bool Equals(object obj)
        {
            OrderEntity<T> incomeValue = obj as OrderEntity<T>;
            if (incomeValue == null)
            {
                return false;
            }
            return Value.Equals(incomeValue.Value)&&Quantity.Equals(incomeValue.Quantity);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}