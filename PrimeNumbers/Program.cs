using System;

namespace PrimeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("This application counts prime numbers within range [A,B]. \nInput A: ");                        
            int a = ReadInput();
            Console.Write("Input B: ");
            int b = ReadInput();          
            Console.WriteLine("\nThere are {0} prime numbers in the given interval.\n\nPress any key to quit...", CountPrimes(a, b).ToString());
            Console.ReadKey();
        }

        /// <summary>
        /// Converts input string into int with exception handling
        /// </summary>
        /// <returns>Input number</returns>
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
                Console.WriteLine("Input string is not a sequence of digits. Input parameter was set to 0.");
            }
            catch (OverflowException e)
            {
                Console.WriteLine("The number cannot fit in an Int32. Input parameter was set to 0.");
            }            
            return num;
        }

        /// <summary>
        /// Determines whether an input number is prime
        /// </summary>
        /// <param name="n">Number to be tested on being prime</param>
        /// <returns>True if n is a prime number</returns>
        private static bool IsPrime (int n)
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
            while (i <= nSqrt) // divisors cannot be greater than square root of n 
            {
                if (n % i == 0)
                {
                    return false;
                }
                i += 2; // exclude even numbers because they have 2 as divisor but n does not 
            }            
            return true;
        }

        /// <summary>
        /// Counts prime numbers within the range [A…B] (both ends are included in the range)
        /// </summary>
        /// <param name="a">Left range end</param>
        /// <param name="b">Right range end</param>
        /// <param name="printPrimeNumbers">Switch on printing prime numbers in the given range</param>
        /// <returns>Number of prime numbers within the range</returns>
        private static int CountPrimes(int a, int b, bool printPrimeNumbers = true)
        {
            if ((a > b) || (b <= 1))
            {
            
                return 0;
            }
            int counter = 0;
            if (a <= 2)
            {
                a = 3;
                counter++; // count 2 as the first prime number
                if (printPrimeNumbers) 
                {
                    Console.Write("2 ");

                }
            }
            else
            {
                if (a % 2 == 0) // will start searching prime numbers from the nearest odd number
                {
                    a++;
                }
            }

            int i = a;
            while (i <= b)
            {
                if (IsPrime(i))
                {
                    counter++;
                    if (printPrimeNumbers)
                    {
                        Console.Write("{0} ", i.ToString());
                    }
                }
                i += 2;
            }
            return counter;
        }
    }
}
