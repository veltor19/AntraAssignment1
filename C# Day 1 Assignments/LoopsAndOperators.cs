using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Day_1_Assignments {
    internal class LoopsAndOperators {
        public void FizzBuzz() {
            for (int i = 1; i <= 100; i++) {
                if (i % 3 == 0 && i % 5 == 0) {
                    Console.WriteLine("FizzBuzz");
                } else if (i % 3 == 0) {
                    Console.WriteLine("Fizz");
                } else if (i % 5 == 0) {
                    Console.WriteLine("Buzz");
                } else {
                    Console.WriteLine(i);
                }
            }
        }

        public void byteOverflow() {
            int max = 500;
            for (byte i = 0; i < max; i++) {
                Console.WriteLine(i);
            }
        }

        public void NumberGuesser() {
            int correctNumber = new Random().Next(1, 4); // random number 1–3
            Console.WriteLine("Guess a number between 1 and 3: ");
            string? input = Console.ReadLine();
            int guessedNumber = int.Parse(input);

            while (guessedNumber != correctNumber) {
                if (guessedNumber < 1 || guessedNumber > 3) {
                    Console.WriteLine("Out of range! Please guess between 1 and 3:");
                } else if (guessedNumber < correctNumber) {
                    Console.WriteLine("Too low!");
                } else {
                    Console.WriteLine("Too high!");
                }

                input = Console.ReadLine();
                guessedNumber = int.Parse(input);
            }

            Console.WriteLine("Correct!");
        }

        public void PrintPyramid() {
            int totalRows = 5;

            for (int i = 1; i <= totalRows; i++) {
                for (int space = totalRows - i; space > 0; space--) {
                    Console.Write(" ");
                }

                for (int star = 1; star <= (2 * i - 1); star++) {
                    Console.Write("*");
                }

                Console.WriteLine();
            }
        }

        public void Birthday() {
            DateTime birthDate = new DateTime(2002, 11, 8);
            DateTime today = DateTime.Today;

            int daysOld = (today - birthDate).Days;
            Console.WriteLine($"You are {daysOld} days old.");

            int daysToNextAnniversary = 10000 - (daysOld % 10000);
            DateTime nextAnniversaryDate = today.AddDays(daysToNextAnniversary);

            Console.WriteLine($"Your next 10,000-day anniversary is in {daysToNextAnniversary} days.");
            Console.WriteLine($"That will be on: {nextAnniversaryDate.ToLongDateString()}");
        }

        public void Greeting() {
            // You can replace DateTime.Now with a fixed time for testing
            DateTime currentTime = DateTime.Now;
            int hour = currentTime.Hour;

            // We'll just use if statements, not else
            if (hour >= 5 && hour < 12) {
                Console.WriteLine("Good Morning!");
            }
            if (hour >= 12 && hour < 17) {
                Console.WriteLine("Good Afternoon!");
            }
            if (hour >= 17 && hour < 21) {
                Console.WriteLine("Good Evening!");
            }
            if (hour >= 21 || hour < 5) {
                Console.WriteLine("Good Night!");
            }

            Console.WriteLine($"(The current time is {currentTime.ToShortTimeString()})");
        }

        public void Counting() {
            for (int i = 0; i < 4; i++) {
                if (i == 0){
                    for (int j = 0; j < 25; j++) {
                        if (j == 24) {
                            Console.WriteLine(j);
                        } else {
                            Console.Write(j + ",");
                        }
                    }
                }
                if (i == 1) {
                    for (int j = 0; j < 25; j = j + 2) {
                        if (j == 24) {
                            Console.WriteLine(j);
                        } else {
                            Console.Write(j + ",");
                        }
                    }
                }
                if (i == 2) {
                    for (int j = 0; j < 25; j = j + 3) {
                        if (j == 24) {
                            Console.WriteLine(j);
                        } else {
                            Console.Write(j + ",");
                        }
                    }
                }
                if (i == 3) {
                    for (int j = 0; j < 25; j = j + 4) {
                        if (j == 24) {
                            Console.WriteLine(j);
                        } else {
                            Console.Write(j + ",");
                        }
                    }
                }
            }
        }
    }
}
