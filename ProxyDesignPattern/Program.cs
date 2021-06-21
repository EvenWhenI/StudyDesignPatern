using System;

namespace ProxyDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ISubject client = new Proxy();
            client.request();
        }
    }

    interface ISubject {
        void request();
    }


    class RealSubject : ISubject {
        public void request() {
            Console.WriteLine("Hello from Real Subject");
        }
    }

    class Proxy : ISubject
    {
        private readonly RealSubject _realSubject;

        public Proxy()
        {
            _realSubject = new RealSubject();
        }
        
        public void request()
        {
            Console.WriteLine("Your request through Proxy before call real SubJect");
            _realSubject.request();
        }
    }
}

