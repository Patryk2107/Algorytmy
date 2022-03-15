using System;

namespace labb_03_zad3
{
    class CashRegister
    {
        private int _one;
        private int _two;
        private int _five;

        public CashRegister(int one, int two, int five)
        {
            _one = one;
            _two = two;
            _five = five;
        }
        private void UnregisterCoins(int[] outcome)
        {
            _one -= outcome[0];
            _two -= outcome[1];
            _five -= outcome[2];
        }
        int[] Payment(int[] income, int amount)
        {
            if (getAmoutFromCoins(income) < amount)
            {
                return new int[] { };
            }
            if ()
                // inne warunki np jak bedzie ujemna liczba monet
                int rest = getAmoutFromCoins(income) - amount;
            RegisterCoins(income);
            // ile jest piątek w reszcie i jeśli więcej od 0 to czy są piątki w kasie
            // ile jest dwójek w pozostałej części reszty i jeśli większe od 0 to czy są dwójki w kasie
            // i ile jest jedynek
            // jeśli braknie to zwracamy pustą tablice
            //jeśli jest reszta do wydania to usuwamy z kasy monety skłądające sie na reszte


        }
        //coins [0] - złotówki
        //coins [1] - dwójki
        //coins [2] - piątki
        private void RegisterCoins(int[] income)
        {
            _one += income[0];
            _two += income[1];
            _five += income[2];
        }
        private int getAmoutFromCoins(int[] coins)
        {
            return coins[0] + coins[1] * 2 + coins[2] * 5;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
