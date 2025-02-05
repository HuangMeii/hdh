using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuan_1
{
    class SinhVien
    {
        private string maSV;
        private string hoTen;
        private double dtb;
        private string kq;
        public string LayMSV ()
        {
            return maSV;
        }
        public void SetMSV(string ma)
        {
            if (ma == null)
                throw new ArgumentNullException("Ma trong");
            for (int i = 0; i < ma.Length; i++)
                if (ma[i] < 'A' || ma[i] > 'z')
                    throw new ArgumentException("Loi ma");
            this.maSV = ma;
        }
        public string LayHoTen()
        {
            return hoTen;
        }
        public void SetHoTen(string hoten)
        {
            if (hoten == null)
                throw new ArgumentNullException("Ten trong");
            for (int i = 0; i < hoten.Length; i++)
                if (hoten[i] < 'A' || hoten[i] > 'z')
                    throw new ArgumentException("Loi ten");
            this.hoTen = hoten;
        }

        public double LayDTB()
        {
            return dtb;
        }
        public void SetDTB(double diem)
        {
            if (diem < 0)
                throw new Exception("Diem so khong am!");
            this.dtb = diem;
        }
        
        public string LayKQ()
        {
            return kq;
        }
        public void NhapSV()
        {
            while (true)
            {
                try
                {
                    Console.Write("\nMa: ");
                    string maMoi = Console.ReadLine();
                    Console.Write("Ho ten: ");
                    string tenMoi = Console.ReadLine();
                    Console.Write("Diem trung binh: ");
                    double diemMoi = double.Parse(Console.ReadLine());
                   
                    SetMSV(maMoi);
                    SetHoTen(tenMoi);
                    SetDTB(diemMoi);
                    XetKetQua();

                    break;          
                }
                catch (Exception er)
                {
                    Console.WriteLine("\nLỗi: {0}", er);
                    Console.WriteLine("Nhap lai!");
                }
            }
        }

        void XetKetQua()
        {
            const double diemGioi = 8;
            const double diemKha = 6.5;
            const double diemTB = 5;

            if (dtb >= diemGioi)
                kq = "Gioi";
            else if (dtb >= diemKha)
                kq = "Kha";
            else if (dtb >= diemTB)
                kq = "Trung binh";
            else
                kq = "Yeu";
        }

        public void Xuat()
        {
            Console.Write("\n\nMa: {0}", maSV);
            Console.Write("\nHo ten: {0}", hoTen);
            Console.Write("\nDiem trung binh: {0}", dtb);
            Console.Write("\nKet qua: {0}", kq);
        }
    }

}
