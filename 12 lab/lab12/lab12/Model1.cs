using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab12
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    public class Model1 : DbContext
    {
        public Model1() : base("name=Model1") { }
        public DbSet<MyEntity> MyEntities { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
    public class MyEntity
    {
        public MyEntity()
        {
            Orders = new List<Order>();
        } 
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set;}
        public virtual ICollection<Order> Orders { get; set; }
    }
    public class Order
    { 
        [Key]
        public int OrderId { get; set; }  
        [Required]
        [ForeignKey("User")]
        public virtual int UserId { get; set; }
        public virtual MyEntity User { get; set; } 
        [Required]
        public double Amount { get; set; }
        [Required]
        public string Text { get; set; }
    }

}
