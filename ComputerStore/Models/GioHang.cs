using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComputerStore.Models
{
    public class GioHang
    {
        public string sMaSP { get; set; }
        public string sTenSP { get; set; }
        public double dDonGia { get; set; }
        public int iSoLuong { get; set; }
        public string sAnhDaiDien { get; set; }
        public double ThanhTien
        {
            get { return iSoLuong * dDonGia; }
        }
    }
}