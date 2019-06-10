using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication.Class
{
    public class IndexDevice<T>
    {
        private T[] arr=new T[100];

        public T this[int i]
        {
            get => arr[i];
            set => arr[i] = value;
        }
    }

    public class SampleCollection<T>
    {
        int _nextIndex = 0;
        readonly T[] _arr=new T[100];

        public T this[int i] => _arr[i];

        public void Add(T value)
        {
            if(_nextIndex>_arr.Length)
                throw new IndexOutOfRangeException();
            _arr[_nextIndex++] = value;
        }
    }
}
