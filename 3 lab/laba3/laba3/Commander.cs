using System;
using System.Collections.Generic;
using System.Text;

namespace laba3
{
    //Commander
    interface ICommand
    {
        void Execute();
        void Undo();
    }
    // Receiver (получатель)
    class Heroes    
    {
        public IState State { get; set; }




        string run = "Солдат бежит";
        string lie = "Солат лежит";
        public void Run()
        {
            Console.WriteLine(run);
        }
        public void Lie()
        {
            Console.WriteLine(lie);
        }
        public void Runner()
        {
            if (run == "бежит")
            {


                Console.WriteLine("Солдат сейчас {0}", run);
            }
            else
                Console.WriteLine("Солдат сейчас {0}", lie);

        }
        public HeroMemento SaveState()
        {
            Console.WriteLine("Сохранение игры. Параметры: {0} ,{1} ", run, lie);
            return new HeroMemento(run, lie);
        }
        public void RestoreState(HeroMemento memento)
        {
            this.run = memento.lie;
            this.run = memento.lie;
            Console.WriteLine("Восстановление игры. Параметры: {0} {1} ", run, lie);
        }

    }

    class HeroesonCommand : ICommand
    {
        Heroes heroes;
        public HeroesonCommand(Heroes heroess)
        {
            heroes = heroess;
        }
        public void Execute()
        {
            heroes.Run();
        }
        public void Undo()
        {
            heroes.Lie();
        }
    }
    // Invoker - инициатор
    class Generals
    {
        ICommand command;
        public Generals()
        { }
        public void SetCommand(ICommand com)
        {
            command = com;
        }
        public void PressShift()
        {
            if (command != null)
                command.Execute();
        }
        public void PressDown()
        {
            if (command != null)
                command.Undo();
        }
    }

    //Memento
        class HeroMemento
    {
        public string run { get; private set; }
        public string lie { get; private set; }    

        public HeroMemento(string m, string energy)
        {
            this.run = m;
            this.lie = energy;
        }
    }
    class GameHistory
    {
        public Stack<HeroMemento> History { get; private set; }

        public GameHistory()
        {
            History = new Stack<HeroMemento>();
        }
    }
}
