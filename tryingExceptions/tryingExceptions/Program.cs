using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tryingExceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = { "Dog", "Cat", "Fish" };
            Object[] objs = (Object[])names;
            Object obj1 = (Object)13;
            objs[2] = obj1; // ArrayTypeMismatchException occurs

            //**********************************************************************************************

            int number1 = 3000;
            int number2 = 0;
            Console.WriteLine(number1 / number2); // DivideByZeroException occurs

            //**********************************************************************************************

            int valueEntered;
            string userValue = "two";
            valueEntered = int.Parse(userValue); // FormatException occurs

            //**********************************************************************************************

            int[] values1 = { 3, 6, 9, 12, 15, 18, 21 };
            int[] values2 = new int[6];
            values2[values1.Length - 1] = values1[values1.Length - 1]; // IndexOutOfRangeException occurs

            //**********************************************************************************************

            //InvalidCastException
            object obj = "This is a string";
            int num = (int)obj;
            decimal x = 400;
            byte i;

            //**********************************************************************************************

            i = (byte)x; // OverflowException occurs
            Console.WriteLine(i);

            Console.ReadLine();
        }
    }
}
