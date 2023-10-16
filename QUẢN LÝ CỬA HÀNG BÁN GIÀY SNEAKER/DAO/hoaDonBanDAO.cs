using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TOOL;

namespace DAO
{
    public class hoaDonBanDAO
    {

        private static hoaDonBanDAO instance;

        public static hoaDonBanDAO Instance
        {
            get { if (instance == null) instance = new hoaDonBanDAO(); return instance; }
            private set { instance = value; }
        }

        private hoaDonBanDAO() { }


        


   


        public List<hoaDonBan> list(string a)
        {
            List<hoaDonBan> list = new List<hoaDonBan>();

            string query = string.Format("select  * from  dbo.hoaDonBan where ngayBan='{0}'", chuyenDoiNgay.ConvertDateTime(a));
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                hoaDonBan ds = new hoaDonBan(item);
                list.Add(ds);
            }
            return list;
        }

        public bool them(hoaDonBan a)
        {

            string query = string.Format("insert into dbo.hoaDonBan(idHoaDonBan,idNhanVien,idKhachHang,ngayBan,tongTien)values('{0}','{1}','{2}','{3}',0)", a.Id, a.IdNhanVien, a.IdKhachHang, chuyenDoiNgay.ConvertDateTime(a.NgayBan));

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool xoa(hoaDonBan a)
        {
            string query = string.Format("delete from  dbo.hoaDonBan where idHoaDonBan='{0}'", a.Id);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;

        }

        public bool checkId(hoaDonBan a)
        {

            string query = string.Format("select * from  dbo.hoaDonBan where idHoaDonBan='{0}'", a.Id);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;

        }


        public DataTable inHd(string ma)
        {
            DataTable tblThongtinHang;
            string sql = " SELECT a.idHoaDonBan, a.ngayBan, a.Tongtien, b.tenKhachHang, b.sdtKhachHang, c.tenNv FROM hoaDonBan AS a, khachHang AS b, nhanVien AS c WHERE a.idHoaDonBan = '" + ma + "' AND a.idKhachHang = b.idKhachHang AND a.idNhanVien = c.idNhanVien";
            tblThongtinHang = DataProvider.Instance.ExecuteQuery(sql);

            return tblThongtinHang;
        }


        public DataTable tblThong(string ma)
        {
            DataTable tblThong;
            string sql = "SELECT x.tenSanPham, a.soLuong, x.giaBan, a.giaBan FROM chiTietHoaDonBan AS a , hoaDonBan AS b , dbo.sanPham as x WHERE a.idChiTietHoaDonBan = '" + ma + "' AND a.idChiTietHoaDonBan = b.idHoaDonBan and a.idSanPham = x.idSanPham";
            tblThong = DataProvider.Instance.ExecuteQuery(sql);

            return tblThong;
        }
    }
}
