using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_3
{
    abstract class IState
    {
        public abstract void Run(Receiver water);
        public abstract  void Lie(Receiver water);
    }

     class HumanState : IState
    {
        public override void Run(Receiver water)
        {
            Console.WriteLine("Бежим");
            water.State = new RunState();
        }

        public override void Lie(Receiver water)
        {
            Console.WriteLine("Начинает ложиться");
        }
    }
     class RunState : IState
    {
        public override void Run(Receiver water)
        {
            Console.WriteLine("Лежим");
            water.State = new RunState();
        }

        public override void Lie(Receiver water)
        {
            Console.WriteLine("Встаём");
            water.State = new HumanState();
        }
    }


    /*IState: определяет интерфейс состояния

    Классы HumanState и RunState - конкретные реализации состояний








    Context: представляет объект, поведение которого должно динамически изменяться в соответствии с состоянием. 
    Выполнение же конкретных действий делегируется объекту состояния*/


}
