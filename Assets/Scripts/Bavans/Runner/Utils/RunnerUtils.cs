using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bavans.Runner.Utils
{
    public static class RunnerUtils 
    {
        public static System.Random random = new System.Random(); 

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
