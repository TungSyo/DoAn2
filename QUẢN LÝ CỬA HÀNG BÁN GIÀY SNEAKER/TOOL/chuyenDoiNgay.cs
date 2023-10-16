using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOOL
{
    public class chuyenDoiNgay
    {
       

        public static string ConvertDateTime(string date)
        {
            string c = date.Remove(10);
            string[] elements = c.Split('/');
            string dt = string.Format("{2}/{1}/{0}", elements[0], elements[1], elements[2]);

            return dt;
        }

        public static string chuyenId(string date)
        {
            string c = date.Remove(10);
            string[] elements = c.Split('/');
            string dt = string.Format("{2}{1}{0}", elements[0], elements[1], elements[2].Substring(2, 4));

            return dt;
        }


    }
}
