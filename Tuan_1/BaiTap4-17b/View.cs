using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuan_1.BaiTap4_17b
{
    class View
    {
        public string GetBrand()
        {
            Console.Write("Nhap brand: ");
            return Console.ReadLine();
        }

        public string GetSerial()
        {
            Console.Write("Nhap serial: ");
            return Console.ReadLine();
        }

        public string GetName()
        {
            Console.Write("Nhap name: ");
            return Console.ReadLine();
        }

        public double GetPrice()
        {
            double price;
            while (true)
            {
                Console.Write("Nhap price: ");
                string input = Console.ReadLine();
                if (double.TryParse(input, out price) && price > 0)
                {
                    return price;
                }
                else
                {
                    Console.WriteLine("Gia phai la so duong. Xin vui long nhap lai.");
                }
            }
        }

        public string GetProductType()
        {
            Console.Write("Nhap loai san pham (May tinh de ban, May tinh xach tay, Dien thoai di dong): ");
            return Console.ReadLine();
        }

        public void DisplayInvoiceDetails(Invoice invoice)
        {
            Console.WriteLine("\n--- Thong tin hoa don ---");
            Console.WriteLine($"Brand: {invoice.GetProductType().GetBrand()}");
            Console.WriteLine($"Serial: {invoice.GetProductType().GetSerial()}");
            Console.WriteLine($"Name: {invoice.GetProductType().GetName()}");
            Console.WriteLine($"Price: {invoice.GetProductType().GetPrice():N0} VND");
            Console.WriteLine($"VAT: {Invoice.GetVAT() * 100}%");
            Console.WriteLine($"Discount: {invoice.CalculateDiscount():N0} VND");
            Console.WriteLine($"Warranty Fee: {invoice.CalculateWarrantyFee():N0} VND");
            Console.WriteLine($"Tax: {invoice.CalculateTax():N0} VND");
            Console.WriteLine($"Total Payment: {invoice.CalculateTotalPayment():N0} VND");
        }
    }
}
