﻿using System;
using System.Collections.Generic;

namespace MemoryGame
{
    /// <summary>
    /// Extension class that we use to add a shuffle method to lists.
    /// </summary>
    static class MyExtensions
    {
        public static void Shuffle<T>(this IList<T> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
