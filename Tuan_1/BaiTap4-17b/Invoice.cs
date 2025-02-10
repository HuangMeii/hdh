using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuan_1.BaiTap4_17b
{
    class Invoice
    {
        private static readonly double VAT = 0.1;
        private ProductType productType;

        // ProductType laptopA = new LapTop();
        public Invoice(ProductType productType)
        {
            SetProductType(productType);
        }

        public void SetProductType(ProductType productType)
        {
            this.productType = productType;
        }

        public ProductType GetProductType() => productType;

        public static double GetVAT() => VAT;

        public bool CheckPromotion()
        {
            if (productType.GetBrand() != "SamSung")
                return false;
            if (productType.GetType() != "Dien thoai di dong")
                return false;
            return true;
        }

        public double CalculateDiscount() => CheckPromotion() ? 500000 : 0;

        public double CalculateWarrantyFee()
        {
            double coefficient = ProductManager.GetProductWarranty(productType.GetType());
            return productType.GetPrice() * coefficient;
        }

        public double CalculateTax() => productType.GetPrice() * VAT;

        public double CalculateTotalPayment()
        {
            double warrantyFee = CalculateWarrantyFee();
            double tax = CalculateTax();
            double discount = CalculateDiscount();
            return productType.GetPrice() + warrantyFee - discount + tax;
        }
    }
}
