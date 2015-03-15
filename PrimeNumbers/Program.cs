using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number: ");                        
            int num = ReadInput();
            Console.WriteLine("The number is prime: {0}", isPrime(num).ToString());
            Console.ReadKey();
        }

        private static int ReadInput()
        {
            string input = Console.ReadLine();
            int num = 0;
            // ToInt32 can throw FormatException or OverflowException. 
            try
            {
                num = Convert.ToInt32(input);
            }
            catch (FormatException e)
            {
                Console.WriteLine("Input string is not a sequence of digits.");
            }
            catch (OverflowException e)
            {
                Console.WriteLine("The number cannot fit in an Int32.");
            }            
            return num;
        }

        private static bool isPrime (int n)
        {
            if (n == 2)
            {
                return true;
            }
            if ((n <= 1) || (n % 2 == 0))
            {
                return false;
            }
            int nSqrt = Convert.ToInt32(Math.Sqrt(Convert.ToDouble(n)));
            int i = 3;
            while (i <= nSqrt)
            {
                if (n % i == 0)
                {
                    return false;
                }
                i += 2;
            }            
            return true;
        }
    }
}
