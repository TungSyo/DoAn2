using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAO
{
    public class nhaCungCapDAO
    {
        private static nhaCungCapDAO instance;

        public static nhaCungCapDAO Instance
        {
            get { if (instance == null) instance = new nhaCungCapDAO(); return instance; }
            private set { instance = value; }
        }

        private nhaCungCapDAO() { }


        public List<nhaCungCap> list()
        {
            List<nhaCungCap> list = new List<nhaCungCap>();

            string query = "select * from dbo.nhaCC ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                nhaCungCap ds = new nhaCungCap(item);
                list.Add(ds);
            }
            return list;
        }

        public bool them(nhaCungCap a)
        {

            string query = string.Format("insert into dbo.nhaCC(idNhaCC,tenNhaCC,sdtNhaCC,diaChiNhaCC)values('{0}',N'{1}',N'{2}',N'{3}')", a.Id, a.Name, a.Sdt,a.DiaChi);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }


        public bool sua(nhaCungCap a)
        {
            string query = string.Format("UPDATE dbo.nhaCC set tenNhaCC= N'{1}',sdtNhaCC=N'{2}',diaChiNhaCC=N'{3}'   where idNhaCC ='{0}'", a.Id, a.Name, a.Sdt, a.DiaChi);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool xoa(nhaCungCap a)
        {
            string query = string.Format("delete from  dbo.nhaCC where idNhaCC='{0}'", a.Id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;

        }

        public bool checkId(nhaCungCap a)
        {

            string query = string.Format("select * from  dbo.nhaCC where idNhaCC='{0}'", a.Id);
           
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;

        }
    }
}
