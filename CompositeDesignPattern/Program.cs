using System;
using System.Collections.Generic;

namespace CompositeDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            IComponent root = new Composite("Root");
            Leaf firstLeaf = new Leaf("Leaf A");
            Leaf secondLeaf = new Leaf("Leaf B");
            

            root.Add(firstLeaf);
            root.Add(secondLeaf);

            IComponent branch = new Composite("Branch");
            Leaf thirdLeaf = new Leaf("Leaf C");
            Leaf fourthLeaf = new Leaf("Leaf D");
            branch.Add(thirdLeaf);
            branch.Add(fourthLeaf);

            root.Add(branch);

            root.Operation();
        }
    }
    interface IComponent
    {
        void Operation();
        void Add(IComponent component);
        void Remove(IComponent component);
        IComponent GetChild(int index);
    }

    class Composite : IComponent
    {
        private readonly string name;
        List<IComponent> listChild;
        public Composite(string name)
        {
            listChild = new List<IComponent>();
            this.name = name;
        }


        public void Add(IComponent component)
        {
            listChild.Add(component);
        }

        public IComponent GetChild(int index)
        {
            if (index < listChild.Count)
            {
                return listChild[index];
            }
            return null;
        }

        public void Operation()
        {
            Console.WriteLine("Start excute operation of childen of " + name);
            foreach (var child in listChild)
            {
                child.Operation();
            }
        }

        public void Remove(IComponent component)
        {
            if (listChild.Contains(component))
            {
                listChild.Remove(component);
            }
            else
            {

            }
        }
    }

    class Leaf : IComponent
    {
        private readonly string _name;

        public Leaf(string name)
        {
            this._name = name;
        }
        
        public void Add(IComponent component)
        {
            throw new NotImplementedException();
        }

        public IComponent GetChild(int index)
        {
            throw new NotImplementedException();
        }

        public void Operation()
        {
            Console.WriteLine("Excuted opreation of Leaf name: " + _name);
        }

        public void Remove(IComponent component)
        {
            throw new NotImplementedException();
        }
    }
}
