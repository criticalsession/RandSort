using System.Diagnostics;

namespace RandSort {
    internal class Program {
        static async Task Main(string[] args) {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            Random r = new Random();

            int[] data = new int[100];
            for (int i = 0; i < 100; i++) {
                data[i] = r.Next(1, 2000);
            }

            var cts = new CancellationTokenSource();
            CancellationToken token = cts.Token;

            List<Task<int[]>> tasks = new();

            for (int i = 0; i < 100; i++) {
                tasks.Add(Task.Run(() => {
                    IntSorter sorter = new((int[])data.Clone());
                    return sorter.Sort(token);
                }, token));
            }

            Task<int[]> completedTask = await Task.WhenAny(tasks);
            cts.Cancel();

            sw.Stop();
            Console.WriteLine($"Done in {sw.ElapsedMilliseconds}ms");
        }
    }
}
