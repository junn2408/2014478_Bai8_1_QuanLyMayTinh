using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyMayTinh
{
    class MayTinh
    {
        List<IThietBi> collection = new List<IThietBi>();
        #region Kiểm tra phần cứng
        public bool KiemTraCpu()
        {
            //foreach (var item in collection)
            //{
            //    if(item is CPU)
            //    {
            //        return true;
            //    }
            //}
            //return false;
            return collection.Any(s => !(s is Ram) && s is CPU);
        }
        public bool KiemTraRam()
        {
            return collection.Any(s => !(s is CPU) && s is Ram);
        }
        #endregion
        #region Tìm máy tính có phần cứng theo giá tiền
        public float GiaCpuThapNhat()
        {
            //var min = float.MaxValue;
            //foreach (var item in collection)
            //{
            //    if (item is CPU && min> item.Gia)
            //    {
            //        min = item.Gia;
            //    }
            //}
            //return min;
            return collection.Where(s => !(s is Ram) && s is CPU).Min(s => s.Gia);
        }
        public float GiaCpuCaoNhat()
        {
            return collection.Where(s => !(s is Ram) && s is CPU).Max(s => s.Gia);
        }
        public float GiaRamThapNhat()
        {
            return collection.Where(s => !(s is CPU) && s is Ram).Min(s => s.Gia);
        }
        public float GiaRamCaoNhat()
        {
            return collection.Where(s => !(s is CPU) && s is Ram).Max(s => s.Gia);
        }
        #endregion
        #region Tìm hãng theo phần cứng

        #endregion
        public void Them(IThietBi tb)
        {
            collection.Add(tb);
        }
        public float TongGia()
        {
            float tong = 0;
            foreach (var item in collection)
            {
                tong += item.Gia;
            }
            return tong;
        }
        public int SoLuongThietBi()
        {
            return collection.Count();
        }
        public override string ToString()
        {
            string s = "";
            foreach (var item in collection)
            {
                s += item + "\n";
            }
            s += "Tong gia la " + TongGia();
            return s;
        }
        public int DemTheoHang(string hang)
        {
            //int dem = 0;
            //foreach (var item in collection)
            //{
            //    if (item.HangSX == hang) dem++;
            //}
            //return dem;
            return collection.Count(x => x.HangSX == hang);
        }
        public List<string> TimDanhSachHangTheoCPU()
        {
            List<string> kq = new List<string>();
            foreach (var item in collection)
            {
                if (!(item is Ram) && item is CPU)
                {
                    kq.Add(item.HangSX);
                }
            }
            return kq;
        }
        public List<string> TimDanhSachHangTheoRam()
        {
            var kq = new List<string>();
            foreach (var item in collection)
            {
                if (!(item is CPU) && item is Ram)
                {
                    kq.Add(item.HangSX);
                }
            }
            return kq;
        }
        public List<string> TimDanhSachHang()
        {
            List<string> kq = new List<string>();
            foreach (var item in collection)
            {
                    kq.Add(item.HangSX);
            }
            return kq;
        }
    }
}