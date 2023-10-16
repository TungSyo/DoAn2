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
    public class hoaDonNhapDAO
    {

        private static hoaDonNhapDAO instance;

        public static hoaDonNhapDAO Instance
        {
            get { if (instance == null) instance = new hoaDonNhapDAO(); return instance; }
            private set { instance = value; }
        }

        private hoaDonNhapDAO() { }


        


     



        public List<hoaDonnhap> list(string a)
        {
            List<hoaDonnhap> list = new List<hoaDonnhap>();

            string query = string.Format("select  * from  dbo.hoaDonNhap where ngayNhap='{0}'" ,chuyenDoiNgay.ConvertDateTime(a));
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                hoaDonnhap ds = new hoaDonnhap(item);
                list.Add(ds);
            }
            return list;
        }

        public bool them(hoaDonnhap a)
        {

            string query = string.Format("insert into dbo.hoaDonNhap(idHoaDonNhap,idNhanVien,idNhaCC,ngayNhap,tongTien) values('{0}','{1}','{2}','{3}',0)", a.Id,a.IdNhanVien,a.IdNhaCungCap, chuyenDoiNgay.ConvertDateTime(a.Ngaynhap));
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool xoa(hoaDonnhap a)
        {
            string query = string.Format("delete from  dbo.hoaDonNhap where idHoaDonNhap='{0}'", a.Id);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;

        }

        public bool checkId(hoaDonnhap a)
        {

            string query = string.Format("select * from  dbo.hoaDonNhap where idHoaDonNhap='{0}'", a.Id);
            
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;

        }




    }
}
