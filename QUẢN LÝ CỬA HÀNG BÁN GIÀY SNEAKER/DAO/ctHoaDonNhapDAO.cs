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
    public class ctHoaDonNhapDAO
    {
        private static ctHoaDonNhapDAO instance;

        public static ctHoaDonNhapDAO Instance
        {
            get { if (instance == null) instance = new ctHoaDonNhapDAO(); return instance; }
            private set { instance = value; }
        }

        private ctHoaDonNhapDAO() { }


        public List<ctHoaDonNhap> ds(string a)
        {
            List<ctHoaDonNhap> list = new List<ctHoaDonNhap>();

            string query = string.Format("select * from dbo.chiTietHoaDonNhap WHERE idHoaDonNhap ='{0}'",a);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                ctHoaDonNhap ds = new ctHoaDonNhap(item);
                list.Add(ds);
            }
            return list;
        }

        public bool them(ctHoaDonNhap a)
        {

            string query = string.Format("ThemHoaDonNhap @MaHoaDon , @MaSanPham , @SoLuong , @Gia");
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { a.IdHoaDonNhap, a.IdSanpham,a.SoLuong,a.DonGia /*list*/});

            return result > 0;
        }

        public bool xoa(ctHoaDonNhap a)
        {
            string query = string.Format("xoaHoaDonNhap @MaHoaDon , @MaSanPham ");
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] {a.IdHoaDonNhap,a.IdSanpham});

            return result > 0;

        }

        


    }
}
