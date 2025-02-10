using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuan_1.BaiTap4_17b
{
    class ProductManager
    {
        private static readonly Dictionary <string, double> productWarrantyList = new Dictionary<string, double>
        {
            { "May tinh de ban", 0.08 },
            { "May tinh xach tay", 0.05 },
            { "Dien thoai di dong", 0.1 }
        };

        public static IReadOnlyDictionary<string, double> GetProductWarrantyList() => productWarrantyList;
        // Dictionary listA = GetProductWarrantyList();
        public static double GetProductWarranty(string productType)
        {
            return productWarrantyList.TryGetValue(productType, out double coefficient) ? coefficient : 0;
        }
    }
}