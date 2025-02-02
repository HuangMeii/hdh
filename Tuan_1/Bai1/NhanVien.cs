using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Tuan_1
{
    internal class NhanVien
    {
        string maNV;
        public string MaNV
        {
            get { return maNV; }
            set { maNV = value;

            if (Regex.IsMatch(value, @"[^a-zA-Z0-9]"))
                throw new ArgumentException("Ma khong chua ki tu dac biet");
            }

        }

        string hoTen;
        public string HoTen
        {
            get { return hoTen; }
            set { hoTen = value; }
        }

        int soNC;
        public int SoNC
        {
            get { return soNC; }
            set { 
                if (soNC < 10)
                {
                    Console.WriteLine("{0}", soNC);
                }
                else
                    soNC = value;
            }
        }

        public char XepLoai
        {
            //Thuộc tính xếp loại không có set, vì giá trị xếp loại dựa theo số ngày công nên không được gián giá trị tùy ý
            get
            {
                if (SoNC >= 26)
                    return 'A';
                else if (SoNC >= 22)
                    return 'B';
                else
                    return 'C';
            }
        }

        //Thuộc tính lương - ngày áp dụng chung cho tất cả nhân viên nên là thành phần static
        public static double LuongNgay = 200000;

        //Phương thức khởi tạo
        public NhanVien()
        {
            MaNV = "3002";
            HoTen = "Van Hoa";
            SoNC = 25;
        }

        //Khi khởi tạo giá trị cho nhân viên chỉ khởi tạo 3 thuộc tính: MaNV, HoTen, SoNC
        public NhanVien(string maNV, string hoTen, int soNC)
        {
            this.MaNV = maNV;
            this.HoTen = hoTen;
            this.SoNC = soNC;
        }

        public NhanVien(NhanVien n) { 
        
            this.MaNV = n.MaNV;
            this.HoTen = n.HoTen;
            this.SoNC = n.SoNC;
        }

        //Các phương thức xử lí khác
        public void Nhap()
        {
            Console.Write("\n\nMa nhan vien: ");
            MaNV = Console.ReadLine();
            Console.Write("\nHo ten nhan vien: ");
            HoTen = Console.ReadLine();
            Console.Write("\nSo ngay cong: ");
            SoNC = int.Parse(Console.ReadLine());
        }

        double TinhLuong()
        {
            return SoNC * LuongNgay;
        }

        public double TinhThuong()
        {
            if (XepLoai == 'A')
                return TinhLuong() * 5 / 100;
            else if (XepLoai == 'B')
                return TinhLuong() * 2 / 100;
            else return 0;
        }

        public void Xuat()
        {
            Console.Write("{0} - {1}: {2} - {3} - {4} / {5}", MaNV, HoTen, SoNC, XepLoai, TinhLuong(), TinhThuong());
        }
    }
}
