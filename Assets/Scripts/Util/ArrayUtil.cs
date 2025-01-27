using System;

namespace Util
{
    public class ArrayUtil
    {
        public static void ShuffleArray<T>(T[] array)
        {
            Random random = new Random();

            for (int i = array.Length - 1; i > 0; i--)
            {
                int randomIndex = random.Next(i + 1);
                
                (array[i], array[randomIndex]) = (array[randomIndex], array[i]);
            }
        }
    }
}
