using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ctHoaDonBan
    {

        public ctHoaDonBan(DataRow row)
        {
            this.IdHoaDonBan = row["idChiTietHoaDonBan"].ToString();
            this.IdSanpham = row["idSanPham"].ToString();
            this.SoLuong = (int)row["soLuong"];
            this.DonGia = row["giaBan"].ToString();
        }

        public ctHoaDonBan(string idHoaDonBan, string idSanpham, int soLuong, string donGia)
        {

            this.IdHoaDonBan = idHoaDonBan;
            this.IdSanpham = idSanpham;
            this.SoLuong = soLuong;
            this.DonGia = donGia;


        }
        public ctHoaDonBan() { }
        private string idHoaDonBan;
        private string idSanpham;
        private int soLuong;
        private string donGia;

        public string IdHoaDonBan { get => idHoaDonBan; set => idHoaDonBan = value; }
        public string IdSanpham { get => idSanpham; set => idSanpham = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public string DonGia { get => donGia; set => donGia = value; }

    }
}
