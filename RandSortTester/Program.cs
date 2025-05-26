using System.Diagnostics;
using RandSort;

namespace RandSortTester {
    internal class Program {
        private static async Task Main(string[] args) {
            var r = new Random();
            var sw = new Stopwatch();

            const int size = 5_000;
            const int chunkSize = 300;

            var data = new int[size];
            for (var i = 0; i < size; i++) {
                data[i] = r.Next(1, 1_000_000);
            }

            Console.WriteLine($"Starting Sort - Size: {size}; Chunks: {chunkSize}.");

            sw.Start();

            var progressTask = Task.Run(async () =>
            {
                while (sw.IsRunning)
                {
                    Console.Write($"\rSorting... (this will take a while). {sw.Elapsed.TotalSeconds:F1}s");
                }
            });
            
            await RandSorter.Sort(data, chunkSize);

            sw.Stop();
            
            await progressTask;
            
            Console.WriteLine($"\nSort Complete!");
            sw.Reset();
        }
    }
}
