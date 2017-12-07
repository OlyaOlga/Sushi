using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SushiEntityFramework
{
    public interface ISushiRepository :
        IDisposable
    {
        IEnumerable<SushiItem> GetSushiItems();
        SushiItem GetSushiByName(string name);
        void InsertSushiItem(SushiItem sushiName);
        void DeleteSushiItem(string sushiName);
        void UpdateSushiItem(SushiItem item);
        void Save();
    }
    public class SushiRepositoriy:
        ISushiRepository
    {
        private SushiContext context;

        public SushiRepositoriy(SushiContext paramContext)
        {
            context = paramContext;
        }
        public IEnumerable<SushiItem> GetSushiItems()
        {
           return context.Menu.ToList();
        }

        public SushiItem GetSushiByName(string name)
        {
            return context.Menu.Find(name);
        }

        public void InsertSushiItem(SushiItem sushiName)
        {
            context.Menu.Add(sushiName);
        }

        public void DeleteSushiItem(string sushiName)
        {
            SushiItem sushi = context.Menu.Find(sushiName);
            context.Menu.Remove(sushi);
        }

        public void UpdateSushiItem(SushiItem item)
        {
            context.Entry(item).State = EntityState.Modified;
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
