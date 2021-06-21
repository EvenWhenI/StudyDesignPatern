using System;

namespace DecoratorDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            IComponent component = new ConcreteDecoratorB(new ConcreteComponent());
            component.Operation();
        }
    }

    interface IComponent
    {
        void Operation();
    }

    class ConcreteComponent : IComponent
    {
        public void Operation()
        {
            Console.WriteLine("Hello from Operation of ConcreteComponent");
        }
    }

    class Decorator : IComponent
    {
        private readonly IComponent component;

        public Decorator(IComponent component)
        {
            this.component = component;
        }

        public virtual void Operation()
        {
            component.Operation();
        }
    }

    class ConcreteDecoratorA : Decorator {

        public ConcreteDecoratorA(IComponent component): base(component)
        {
        }

        public int adddedState { get; set; }
    }

    class ConcreteDecoratorB : Decorator
    {

        public ConcreteDecoratorB(IComponent component) : base(component)
        {
        }

        public void AddedBehavior() {
            Console.WriteLine("Added Behavior");
        }

        public override void Operation()
        {
            base.Operation();
            AddedBehavior();
        }

    }

}
