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

namespace QUẢN_LÝ_CỬA_HÀNG_BÁN_GIÀY_SNEAKER
{
    public partial class FQuanLyNhaCC : Form
    {
        public FQuanLyNhaCC()
        {
            InitializeComponent();
        }

        nhaCungCap getDataFrom()
        {
            nhaCungCap a = new nhaCungCap();
            a.Id = txtId.Text;
            a.Name = txtName.Text;
            a.DiaChi = txtDiaChi.Text;
            a.Sdt = txtSdt.Text;
            return a;
        }

        void xoaTextBox()
        {
            txtId.Text = "";
            txtName.Text = "";
            txtDiaChi.Text = "";
            txtSdt.Text = "";
            txtId.Enabled = true;
        }

        void load()
        {
            dgvDS.DataSource= nhaCCBLL.Instance.ds();
            btnBoQua.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            try
            {
                MessageBox.Show(nhaCCBLL.Instance.them(getDataFrom()));
                load();
                xoaTextBox();
            }
            catch
            {
                MessageBox.Show("bạn phải nhập lại có thể bị trùng id");
            }
        }

        private void FQuanLyNhaCC_Load(object sender, EventArgs e)
        {

            load();
            xoaTextBox();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(nhaCCBLL.Instance.sua(getDataFrom()));
                load();
                xoaTextBox();
            }
            catch
            {
                MessageBox.Show("bạn phải nhập lại ");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(nhaCCBLL.Instance.xoa(getDataFrom()));
                load();
                xoaTextBox();
            }
            catch
            {
                MessageBox.Show("bạn phải nhập lại ");
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
                txtDiaChi.Text = row.Cells[3].Value.ToString();
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
