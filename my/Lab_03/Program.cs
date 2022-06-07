using System;

namespace Lab_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(fibonacci(10));
        }
        static long fibonacci(int n)
        {
            if (n < 2)
                return n;
            else if (n < 0)
            {
                Console.WriteLine("n musi być liczbą dodatnią");
                return -1;
            }
            else
            {
                long dwaMniejszy = 0;
                long jedenMniejszy = 1;
                long result = 0;
                for (int i = 0; i < (n - 1); i++)
                {
                    result = jedenMniejszy + dwaMniejszy;
                    dwaMniejszy = jedenMniejszy;
                    jedenMniejszy = result;
                }
                return result;
            }
        }
    }

}
