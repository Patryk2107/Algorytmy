using System;

namespace Lab_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //EX1 suma wynosi 20
            int[] tab = { 1, 1, 2, 3, -1, 5, 6, 1, 1, 1 };
            Console.WriteLine(Ex1(tab, tab.Length));

            //EX2 wartość 1 powtarza się 5 razy
            int[] tab1 = { 1, 1, 2, 3, -1, 5, 6, 1, 1, 1 };
            Console.WriteLine(Ex2(tab1, 1, tab1.Length));

            //EX3
            Ex3(1);
        }
        //EX1 Zaimplementuj rekurencyjną wersję algorytmu sumowania elementów tablicy

        static int Ex1(int[] tab, int len)
        {
            if (len == 0)
                return 0;
            return tab[len - 1] += Ex1(tab, len - 1);
        }
        //EX2 Zaimplementuj rekurencyjną wersję algorytmu obliczania liczby wystąpień
        //danego elementu w tablicy

        static int Ex2(int[] tab1, int k, int size)
        {
            if (size > 0)
            {
                if (k == tab1[size - 1])
                    return 1 + Ex2(tab1, 1, size - 1);
                else return 0 + Ex2(tab1, 1, size - 1);
            }
            return 0;
        }
        /* EX3 Zaimplementuj rekurencyjną wersję programu FizzBuzz. Jest to zadanie
        rekrutacyjne polegające na
         wyświetleniu liczby od 1 do 100, ale
         • dla liczb podzielnych przez 3 należy wyświetlić Fizz
         • dla liczb podzielnych przez 5 należy wyświetlić Buzz
         • dla liczb podzielnych przez 15 należy wyświetlić FizzBuzz
         Nie można stosować operatora modulo %! */

        static void Ex3(int x)
        {
            if ((x - (x / 15) * 15) == 0)
                Console.WriteLine("FizzBuzz");
            else if ((x - (x / 3) * 3 == 0))
                Console.WriteLine("Fizz");
            else if ((x - (x / 5) * 5 == 0))
                Console.WriteLine("Buzz");
            else
                Console.WriteLine(x);
            if (x < 100)
                Ex3(x + 1);
        }
    }
}
