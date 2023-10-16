using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SanPham
    {
        public SanPham( string id, string name, string hang, string loai, string chatLieu, string giaBan, string soLuong,string size) 
        { 
            this.Id = id;
            this.Name = name;
            this.Hang = hang;
            this.Loai = loai;
            this.ChatLieu= chatLieu;
            this.Size = size;
            this.GiaBan= giaBan;
            this.SoLuong= soLuong;
        
        }

        public SanPham() { }

        public SanPham( DataRow row) 
        {

            this.Id = row["idSanPham"].ToString();
            this.Name = row["tenSanPham"].ToString(); 
            this.Hang = row["hangSx"].ToString();
            this.Loai = row["loaiSanPham"].ToString();
            this.ChatLieu = row["ChatLieu"].ToString();
            this.Size = row["size"].ToString();
            this.GiaBan = row["giaBan"].ToString();
            this.SoLuong = row["soLuong"].ToString();

        }
        

        // crtrl + r + e
        private string id;
        private string name;
        private string hang;
        private string loai;
        private string chatLieu;
        private string giaBan;
        private string soLuong;
        private string size;

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Hang { get => hang; set => hang = value; }
        public string Loai { get => loai; set => loai = value; }
        public string ChatLieu { get => chatLieu; set => chatLieu = value; }
        public string GiaBan { get => giaBan; set => giaBan = value; }
        public string SoLuong { get => soLuong; set => soLuong = value; }
        public string Size { get => size; set => size = value; }
    }
}
