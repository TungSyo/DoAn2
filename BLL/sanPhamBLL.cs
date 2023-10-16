using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL
{
    public class sanPhamBLL
    {
        private static sanPhamBLL instance;

        public static sanPhamBLL Instance
        {
            get { if (instance == null) instance = new sanPhamBLL(); return instance; }
            private set { instance = value; }
        }



        public List<SanPham> ds()
        {
            return SanPhamDAO.Instance.DsSanPham();
        }

        public string them(SanPham a)
        {
            if (SanPhamDAO.Instance.them(a))
            {
                return "thành công";
            }
            else
            {
                return "thất bại";
            }
        }
        public string sua(SanPham a)
        {
            if (SanPhamDAO.Instance.sua(a))
            {
                return "thành công";
            }
            else
            {
                return "thất bại";
            }
        }

        public string xoa(SanPham a)
        {
            if (SanPhamDAO.Instance.xoa(a))
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
