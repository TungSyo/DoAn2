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
using System.Xml;

namespace QUẢN_LÝ_CỬA_HÀNG_BÁN_GIÀY_SNEAKER
{
    public partial class FquanLyKhachHang : Form
    {
        public FquanLyKhachHang()
        {
            InitializeComponent();
        }

        KhachHang getDataFrom()
        {
            KhachHang a = new KhachHang();
            a.Id = txtId.Text;  
            a.Name = txtName.Text;
            a.Sdt = txtSdt.Text;
            return a;
        }

        void xoaTextBox()
        {
            txtId.Text = "";
            txtName.Text = "";
            txtSdt.Text = "";
            txtId.Enabled = true;
        }
        void load()
        {
            dgvDS.DataSource= khachHangBLL.Instance.ds();
            btnBoQua.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;
        }


        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }

        private void FquanLyKhachHang_Load(object sender, EventArgs e)
        {
            load();
            xoaTextBox();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(khachHangBLL.Instance.them(getDataFrom()));
                load();
                xoaTextBox();
            }
            catch
            {
                MessageBox.Show("bạn phải nhập lại có thể bị trùng id");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(khachHangBLL.Instance.sua(getDataFrom()));
                load();
                xoaTextBox();
            }
            catch
            {
                MessageBox.Show("bạn phải nhập lại có thể bị trùng id");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(khachHangBLL.Instance.xoa(getDataFrom()));
                load();
                xoaTextBox();
            }
            catch
            {
                MessageBox.Show("bạn phải nhập lại có thể bị trùng id");
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            load();
            xoaTextBox();
        }

        private void dgvDS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // kiểm tra hàng được click là hàng thực sự, không phải hàng tiêu đề
            {
                DataGridViewRow row = dgvDS.Rows[e.RowIndex];

                txtId.Text = row.Cells[0].Value.ToString();
                txtName.Text = row.Cells[1].Value.ToString();

                txtSdt.Text = row.Cells[2].Value.ToString();




                btnSua.Enabled = true;
                btnXoa.Enabled = true;

                txtId.Enabled = false;
                btnThem.Enabled = true;
                btnBoQua.Enabled = true;
            }
        }
    }
}
