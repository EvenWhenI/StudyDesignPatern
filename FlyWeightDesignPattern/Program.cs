using System;
using System.Collections.Generic;

namespace FlyWeightDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var factory = new FlyweightFactory();
            factory.GetFlyweight(1).Operation();
            factory.GetFlyweight(2).Operation();
        }
    }

    class Flyweight {
        public virtual void Operation() {
            Console.WriteLine("Default Flyweight");
        }
    }
    class UnSharedFlyweight : Flyweight { }
    class ConcreteFlyweight : Flyweight {
        public override void Operation()
        {
            Console.WriteLine("ConcreteFlyweight");

        }
    }
    class ConcreteOtherFlyweight : Flyweight
    {
        public override void Operation()
        {
            Console.WriteLine("ConcreteOtherFlyweight ====D");

        }
    }

    class FlyweightFactory
    {
        //creates and manages flyweight objects
        Dictionary<int, Flyweight> flyWeights = new Dictionary<int, Flyweight>();
        public FlyweightFactory()
        {
            DoFactory();
        }

        void DoFactory() {
            flyWeights.Add(1, new ConcreteFlyweight());
            flyWeights.Add(2, new ConcreteOtherFlyweight());
        }

        public Flyweight GetFlyweight(int key)
        {
            if (flyWeights.ContainsKey(key)) {
                return flyWeights[key];
            }
            return null;
        }
    }
}
