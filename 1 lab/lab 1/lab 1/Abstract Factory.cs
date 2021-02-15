using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_1
{
    abstract class Factory
    {
        public string Name { get; set; }
       

        public Factory(string n)
        {
            Name = n;
        }
        abstract public Human Create();
    }


   
    class GoodHumanFactory : Factory
    {
        public GoodHumanFactory(string n) : base(n)
        { }
        
        
        public override Human Create()
        {
            return new GoodHuman();
        }
    }



    class BadHumanFactory: Factory
    {
        public BadHumanFactory(string n) : base(n)
        { }

        public override Human Create()
        {
            return new BadHuman();
        }
    }

    abstract class Human
    { }



    class GoodHuman : Human
    {
        public GoodHuman()
        {
            Console.WriteLine("хороший чеовек построен");
        }
    }
    class BadHuman : Human
    {
        public BadHuman()
        {
            Console.WriteLine("плохой чеовек построен");
        }
    }

}
