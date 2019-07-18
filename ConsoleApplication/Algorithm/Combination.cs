using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication.Algorithm
{
    public class Combination
    {
        public static IEnumerable<T[]> GetPermutations<T>(T[] items)
        {
            int[] work = new int[items.Length];
            for (int i = 0; i < work.Length; i++)
            {
                work[i] = i;
            }
            foreach (int[] index in GetIntPermutations(work, 0, work.Length))
            {
                T[] result = new T[index.Length];
                for (int i = 0; i < index.Length; i++) result[i] = items[index[i]];
                yield return result;
            }
        }

        public static IEnumerable<int[]> GetIntPermutations(int[] index, int offset, int len)
        {
            if (len == 1)
            {
                yield return index;
            }
            else if (len == 2)
            {
                yield return index;
                Swap(index, offset, offset + 1);
                yield return index;
                Swap(index, offset, offset + 1);
            }
            else
            {
                foreach (int[] result in GetIntPermutations(index, offset + 1, len - 1))
                {
                    yield return result;
                }
                for (int i = 1; i < len; i++)
                {
                    Swap(index, offset, offset + i);
                    foreach (int[] result in GetIntPermutations(index, offset + 1, len - 1))
                    {
                        yield return result;
                    }
                    Swap(index, offset, offset + i);
                }
            }
        }

        private static void Swap(int[] index, int offset1, int offset2)
        {
            int temp = index[offset1];
            index[offset1] = index[offset2];
            index[offset2] = temp;
        }



        public static IEnumerable<IEnumerable<T>> GetKCombs<T>(IEnumerable<T> list, int length) where T : IComparable
        {
            if (length == 1) return list.Select(t => new T[] { t });
            return GetKCombs(list, length - 1)
                .SelectMany(t => list.Where(o => o.CompareTo(t.Last()) > 0),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }
    }
}
