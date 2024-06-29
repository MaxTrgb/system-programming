using System;
using System.IO;
using System.Linq;
using System.Threading;
using static ConsoleApp3.Program;
using System.Text.Json;

namespace ConsoleApp3
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[10000];
            Random rnd = new Random();

            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = rnd.Next();
            }

            int max = maxNum(nums);
            Console.WriteLine("Max number: "+max);

            int min = minNum(nums);
            Console.WriteLine("\nMin number: "+min);

            double mean = meanNum(nums);
            Console.WriteLine("\nMean number: "+mean);

            CountingResults countingResults = new CountingResults();

            countingResults.maxNumber = max;
            countingResults.minNumber = min;
            countingResults.meanNumber = mean;
           
            writeFile(countingResults);

            Console.ReadLine();          

        }
        private static void writeFile(CountingResults countingResults)
        {
            string fileName = "CountingResults";
            string filePath = $"..\\..\\{fileName}.json";

            using (FileStream file = new FileStream($"..\\..\\filePath.json", FileMode.Create))
            {
                JsonSerializer.Serialize<CountingResults>(file, countingResults);
              
            }
        }
        [Serializable]
        public class CountingResults
        {
            public int maxNumber { get; set; }
            public int minNumber { get; set; }
            public double meanNumber { get; set; }
        }
        public static int maxNum(int[] nums)
        {
            int max = 0;
            Thread thread = new Thread(() =>
            {
               max = nums.Max();
            });
            thread.Start();
            thread.Join();
            return max;
        }
      
        public static int minNum(int[] nums)
        {
            int min = 0;
            Thread thread = new Thread(() =>
            {
                min = nums.Min();
            });
            thread.Start();
            thread.Join();
            return min;
        }

        public static double meanNum(int[] nums)
        {
            double mean = 0;
            Thread thread = new Thread(() =>
            {
                mean = nums.Average();
            });
            thread.Start();
            thread.Join();
            return mean;
        }



        //Task 1, 2, 3:
        //public static void taskOne(int start, int stop, int threadsNum)
        //{
        //    Thread[] threads = new Thread[threadsNum];

        //    for (int i = 0; i < threadsNum; i++)
        //    {
        //        threads[i] = new Thread(() =>
        //        {
        //            for (int j = start; j <= stop; j++)
        //            {
        //                Console.WriteLine(j);
        //            }
        //        });
        //        threads[i].Start();
        //        threads[i].Join();
        //    }
        //}
    }
}