using System.Diagnostics;

namespace RandSort {
    internal class Program {
        static async Task Main(string[] args) {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            Random r = new Random();

            int[] data = new int[200];
            for (int i = 0; i < 200; i++) {
                data[i] = r.Next(1, 10000);
            }

            int[] res = await RandSorter.Sort(data, 1);

            sw.Stop();
            Console.WriteLine($"Done in {sw.ElapsedMilliseconds}ms");
        }
    }
}
