using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUẢN_LÝ_CỬA_HÀNG_BÁN_GIÀY_SNEAKER
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
            OpenChildForm(new fTrangChu());
        }
        private Form currentFormChild1;
        private void OpenChildForm(Form FormChild)
        {
            if (currentFormChild1 != null)
            {
                currentFormChild1.Close();
            }
            currentFormChild1 = FormChild;
            FormChild.TopLevel = false;
            FormChild.FormBorderStyle = FormBorderStyle.None;
            FormChild.Dock = DockStyle.Fill;
            panel1.Controls.Add(currentFormChild1);
            panel1.Tag = FormChild;
            FormChild.BringToFront();
            FormChild.Show();
        }
        private void main_Load(object sender, EventArgs e)
        {

        }

        private void nHÂNVIÊNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (int.Parse(Program.quyen) > 0)
            {
                nHÂNVIÊNToolStripMenuItem.Enabled = false;
                MessageBox.Show("bạn không đủ quyền hạn");


            }
            else
            {
                try
                {
                    OpenChildForm(new FQuanLyNhanVien());
                }
                catch (Exception ex) { MessageBox.Show("lỗi"); }
            }
        }

        private void nHÀCUNGCẤPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (int.Parse(Program.quyen) > 0)
            {

                nHÀCUNGCẤPToolStripMenuItem.Enabled = false;
                MessageBox.Show("bạn không đủ quyền hạn");


            }
            else
            {
                try
                {
                    OpenChildForm(new FQuanLyNhaCC());

                }
                catch (Exception ex) { MessageBox.Show("lỗi"); }
            }
        }

        private void sẢNPHẨMToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (int.Parse(Program.quyen) > 0)
            {

                sẢNPHẨMToolStripMenuItem.Enabled = false;
                MessageBox.Show("bạn không đủ quyền hạn");


            }
            else
            {
                try
                {
                    OpenChildForm(new fQuanLySanPham());

                }
                catch (Exception ex) { MessageBox.Show("lỗi"); }
            }
        }

        private void hÓAĐƠNNHẬPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (int.Parse(Program.quyen) > 0)
            {

                hÓAĐƠNNHẬPToolStripMenuItem.Enabled = false;
                MessageBox.Show("bạn không đủ quyền hạn");


            }
            else
            {
                try
                {
                    OpenChildForm(new FhoaDonNhap());

                }
                catch (Exception ex) { MessageBox.Show("lỗi"); }
            }
        }

        private void hÓAĐƠNBÁNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenChildForm(new fHoaDonBan());

            }
            catch (Exception ex) { MessageBox.Show("lỗi"); }
        }

        private void tRANGCHURToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenChildForm(new fTrangChu());

            }
            catch (Exception ex) { MessageBox.Show("lỗi"); }
        }

        private void kHÁCHHÀNGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenChildForm(new FquanLyKhachHang());

            }
            catch (Exception ex) { MessageBox.Show("lỗi"); }
        }

        private void tHỐNGKÊToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (int.Parse(Program.quyen) > 0)
            {

                sẢNPHẨMToolStripMenuItem.Enabled = false;
                MessageBox.Show("bạn không đủ quyền hạn");


            }
            else
            {
                try
                {
                    OpenChildForm(new FthongKeDoanhThuBan());

                }
                catch (Exception ex) { MessageBox.Show("lỗi"); }
            }
        }

        
    }
}
