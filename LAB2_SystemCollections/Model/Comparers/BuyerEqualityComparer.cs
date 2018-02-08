using System.Collections;
using System.Collections.Generic;

namespace LAB2_SystemCollections.Model.Comparers
{
    internal class BuyerEqualityComparer : IEqualityComparer<Buyer>
    {
        private CaseInsensitiveComparer comparer = new CaseInsensitiveComparer();

        public bool Equals(Buyer x, Buyer y)
        {
            return comparer.Compare(x.Name, y.Name) == 0;
        }

        public int GetHashCode(Buyer obj)
        {
            return obj.Name.ToLowerInvariant().GetHashCode();
        }
    }
}
