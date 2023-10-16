using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ctHoaDonNhap
    {

        public ctHoaDonNhap(DataRow row) 
        {
            this.IdHoaDonNhap= row["idHoaDonNhap"].ToString();
            this.IdSanpham=     row["idSanpham"].ToString();
            this.SoLuong=       (int)row["soluong"];
            this.DonGia=        row["DonGia"].ToString();
        }

        public ctHoaDonNhap( string idHoaDonNhap, string idSanpham, int soLuong, string donGia) 
        {

            this.IdHoaDonNhap = idHoaDonNhap;
            this.IdSanpham = idSanpham;
            this.SoLuong = soLuong;
            this.DonGia = donGia;


        }
        public ctHoaDonNhap() { }


        private string idHoaDonNhap;
        private string idSanpham;
        private int soLuong;
        private string donGia;
        
        public string IdHoaDonNhap { get => idHoaDonNhap; set => idHoaDonNhap = value; }
        public string IdSanpham    { get => idSanpham; set => idSanpham = value; }
        public int    SoLuong      { get => soLuong; set => soLuong = value; }
        public string DonGia        { get => donGia; set => donGia = value; }
    }
}
