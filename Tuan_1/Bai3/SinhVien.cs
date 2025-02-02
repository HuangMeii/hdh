using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuan_1
{
    class SinhVien
    {
        string maSV;
        string hoTen;
        double dtb;
        string kq;
        public void NhapSV()
        {
            Console.Write("\nMa: ");
            maSV = Console.ReadLine();
            Console.Write("Ho ten: ");
            hoTen = Console.ReadLine();
            Console.Write("Diem trung binh: ");
            dtb = double.Parse(Console.ReadLine());
            if (dtb < 0)
                throw new Exception("Diem so khong am!");
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
            XetKetQua();
            Console.Write("\n\nMa: {0}", maSV);
            Console.Write("\nHo ten: {0}", hoTen);
            Console.Write("\nDiem trung binh: {0}", dtb);
            Console.Write("\nKet qua: {0}", kq);
        }
    }

}
