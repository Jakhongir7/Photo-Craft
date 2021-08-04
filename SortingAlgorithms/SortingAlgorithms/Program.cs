using System;
using System.Collections.Generic;
using System.Linq;

namespace SortingAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = {2, 5, 7, 3, 10, 9, 1, 4, 8, 6 };
            Console.WriteLine("Unsorted Array:");
            foreach (int a in arr)
            {
                Console.Write(a + " ");
            }

            Console.WriteLine("\n\nChoose one of the sorting methods:");
            Console.WriteLine("1. Bubble sort:");
            Console.WriteLine("2. Selection sort:");
            Console.WriteLine("3. Insertion sort:");
            Console.WriteLine("4. Merger sort:");
            Console.Write("\nPlease enter: ");
            int userInput = Convert.ToInt32(Console.ReadLine());

            switch (userInput)
            {
                case 1:
                    BubbleSort(arr);
                    printArray(arr);
                    break;
                case 2:
                    SelectionSort(arr);
                    printArray(arr);
                    break;
                case 3:
                    InsertionSort(arr);
                    printArray(arr);
                    break;
                case 4:
                    List<int> list = arr.ToList();
                    list = MergeSort(list);
                    printArray(list.ToArray());
                    break;
                default:
                    break;
            }
        }
        //Print
        static void printArray(int[] arr)
        {
            Console.WriteLine("\nSorted Array:");
            foreach (int a in arr)
            {
                Console.Write(a + " ");
            }
            Console.WriteLine();
        }

        //BubbleSort
        public static void BubbleSort(int[] input)
        {
            var item = false;
            do
            {
                item = false;
                for(int i = 0; i < input.Length - 1; i++)
                {
                    if (input[i] > input[i + 1])
                    {
                        var lowerValue = input[i + 1];
                        input[i + 1] = input[i];
                        input[i] = lowerValue;
                        item = true;
                    }
                }
            } while (item);
        }

        //SelectionSort
        public static void SelectionSort(int[] input)
        {
            for (int i = 0; i < input.Length - 1; i++)
            {
                var min = i;
                for (int j = i + 1; j < input.Length; j++)
                {
                    if (input[min] > input[j])
                    {
                        min = j;
                    }
                }
                if (min != i)
                {
                    var lowerValue = input[min];
                    input[min] = input[i];
                    input[i] = lowerValue;
                }
            }
        }

        //InsertionSort
        public static void InsertionSort(int[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                var item = input[i];
                var currentIndex = i;
                while(currentIndex > 0 && input[currentIndex - 1] > item)
                {
                    input[currentIndex] = input[currentIndex - 1];
                    currentIndex--;
                }
                    input[currentIndex] = item;
            }
        }

        //MergeSort
        private static List<int> MergeSort(List<int> unsorted)
        {
            if (unsorted.Count <= 1)
                return unsorted;

            List<int> left = new List<int>();
            List<int> right = new List<int>();

            int middle = unsorted.Count / 2;
            for (int i = 0; i < middle;i++)  //Dividing the unsorted list
            {
                left.Add(unsorted[i]);
            }
            for (int i = middle; i < unsorted.Count; i++)
            {
                right.Add(unsorted[i]);
            }

            left = MergeSort(left);
            right = MergeSort(right);
            return Merge(left, right);
        }

        private static List<int> Merge(List<int> left, List<int> right)
        {
            List<int> result = new List<int>();

            while(left.Count > 0 || right.Count>0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    if (left.First() <= right.First())  //Comparing First two elements to see which is smaller
                    {
                        result.Add(left.First());
                        left.Remove(left.First());      //Rest of the list minus the first element
                    }
                    else
                    {
                        result.Add(right.First());
                        right.Remove(right.First());
                    }
                }
                else if(left.Count>0)
                {
                    result.Add(left.First());
                    left.Remove(left.First());
                }
                else if (right.Count > 0)
                {
                    result.Add(right.First());

                    right.Remove(right.First());    
                }    
            }
            return result;
        }


    }
}
