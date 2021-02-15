using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab12
{
    public class MyEntityRepository : IRepository<MyEntity>
    {
        private Model1 db;

        public MyEntityRepository(Model1 context)
        {
            this.db = context;
        }

        public IEnumerable<MyEntity> GetAll()
        {
            return db.MyEntities;
        }

        public MyEntity Get(int id)
        {
            return db.MyEntities.Find(id);
        }

        public void Create(MyEntity book)
        {
            db.MyEntities.Add(book);
        }

        public void Update(MyEntity book)
        {
            db.Entry(book).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            MyEntity book = db.MyEntities.Find(id);
            if (book != null)
                db.MyEntities.Remove(book);
        }
    }

    public class OrdersRepository : IRepository<Order>
    {
        private Model1 db;

        public OrdersRepository(Model1 context)
        {
            this.db = context;
        }

        public IEnumerable<Order> GetAll()
        {
            return db.Orders.Include(o => o.User);
        }

        public Order Get(int id)
        {
            return db.Orders.Find(id);
        }

        public void Create(Order order)
        {
            db.Orders.Add(order);
        }

        public void Update(Order order)
        {
            db.Entry(order).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Order order = db.Orders.Find(id);
            if (order != null)
                db.Orders.Remove(order);
        }
    }
}
