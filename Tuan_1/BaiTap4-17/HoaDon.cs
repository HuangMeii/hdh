using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Tuan_1.BaiTap4_17
{
    class HoaDon
    {
        private string hangSX, soSeries, tenSP, loaiSP;
        private int gia;
        public string LayHangSX() {
            return hangSX;  
        }
        public void SetHangSX(string HangSX)
        {
            if (HangSX == null)
                throw new ArgumentNullException("Loi hang san xuat!");
            this.hangSX = HangSX;
        }

        public string LaySoSeries()
        {
            return soSeries;
        }
        public void SetSoSeries(string SoSeries)
        {
            if (SoSeries == null)
                throw new ArgumentNullException("Series trong");
            if (SoSeries[0] != 'S')
                SoSeries = "S000";
            this.soSeries = SoSeries;
        }

        public string LayTenSP() {
            return tenSP;
        }

        public void SetTenSP(string TenSP)
        {
            if (TenSP == null)
                throw new ArgumentNullException("Loi ten san pham!");
            this.tenSP = TenSP;
        }

        public string LayLoaiSP() {
            return loaiSP;
        }

        const string MT_DeBan = "May tinh de ban";
        const string MT_XachTay= "May tinh xach tay";
        const string DTDD= "Dien thoai di dong";
        public void SetLoaiSP(string LoaiSP)
        {
            if (LoaiSP == null)
                throw new ArgumentNullException("Loi loai san pham!");
            if (string.Compare(LoaiSP,MT_DeBan) != 0 && string.Compare(LoaiSP, MT_XachTay) != 0 && string.Compare(LoaiSP, DTDD) != 0)
                LoaiSP = DTDD;
            this.loaiSP = LoaiSP;
        }

        public int LayGia() {
            return gia;
        }

        public void SetGia(int Gia)
        {
            if (Gia < 4000000)
                throw new ArgumentOutOfRangeException("Gia loi");
            this.gia = Gia;
        }


        public int TinhThanhTien()
        {
            string hangUuDai = "SamSung";
            int baoHanhMTDB = LayGia() * 8 / 100;
            int baoHanhMTXT = LayGia() * 5 / 100;
            int baoHanhDTDD = LayGia() / 10;
            if (baoHanhDTDD > 2000000)
                baoHanhDTDD = 2000000;
            int thue = LayGia() / 10;
            int uuDai = 500000;

            if (string.Compare(LayLoaiSP(), MT_DeBan) == 0)
                return LayGia() + baoHanhMTDB + thue;
            else if (string.Compare(LayLoaiSP(), MT_XachTay) == 0)
                return LayGia() + baoHanhMTXT + thue;
            else if(string.Compare(LayLoaiSP(), DTDD) == 0 && string.Compare(LayHangSX(), hangUuDai) == 0)
                return LayGia()  + baoHanhDTDD - uuDai + thue;
            else
                return LayGia() + baoHanhDTDD + thue;
        }

        public void Nhap()
        {
            while (true)
            {
                try
                {
                    Console.Write("\n\nHang san xuat: ");
                    string hangMoi = Console.ReadLine();
                    Console.Write("So Series: ");
                    string seriesMoi = Console.ReadLine();
                    Console.Write("Ten san pham: ");
                    string tenMoi = Console.ReadLine();
                    Console.Write("Gia ban: ");
                    int giaMoi = int.Parse(Console.ReadLine());
                    Console.Write("Loai san pham: ");
                    string loaiMoi = Console.ReadLine();

                    SetHangSX(hangMoi);
                    SetSoSeries(seriesMoi);
                    SetTenSP(tenMoi);
                    SetGia(giaMoi);
                    SetLoaiSP(loaiMoi);
                    break;
                }
                catch (Exception er)
                {
                    Console.WriteLine("Loi: {0}\nVui long nhap lai!", er);
                }
            }
        }

        public void Xuat()
        {
            Console.WriteLine($"{LayHangSX()} - {LaySoSeries()} - {LayTenSP()} - Gia: {LayGia():N0} - {LayLoaiSP()} - Thanh tien: {TinhThanhTien()}");
        }

    }
}
