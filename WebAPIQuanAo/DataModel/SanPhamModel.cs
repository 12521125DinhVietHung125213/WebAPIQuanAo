using DataModel;

namespace DataModel
{
    public class SanPhamModel
    {
        public int MaSanPham {get;set;}
        public int MaDanhMuc { get; set; }
        public string TenSanPham { get; set; }
        public float Gia { get; set; }
        public int SoLuong { get; set; }
        public string MauSac { get; set; }
    }
}
