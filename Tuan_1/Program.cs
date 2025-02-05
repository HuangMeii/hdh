using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuan_1
{
    internal class Program
    {
        // Static là thuộc về lớp, không cần tạo đối tượng để thực thi
        static void XepBai()
        {
            Console.WriteLine("\n\t1. Nhan vien");
            Console.WriteLine("\t2. Phan so");
            Console.WriteLine("\t3. Sinh vien");
            Console.WriteLine("\t4. Hinh tron");
        }

        static void Main(string[] args)
        {
            int choice;
            do
            {
                XepBai();
                Console.Write("\nChon bai: ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            NhanVien n = new NhanVien();
                            n.Nhap();
                            n.Xuat();
                            break;
                        }
                    case 2:
                        {
                            PhanSo a = new PhanSo();
                            PhanSo b = new PhanSo();

                            try
                            {
                                a.Nhap();
                            }
                            catch (DivideByZeroException ex)
                            {
                                Console.WriteLine("Lỗi: Không thể chia cho 0.");
                            }
                            catch (FormatException ex)
                            {
                                    Console.WriteLine("Lỗi: Vui lòng nhập một số nguyên hợp lệ.");
                            }
                            catch (OverflowException ex)
                            {
                                    Console.WriteLine("Lỗi: Giá trị nhập vào nằm ngoài phạm vi cho phép của kiểu int.");
                            }
                            catch (Exception ex)
                            {
                                    Console.WriteLine("Lỗi không xác định: " + ex.Message);
                            }

                            Console.Write("Phan so duoc nhap vao: ");
                            a.Xuat();
                            b.Nhap();
                            Console.Write("Phan so duoc nhap vao: ");
                            b.Xuat();

                            PhanSo c = new PhanSo();
                            c = c.TinhTong(a, b);

                            Console.Write("\n\ntong hai phan so: ");
                            c.ToiGian();
                            break;
                        }
                    case 3:
                        {
                            SinhVien sv = new SinhVien();
                            try
                            {
                                sv.NhapSV();
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                            sv.Xuat();
                            break;
                        }

                    default:
                        Console.Write("Lua chon khong phu hop!");
                        break;
                }
            } while (choice!=0);

            Console.ReadLine();
        }
    }
}
