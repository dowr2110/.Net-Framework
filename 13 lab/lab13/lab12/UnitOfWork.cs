using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab12
{
    public class UnitOfWork : IDisposable
    {
        private Model1 db = new Model1();
        private MyEntityRepository bookRepository;
        private OrdersRepository orderRepository;

        public MyEntityRepository MyEntities
        {
            get
            {
                if (bookRepository == null)
                    bookRepository = new MyEntityRepository(db);
                return bookRepository;
            }
        }

        public OrdersRepository Orders
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new OrdersRepository(db);
                return orderRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
