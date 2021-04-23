using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyMayTinh
{
    class Menu
    {
        DanhSachMayTinh ds = new DanhSachMayTinh();
        public Menu()
        {
                
        }
        public void Xuat()
        {
            DanhSachMayTinh ds = new DanhSachMayTinh();
            ds.NhapTuFile();
            Console.WriteLine("Danh sách máy tính:");
            Console.WriteLine(ds);
            //Console.WriteLine("\n---------------------\nDanh sach may tinh co ga cao nhat la ");
            //Console.WriteLine(ds.TimMayTinhCoGiaCaoNhat());
            ////Console.WriteLine(" Dem hang Intel " + ds.DemThietBiTheoHang("Intel"));
            //Console.WriteLine("Danh sách các cpu cao nhất:");
            //foreach (string s in ds.TimDanhSachHang())
            //    Console.WriteLine(s);

            Console.WriteLine(" Hang xuat hien nhieu nhat la ");
            foreach (string s in ds.TimHangXuatHienItCPUNhat())
                Console.WriteLine(s + " so lan " + ds.DemThietBiTheoHang(s));
            //Console.WriteLine("Danh sach cac may co gia re nhat:\n" + ds.DanhSachMayCoGiaThapNhat().ToString());
            //var dscpu = ds.DanhSachCPUCoGiaCaoNhat();
            //int x = 1;
            //foreach (var item in dscpu)
            //{
            //    Console.WriteLine("Máy tính thứ {0}:", x++);
            //    Console.WriteLine(item);
            //}
        }
    }
}

