﻿using System.Collections.Generic;
using Depra.ObjectPooling.Runtime.Pooled.Interfaces;
using Depra.ObjectPooling.Runtime.Pools.Interfaces;

namespace Depra.ObjectPooling.Runtime.Extensions
{
    public static class GeneralPoolExtensions
    {
        public static void WarmUp<T>(this IPool<T> pool, int count) where T : IPooled
        {
            var objects = pool.RequestRange(count);
            pool.ReleaseRange(objects);
        }

        public static IEnumerable<T> RequestRange<T>(this IPool<T> pool, int count) where T : IPooled
        {
            var result = new T[count];
            for (var i = 0; i < count; i++)
            {
                result[i] = pool.Request();
            }

            return result;
        }

        /// <summary>
        /// Releases all objects in the list, the list should be cleared afterwards.
        /// </summary>
        /// <param name="pool"></param>
        /// <param name="collection"></param>
        public static void ReleaseRange<T>(this IPool<T> pool, IEnumerable<T> collection) where T : IPooled
        {
            foreach (var item in collection)
            {
                pool.Release(item);
            }
        }
    }
}