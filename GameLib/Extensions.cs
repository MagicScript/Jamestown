using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib
{
    public static class Extensions
    {

        public static int MaxElementIndex<T>(this T[] array) where T : IComparable
        {
            int maxIndex = 0;
            T max = array[0];
            for(int i = 1; i < array.Length; ++i)
            {
                if(max.CompareTo(array[i]) < 0)
                {
                    max = array[i];
                    maxIndex = i;
                }
            }
            return maxIndex;
        }
    }
}
