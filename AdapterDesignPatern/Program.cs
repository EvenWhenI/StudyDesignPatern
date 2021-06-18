using System;

namespace AdapterDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ICharge chargeIphone = new Adapter(InputType.Input110V, OutputType.Output5v);
            chargeIphone.Charge();

            ICharge chargeLaptop = new Adapter(InputType.Input220V, OutputType.Output12v);
            chargeLaptop.Charge();
        }
    }


    interface ICharge {
        void Config(InputType input, OutputType output);
        void Charge();
    }
    enum InputType {
        Input110V,
        Input220V
    }
    enum OutputType {
        Output5v,
        Output9V,
        Output12v
    }

    class Adapter : ICharge {
        Adaptee adaptee;

        public Adapter(InputType input, OutputType output)
        {
            adaptee = new Adaptee(input, output);
        }

        public void Config(InputType input, OutputType output)
        {
            adaptee = new Adaptee(input, output);
        }

        public void Charge() {
            adaptee.Charge();
        }
    }

    class Adaptee
    {
        InputAdaptee inputAdaptee;
        OutputAdaptee outputAdaptee;

        public Adaptee(InputType input, OutputType output)
        {
            inputAdaptee = new InputAdaptee(input);
            outputAdaptee = new OutputAdaptee(output);
        }
        public void Charge()
        {
            inputAdaptee.Input();
            outputAdaptee.Output();
            Console.WriteLine("Start charging");
        }
    }


    class InputAdaptee {

        InputType inputType;
        public InputAdaptee(InputType input)
        {
            inputType = input;
        }

        public void Input() {
            Console.WriteLine("Input " + inputType.ToString());
        }
    }
    class OutputAdaptee {
        OutputType outputType;
        public OutputAdaptee(OutputType output)
        {
            outputType = output;
        }
        public void Output() {
            Console.WriteLine("Output " + outputType.ToString());
        }
    }
}
