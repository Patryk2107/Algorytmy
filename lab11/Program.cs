using System;
namespace lab22
{
    class Program
    {
        static void Main(string[] args)
        {
            Method3();
        }
        private static void Method3()
        {
            Random rnd = new Random();
            int poczatek = 0;
            int koniec = 99;
            int wylosowana = rnd.Next(poczatek, koniec);
            Console.Write(wylosowana);
            if (wylosowana / 3.0 == wylosowana / 3)
            {
                Console.WriteLine("Fizz");
            }
            else if (wylosowana / 5.0 == wylosowana / 5)
            {
                Console.WriteLine("Buzz");
            }
            else if (wylosowana / 15.0 == wylosowana / 15)
            {
                Console.WriteLine("Fizzbuzz");
            }
        }
    }
}