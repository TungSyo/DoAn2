using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAO
{
    public class khachHangDAO
    {

        private static khachHangDAO instance;

        public static khachHangDAO Instance
        {
            get { if (instance == null) instance = new khachHangDAO(); return instance; }
            private set { instance = value; }
        }

        private khachHangDAO() { }


        public List<KhachHang> list()
        {
            List<KhachHang> list = new List<KhachHang>();

            string query = "select * from dbo.khachHang ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                KhachHang ds = new KhachHang(item);
                list.Add(ds);
            }
            return list;
        }

        public bool them(KhachHang a)
        {

            string query = string.Format("insert into dbo.khachHang(idKhachHang,tenKhachHang,sdtKhachHang) values ('{0}',N'{1}',N'{2}')", a.Id, a.Name, a.Sdt);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }


        public bool sua(KhachHang a)
        {
            string query = string.Format("UPDATE dbo.khachHang set tenKhachHang =N'{1}',sdtKhachHang=N'{2}' where  idKhachHang = '{0}'", a.Id, a.Name, a.Sdt);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool xoa(KhachHang a)
        {
            string query = string.Format("delete from  dbo.khachHang where idKhachHang='{0}'", a.Id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;

        }

        public bool checkId(KhachHang a)
        {

            string query = string.Format("select * from  dbo.khachHang where idKhachHang='{0}'", a.Id);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;

        }
    }
}
