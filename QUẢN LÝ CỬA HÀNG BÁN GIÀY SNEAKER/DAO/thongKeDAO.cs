using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class thongKeDAO
    {

        private static thongKeDAO instance;

        public static thongKeDAO Instance
        {
            get { if (instance == null) instance = new thongKeDAO(); return thongKeDAO.instance; }
            private set { thongKeDAO.instance = value; }
        }


        public List<thongKe> thongKethang(string thang, string nam)
        {
            List<thongKe> list = new List<thongKe>();

            string query = string.Format("SELECT * FROM fn_DoanhThuTheoThang({0}, {1}) ", thang, nam);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                thongKe baoCao = new thongKe(item);
                list.Add(baoCao);
            }
            return list;
        }

        public DataTable inThongKethang(string thang, string nam)
        {
            DataTable tblThong;
            string sql = string.Format("SELECT * FROM fn_DoanhThuTheoThang({0}, {1}) ", thang, nam);
            tblThong = DataProvider.Instance.ExecuteQuery(sql);

            return tblThong;
        }
    }
}
