using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Day_1_Assignments {
    internal class PracticeArrays {

        public void CopyArray(int[] sourceArray) {
            int[] destinationArray = new int[sourceArray.Length];
            for (int i = 0; i < sourceArray.Length; i++) {
                destinationArray[i] = sourceArray[i];
            }
            Console.Write("Destination Array: ");
            for (int i = 0; i < destinationArray.Length; i++) {
                Console.Write(destinationArray[i] + " ");
            }
            Console.WriteLine();
            Console.Write("Source Array: ");
            for (int i = 0; i < sourceArray.Length; i++) {
                Console.Write(sourceArray[i] + " ");
            }
            return;
        }

        public void ListManager() {
            List<string> items = new List<string>();

            while (true) {
                Console.WriteLine("Enter command (+ item, - item, or -- to clear):");
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                    continue;

                if (input.StartsWith("+")) {
                    string itemToAdd = input.Substring(1).Trim();
                    if (!string.IsNullOrEmpty(itemToAdd)) {
                        items.Add(itemToAdd);
                        Console.WriteLine($"Added: {itemToAdd}");
                    } else {
                        Console.WriteLine("No item entered to add.");
                    }
                } else if (input.StartsWith("-")) {
                    string itemToRemove = input.Substring(1).Trim();

                    if (itemToRemove == "")  // user entered just "-"
                    {
                        items.Clear();
                        Console.WriteLine("List cleared.");
                    } else {
                        if (items.Remove(itemToRemove)) {
                            Console.WriteLine($"Removed: {itemToRemove}");
                        } else {
                            Console.WriteLine($"Item not found: {itemToRemove}");
                        }
                    }
                } else {
                    Console.WriteLine("Invalid command.");
                }

                Console.WriteLine("Current list:");
                if (items.Count == 0)
                    Console.WriteLine("(empty)");
                else
                    foreach (string item in items)
                        Console.WriteLine($"- {item}");

                Console.WriteLine();
            }

        }

        public int[] FindPrimesInRange(int start, int end) {
            List<int> primes = new List<int>();
            for (int number = start; number <= end; number++) {
                if (IsPrime(number)) {
                    primes.Add(number);
                }
            }
            return primes.ToArray();
        }

        static bool IsPrime(int number) {
            if (number <= 1) return false;
            for (int i = 2; i <= Math.Sqrt(number); i++) {
                if (number % i == 0) return false;
            }
            return true;
        }

        public int[] AddRotatingArray(int[] array, int rotations) {
            int length = array.Length;
            int[] sum = new int[length];
            int lastElement;
            for (int r = 0; r < rotations; r++) {
                lastElement = array[length - 1];
                for (int i = length - 1; i > 0; i--) {
                    array[i] = array[i - 1];
                }
                array[0] = lastElement;
                for (int i = 0; i < length; i++) {
                    sum[i] += array[i];
                }
            }
            return sum;
        }

        public int[] LongestSequenceOfEqualElements(int[] array) {
            int maxLength = 1;
            int currentLength = 1;
            int startIndex = 0;
            int maxStartIndex = 0;
            for (int i = 1; i < array.Length; i++) {
                if (array[i] == array[i - 1]) {
                    currentLength++;
                    if (currentLength > maxLength) {
                        maxLength = currentLength;
                        maxStartIndex = i - maxLength + 1;
                    }
                } else {
                    currentLength = 1;
                }
            }
            int[] longestSequence = new int[maxLength];
            Array.Copy(array, maxStartIndex, longestSequence, 0, maxLength);
            return longestSequence;
        }

        public void MostFrequentNumber(int[] array) {
            Dictionary<int, int> frequencyMap = new Dictionary<int, int>();
            foreach (int num in array) {
                if (frequencyMap.ContainsKey(num)) {
                    frequencyMap[num]++;
                } else {
                    frequencyMap[num] = 1;
                }
            }
            int mostFrequent = array[0];
            int maxCount = 1;
            foreach (var pair in frequencyMap) {
                if (pair.Value > maxCount) {
                    maxCount = pair.Value;
                    mostFrequent = pair.Key;
                }
            }
            Console.WriteLine($"Most frequent number is {mostFrequent} with a count of {maxCount}");
            return;
        }
    }
}