using System.Diagnostics;

namespace RandSort {
    internal class Program {
        static async Task Main(string[] args) {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            Random r = new Random();

            int[] data = new int[300];
            for (int i = 0; i < 300; i++) {
                data[i] = r.Next(1, 1000);
            }

            int[] res = await RandSorter.Sort(data, 300);

            sw.Stop();
            Console.WriteLine($"Done in {sw.ElapsedMilliseconds}ms");
        }
    }
}
