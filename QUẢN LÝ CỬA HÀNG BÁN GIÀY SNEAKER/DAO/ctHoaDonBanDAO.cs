using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAO
{
    public class ctHoaDonBanDAO
    {
        private static ctHoaDonBanDAO instance;

        public static ctHoaDonBanDAO Instance
        {
            get { if (instance == null) instance = new ctHoaDonBanDAO(); return instance; }
            private set { instance = value; }
        }

        private ctHoaDonBanDAO() { }


        public List<ctHoaDonBan> ds(ctHoaDonBan a)
        {
            List<ctHoaDonBan> list = new List<ctHoaDonBan>();

            string query = string.Format("select * from dbo.chiTietHoaDonBan WHERE idChiTietHoaDonBan ='{0}'", a.IdHoaDonBan);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                ctHoaDonBan ds = new ctHoaDonBan(item);
                list.Add(ds);
            }
            return list;
        }

        public bool them(ctHoaDonBan a)
        {

            string query = string.Format("ThemHoaDonban @MaHoaDon , @MaSanPham , @SoLuong ");
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { a.IdHoaDonBan, a.IdSanpham, a.SoLuong /*list*/});

            return result > 0;
        }

        public bool xoa(ctHoaDonBan a)
        {
            string query = string.Format("xoaHoaDonBan @MaHoaDon , @MaSanPham");
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { a.IdHoaDonBan, a.IdSanpham });

            return result > 0;

        }
    }
}
