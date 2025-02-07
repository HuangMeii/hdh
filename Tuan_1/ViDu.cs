using System;
using System.Collections.Generic;

abstract class ProductType
{
    protected string brand;
    protected readonly string serial;
    protected string name;
    protected double price;

    private static readonly double minPrice = 4000000;

    public ProductType(string serial)
    {
        this.serial = FormatSerial(serial);
    }

    protected string FormatSerial(string serial)
    {
        if (string.IsNullOrEmpty(serial))
            throw new ArgumentNullException(nameof(serial), "Serial cannot be null or empty.");
        return serial.StartsWith("S") ? "S000" : serial;
    }

    public virtual void SetBrand(string brand)
    {
        if (string.IsNullOrEmpty(brand))
            throw new ArgumentNullException(nameof(brand), "Brand cannot be null or empty.");
        this.brand = brand;
    }

    public virtual string GetBrand() => brand;

    public virtual string GetSerial() => serial;

    public virtual void SetName(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentNullException(nameof(name), "Name cannot be null or empty.");
        this.name = name;
    }

    public virtual string GetName() => name;

    public virtual void SetPrice(double price)
    {
        if (!IsGreaterThanMinPrice(price))
        {
            throw new ArgumentException($"Price must be greater than {minPrice}.");
        }
        this.price = price;
    }

    public virtual double GetPrice() => price;

    public static double GetMinPrice() => minPrice;

    public static bool IsGreaterThanMinPrice(double price)
    {
        return price > minPrice;
    }

    public abstract string GetType();
}

class Desktop : ProductType
{
    public Desktop(string brand, string serial, string name, double price)
        : base(serial)
    {
        SetBrand(brand);
        SetName(name);
        SetPrice(price);
    }

    public override string GetType() => "May tinh de ban";
}

class Laptop : ProductType
{
    public Laptop(string brand, string serial, string name, double price)
        : base(serial)
    {
        SetBrand(brand);
        SetName(name);
        SetPrice(price);
    }

    public override string GetType() => "May tinh xach tay";
}

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

class ProductManager
{
    private static readonly Dictionary<string, double> productWarrantyList = new Dictionary<string, double>
    {
        { "May tinh de ban", 0.08 },
        { "May tinh xach tay", 0.05 },
        { "Dien thoai di dong", 0.1 }
    };

    public static IReadOnlyDictionary<string, double> GetProductWarrantyList() => productWarrantyList;

    public static double GetProductWarranty(string productType)
    {
        return productWarrantyList.TryGetValue(productType, out double coefficient) ? coefficient : 0;
    }
}

class Invoice
{
    private static readonly double VAT = 0.1;
    private ProductType productType;

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
        Console.WriteLine($"Price: {invoice.GetProductType().GetPrice()} VND");
        Console.WriteLine($"VAT: {Invoice.GetVAT() * 100}%");
        Console.WriteLine($"Discount: {invoice.CalculateDiscount()} VND");
        Console.WriteLine($"Warranty Fee: {invoice.CalculateWarrantyFee()} VND");
        Console.WriteLine($"Tax: {invoice.CalculateTax()} VND");
        Console.WriteLine($"Total Payment: {invoice.CalculateTotalPayment()} VND");
    }
}

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
            case "dien thoai di dong":
                return new Phone(brand, serial, name, price);
            default:
                throw new ArgumentException("Product type string is not valid.");
        }
    }
}

class Program
{
    static void Main()
    {
        View view = new View();
        Controller controller = new Controller(view);
        controller.Run();
    }
}