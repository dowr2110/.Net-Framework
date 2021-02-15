using System;
using System.Collections.Generic;

namespace laba3
{
    class Program
    {
        static void Main(string[] args)
        {
     
            Generals generals = new Generals();
            Heroes heroes = new Heroes();
            generals.SetCommand(new HeroesonCommand(heroes));
         
            Army army = new Army(100, "Archel", new attack());           
             
            army.Move();
         

            GameHistory game = new GameHistory();
            
            while (true)
            {
                var x = Console.ReadKey();
                if (x.Key.ToString() == "UpArrow")
                {
                    heroes.Run();
                }
                if (x.Key.ToString() == "DownArrow")
                {
                    heroes.Lie();
                }
                if (x.Key.ToString() == "W")
                {
                    game.History.Push(heroes.SaveState());
                }
                if (x.Key.ToString() == "S")
                {
                   heroes.RestoreState(game.History.Pop());
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
