using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL
{
    public class nhaCCBLL
    {

        private static nhaCCBLL instance;

        public static nhaCCBLL Instance
        {
            get { if (instance == null) instance = new nhaCCBLL(); return instance; }
            private set { instance = value; }
        }



        public List<nhaCungCap> ds()
        {
            return nhaCungCapDAO.Instance.list();
        }

        public string them(nhaCungCap a)
        {
            if (nhaCungCapDAO.Instance.them(a))
            {
                return "thành công";
            }
            else
            {
                return "thất bại";
            }
        }
        public string sua(nhaCungCap a)
        {
            if (nhaCungCapDAO.Instance.sua(a))
            {
                return "thành công";
            }
            else
            {
                return "thất bại";
            }
        }

        public string xoa(nhaCungCap a)
        {
            if (nhaCungCapDAO.Instance.xoa(a))
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
