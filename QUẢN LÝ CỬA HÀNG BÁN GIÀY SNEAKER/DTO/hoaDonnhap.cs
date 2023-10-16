using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class hoaDonnhap
    {


        public hoaDonnhap(DataRow row) 
        
        {

            this.Id =row["idHoaDonNhap"].ToString();
            this.IdNhanVien =row["idNhanVien"].ToString();
            this.IdNhaCungCap = row["idNhaCC"].ToString();

            this.Ngaynhap = row["ngayNhap"].ToString();

            this.TongTien = row["tongTien"].ToString();


        }


        public hoaDonnhap(string id,  string idNhanVien, string idNhaCungCap, string ngaynhap, string tongTien)
        {

            this.Id = id;
            this.IdNhanVien = idNhanVien;
            this.IdNhaCungCap = idNhaCungCap;
            this.Ngaynhap=ngaynhap;
            this.tongTien=tongTien;



        }
        public hoaDonnhap() { }

        protected string id;
        protected string idNhanVien;
        protected string idNhaCungCap;
        protected string ngaynhap;
        protected string tongTien;

        public string Id{ get => id; set => id = value; }
        public string IdNhanVien { get => idNhanVien; set => idNhanVien = value; }
        public string IdNhaCungCap { get => idNhaCungCap; set => idNhaCungCap = value; }
        public string Ngaynhap{ get => ngaynhap; set => ngaynhap = value; }
        public string TongTien { get => tongTien; set => tongTien = value; }
    }
}
