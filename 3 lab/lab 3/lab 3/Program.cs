using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_3
{
    public class Program
    {
        static void Main(string[] args)
        {

            Invoker generals = new Invoker();
            Receiver humans = new Receiver();
            generals.SetCommand(new HumanCommand(humans));

            Army army = new Army(100, "Archel", new attack());

            army.Move();


            GameHistory game = new GameHistory();

            while (true)
            {
                var x = Console.ReadKey();
                if (x.Key.ToString() == "UpArrow")
                {
                    humans.Run();
                }
                if (x.Key.ToString() == "DownArrow")
                {
                    humans.Lie();
                }
                if (x.Key.ToString() == "W")
                {
                    game.History.Push(humans.SaveState());
                }
                if (x.Key.ToString() == "S")
                {
                    humans.RestoreState(game.History.Pop());
                }
                if (x.Key.ToString() == "RightArrow")
                {
                    army.Movable = new attack();
                    army.Move();
                }
                if (x.Key.ToString() == "LeftArrow")
                {
                    army.Movable = new retreat();
                    army.Move();
                }


            }


        }
    }






}
