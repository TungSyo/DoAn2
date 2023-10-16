using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL
{
    public class nhapBLL
    {

        private static nhapBLL instance;

        public static nhapBLL Instance
        {
            get { if (instance == null) instance = new nhapBLL(); return instance; }
            private set { instance = value; }
        }



        public List<hoaDonnhap> ds(string ngay)
        {
            return hoaDonNhapDAO.Instance.list(ngay);
        }

        public string them(hoaDonnhap a)
        {
            if (hoaDonNhapDAO.Instance.them(a))
            {
                return "thành công";
            }
            else
            {
                return "thất bại";
            }
        }


        public string xoa(hoaDonnhap a)
        {
            if (hoaDonNhapDAO.Instance.xoa(a))
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
