using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_3
{ //Commander
    abstract class ICommand
    {
       public abstract void Execute();
        public abstract void Undo();
    }

     class HumanCommand : ICommand
    {
        Receiver humann;
        public HumanCommand(Receiver humannn)
        {
            humann = humannn;
        }
        public override void Execute()
        {
            humann.Run();
        }
        public override void Undo()
        {
            humann.Lie();
        }
    }
    // Receiver (получатель)получатель команды. Определяет действия, которые должны выполняться в результате запроса.
    class Receiver
    {
        public IState State { get; set; }

        string run = "человек бежит";
        string lie = "человек лежит";
        public void Run()
        {
            Console.WriteLine(run);
        }
        public void Lie()
        {
            Console.WriteLine(lie);
        }

        public HumanMemento SaveState()
        {
            Console.WriteLine("Сохранение . Параметры: {0} ,{1} ", run, lie);
            return new HumanMemento(run, lie);
        }
        public void RestoreState(HumanMemento memento)
        {
            this.run = memento.lie;
            this.run = memento.lie;
            Console.WriteLine("Восстановление игры. Параметры: {0} {1} ", run, lie);
        }

    }

    // Invoker - инициатор инициатор команды - вызывает команду для выполнения определенного запроса
    class Invoker
    {
        ICommand command;
        public Invoker()
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
     class HumanMemento
    {
        public string run { get; private set; }
        public string lie { get; private set; }

        public HumanMemento(string m, string energy)
        {
            this.run = m;
            this.lie = energy;
        }
    }

     class GameHistory
    {
        public Stack<HumanMemento> History { get; set; }

        public GameHistory()
        {
            History = new Stack<HumanMemento>();
        }
    }


    /*ICommand: интерфейс, представляющий команду.
     * Обычно определяет метод Execute() для выполнения действия,
     * а также нередко включает метод Undo(), 
     * реализация которого должна заключаться в отмене действия команды


    HumanCommand: конкретная реализация команды, реализует метод Execute(),
    в котором вызывается определенный метод, определенный в классе Receiver

    Receiver: получатель команды. Определяет действия, которые должны выполняться в результате запроса.

    Invoker: инициатор команды - вызывает команду для выполнения определенного запроса

    Client: клиент - создает команду и устанавливает ее получателя с помощью метода SetCommand()*/

}
