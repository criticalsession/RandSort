using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandSort;
public class RandSorter {
    /// <summary>
    /// Sorts data using random swapping. Horribly inefficient. Do not use.
    /// </summary>
    /// <param name="data">Array to sort</param>
    /// <param name="taskCount">Number of tasks to launch</param>
    /// <returns>Returns sorted array... eventually</returns>
    public static async Task<int[]> Sort(int[] data, int taskCount) {
        var cts = new CancellationTokenSource();
        CancellationToken token = cts.Token;

        List<Task<int[]>> tasks = new();

        for (int i = 0; i < taskCount; i++) {
            tasks.Add(Task.Run(() => {
                IntSorter sorter = new((int[])data.Clone());
                return sorter.Sort(token);
            }, token));
        }

        Task<int[]> completedTask = await Task.WhenAny(tasks);
        cts.Cancel();

        return completedTask.Result;
    }
}
