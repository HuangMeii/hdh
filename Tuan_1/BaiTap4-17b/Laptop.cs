using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuan_1.BaiTap4_17b
{
    class Laptop : ProductType
    {
        public Laptop(string brand, string serial, string name, double price)
            : base(serial)
        {
            SetBrand(brand);
            SetName(name);
            SetPrice(price);
        }

        // override: ghi đè abtract
        public override string GetType() => "May tinh xach tay";
    }
}
