using System;
using System.Collections.Generic;
using System.Text;

namespace sorting_array
{
    public interface IIndexCondition
    {
        bool IsSatisfied(int index);
    }

    public class IsIndexEvenCondition : IIndexCondition
    {
        public bool IsSatisfied(int index)
        {
            if (index % 2 == 0) return true;
            return false;
        }
    }

    public class IsIndexNotEvenCondition : IIndexCondition
    {
        public bool IsSatisfied(int index)
        {
            if (index % 2 != 0) return true;
            return false;
        }
    }

    public class IsIndexAMultipleOfCondition : IIndexCondition
    {
        private int D { get; }
        public IsIndexAMultipleOfCondition(int d)
        {
            D = d;
        }

        public bool IsSatisfied(int index)
        {
            if (index % this.D == 0) return true;
            return false;
        }
    }
}
