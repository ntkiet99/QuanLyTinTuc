using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyTinTuc.Models
{
    public class TinTuc
    {
        public int Id { get; set; }
        public string TieuDe { get; set; }
        public string MoTa { get; set; }
        public string NoiDung { get; set; }
        public string HinhAnh { get; set; }
        public DateTime NgayDang { get; set; } = DateTime.Now;
    }
}