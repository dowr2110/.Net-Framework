using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_1
{
    public sealed class President
    {
        public static President instance;

        public string Name { get; }
        
        public President()
        {
            this.Name = "Putin";
        }

        public static President getInstance()
        {
            if (instance == null)
                instance = new President();
            return instance;
        }
        public void GetInfo()
        {
            Console.WriteLine("Это Президент!!!");
            Console.WriteLine($"Имя: {Name}");
        }
    }
}
