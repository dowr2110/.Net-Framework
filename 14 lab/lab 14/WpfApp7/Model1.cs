using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WpfApp7
{
    using System.Data.Entity;
    public class Model1 : DbContext
    {
        public Model1() : base("name=Model1") { } 
        public DbSet<Distiplina> Dists { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
    
  
    public class Order
    { 
        [Key]
        public int OrderId { get; set; }
        public string StdudentName { get; set; }
        public string StdudentFamilyName { get; set; }
        public string Email { get; set; }
        public DateTime When { get; set; }
        [ForeignKey("Distiplina")]
        public virtual int DistiplinaId { get; set; }//////// 
        public virtual Distiplina Distiplina { get; set; }/////// 
   
    }
    public class Distiplina
    {
        [Key]
        public int DistiplinaId { get; set; } 
        public double Hours { get; set; } 
        public string Name { get; set; }
        public string TeacherName { get; set; } 
        public double Left { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
