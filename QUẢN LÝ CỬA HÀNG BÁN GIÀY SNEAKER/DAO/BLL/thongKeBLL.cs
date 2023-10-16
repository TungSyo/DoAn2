using DAO;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.SS.UserModel;
using COMExcel = NPOI.XSSF.UserModel; 

using System.Data;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using System.IO;

namespace cuaHangBanRauCu
{
    public class thongKeBLL
    {

        private static thongKeBLL instance; // Ctrl + R + E

        public static thongKeBLL Instance
        {
            get { if (instance == null) instance = new thongKeBLL(); return thongKeBLL.instance; }
            private set { thongKeBLL.instance = value; }
        }


        public List<thongKe> dsNhapNgay(string thang, string nam)
        {
            return thongKeDAO.Instance.thongKethang(thang, nam);
        }

        public void inthongKethang(string thang, string nam)
        {
            // Khởi động chương trình Excel
            IWorkbook workbook = new XSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("Sheet1");
            IRow row;
            ICell cell;

            int hang = 0, cot = 0;

            // Định dạng chung
            ICellStyle generalStyle = workbook.CreateCellStyle();
            IFont generalFont = workbook.CreateFont();
            generalFont.FontName = "Times New Roman";
            generalStyle.SetFont(generalFont);

            ICellStyle headerStyle = workbook.CreateCellStyle();
            IFont headerFont = workbook.CreateFont();
            headerFont.FontName = "Times New Roman";
            headerFont.FontHeight = 10;
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
            cell.SetCellValue("Cửa hàng bán giày Duck");
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
            cell.SetCellValue("Thống kê");
            cell.CellStyle = titleStyle;
            sheet.AddMergedRegion(new CellRangeAddress(1, 1, 2, 4));

            // Tiêu đề cột
            row = sheet.CreateRow(11);
            row.RowStyle = headerStyle;
            cell = row.CreateCell(0);
            cell.SetCellValue("STT");
            cell = row.CreateCell(1);
            cell.SetCellValue("Ngày");
            cell = row.CreateCell(2);
            cell.SetCellValue("Doanh thu");

            // Thêm dữ liệu
            System.Data.DataTable thongke;
            thongke = thongKeDAO.Instance.inThongKethang(thang, nam);

            for (hang = 0; hang < thongke.Rows.Count; hang++)
            {
                row = sheet.CreateRow(hang + 12);

                cell = row.CreateCell(0);
                cell.SetCellValue(hang + 1);

                for (cot = 0; cot < thongke.Columns.Count; cot++)
                {
                    cell = row.CreateCell(cot + 1);
                    cell.SetCellValue(thongke.Rows[hang][cot].ToString());
                }
            }

            // Thiết lập định dạng cho các cột
            sheet.SetColumnWidth(0, 7 * 256);
            sheet.SetColumnWidth(1, 15 * 256);
            workbook = new XSSFWorkbook();
            sheet = workbook.CreateSheet("Sheet1");




            // Định dạng chung
            generalStyle = workbook.CreateCellStyle();
            generalFont = workbook.CreateFont();
            generalFont.FontName = "Times New Roman";
            generalStyle.SetFont(generalFont);

            headerStyle = workbook.CreateCellStyle();
            headerFont = workbook.CreateFont();
            headerFont.FontName = "Times New Roman";
            headerFont.FontHeight = 10;
            headerFont.IsBold = true;
            headerFont.Color = IndexedColors.Blue.Index;
            headerStyle.SetFont(headerFont);

            titleStyle = workbook.CreateCellStyle();
            titleFont = workbook.CreateFont();
            titleFont.FontName = "Times New Roman";
            titleFont.FontHeight = 16;
            titleFont.IsBold = true;
            titleFont.Color = IndexedColors.Red.Index;
            titleStyle.SetFont(titleFont);

            // Định dạng tiêu đề
            row = sheet.CreateRow(0);
            cell = row.CreateCell(0);
            cell.SetCellValue("Cửa hàng bán giày Duck");
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
            cell.SetCellValue("Thống kê");
            cell.CellStyle = titleStyle;
            sheet.AddMergedRegion(new CellRangeAddress(1, 1, 2, 4));

            // Tiêu đề cột
            row = sheet.CreateRow(11);
            row.RowStyle = headerStyle;
            cell = row.CreateCell(0);
            cell.SetCellValue("STT");
            cell = row.CreateCell(1);
            cell.SetCellValue("Ngày");
            cell = row.CreateCell(2);
            cell.SetCellValue("Doanh thu");

            // Thêm dữ liệu

            thongke = thongKeDAO.Instance.inThongKethang(thang, nam);

            for (hang = 0; hang < thongke.Rows.Count; hang++)
            {
                row = sheet.CreateRow(hang + 12);

                cell = row.CreateCell(0);
                cell.SetCellValue(hang + 1);

                for (cot = 0; cot < thongke.Columns.Count; cot++)
                {
                    cell = row.CreateCell(cot + 1);
                    cell.SetCellValue(thongke.Rows[hang][cot].ToString());
                }
            }

            // Thiết lập định dạng cho các cột
            sheet.SetColumnWidth(0, 7 * 256);
            sheet.SetColumnWidth(1, 15 * 256);

            // Lưu workbook vào tệp tin
            string filePath = "C:\\Users\\pc\\Desktop\\thongke\\file.xlsx";
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                workbook.Write(fileStream);
            }

        }

    }
}
