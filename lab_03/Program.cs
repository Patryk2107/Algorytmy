using System;
namespace lab22
{
    class Program
    {
        static void Main(string[] args)
        {
           // fib(6);
            Console.WriteLine(fibonacci(45));
        }
        static long fib(int n)
        {
            if (n < 2)
            {
                return 1;
            }
            return fib(n - 1) + fib(n - 2);
        }
        static long fibonacci(int n)
        {
            long[] mem = new long[n];
            Array.Fill<long>(mem, -1);
            return fibmem(n, mem);
        }
        static long fibmem(int n, long[] mem)
        {
            if (n < 2)
            {
                return 1;
            }
            if(mem[n-1] == -1)
            {
                mem[n - 1] = fibmem(n - 1, mem);
            }
            if (mem[n - 2] == -2)
            {
                mem[n - 2] = fibmem(n - 2, mem);
            }
            return mem[n - 1] + mem[n - 2];
        }
    }
}