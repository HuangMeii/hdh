using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuan_1
{
    internal class NhanVien
    {
        string maNV;
        public string LayMaNV()
        {
            return maNV; 
        }

        public void SetMaNV(string maN)
        {
            if (string.IsNullOrEmpty(maN))
                throw new ArgumentException("Ma trong khong!");
            if (maN.Length != 5)
                throw new ArgumentException("Loi do dai!");
            const int KiTu = 2;
            for (int i = 0; i < KiTu; i++)
            {
                char s = maN[i];
                if(s <'A' || s > 'z')
                {
                    throw new ArgumentException("Loi ma");
                }
            }

            for (int i = maN.Length-1; i >= KiTu; i--)
            {
                if (maN[i] < '0' || maN[i] > '9')
                    throw new ArgumentException("Loi ma");
            }
            this.maNV = maN;
        }

        string hoTen;
        public string LayHoTen()
        {
            return hoTen;
        }
        public void SetHoTen(string hoTen) {
            if (hoTen == null)
                throw new ArgumentException("Ma trong khong!");
            if (hoTen.Length <= 1)
                throw new ArgumentException("Loi do dai!");
            this.hoTen = hoTen;
        }

        int soNC;
        public int LaySoNC()
        {
            return soNC;
        }
        public void SetSoNC(int soNC) {
            if (soNC <= 0)
                throw new ArgumentException("Gia tri khong am hoac bang 0!");
            this.soNC = soNC;
        }

        public char XepLoai()
        {
            //Thuộc tính xếp loại không có set, vì giá trị xếp loại dựa theo số ngày công nên không được gián giá trị tùy ý
                if (soNC >= 26)
                    return 'A';
                else if (soNC >= 22)
                    return 'B';
                else
                    return 'C';
        }

        //Thuộc tính lương - ngày áp dụng chung cho tất cả nhân viên nên là thành phần static
        public static double LuongNgay = 200000;

        //Phương thức khởi tạo
        public NhanVien()
        {
            //Để trống lỏng 
        }

        //Khi khởi tạo giá trị cho nhân viên chỉ khởi tạo 3 thuộc tính: MaNV, HoTen, SoNC
        public NhanVien(string maNV, string hoTen, int soNC)
        {
            SetMaNV(maNV);
            SetHoTen(hoTen);
            SetSoNC(soNC);
        }

        public NhanVien(NhanVien n) { 
            SetMaNV(maNV);
            SetHoTen(hoTen);
            SetSoNC(soNC);
        }

        //Các phương thức xử lí khác
        public void Nhap()
        {
            while (true)
            {
                try
                {
                    Console.Write("\n\nMa nhan vien: ");
                    string maMoi = Console.ReadLine();
                    Console.Write("\nHo ten nhan vien: ");
                    string tenMoi = Console.ReadLine();
                    Console.Write("\nSo ngay cong: ");
                    int ngayMoi = int.Parse(Console.ReadLine());

                    SetMaNV(maMoi);
                    SetHoTen(tenMoi);
                    SetSoNC(ngayMoi);
                    break; // Thoát khỏi vòng lặp nếu nhập thành công
                }
                catch (Exception r)
                {
                    Console.WriteLine("Loi: {0}", r.Message);
                    Console.WriteLine("Vui long nhap lai thong tin.");
                }
            }
        }

        double TinhLuong()
        {
            return LaySoNC() * LuongNgay;
        }

        public double TinhThuong()
        {
            if (XepLoai() == 'A')
                return TinhLuong() * 5 / 100;
            else if (XepLoai() == 'B')
                return TinhLuong() * 2 / 100;
            else return 0;
        }

        public void Xuat()
        {
            Console.Write("{0} - {1}: {2} - {3} - {4} / {5}", LayMaNV(), LayHoTen(), LaySoNC(), XepLoai(), TinhLuong(), TinhThuong());
        }
    }
}
