using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuan_1.Bai4
{
    class HinhTron
    {
        private double banKinh;
        public HinhTron() {
        }
        
        public HinhTron(double r) {
            SetBanKinh(r);
        }

        public double LayBanKinh() {
            return banKinh;
        } 

        public void SetBanKinh(double r) {
            if (r <= 0)
                throw new ArgumentException("Loi gia tri!");
            banKinh = r;
        }
        public void Nhap()
        {
            while (true)
            {
                try
                {
                    Console.Write("Ban kinh: ");
                    double banKinhMoi = double.Parse(Console.ReadLine());
                    SetBanKinh(banKinhMoi);
                    break;
                }
                catch (Exception er)
                {
                    Console.WriteLine("Loi: {0}\nVui long nhap lai!", er);
                }
            }
        }

        public double TinhChuVi() {
            return 2 * LayBanKinh() * Math.PI;
        }

        public double TinhDienTich() {
            return Math.Pow(LayBanKinh(), 2) * Math.PI;
        }
    }
}
