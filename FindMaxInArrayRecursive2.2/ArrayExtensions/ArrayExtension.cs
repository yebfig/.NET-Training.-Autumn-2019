namespace ArrayExtensions
{
    public static class ArrayExtension
    {
        public static int[] FilterArrayByKey(this int[] array, int key)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));
            if (key < 0 || key > 9) throw new ArgumentOutOfRangeException("Key must be between 0 and 9");
            if(array.Length == 0) throw new ArgumentException("Array cannot be empty", nameof(array));;
            
            List<int> result = new List<int>();
            foreach (int a in array)
            {
                long temp = Math.Abs((long)a);
                do
                {
                    if (temp % 10 == key)
                    {
                        result.Add(a);
                        break;
                    }

                    temp /= 10;
                } while (temp > 0);
            }

            return result.ToArray();
        }

        public static int FindMaximumItem(this int[] array)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));
            if (array.Length == 0) throw new ArgumentException("Array length cannot be zero");
            if (array.Length == 1) return array[0];
            
            return FindMaximumItemRecursive(array, 0, array.Length - 1);
        }
        private static int FindMaximumItemRecursive(int[] array, int left, int right)
        {
            if(left == right) return array[left];
            int mid = left + (right - left) / 2;
            
            int leftMax = FindMaximumItemRecursive(array, left, mid);
            int rightMax = FindMaximumItemRecursive(array, mid + 1, right);
            return leftMax > rightMax ? leftMax : rightMax;
        }

        public static int? FindBalanceIndex(this int[] array)
        {
            if (array == null) throw new ArgumentNullException("Array cannot be null");
            if (array.Length == 1) return 0;
            if (array.Length == 0) return null;
            
            int len = array.Length;
            long totalSum = 0;
            for (int i = 0; i < len; ++i)
            {
                totalSum+= array[i];
            }

            long leftSum = 0;
            for (int i = 0; i < len; ++i)
            {
                long rightSum = totalSum - leftSum - array[i];
                if (rightSum == leftSum) return i;
                leftSum += array[i];
            }

            return null;
        }
    }
}
