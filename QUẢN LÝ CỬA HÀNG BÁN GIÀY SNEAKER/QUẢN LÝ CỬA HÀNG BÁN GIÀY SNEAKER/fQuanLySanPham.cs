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
    public partial class fQuanLySanPham : Form
    {
        public fQuanLySanPham()
        {
            InitializeComponent();
        }

        SanPham getDataFrom()
        {
            SanPham a = new SanPham();
            a.Id = txtId.Text;
            a.Name = txtName.Text;
            a.Hang= txtHang.Text;
            a.ChatLieu= txtChatLieu.Text;
            a.Loai = ccbLoaiSp.SelectedItem.ToString();
            a.Size= ccbSize.SelectedItem.ToString();
            a.GiaBan=txtGiaBan.Text;

            return a;
        }

        void xoaTextBox()
        {
            txtId.Text = "";
            txtName.Text = "";
            txtChatLieu.Text = "";
            txtId.Enabled = true;
            txtGiaBan.Text = "";
            ccbLoaiSp.SelectedItem=null;
            ccbSize.SelectedItem=null;
            txtHang.Text= "";
        }
        void load()
        {
            dgvDS.DataSource= sanPhamBLL.Instance.ds();
            btnBoQua.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;
        }




        private void fQuanLySanPham_Load(object sender, EventArgs e)
        {
            load();
            xoaTextBox();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(sanPhamBLL.Instance.them(getDataFrom()));
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
               MessageBox.Show(sanPhamBLL.Instance.sua(getDataFrom()));
            load();
            xoaTextBox();
            }
            catch
            {
                MessageBox.Show("lỗi");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            MessageBox.Show(sanPhamBLL.Instance.xoa(getDataFrom()));
            load();
            xoaTextBox();
            try
            {
                
            }
            catch
            {
                MessageBox.Show("lỗi");
            }
        }

        private void dgvDS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // kiểm tra hàng được click là hàng thực sự, không phải hàng tiêu đề
            {
                DataGridViewRow row = dgvDS.Rows[e.RowIndex];

                txtId.Text = row.Cells[0].Value.ToString();
                txtName.Text = row.Cells[1].Value.ToString();
                txtHang.Text = row.Cells[2].Value.ToString();
                ccbLoaiSp.SelectedItem = row.Cells[3].Value.ToString();
                txtChatLieu.Text = row.Cells[4].Value.ToString();

                txtGiaBan.Text = row.Cells[5].Value.ToString();
                string a;
                a= row.Cells[7].Value.ToString().Substring(0, 7);
                ccbSize.SelectedItem = a;
                //ccbSize.SelectedItem = "size 29";


                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                txtId.Enabled = false;
                btnThem.Enabled = false;
                btnBoQua.Enabled = true;
            }
        }

        private void ccbSize_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            load();
            xoaTextBox();
        }
    }
}
