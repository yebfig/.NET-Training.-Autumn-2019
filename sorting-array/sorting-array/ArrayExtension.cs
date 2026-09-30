using static System.Runtime.InteropServices.JavaScript.JSType;

namespace sorting_array
{
    public static class ArrayExtension
    {
        public static void BubbleSort(ref int[] array, IKeyFunction key, IIndexCondition index)
        {
            List<int> validIndices = new List<int>();
            for(int i = 0; i< array.Length;++i)
            {
                if(index.IsSatisfied(i)) validIndices.Add(i);
            }

            for (int i = 0; i < validIndices.Count-1; i++)
            {            
                for (int j = 0; j < validIndices.Count-i-1; j++)
                {
                    int indexA = validIndices[j];
                    int indexB = validIndices[j+1];
                    if (key.GetKey(array[indexA]) > key.GetKey(array[indexB]))
                    {
                        int temp = array[indexB];
                        array[indexB] = array[indexA];
                        array[indexA] = temp;
                    }
                }
            }
        }
        
        public static void Merge(int[] array, int[] left, int[] right, IKeyFunction key)
        {
            int leftLen = left.Length;
            int rightLen = right.Length;

            int l = 0, r = 0, i = 0;

            while (l < leftLen && r < rightLen)
            {
                if (key.GetKey(left[l]) <= key.GetKey(right[r]))
                {
                    array[i++] = left[l++];
                }
                else
                {
                    array[i++] = right[r++];
                }
            }

            while (l < leftLen)
            {
                array[i++] = left[l++];               
            }

            while (r < rightLen)
            {
                array[i++] = right[r++];               
            }
        }

        public static void MergeSort(int[] derivedArray, IKeyFunction key)
        {
            if(derivedArray.Length<=1) return;

            int arrayLen = derivedArray.Length;
            int mid = arrayLen / 2;
            int[] left = new int[mid];
            int[] right = new int[arrayLen - mid];

            Array.Copy(derivedArray, 0, left, 0, left.Length);
            Array.Copy(derivedArray, left.Length, right, 0, right.Length);

            MergeSort(left, key);
            MergeSort(right, key);
            Merge(derivedArray, left, right, key);
        }
        public static void MergeSort(ref int[] array, IKeyFunction key, IIndexCondition condition)
        {
            if (array == null || array.Length <= 1) return;

            List<int> validIndices = new List<int>();

            for (int i = 0; i < array.Length; ++i)
            {
                if (condition.IsSatisfied(i)) validIndices.Add(i);
            }

            int[] derivedArray = new int[validIndices.Count];
            for (int i = 0; i < validIndices.Count; ++i)
            {
                derivedArray[i] = array[validIndices[i]];
            }

            MergeSort(derivedArray, key);
            for (int i = 0; i < validIndices.Count; ++i)
            {
                array[validIndices[i]] = derivedArray[i];
            }
        }
    }
}
