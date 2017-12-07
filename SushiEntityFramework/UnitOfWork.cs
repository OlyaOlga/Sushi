using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SushiEntityFramework
{
    public class UnitOfWork:IDisposable
    {
        private SushiContext context = new SushiContext();
        private SushiRepositoriy sushiRepository;
        private OrderRepository orderRepository;

        public SushiRepositoriy SushiRepositoriy
        {
            get { return this.sushiRepository ?? new SushiRepositoriy(context); }
        }

        public OrderRepository OrderRepository
        {
            get { return this.orderRepository ?? new OrderRepository(context); }
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
