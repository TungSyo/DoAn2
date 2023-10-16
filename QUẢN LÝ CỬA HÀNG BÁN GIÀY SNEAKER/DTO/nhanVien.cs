using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class nhanVien
    {

        public nhanVien(DataRow row) 
        {

            this.Id =        row["idNhanVien"].ToString();
            this.Name =       row["tenNv"].ToString();
            this.NamSinh =   row["namSinh"].ToString();
            this.QueQuanNv = row["queQuanNv"].ToString();
            this.SdtNv =     row["sdtNv"].ToString();
            this.LuongCb =    row["luongCb"].ToString();
            this.TaiKhoan =   row["taiKhoan"].ToString();
            this.MatKhau =    row["matKhau"].ToString();
            this.Quyen =      row["quyen"].ToString(); ;


        }
        public nhanVien(  string id, string name, string namSinh, string queQuanNv, string sdtNv, string luongCb, string taiKhoan, string matKhau, string quyen ) 
        {
            this.Id =id;
            this.Name =name;
            this.NamSinh =namSinh;
            this.QueQuanNv =queQuanNv;
            this.SdtNv =sdtNv; 
            this.LuongCb =luongCb;
            this.MatKhau = matKhau;
            this.Quyen = quyen;




        }

        public nhanVien() { }

        private string id;
        private string name;
        private string namSinh;
        private string queQuanNv;
        private string sdtNv;
        private string luongCb;
        private string taiKhoan;
        private string matKhau;
        private string quyen;

        public string Id        { get => id; set => id = value; }
        public string Name      { get => name; set => name = value; }
        public string NamSinh   { get => namSinh; set => namSinh = value; }
        public string QueQuanNv { get => queQuanNv; set => queQuanNv = value; }
        public string SdtNv     { get => sdtNv; set => sdtNv = value; }
        public string LuongCb   { get => luongCb; set => luongCb = value; }
        public string TaiKhoan  { get => taiKhoan; set => taiKhoan = value; }
        public string MatKhau   { get => matKhau; set => matKhau = value; }
        public string Quyen     { get => quyen; set => quyen = value; }
    }
}
