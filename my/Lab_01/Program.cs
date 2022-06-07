using System;
using System.Linq;

namespace Lab_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] tab = { 224, 1, 23, 56, 1234, 67 };
            Console.WriteLine(Ex1(tab));
            static int Ex1(int[] tab)
            {
                int index = -1;
                int min = int.MaxValue;
                for (int i = 0; i < tab.Length; i++)
                {
                    if (tab[i] >= 10 && tab[i] < 100 && min >= tab[i])
                    {
                        min = tab[i];
                        index = i;
                    }
                }
                return index;
            }

            int[] tab2 = { -1, 234, 2345, 2, 15, 9, 11 };
            Console.WriteLine(Ex2(tab2, 1));
            uint[] tab3 = { 1, 2, 4, 2, 4, 10000 };
            Console.WriteLine(Ex3(tab3, 2));
        }
        static int Ex2(int[] tab, int k)
        {
            if (k < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            // average
            int sum = 0;
            float average = 0.0f;
            for (int i = 0; i < tab.Length; i++)
            {
                sum += tab[i];
            }
            average = (float)sum / tab.Length;
            sum = 0;
            int dec = (int)(Math.Pow(10, k - 1)); // k-number
            for (int i = 0; i < tab.Length; i++)
            {
                if (tab[i] < average && Math.Abs(tab[i]) >= dec && tab[i] < dec * 10)
                {
                    sum += tab[i];
                }
            }
            return sum;
        }

        static uint Ex3(uint[] tab, int k)
        {
            // checking array range
            for (int i = 0; i < tab.Length; i++)
            {
                if (tab[i] > 10000) throw new ArgumentOutOfRangeException();
            }
            // sorting array
            for (int i = 0; i < tab.Length - 1; i++)
            {
                for (int j = 0; j < tab.Length - 1; j++)
                {
                    if (tab[j] > tab[j + 1])
                    {
                        uint sort = tab[j];
                        tab[j] = tab[j + 1];
                        tab[j + 1] = sort;
                    }
                }
            }
            // creating new array with no repetitions
            uint[] sortedTab = new uint[tab.Length];
            sortedTab = tab.Distinct().ToArray();

            return sortedTab[k - 1];
        }
    }
}
