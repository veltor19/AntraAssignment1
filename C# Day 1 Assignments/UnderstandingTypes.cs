using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Day_1_Assignments {
    internal class UnderstandingTypes {
        public void TypeValuesAndSize() {
            Console.WriteLine($"sbytes has a range from {sbyte.MinValue} to {sbyte.MaxValue} and takes up {sizeof(sbyte)} byte");
            Console.WriteLine($"bytes has a range from {byte.MinValue} to {byte.MaxValue} and takes up {sizeof(byte)} byte");
            Console.WriteLine($"shorts has a range from {short.MinValue} to {short.MaxValue} and takes up {sizeof(short)} bytes");
            Console.WriteLine($"ushorts has a range from {ushort.MinValue} to {ushort.MaxValue} and takes up {sizeof(ushort)} bytes");
            Console.WriteLine($"ints has a range from {int.MinValue} to {int.MaxValue} and takes up {sizeof(int)} bytes");
            Console.WriteLine($"uints has a range from {uint.MinValue} to {uint.MaxValue} and takes up {sizeof(uint)} bytes");
            Console.WriteLine($"longs has a range from {long.MinValue} to {long.MaxValue} and takes up {sizeof(long)} bytes");
            Console.WriteLine($"ulongs has a range from {ulong.MinValue} to {ulong.MaxValue} and takes up {sizeof(ulong)} bytes");
            Console.WriteLine($"floats has a range from {float.MinValue} to {float.MaxValue} and takes up {sizeof(float)} bytes");
            Console.WriteLine($"doubles has a range from {double.MinValue} to {double.MaxValue} and takes up {sizeof(double)} bytes");
            Console.WriteLine($"decimals has a range from {decimal.MinValue} to {decimal.MaxValue} and takes up {sizeof(decimal)} bytes");
        }

        public void CenturyConverter(int centuries) {
            long years = centuries * 100L;
            long days = years * 365;
            long hours = days * 24;
            long minutes = hours * 60;
            long seconds = minutes * 60;
            long milliseconds = seconds * 1000;
            long microseconds = milliseconds * 1000;
            long nanoseconds = microseconds * 1000;

            Console.WriteLine($"{centuries} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes = {seconds} seconds = {milliseconds} milliseconds = {nanoseconds} nanocseconds");
        }
    }
}
