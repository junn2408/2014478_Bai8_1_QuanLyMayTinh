using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyMayTinh
{
    class DanhSachMayTinh
    {
        List<MayTinh> collection = new List<MayTinh>();
        public void NhapTuFile()
        {
            string path = @"Book1.csv";
            StreamReader sr = new StreamReader(path);
            string str = "";
            while ((str = sr.ReadLine()) != null)
            {
                // CPU,Intel,300 * CPU,Intel,300 * RAM,SamSung,50 * HDD,Seagate,500
                MayTinh m = new MayTinh();
                string[] s = str.Split('*');
                foreach (string item in s)
                {
                    if (item.IndexOf("CPU") == 0)
                        m.Them(new CPU(item));
                    if (item.IndexOf("RAM") == 0)
                        m.Them(new Ram(item));
                }
                Them(m);
            }
        }
        public void Them(MayTinh mt)
        {
            collection.Add(mt);
        }
        public DanhSachMayTinh TimMayTinhCoGiaCaoNhat()
        {
            //float max = collection.Max(x => x.TongGia());
            float max = TimGiaCaoNhat();
            DanhSachMayTinh kq = new DanhSachMayTinh();
            foreach (var item in collection)
            {
                if (item.TongGia() == max)
                    kq.Them(item);
            }
            return kq;
        }
        public float TimGiaCaoNhat()
        {
            float max = -1;
            foreach (var item in collection)
            {
                if (max < item.TongGia())
                    max = item.TongGia();
            }
            return max;
        }
        public override string ToString()
        {
            string s = "";
            int k = 1;
            foreach (var item in collection)
            {
                s += "Danh sách máy thứ: " + k + ".\n" + item + "\n";
                k++;
            }
            return s;
        }
        float GiaMayTinhThapNhat()
        {
            return collection.Min(x => x.TongGia());
        }
        #region Danh sách máy tính
        public List<MayTinh> DanhSachMayCoGiaThapNhat()
        {
            var min = GiaMayTinhThapNhat();
            var ds = collection.Where(s => s.TongGia() == min).ToList();
            return ds;
            //var kq = new DanhSachMayTinh();
            //foreach (var item in collection)
            //{
            //    if (item.TongGia() == min)
            //    {
            //        kq.Them(item);
            //    }
            //}
            //return kq;
        }
        public List<MayTinh> DanhSachCPUCoGiaThapNhat()
        {
            var ds = collection.Where(s => s.KiemTraCpu()).ToList();
            var min = ds.Min(s => s.GiaCpuThapNhat());
            var result = ds.Where(s => s.GiaCpuThapNhat() == min).ToList();
            return result;
        }
        public List<MayTinh> DanhSachCPUCoGiaCaoNhat()
        {
            var ds = collection.Where(s => s.KiemTraCpu()).ToList();
            var max = ds.Max(s => s.GiaCpuCaoNhat());
            var result = ds.Where(s => s.GiaCpuCaoNhat() == max).ToList();
            return result;
        }
        public List<MayTinh> DanhSachRamCoGiaThapNhat()
        {
            var ds = collection.Where(s => s.KiemTraRam()).ToList();
            var min = ds.Min(s => s.GiaRamThapNhat());
            var result = ds.Where(s => s.GiaRamThapNhat() == min).ToList();
            return result;
        }
        public List<MayTinh> DanhSachRamCoGiaCaoNhat()
        {
            var ds = collection.Where(s => s.KiemTraRam()).ToList();
            var min = ds.Min(s => s.GiaRamCaoNhat());
            var result = ds.Where(s => s.GiaRamCaoNhat() == min).ToList();
            return result;
        }
        #endregion
        #region Danh sách các hãng
        public int DemThietBiTheoHang(string hang)
        {
            //int dem = 0;
            //foreach (var item in collection)
            //{
            //    dem += item.DemTheoHang(hang);
            //}
            //return dem;
            return collection.Sum(x => x.DemTheoHang(hang));
        }
        /// <summary>
        /// Ham them 1 ds chuoi vao ds chuoi, tranh trung nhau
        /// </summary>
        /// <param name="kq">Danh sach goc</param>
        /// <param name="hang">Danh sach hang</param>
        public void ThemDanhSachHang(List<string> kq, List<string> hang)
        {
            foreach (var item in hang)
            {
                if (!kq.Contains(item))
                    kq.Add(item);
            }
        }
        public List<string> TimDanhSachHang()
        {
            List<string> kq = new List<string>();
            foreach (var item in collection)
            {
                ThemDanhSachHang(kq, item.TimDanhSachHang());
            }
            return kq;
        }
        private int TimThietBiNhieuNhat()
        {
            int max = -1;
            List<string> ds = TimDanhSachHang();
            foreach (var item in ds)
            {
                int tam = DemThietBiTheoHang(item);
                if (max < tam)
                    max = tam;
            }
            return max;
        }
        private int TimThietBiItNhat()
        {
            int min = int.MaxValue;
            var ds = TimDanhSachHang();
            foreach (var item in ds)
            {
                int tam = DemThietBiTheoHang(item);
                if (min > tam)
                {
                    min = tam;
                }
            }
            return min;
        }
        public List<string> TimHangXuatHienNhieuNhat()
        {
            List<string> kq = new List<string>();
            int max = TimThietBiNhieuNhat();
            List<string> ds = TimDanhSachHang();
            foreach (var item in ds)
            {
                int tam = DemThietBiTheoHang(item);
                if (tam == max)
                    kq.Add(item);
            }
            return kq;
        }
        public List<string> TimDanhSachHangTheoCPU()
        {
            List<string> kq = new List<string>();
            foreach (var item in collection)
            {
                ThemDanhSachHang(kq, item.TimDanhSachHangTheoCPU());
            }
            return kq;
        }
        public List<string> TimDanhSachTheoRam()
        {
            var kq = new List<string>();
            foreach (var item in collection)
            {
                ThemDanhSachHang(kq, item.TimDanhSachHangTheoRam());
            }
            return kq;
        }
        public List<string> TimHangXuatHienNhieuCPUNhat()
        {
            List<string> kq = new List<string>();
            int max = TimThietBiNhieuNhat();
            List<string> ds = TimDanhSachHangTheoCPU();
            foreach (var item in ds)
            {
                int tam = DemThietBiTheoHang(item);
                if (tam == max)
                    kq.Add(item);
            }
            return kq;
        }
        public List<string> TimHangXuatHienItCPUNhat()
        {
            List<string> kq = new List<string>();
            int min = TimThietBiItNhat();
            List<string> ds = TimDanhSachHangTheoCPU();
            foreach (var item in ds)
            {
                int tam = DemThietBiTheoHang(item);
                if (tam == min)
                    kq.Add(item);
            }
            return kq;
        }
        public List<string> TimHangXuatHienNhieuRamNhat()
        {
            var kq = new List<string>();
            int max = TimThietBiNhieuNhat();
            var ds = TimDanhSachTheoRam();
            foreach (var item in ds)
            {
                int tam = DemThietBiTheoHang(item);
                if (tam == max)
                {
                    kq.Add(item);
                }
            }
            return kq;
        }
        public List<string> TimHangXuatHienItNhat()
        {
            var kq = new List<string>();
            int min = TimThietBiItNhat();
            var ds = TimDanhSachTheoRam();
            foreach (var item in ds)
            {
                int tam = DemThietBiTheoHang(item);
                if (tam == min)
                {
                    kq.Add(item);
                }
            }
            return kq;
        }
        #endregion
        #region Sắp xếp máy tính
        List<int> soLuong()
        {
            var x = new List<int>();
            foreach (var item in collection)
            {
                x.Add(item.SoLuongThietBi());
            }
            return x;
        }
        #endregion
    }
}