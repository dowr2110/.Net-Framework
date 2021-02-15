using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_1
{
    interface IFigure
    {
        IFigure Clone();
        void GetInfo();
    }

    class Humans : IFigure
    {
        
        string Name;
        public Humans( string c)
        {
            Name = c;
        }

        public IFigure Clone()
        {
            return new Humans(this.Name);
        }
        public void GetInfo()
        {
            Console.WriteLine($"Клон, имя: {Name} ");
        }
    }
}
