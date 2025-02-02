using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuan_1.Bai4
{
    internal class HinhTron
    {
        double r;
        public double R //Property với ràng buộc bán kính lớn hơn 0
        {
            get { return r; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Du lieu bi loi!");
                    r = 0;
                }
                else
                    r = value;
            }
        }

        public HinhTron()
        {
            this.R = 0;  //khởi tạo không tham số
        }
        
        public HinhTron(double r)
        {
            this.R = r;  //khởi tạo có tham số
        }

        public void Nhap()
        {
            Console.Write("Ban kinh: ");
            this.R = double.Parse(Console.ReadLine());
        }
    }
}
