using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL
{
    public class nhanVienBLL
    {

        private static nhanVienBLL instance;

        public static nhanVienBLL Instance
        {
            get { if (instance == null) instance = new nhanVienBLL(); return instance; }
            private set { instance = value; }
        }
        public bool dangNhap(string tk, string mk)
        {
            return nhanVienDAO.Instance.Login(tk, mk);
        }

        public string[] idQuyen(string tk, string mk)
        {
            return nhanVienDAO.Instance.IdQuyen(tk, mk);
        }



        public List<nhanVien> ds()
        {
            return nhanVienDAO.Instance.list();
        }

        public string them(nhanVien a)
        {
            if(nhanVienDAO.Instance.them(a))
            {
                return "thành công";
            }
            else
            {
                return "thất bại";
            }
        }
        public string sua(nhanVien a)
        {
            if (nhanVienDAO.Instance.sua(a))
            {
                return "thành công";
            }
            else
            {
                return "thất bại";
            }
        }

        public string xoa(nhanVien a)
        {
            if (nhanVienDAO.Instance.xoa(a))
            {
                return "thành công";
            }
            else
            {
                return "thất bại";
            }
        }
    }
}
