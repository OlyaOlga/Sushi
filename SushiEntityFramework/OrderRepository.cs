using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SushiEntityFramework
{
    public interface IOrderRepository :
        IDisposable
    {
        IEnumerable<Order> GetOrders();
        Order GetOrderById(int id);
        void InsertOrder(Order order);
        void DeleteOrder(int id);
        void UpdateOrder(Order order);
        void Save();
    }
    public class OrderRepository:
        IOrderRepository
    {
        private SushiContext context;

        public OrderRepository(SushiContext paramContext)
        {
            context = paramContext;
        }
        public IEnumerable<Order> GetOrders()
        {
            return context.Orders.ToList();
        }

        public Order GetOrderById(int id)
        {
            return context.Orders.Find(id);
        }

        public void InsertOrder(Order order)
        {
            context.Orders.Add(order);
        }

        public void DeleteOrder(int id)
        {
            Order order = context.Orders.Find(id);
            context.Orders.Remove(order);
        }

        public void UpdateOrder(Order order)
        {
            context.Entry(order).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
