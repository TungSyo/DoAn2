using DAO;
using DTO;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL
{
    public class banBLL
    {
        private static banBLL instance;

        public static banBLL Instance
        {
            get { if (instance == null) instance = new banBLL(); return instance; }
            private set { instance = value; }
        }



       

        public List<hoaDonBan> ds(string ngay)
        {
            return hoaDonBanDAO.Instance.list(ngay);
        }

        public string them(hoaDonBan a)
        {
            if (hoaDonBanDAO.Instance.them(a))
            {
                return "thành công";
            }
            else
            {
                return "thất bại";
            }
        }


        public string xoa(hoaDonBan a)
        {
            if (hoaDonBanDAO.Instance.xoa(a))
            {
                return "thành công";
            }
            else
            {
                return "thất bại";
            }
        }



        public void inHoaDon(string ma)
        {

            IWorkbook workbook = new XSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("Sheet1");
            IRow row;
            ICell cell;

            int hang = 0, cot = 0;
            DataTable tblThongtinHD = hoaDonBanDAO.Instance.inHd(ma);
            // Định dạng chung
            ICellStyle generalStyle = workbook.CreateCellStyle();
            IFont generalFont = workbook.CreateFont();
            generalFont.FontName = "Times New Roman";
            generalStyle.SetFont(generalFont);
           

            ICellStyle headerStyle = workbook.CreateCellStyle();
            IFont headerFont = workbook.CreateFont();
            headerFont.FontName = "Times New Roman";
            headerFont.IsBold = true;
            headerFont.Color = IndexedColors.Blue.Index;
            headerStyle.SetFont(headerFont);
           

            ICellStyle titleStyle = workbook.CreateCellStyle();
            IFont titleFont = workbook.CreateFont();
            titleFont.FontName = "Times New Roman";
            titleFont.FontHeight = 16;
            titleFont.IsBold = true;
            titleFont.Color = IndexedColors.Red.Index;
            titleStyle.SetFont(titleFont);

            // Định dạng tiêu đề
            row = sheet.CreateRow(0);
            cell = row.CreateCell(0);
            cell.SetCellValue("Cửa hàng bán giày Duck ");
            cell.CellStyle = headerStyle;
            sheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, 1));

            row = sheet.CreateRow(1);
            cell = row.CreateCell(0);
            cell.SetCellValue("ÂHưng Yên");
            cell.CellStyle = headerStyle;
            sheet.AddMergedRegion(new CellRangeAddress(1, 1, 0, 1));

            row = sheet.CreateRow(2);
            cell = row.CreateCell(0);
            cell.SetCellValue("Điện thoại: 0363946628");
            cell.CellStyle = headerStyle;
            sheet.AddMergedRegion(new CellRangeAddress(2, 2, 0, 1));

            row = sheet.CreateRow(1);
            cell = row.CreateCell(2);
            cell.SetCellValue("HÓA ĐƠN");
            cell.CellStyle = titleStyle;
            sheet.AddMergedRegion(new CellRangeAddress(1, 1, 2, 4));

            // Tiêu đề cột
            row = sheet.CreateRow(11);
            row.RowStyle = headerStyle;
            cell = row.CreateCell(0);
            
            cell.SetCellValue("Tên hàng");
            cell = row.CreateCell(1);
            cell.SetCellValue("Số lượng");
            cell = row.CreateCell(2);
            cell.SetCellValue("Giá bán");
            cell = row.CreateCell(3);
            cell.SetCellValue("Thành tiền");

            // Thêm dữ liệu
            DataTable tblThongtinHang;
            tblThongtinHang = hoaDonBanDAO.Instance.tblThong(ma);

        for (hang = 0; hang < tblThongtinHang.Rows.Count; hang++)
            {
                row = sheet.CreateRow(hang + 12);
                for (cot = 0; cot < tblThongtinHang.Columns.Count; cot++)
                {
                    cell = row.CreateCell(cot);
                    cell.SetCellValue(tblThongtinHang.Rows[hang][cot].ToString());
                }
            }

            // Ô Tổng tiền
            row = sheet.CreateRow(hang + 14);
            cell = row.CreateCell(cot);
            cell.CellStyle = headerStyle;
            cell.SetCellValue("Tổng tiền:");

            cell = row.CreateCell(cot + 1);
            cell.CellStyle = headerStyle;
            cell.SetCellValue(tblThongtinHD.Rows[0][2].ToString());

            // Ô Bằng chữ
            row = sheet.CreateRow(hang + 15);
            cell = row.CreateCell(0);
            cell.CellStyle = headerStyle;
           
            cell.CellStyle.Alignment = HorizontalAlignment.Right;
            cell.CellStyle.WrapText = true;
            sheet.AddMergedRegion(new CellRangeAddress(hang + 15, hang + 15, 0, 5));

            // Ô Ngày tháng
            row = sheet.CreateRow(hang + 17);
            cell = row.CreateCell(0);
            cell.CellStyle = headerStyle;
            DateTime d = Convert.ToDateTime(tblThongtinHD.Rows[0][1]);
            cell.SetCellValue("Hưng Yên, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year);
            sheet.AddMergedRegion(new CellRangeAddress(hang + 17, hang + 17, 0, 2));

            row = sheet.CreateRow(hang + 18);
            cell = row.CreateCell(0);
            cell.CellStyle = headerStyle;
            cell.SetCellValue("Nhân viên bán hàng");
            sheet.AddMergedRegion(new CellRangeAddress(hang + 18, hang + 18, 0, 2));

            row = sheet.CreateRow(hang + 22);
            cell = row.CreateCell(0);
            cell.CellStyle = headerStyle;
            //cell.SetCellValue(tblThongtinHD.Rows[0][6]);
            sheet.AddMergedRegion(new CellRangeAddress(hang + 22, hang + 22, 0, 2));

            string filePath = "C:\\Users\\pc\\Desktop\\in Hoa đơn\\Hóa đơn "+ma+".xlsx";
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                workbook.Write(fileStream);
            }

            Console.WriteLine($"Đã tạo một tệp tin mới tại đường dẫn: {filePath}");
            Console.ReadLine();



        }
    }
}
