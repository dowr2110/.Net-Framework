using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Factory fac = new GoodHumanFactory("Ilya");
            Human human = fac.Create();
            fac = new BadHumanFactory("Naibic");
            Human human2 = fac.Create();

            President president = new President();
            president.GetInfo();

            Builder builder = new ConcreteBuilder();
            Director director = new Director(builder);
            director.Construct();
            Product product = builder.GetResult();

            IFigure hum = new Humans("Dowr");
            IFigure clonedFigure = hum.Clone();

            hum.GetInfo();
            clonedFigure.GetInfo();

            Console.ReadLine();
        }
    
    
   
}
}
