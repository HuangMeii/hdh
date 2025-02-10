using System;
using System.Collections.Generic;

// lớp có triển khai abtract trù tượng
// abtract interface
abstract class ProductType
{
    protected string brand;
    protected readonly string serial;
    protected string name;
    protected double price;

    // nhiều đối tượng nhưng có 1 giá trị chung nhất -> static
    private static readonly double minPrice = 4000000;

    // hàm khởi tao viết đầu tiên
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

    // hàm ảo - các hàm khác có thể ghi đè - update hàm
    public virtual void SetBrand(string brand)
    {
        if (string.IsNullOrEmpty(brand))
            throw new ArgumentNullException(nameof(brand), "Brand cannot be null or empty.");
        this.brand = brand;
    }

    public virtual string GetBrand() => brand; 
    // hàm lambda, hàm không tên
    //public virtual string GetBrand() {
    //  return brand;
    //}

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
    // double minPriceOfProductType = ProductType.IsGreaterThanMinPrice()
    public abstract string GetType();
    // lớp con nếu kế thừa thì bắt buộc ghi đè
}