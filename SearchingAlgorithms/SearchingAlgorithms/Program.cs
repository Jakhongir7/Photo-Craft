using System;

namespace SearchingAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 2, 5, 7, 3, 10, 9, 1, 4, 8, 6 };
            int result;
            Console.WriteLine("Given Array:");
            foreach (int a in arr)
            {
                Console.Write(a + " ");
            }
            Console.Write("\nPlease enter what number are you searching: ");
            int userInput = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nChoose one of the searching methods:");
            Console.WriteLine("1. Linear search:");
            Console.WriteLine("2. Binary search:");
            Console.Write("\nPlease enter: ");
            int searchingMethod = Convert.ToInt32(Console.ReadLine());

            switch (searchingMethod)
            {
                case 1:
                    result = LinearSearch(arr, userInput);
                    printResult(arr, result);
                    break;
                case 2:
                    result = BinarySearch(arr, userInput);
                    printResult(arr, result);
                    break;
                default:
                    break;
            }
        }
        static void printResult(int[] arr, int result)
        {
            if(result == -1)
            {
                Console.WriteLine("\nElement is not present in the Array");
            }
            else
            {
                Console.WriteLine("\nSearching element " + arr[result] + " is located at index " + result);
            }
        }

        public static int LinearSearch(int[] arr, int input)
        {
            int n = arr.Length;
            for (int i = 0; i < n; i++)
            {
                if(arr[i] == input)
                {
                    return i;
                }
            }
            return -1;
        }

        public static int BinarySearch(int[] arr, int input)
        {
            int min = 0;
            int max = arr.Length - 1;
         
            while (min <= max)
            {
                int middle = (min + max) / 2;

                if (input == arr[middle])
                {
                    return middle;
                }
                else if (input > arr[middle])
                {

                    min = middle + 1; 
                }
                else
                {
                    max = middle - 1;
                }
            }
                return -1;
        }
    }
}
