using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ExtensionMethods
{
    /// <summary>
    /// From https://github.com/dotnet/runtime/blob/main/src/libraries/System.Private.CoreLib/src/System/Random.cs
    /// MIT License
    /// </summary>
    public static class ShuffleExtensionMethods
    {   
        /// <summary>
        ///   Performs an in-place shuffle of an array.
        /// </summary>
        /// <param name="values">The array to shuffle.</param>
        /// <typeparam name="T">The type of array.</typeparam>
        /// <exception cref="ArgumentNullException"><paramref name="values" /> is <see langword="null" />.</exception>
        /// <remarks>
        ///   This method uses <see cref="Next(int, int)" /> to choose values for shuffling.
        ///   This method is an O(n) operation.
        /// </remarks>
        public static void Shuffle<T>(this T[] values)
        {
            if (values == null) {
                throw new System.ArgumentNullException("Array must not be null when shuffling.");
            }
            Shuffle(values.AsSpan());
        }
    
        /// <summary>
        ///   Performs an in-place shuffle of a span.
        /// </summary>
        /// <param name="values">The span to shuffle.</param>
        /// <typeparam name="T">The type of span.</typeparam>
        /// <remarks>
        ///   This method uses <see cref="Next(int, int)" /> to choose values for shuffling.
        ///   This method is an O(n) operation.
        ///   
        ///   For Unity consider discussion here: https://forum.unity.com/threads/collectionmarshal-asspan-support.1235407/
        /// </remarks>
        public static void Shuffle<T>(this System.Span<T> values)
        {
            int n = values.Length;
    
            for (int i = 0; i < n - 1; i++)
            {
                int j = UnityEngine.Random.Range(i, n);
    
                if (j != i)
                {
                    T temp = values[i];
                    values[i] = values[j];
                    values[j] = temp;
                }
            }
        }
    }
}
