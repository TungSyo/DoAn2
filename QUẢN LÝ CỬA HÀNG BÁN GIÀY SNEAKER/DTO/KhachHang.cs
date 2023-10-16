using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhachHang
    {
        public KhachHang(DataRow row) 
        {
            this.Id =row["idKhachHang"].ToString();
            this.Name = row["tenKhachHang"].ToString();
            this.Sdt = row["sdtKhachHang"].ToString();

        }

        public KhachHang(string id, string name, string sdt) 
        {

            this.Id = id;
            this.Name = name;
            this.Sdt = sdt;
         }
        public KhachHang()
        {

        }


        protected string id;
        protected string name;
        protected string sdt;

        public string Id   { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Sdt  { get => sdt; set => sdt = value; }
    }
}
