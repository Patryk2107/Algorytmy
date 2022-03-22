using System;

namespace lab4
{

    class sort
    {
        public static void Main()
        {
            int[] arr = { 124, 111, 524, 25, 56, 90, 11 };
            sort sst = new sort();

            sst.Selectionsort(arr);
            Console.WriteLine("Zadanie 4 : ");
            druk(arr);


            Console.WriteLine("Zadanie 6 (2pkt)");
            var sorted = QuickSort(arr, 0, arr.Length);
            foreach(var item in sorted)
            {
                Console.Write(item + ",");
            }
            Console.WriteLine();

        }

        void Selectionsort(int[] arr)
        {
            int dlugosc = arr.Length;

            for (int i = 0; i < dlugosc - 1; i++)
            {
                
                int min = i;
                for (int j = i + 1; j < dlugosc; j++)
                    if (arr[j] > arr[min])
                        min = j;

                
                int t = arr[min];
                arr[min] = arr[i];
                arr[i] = t;
            }
        }

        static void druk(int[] arr)
        {
            int dlugosc = arr.Length;
            for (int i = 0; i < dlugosc; i++)
            Console.Write(arr[i] + " ");
            Console.WriteLine();
        }

        //Zad 6
        public static int[] QuickSort(int [] arr, int start, int end)
        {
            if(start < end)
            {
                int obr = Partion(arr, start, end);
                QuickSort(arr, start, obr);
                QuickSort(arr, obr + 1, end);
            }
            return arr;
        }


        public static void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
        public static int Partion(int[] arr, int start, int end)
        {
            int pivot= arr[start];
            int swapIndex = start;
            for(int i = start +1; i< end; i++)
            {
                if(arr[i] < pivot){
                    swapIndex++;
                    Swap(arr, i, swapIndex);
                }

            }
            Swap(arr, start, swapIndex);
            return swapIndex;
        }


    }
}

