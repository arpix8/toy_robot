using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotSimulator.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            var robot = new Robot();

            Console.WriteLine("Welcome to Toy Robot Simulator!\nEnter a command or write 'quit' for exit.\n\n");

            while (true)
            {
                Console.WriteLine("# Please enter your command:");
                input = Console.ReadLine();

                if (input.ToUpper().Equals("QUIT"))
                    break;

                Console.WriteLine(robot.Command(input).Message + "\n");
            }
        }
    }
}
