using System;
using System.Threading.Tasks;

namespace Sprint9_ex3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    class Calc
    {
        public static int Seq(int n)
        {
            return n;
        }
    }

    class CalcAsync
    {
        public static async Task<int> SeqAsync(int n)
        {
            return await Task.Run(() => Calc.Seq(n));
        }

        public static async void PrintSeqElementsConsequentlyAsync(int quant)
        {
            for (int i = 1; i <= quant; i++)
            {
                var y = await Task.Run(() => SeqAsync(i));
                Console.WriteLine($"Seq[{i}] = {y}");
            }
        }

        public static async void PrintSeqElementsInParallelAsync(int quant)
        {
            for (int i = 1; i <= quant; i++)
            {
                var y = await Task.Run(() => SeqAsync(i));
                Console.WriteLine($"Seq[{i}] = {y}");
            }
        }

        public static Task<int>[] GetSeqAsyncTasks(int n)
        {
            Task<int> task = Task.Run(() => Calc.Seq(n));
            Task<int>[] array = { task };
            return array;
        }
    }
}
