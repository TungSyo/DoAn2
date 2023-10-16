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
    public class nhanVienDAO
    {

        private static nhanVienDAO instance;

        public static nhanVienDAO Instance
        {
            get { if (instance == null) instance = new nhanVienDAO(); return instance; }
            private set { instance = value; }
        }

        private nhanVienDAO() { }


        public List<nhanVien> list()
        {
            List<nhanVien> list = new List<nhanVien>();

            string query = "select * from dbo.nhanVien ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                nhanVien nhanVien = new nhanVien(item);
                list.Add(nhanVien);
            }
            return list;
        }

        public bool them(nhanVien a)
        {

            string query = string.Format("insert into dbo.nhanVien(idNhanVien,tenNv,namSinh,queQuanNv,sdtNv,luongCb,taiKhoan,matKhau,quyen) values ('{0}',N'{1}','{2}',N'{3}','{4}',{5},'{6}','{7}',{8})",a.Id,a.Name,chuyenDoiNgay.ConvertDateTime( a.NamSinh),a.QueQuanNv,a.SdtNv,a.LuongCb,a.TaiKhoan,a.MatKhau,a.Quyen);
            
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }


        public bool sua(nhanVien a)
        {

            string query = string.Format("UPDATE dbo.nhanVien set tenNv = N'{1}' ,namSinh = '{2}',queQuanNv=N'{3}',sdtNv='{4}',luongCb={5},taiKhoan='{6}',matKhau='{7}',quyen={8} where idNhanVien='{0}'", a.Id, a.Name, chuyenDoiNgay.ConvertDateTime(a.NamSinh), a.QueQuanNv, a.SdtNv, a.LuongCb, a.TaiKhoan, a.MatKhau, a.Quyen);
           
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool xoa(nhanVien a)
        {
            string query = string.Format("delete from  dbo.nhanVien where idNhanVien='{0}'",a.Id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;

        }

        public bool checkidAndTk(nhanVien a)
        {
            string query = string.Format("select * from dbo.nhanVien where idNhanVien='{0}' or taiKhoan ='{1}'", a.Id,a.TaiKhoan);
            int result = DataProvider.Instance.KiemTraMa(query);
            

            return result > 0;
        }





        public bool Login(string userName, string passWord)
        {


            string query = "USP_Login @userName , @passWord";

            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { userName, passWord /*list*/});

            return result.Rows.Count > 0;

        }

        public string[] IdQuyen(string tk, string mk)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("Select idNhanVien,quyen from dbo.nhanVien where taiKhoan = '" + tk + "'  and matKhau='" + mk + "' ");
            string[] s = new string[2];
            foreach (DataRow row in data.Rows)
            {
                s[0] = row[0].ToString(); ;
                s[1] = row[1].ToString(); ;
                break;
            }

            return s;



        }

    }
}
