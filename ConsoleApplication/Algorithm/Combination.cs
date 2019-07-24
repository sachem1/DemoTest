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



        public static void Test()
        {
            Dictionary<string, List<string>> finishProductDic = new Dictionary<string, List<string>>();
            List<string> materielList1 = new List<string>() { "A1", "B1", "C1" };
            List<string> materielList2 = new List<string>() { "A2", "B2", "C2" };
            List<string> materielList3 = new List<string>() { "A3", "B3", "C3" };
            finishProductDic.Add("P001", materielList1);
            finishProductDic.Add("P002", materielList2);
            finishProductDic.Add("P003", materielList3);

            var materielSum = finishProductDic.Values.SelectMany(x => x.ToArray());
            var enumerable = materielSum as string[] ?? materielSum.ToArray();
            var result= GetKCombs(enumerable,3);
            foreach (var item in result)
            {
                Console.WriteLine(string.Join(",", item));
                Console.WriteLine("\r\n");
            }
        }


        public static void Test2()
        {
            Dictionary<string, List<string>> finishProductDic = new Dictionary<string, List<string>>();
            List<string> materielList1 = new List<string>() { "A1", "A2", "A3" };
            List<string> materielList2 = new List<string>() { "B1", "B2", "B2" };
            List<string> materielList3 = new List<string>() { "C1", "C2", "C2" };
            finishProductDic.Add("P001", materielList1);
            finishProductDic.Add("P002", materielList2);
            finishProductDic.Add("P003", materielList3);

            var materielSum = finishProductDic.Values.SelectMany(x => x.ToArray());
            var enumerable = materielSum as string[] ?? materielSum.ToArray();
            var result = GetKCombs(enumerable, 3);
            foreach (var item in result)
            {
                Console.WriteLine(string.Join(",", item));
                Console.WriteLine("\r\n");
            }
        }
    }
}
