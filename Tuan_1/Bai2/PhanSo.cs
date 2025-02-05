using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Tuan_1
{
    class PhanSo
    {
        private int tuSo, mauSo;
        public void Nhap()
        {
            Console.Write("\n\nNhap tu: ");
            tuSo = int.Parse(Console.ReadLine());
            Console.Write("Nhap mau: ");
            mauSo = int.Parse(Console.ReadLine());
            if (mauSo == 0) 
                throw new DivideByZeroException("Mau so khong the bang 0!!");
        }

        public void Xuat()
        {
            Console.Write("{0} / {1}", tuSo, mauSo);
        }

        int UCLN(int a, int b)
        {
            if (a == b)
                return a;
            if (a > b)
                return UCLN(a - b, b);
            return UCLN(a, b - a);
        }

        int UCLN1(int a, int b)
        {
            if (b == 0)
                return a;
            return UCLN(b, a % b);
        } // Thuật toán Euclid giảm số lần đệ quy

        public void ToiGian()
        {
            int ucln = UCLN(tuSo, mauSo);
            tuSo /= ucln;
            mauSo /= ucln;
            Xuat();
        }

        public PhanSo TinhTong(PhanSo a, PhanSo b)
        {
            PhanSo c = new PhanSo();
            c.tuSo = a.tuSo * b.mauSo + b.tuSo * a.mauSo;
            c.mauSo = a.mauSo * b.mauSo;
            return c;
        }

    }
}
