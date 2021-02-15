using System;
using System.Collections.Generic;
using System.Text;

namespace laba3
{
    interface IMovable
    {
        void Move();
    }

    class attack : IMovable
    {
        public void Move()
        {
            Console.WriteLine("Атака!!!");
        }
    }

    class retreat : IMovable
    {

        public void Move()
        {
            Console.WriteLine("Отступление");
        }
    }
    class Army
    {

        protected int Heroes;
        protected string Name;

        public Army(int num, string model, IMovable mov)
        {
            this.Heroes = num;
            this.Name = model;
            Movable = mov;
        }
        public IMovable Movable {  get; set; }

       

        public void Move()
        {
            Movable.Move();
        }
    }
}
