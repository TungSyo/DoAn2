using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class SanPhamDAO
    {

        private static SanPhamDAO instance;

        public static SanPhamDAO Instance
        {
            get { if (instance == null) instance = new SanPhamDAO(); return instance; }
            private set { instance = value; }
        }

        

        
        public List<SanPham> DsSanPham()
        {
            List<SanPham> list = new List<SanPham>();

            string query = "select * from dbo.sanPham ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                SanPham ds = new SanPham(item);
                list.Add(ds);
            }
            return list;
        }




        public bool kiemtraMa(string id)
        {
            string query = string.Format("select * from dbo.sanPham where idSanPham ='{0}'", id);

            int result = DataProvider.Instance.KiemTraMa(query);

            return result <= 0;
        }


        public bool xoa(SanPham a)
        {
            string query = string.Format("delete from dbo.sanPham where idSanPham ='{0}'", a.Id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }



        public bool them(SanPham a)
        {
            string query = string.Format("insert into dbo.sanPham(idSanPham,tenSanPham,hangSx,loaiSanPham,ChatLieu,size,giaBan,soLuong) VALUES(N'{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}',N'{6}',0)", a.Id,a.Name,a.Hang,a.Loai,a.ChatLieu, a.Size, a.GiaBan);



            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;

        }

        public bool sua(SanPham a)
        {
            string query = string.Format("UPDATE dbo.sanPham  SET  tenSanPham='{1}',hangSx=N'{2}',loaiSanPham=N'{3}',ChatLieu=N'{4}',size=N'{5}',giaBan={6} WHERE idSanPham= '{0}'", a.Id, a.Name, a.Hang, a.Loai, a.ChatLieu, a.Size, a.GiaBan);

            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;

        }
    }
}
