using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL
{
    public class khachHangBLL
    {


        private static khachHangBLL instance;

        public static khachHangBLL Instance
        {
            get { if (instance == null) instance = new khachHangBLL(); return instance; }
            private set { instance = value; }
        }



        public List<KhachHang> ds()
        {
             return khachHangDAO.Instance.list();
        }

        public string them(KhachHang a)
        {
            if (khachHangDAO.Instance.them(a))
            {
                return "thành công";
            }
            else
            {
                return "thất bại";
            }
        }
        public string sua(KhachHang a)
        {
            if (khachHangDAO.Instance.sua(a))
            {
                return "thành công";
            }
            else
            {
                return "thất bại";
            }
        }

        public string xoa(KhachHang a)
        {
            if (khachHangDAO.Instance.xoa(a))
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
