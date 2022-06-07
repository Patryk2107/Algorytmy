using System;

namespace Lab_13
{
    class Program
    {
        static void Main(string[] args)
        {
            int points = 0;
            if (
                IsPalindrome("a")
                && IsPalindrome("aaa")
                && IsPalindrome("")
                && IsPalindrome("zakaz")
                && IsPalindrome("ZaKAZ")
                && IsPalindrome("KamilŚlimak")
                && !IsPalindrome("abc")
                )
            {
                Console.WriteLine("Zadanie 1: ok");
                points += 1;
            }
            if (
                IsAnagrams("abcd", "bcda")
                && IsAnagrams("aa", "aa")
                && !IsAnagrams("AA", "aa")
                && IsAnagrams("", "")
                && !IsAnagrams("abc", "abca")
                )
            {
                Console.WriteLine("Zadanie 2: ok");
                points += 1;
            }
            if (
                LongestIdenticalString("aaaa").Equals("aaaa")
                && LongestIdenticalString("abcddddaaddd").Equals("dddd")
                && LongestIdenticalString("abcd").Equals("a")
                && LongestIdenticalString("abbcdd").Equals("bb")
                && LongestIdenticalString("aaaa").Equals("aaaa")
                )
            {
                Console.WriteLine("Zadanie 3: ok");
                points += 2;
            }
        }


        //czy input jest palindromem
        public static bool IsPalindrome(string input)
        {
            string revString;
            char[] letter = input.ToCharArray();
            Array.Reverse(letter);
            revString = new string(letter);
            bool check = input.Equals(revString, StringComparison.OrdinalIgnoreCase);

            if (check == true) return true;
            else return false;
        }

        //czy łańcuchy są anagramami
        public static bool IsAnagrams(string a, string b)
        {
            if (a.Length == b.Length)
            {
                char[] first = a.ToCharArray();
                char[] second = b.ToCharArray();

                Array.Sort(first);
                Array.Sort(second);

                string word = new string(first);
                string word2 = new string(second);

                if (word == word2) return true;
                else return false;
            }
            else return false;
        }


        //zwróć pierwszy najdłuższy fragment złożony z powtarzających się znaków wejścia
        public static string LongestIdenticalString(string input)
        {
            var charArray = input.ToCharArray();
            string s = input[0].ToString();
            string c = input[0].ToString();
            for (int i = 1; i < input.Length; i++)
            {
                if (charArray[i] == charArray[i-1])
                {
                    c += charArray[i];
                    if (c.Length > s.Length)
                    {
                        s = c;
                    }                                    
                }
                else c = charArray[i].ToString();
            }
            return s;
        }
    }
}