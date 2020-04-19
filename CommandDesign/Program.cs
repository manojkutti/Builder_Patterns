using System;
using System.Collections.Generic;

namespace CommandDesign
{
    public interface ICommand
    {
        void Execute();
    }


    /// The 'Invoker' class

    public class Switch
    {


        public void StoreAndExecute(ICommand command)
        {

             command.Execute();
        }
    }


    /// The 'Receiver' class

    public class Light
    {
        public String TurnOn()
        {
            return "The light is on";
        }

        public String TurnOff()
        {
            return "The light is off";
            
        }
    }


    /// The Command for turning on the light - ConcreteCommand #1 

    public class FlipUpCommand : ICommand
    {
        private Light _light;

        public FlipUpCommand(Light light)
        {
            _light = light;
        }

        public void Execute()
        {
           String str=_light.TurnOn();
            Console.WriteLine(str);
        }
    }


    /// The Command for turning off the light - ConcreteCommand #2 

    public class FlipDownCommand : ICommand
    {
        private Light _light;

        public FlipDownCommand(Light light)
        {
            _light = light;
        }

        public void Execute()
        {
            String str=_light.TurnOff();
            Console.WriteLine(str);
        }
    }

    /// Command Pattern Demo

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter Commands (ON/OFF) : ");
            string cmd = Console.ReadLine();

            Light lamp = new Light();
            ICommand switchUp = new FlipUpCommand(lamp);
            ICommand switchDown = new FlipDownCommand(lamp);

            Switch s = new Switch();

            if (cmd.ToUpper() == "ON")
            {
                s.StoreAndExecute(switchUp);
            }
            else if (cmd.ToUpper() == "OFF")
            {
                s.StoreAndExecute(switchDown);
            }
            else
            {
                Console.WriteLine("Command \"ON\" or \"OFF\" is required.");
            }
        }
    }
}
