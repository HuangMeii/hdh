using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuan_1.BaiTap4_17b
{
    class Controller
    {
        private View view;
        private bool firstTime = true;
        private Exception exception = null;

        public Controller(View view)
        {
            this.view = view;
        }

        private bool ShouldInputField(string fieldName)
        {
            return firstTime || (exception.Message.Contains(fieldName));
        }

        private string formatProductTypeString(string input)
        {
            return input.Trim().ToLower();
            // "       May tinh de BAN  "
            // "may tinh de ban"
        }

        public void Run()
        {
            string brand = "";
            string serial = "";
            string name = "";
            double price = 0;
            string productTypeString = "";

            ProductType product = null;
            bool validInput = false;

            while (!validInput)
            {
                try
                {
                    if (firstTime)
                        Console.WriteLine("\n--- Nhap thong tin san pham ---");
                    else
                        Console.WriteLine("\n--- Nhap lai thong tin san pham ---");

                    if (ShouldInputField("Brand"))
                        brand = view.GetBrand();

                    if (ShouldInputField("Serial"))
                        serial = view.GetSerial();

                    if (ShouldInputField("Name"))
                        name = view.GetName();

                    if (ShouldInputField("Price"))
                        price = view.GetPrice();

                    if (ShouldInputField("Product type"))
                        productTypeString = view.GetProductType();

                    productTypeString = formatProductTypeString(productTypeString);

                    product = CreateProduct(productTypeString, brand, serial, name, price);
                    validInput = true;
                }
                catch (ArgumentException ex)
                {
                    exception = ex;
                    firstTime = false;
                }
            }
            Invoice invoice = new Invoice(product);
            view.DisplayInvoiceDetails(invoice);
        }

        private ProductType CreateProduct(string productTypeString, string brand, string serial, string name, double price)
        {
            switch (productTypeString)
            {
                case "may tinh de ban":
                    return new Desktop(brand, serial, name, price);
                case "may tinh xach tay":
                    return new Laptop(brand, serial, name, price);
                default:
                    return new Phone(brand, serial, name, price);
            }
        }
    }
}
