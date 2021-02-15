using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_3
{


      abstract  class  IMovable
    {
        public abstract  void Move();
    }

     class attack : IMovable
    {
        public override void Move()
        {
            Console.WriteLine("Атака!!!");
        }
    }

    /*Классы attack и retreat, которые реализуют интерфейс IMovable,
    предоставляя свою версию метода Move(). Подобных классов-реализаций может быть множество.*/
     class retreat : IMovable
    {

        public override void Move()
        {
            Console.WriteLine("Отступление");
        }
    }
     class Army// Класс Army хранит ссылку на объект IMovable и связан с интерфейсом IMovable отношением агрегации.
    {
        protected int Humans;
        protected string Name;
        public IMovable Movable { get; set; }

        public Army(int num, string model, IMovable mov)
        {
            this.Humans = num;
            this.Name = model;
            Movable = mov;
        }


        public void Move()
        {
            Movable.Move();
        }
    }


    /*Интерфейс IMovable, который определяет метод Move(). 
     * Это общий интерфейс для всех реализующих его алгоритмов. 
     * Вместо интерфейса здесь также можно было бы использовать абстрактный класс.


    Классы attack и retreat, которые реализуют интерфейс IMovable,
    предоставляя свою версию метода Move(). Подобных классов-реализаций может быть множество.

    Класс Army хранит ссылку на объект IMovable и связан с интерфейсом IMovable отношением агрегации.*/

}
