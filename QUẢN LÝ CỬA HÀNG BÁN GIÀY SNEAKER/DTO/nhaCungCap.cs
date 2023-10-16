using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class nhaCungCap
    {

        public nhaCungCap(DataRow row) {

            this.Id =     row["idNhaCC"].ToString();
            this.Name =   row["tenNhaCC"].ToString();
            this.Sdt =     row["sdtNhaCC"].ToString();
            this.DiaChi = row["diaChiNhaCC"].ToString();


        }
        public nhaCungCap( string id,string name, string sdt,string diaChi) 
        {
            this.Id = id;
            this.Name =name;
            this.Sdt = sdt;
            this.DiaChi = diaChi;




        }
        public nhaCungCap() { }

        private string id;
        private string name;
        private string sdt;
        private string diaChi;

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
    }
}
