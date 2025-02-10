using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuan_1.BaiTap4_17b
{
    class Phone : ProductType
    {
        public Phone(string brand, string serial, string name, double price)
            : base(serial)
        {
            SetBrand(brand);
            SetName(name);
            SetPrice(price);
        }

        public override string GetType() => "Dien thoai di dong";
    }
}
