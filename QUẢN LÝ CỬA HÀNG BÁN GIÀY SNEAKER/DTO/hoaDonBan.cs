using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO
{
    public class hoaDonBan
    {

        public hoaDonBan(DataRow row)

        {

            this.Id = row["idHoaDonBan"].ToString();
            this.IdNhanVien = row["idNhanVien"].ToString();
            this.IdKhachHang = row["idKhachHang"].ToString();

             this.NgayBan= row["ngayBan"].ToString();
            
                
            this.TongTien = row["tongTien"].ToString();


        }


        public hoaDonBan(string id, string idNhanVien, string idKhachHang, string ngayBan, string tongTien)
        {

            this.Id = id;
            this.IdNhanVien = idNhanVien;
            this.IdKhachHang = idKhachHang;
            this.NgayBan = ngayBan;
            this.tongTien = tongTien;



        }
        public hoaDonBan() { }

        protected string id;
        protected string idNhanVien;
        protected string idKhachHang;
        protected string ngayBan;
        protected string tongTien;

        public string Id { get => id; set => id = value; }
        public string IdNhanVien { get => idNhanVien; set => idNhanVien = value; }
        public string IdKhachHang { get => idKhachHang; set => idKhachHang = value; }
        public string NgayBan { get => ngayBan; set => ngayBan = value; }
        public string TongTien { get => tongTien; set => tongTien = value; }
    }
}
