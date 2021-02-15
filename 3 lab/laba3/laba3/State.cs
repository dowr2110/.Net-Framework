using System;
using System.Collections.Generic;
using System.Text;

namespace laba3
{


    interface IState
    {
        void Run(Heroes water);
        void Lie(Heroes water);
    }

    class SolidState : IState
    {
        public void Run(Heroes water)
        {
            Console.WriteLine("Бежим");
            water.State = new RunState();
        }

        public void Lie(Heroes water)
        {
            Console.WriteLine("Начинает ложиться");
        }
    }
    class RunState : IState
    {
        public void Run(Heroes water)
        {
            Console.WriteLine("Лежим");
            water.State = new RunState();
        }

        public void Lie(Heroes water)
        {
            Console.WriteLine("Встаём");
            water.State = new SolidState();
        }
    }

}
