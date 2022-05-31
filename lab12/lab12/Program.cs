using System;
using System.Collections.Generic;
using System.Linq;
namespace lab_12
{
    class Program
    {
        static void Main(string[] args)
        {
            int points = 0;
            //test do 1
            if (
                IsPalindrome("aga")
                && IsPalindrome("aga")
                && IsPalindrome("aga")
                && IsPalindrome("aga")
                && IsPalindrome("aga")
                && IsPalindrome("aga")
                && IsPalindrome("aga")
                )
            {
                Console.WriteLine("Zadanie 1: Wszystkie sa palindromem");
                points += 1;
            }
            else
            {
                Console.WriteLine("Zadanie 1:nie wszystkie są palindromem");
            }

            //test do 2

            if (
                IsAnagrams("kra", "rak")
                && IsAnagrams("aa", "aa")
                && IsAnagrams("AA", "aa")
                && IsAnagrams("", "")
                && IsAnagrams("abc", "abca")
                )
            {
                Console.WriteLine("Zadanie 2: wszystkie są anagramami ");
                points += 1;
            }
            else
            {
                Console.WriteLine("Zadanie 2: nie wszystkie są anagramami");
            }

            if (
                LongestIdenticalString("aaaa").Equals("aaaa")
                && LongestIdenticalString("abcddddaaddd").Equals("dddd")
                && LongestIdenticalString("abcd").Equals("a")
                && LongestIdenticalString("abbcdd").Equals("bb")
                )
            {
                Console.WriteLine("Zadanie 3: ok");
                points += 2;
            }
        }


        //czy input jest palindromem
        public static bool IsPalindrome(string added)
        {
            List<char> pali = new List<char>();
            for (int i = added.Length; i > 0; i--)
            {
                pali.Add(added[i - 1]);
            }
            string joinedName = string.Join("", pali);
            return added == joinedName;
        }


        //czy łańcuchy są anagramami
        public static bool IsAnagrams(string a, string b)
        {
            char[] arr1 = a.ToCharArray();
            char[] arr2 = b.ToCharArray();
            Array.Sort(arr1);
            Array.Sort(arr2);
            return Enumerable.SequenceEqual(arr1, arr2);
        }


        //zwróć pierwszy najdłuższy fragment złożony z powtarzających się znaków wejścia
        public static string LongestIdenticalString(string input)
        {
            return "";
        }

    }
}
