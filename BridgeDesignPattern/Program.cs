using System;

namespace BridgeDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            RefineAbstraction refineAbstractionA = new RefineAbstraction(new ConcreteImplementorA());
            refineAbstractionA.Operator();
            RefineAbstraction refineAbstractionB = new RefineAbstraction(new ConcreteImplementorB());
            refineAbstractionB.Operator();
        }
    }
    interface IImplementor
    {
        void OperationImp();
    }

    class ConcreteImplementorA : IImplementor
    {
        public void OperationImp()
        {
            Console.WriteLine("OperationImp Of Concrete AAAAAA");
        }
    }
    class ConcreteImplementorB : IImplementor
    {
        public void OperationImp()
        {
            Console.WriteLine("OperationImp Of Concrete BBBBBB");
        }
    }

    class Abstraction {
        IImplementor implementor;
        public Abstraction(IImplementor implementor)
        {
            this.implementor = implementor;
        }

        public void Operator() {
            implementor.OperationImp();
        }
    }

    class RefineAbstraction : Abstraction
    {
        public RefineAbstraction(IImplementor implementor) : base(implementor)
        {
        }
    }
}
