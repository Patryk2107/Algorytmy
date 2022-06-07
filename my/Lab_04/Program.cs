using System;

namespace Lab_04
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] tablicaTestowa = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 0 };

            // EX1
            Console.WriteLine("Insertion Sort dla tablicy łańcuchów w kolejności alfabetycznej.");
            string[] tab1 = { "jeden", "dwa", "trzy", "cztery", "pięć", "szcześć" };
            Ex1(tab1);

            Console.WriteLine(); // space

            // EX2
            Console.WriteLine("\nInsertion Sort dla tablicy liczb w kolejności rosnącej:");
            Ex2(tablicaTestowa);
            int[] tab2 = { 100, 2, 30, 4, 5000, 6, 7, 80, -9, 10, 0 };
            Ex2(tab2);

            Console.WriteLine(); // space


            // EX4
            Console.WriteLine("\nSelection Sort dla tablicy liczb w kolejności malejącej:");
            Ex4(tablicaTestowa);
            int[] tab4 = { -10, -20, -3, -15, 15, 1, -7, 65, -9, 0 };
            Ex4(tab4);
        }
        static void Ex1(string[] tab)
        {
            for (int i = 1; i < tab.Length; i++)
            {
                string temp = tab[i];
                int j = i - 1;
                while (j >= 0 && tab[j].CompareTo(temp) > 0)
                {
                    tab[j + 1] = tab[j];
                    j -= 1;
                }
                tab[j + 1] = temp;
            }

            Console.WriteLine();
            for (int i = 0; i < tab.Length; i++)
            {
                Console.Write(tab[i] + " ");
            }
        }

        //////////////////////////////////////////////////////////////
        static void Ex2(int[] tab)
        {
            for (int i = 1; i < tab.Length; i++)
            {
                int temp = tab[i];
                int j = i - 1;
                while (j >= 0 && tab[j] > temp)
                {
                    tab[j + 1] = tab[j];
                    j -= 1;
                }
                tab[j + 1] = temp;
            }

            Console.WriteLine();
            for (int i = 0; i < tab.Length; i++)
            {
                Console.Write(tab[i] + " ");
            }
        }

        //////////////////////////////////////////////////////////////
        static void Ex4(int[] tab)
        {
            for (int i = 0; i < tab.Length - 1; i++)
            {
                int x = i;
                int temp;

                for (int j = i + 1; j < tab.Length; j++)
                {
                    if (tab[j] > tab[x])
                        x = j;
                }

                temp = tab[x];
                tab[x] = tab[i];
                tab[i] = temp;
            }

            Console.WriteLine();
            for (int i = 0; i < tab.Length; i++)
            {
                Console.Write(tab[i] + " ");
            }
        }
    }
}
