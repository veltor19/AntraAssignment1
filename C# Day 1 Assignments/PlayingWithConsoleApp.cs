using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Day_1_Assignments {
    internal class PlayingWithConsoleApp {
        public void Con() {
            Console.WriteLine("What is your name: ");
            string? name = Console.ReadLine();
            Console.WriteLine("How old are you: ");
            string? age = Console.ReadLine();
            Console.WriteLine($"Hello {name}, you are {age} years old!");
        }
    }
}
    