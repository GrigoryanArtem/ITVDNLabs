using LAB2_SystemCollections.Model;
using LAB2_SystemCollections.Model.Comparers;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace LAB2_SystemCollections
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Dictionary<Buyer, List<PurchaseCategory>> dict1 = new Dictionary<Buyer, List<PurchaseCategory>> (new BuyerEqualityComparer());

            dict1.Add(new Buyer("Misha"), new List<PurchaseCategory> { PurchaseCategory.Fruit, PurchaseCategory.Meat });
            dict1.Add(new Buyer("Sasha"), new List<PurchaseCategory> { PurchaseCategory.Fruit});
            dict1.Add(new Buyer("Dasha"), new List<PurchaseCategory> { PurchaseCategory.Meat });

            Console.WriteLine(String.Join(", ", dict1.GetCategoriesByBuyer(new Buyer("Misha"))));
            Console.WriteLine(String.Join(", ", dict1.GetBuyersByCategories(PurchaseCategory.Meat).Select(buyer => buyer.Name)));
        }

        #region Extension Methods
        static IEnumerable<PurchaseCategory> GetCategoriesByBuyer(this Dictionary<Buyer, List<PurchaseCategory>> dict, Buyer buyer)
        {
            if (!dict.ContainsKey(buyer))
                return null;

            return dict[buyer];
        }

        static IEnumerable<Buyer> GetBuyersByCategories(this Dictionary<Buyer, List<PurchaseCategory>> dict, PurchaseCategory category)
        {
            return dict.Where(x => x.Value.Where(y => y == category).Any()).Select(x => x.Key);
        }

        #endregion
    }
}
