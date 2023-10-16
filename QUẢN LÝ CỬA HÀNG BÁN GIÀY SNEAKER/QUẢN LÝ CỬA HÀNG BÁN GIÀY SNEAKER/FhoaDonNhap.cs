using BLL;
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
using TOOL;

namespace QUẢN_LÝ_CỬA_HÀNG_BÁN_GIÀY_SNEAKER
{
    public partial class FhoaDonNhap : Form
    {


        hoaDonnhap get()
        {
            hoaDonnhap a = new hoaDonnhap();
            a.Id = txtId.Text;
            a.IdNhanVien = Program.id;

            a.IdNhaCungCap = txtIdNhaCC.Text;

            a.Ngaynhap = DateTime.Now.ToString();
            return a;
        }

        ctHoaDonNhap getCtDon()
        {
            ctHoaDonNhap a =new ctHoaDonNhap();
            a.IdHoaDonNhap = txtId.Text;
            a.IdSanpham = txtMaSp.Text;
            a.SoLuong = (int)Soluong.Value;
            a.DonGia = txtGiaSp.Text;
            return a;

        }


        void load()
        {
            dsvHD.DataSource=nhapBLL.Instance.ds(DateTime.Now.ToString());


        }

        void loadSp()
        {


            dgvSanPham.DataSource=ctNhapBLL.Instance.ds(getCtDon().IdHoaDonNhap);
        }

        void xoaTextHD()
        {
            txtId.Enabled = true;
            btnXoaHD.Enabled = false;
            btnThemHD.Enabled = true;
            btnXoaHD.Enabled = true;
        }


        void xoaTextsp()
        {
            txtMaSp.Enabled = true;
            btnThemSp.Enabled = true;
            btnXoaSp.Enabled = false;

        }
        public FhoaDonNhap()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void FhoaDonNhap_Load(object sender, EventArgs e)
        {
            load();
        }

        private void dsvHD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // kiểm tra hàng được click là hàng thực sự, không phải hàng tiêu đề
            {
                DataGridViewRow row = dsvHD.Rows[e.RowIndex];

                txtId.Text = row.Cells[0].Value.ToString();
                txtIdNhaCC.Text = row.Cells[2].Value.ToString();

                txtId.Enabled = false;
                txtIdNhaCC.Enabled = false;
                loadSp();




            }
        }

        private void btnThemHD_Click(object sender, EventArgs e)
        {
           
            try
            {
                MessageBox.Show(nhapBLL.Instance.them(get()));
            load();
            xoaTextHD();
            }
            catch
            {
                MessageBox.Show("bạn phải nhập lại có thể bị trùng id");
            }
        }

        private void btnThemSp_Click(object sender, EventArgs e)
        {
            
            try
            {
                MessageBox.Show(ctNhapBLL.Instance.them(getCtDon()));
                loadSp();
                xoaTextsp();
            }
            catch
            {
                MessageBox.Show("bạn phải nhập lại ");
            }
        }

        private void dgvSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // kiểm tra hàng được click là hàng thực sự, không phải hàng tiêu đề
            {
                DataGridViewRow row = dgvSanPham.Rows[e.RowIndex];

                txtMaSp.Text = row.Cells[1].Value.ToString();


                txtMaSp.Enabled = false;
                btnXoaSp.Enabled = true;
                loadSp();




            }
        }

        private void btnXoaSp_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(ctNhapBLL.Instance.xoa(getCtDon()));
                loadSp();
                xoaTextsp();
            }
            catch
            {
                MessageBox.Show("bạn phải nhập lại ");
            }
        }

        private void btnBoQuaSP_Click(object sender, EventArgs e)
        {
            loadSp();
            xoaTextsp();
        }

        private void btnXoaHD_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(nhapBLL.Instance.xoa(get()));
                load();
                xoaTextHD();
            }
            catch
            {
                MessageBox.Show("bạn phải nhập lại có thể bị trùng id");
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                dsvHD.DataSource= nhapBLL.Instance.ds(dateTk.Value.ToString());
            }
            catch { MessageBox.Show("lỗi"); }
        }
    }
}
