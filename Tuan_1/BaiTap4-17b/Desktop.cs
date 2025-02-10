using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuan_1.BaiTap4_17b
{
    class Desktop : ProductType
    {
        public Desktop(string brand, string serial, string name, double price)
            : base(serial)
        {
            SetBrand(brand);
            SetName(name);
            SetPrice(price);
        }

        // cú pháp ghi đè
        public override string GetType() => "May tinh de ban";
    }
}
