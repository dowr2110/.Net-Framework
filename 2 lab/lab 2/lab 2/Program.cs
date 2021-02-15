using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2
{

    
    class Program
    {
        static void Main(string[] args)
        {
            // Человек
            Human human = new Human();
            // Велосипед
            Velosiped velosiped = new Velosiped();
            // отправляемся
            human.Go(velosiped);
            // встретили хорошую дорогу, надо использовать ролики
            Roliki roliki = new Roliki();
            // используем адаптер
            ITransport rolikiTransport = new Adapter(roliki);
            // продолжаем путь по хорошей дороге
            human.Go(rolikiTransport);


            Console.WriteLine();
            Hleb hleb1 = new TurkmenHleb();
            hleb1 = new CernyyHleb(hleb1);  
            Console.WriteLine("Название: {0}", hleb1.Name);
            Console.WriteLine("Цена: {0}", hleb1.GetCost());

            Hleb hleb2 = new TurkmenHleb();
            hleb2 = new ZernovoyHleb(hleb2);
            Console.WriteLine("Название: {0}", hleb2.Name);
            Console.WriteLine("Цена: {0}", hleb2.GetCost());
            Hleb hleb3 = new BelarusHleb();
            hleb3 = new NarezannyyHleb(hleb3);
            hleb3 = new HlebSMasloy(hleb3); 
            Console.WriteLine("Название: {0}", hleb3.Name);
            Console.WriteLine("Цена: {0}", hleb3.GetCost());

            Console.WriteLine();
            var district = new Map { Title = "District" };
            district.AddComponent(new MapComponent { Title = "Move1" });
            district.AddComponent(new MapComponent { Title = "Move2" });
            district.AddComponent(new MapComponent { Title = "Move3" });
            var city = new Map { Title = "New object" };
            city.AddComponent(district);
            city.Draw();
            var house = city.Find("Move1");
            house.Draw();


        }
    }

    /// <summary>
    /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>
    interface ITransport
    {
        void Ride();
    }

    class Velosiped : ITransport
    {
        public void Ride()
        {
            Console.WriteLine("человек едет на велосипеде по плохой дороге");
        }
    }
    class Human
    {
        public void Go(ITransport transport)
        {
            transport.Ride();
        }
    }

    interface IRun
    {
        void Rollerblading();
    }

    class Roliki : IRun
    {
        public void Rollerblading()
        {
            Console.WriteLine("Человек катается на роликах по хорошей дороге");
        }
    }
    // Адаптер от Roliki к ITransport
    class Adapter : ITransport
    {
        Roliki roliki;
        public Adapter(Roliki c)
        {
            roliki = c;
        }

        public void Ride()
        {
            roliki.Rollerblading();
        }
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



    abstract class Hleb
    {
        public Hleb(string n)
        {
            this.Name = n;
        }
        public string Name { get; set; }
        public abstract int GetCost();
    }

    class TurkmenHleb : Hleb
    {
        public TurkmenHleb() : base("Туркменский чурек")
        { }
        public override int GetCost()
        {
            return 10;
        }
    }
    class BelarusHleb : Hleb
    {
        public BelarusHleb()
            : base("Белорусский хлеб")
        { }
        public override int GetCost()
        {
            return 8;
        }
    }

    abstract class Decorator : Hleb
    {
        public Hleb hleb;
        public Decorator(string n, Hleb hl) : base(n)
        {
            this.hleb = hl;
        }
    }

    class HlebSMasloy : Decorator
    {
        public HlebSMasloy(Hleb p)
            : base(p.Name + ", с маслой", p)
        { }

        public override int GetCost()
        {
            return hleb.GetCost() + 3;
        }
    }

    class CernyyHleb : Decorator
    {
        public CernyyHleb(Hleb p)
            : base(p.Name + ", черный", p)
        { }

        public override int GetCost()
        {
            return hleb.GetCost() + 5;
        }
    }
    class NarezannyyHleb : Decorator
    {
        public NarezannyyHleb(Hleb p)
            : base(p.Name + ",  уже нарезанный", p)
        { }

        public override int GetCost()
        {
            return hleb.GetCost() + 5;
        }
    }
    class ZernovoyHleb : Decorator
    {
        public ZernovoyHleb(Hleb p)
            : base(p.Name + ", с зернами", p)
        { }

        public override int GetCost()
        {
            return hleb.GetCost() + 5;
        }
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public interface IComponent
    {
        string Title { get; set; }
        void Draw();
        IComponent Find(string title);
    }
    public class MapComponent : IComponent
    {
        public string Title { get; set; }
        public void Draw()
        {
            Console.WriteLine(Title);
        }
        public IComponent Find(string title)
        {
            return Title == title ? this : null;
        }
    }
    public class Map : IComponent
    {
        private readonly List<IComponent> _map = new List<IComponent>();
        public string Title { get; set; }
        public void AddComponent(IComponent component)
        {
            _map.Add(component);
        }
        public void Draw()
        {
            Console.WriteLine(Title);
            foreach (var component in _map)
            {
                component.Draw();
            }
        }
        public IComponent Find(string title)
        {
            if (Title == title)
            {
                return this;
            }
            foreach (var component in _map)
            {
                var found = component.Find(title);
                if (found != null)
                {
                    return found;
                }
            }
            return null;
        }
    }

}