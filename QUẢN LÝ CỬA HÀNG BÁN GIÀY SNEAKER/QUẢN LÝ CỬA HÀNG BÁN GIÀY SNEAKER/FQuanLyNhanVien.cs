using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;

namespace QUẢN_LÝ_CỬA_HÀNG_BÁN_GIÀY_SNEAKER
{
    public partial class FQuanLyNhanVien : Form
    {
        public FQuanLyNhanVien()
        {
            InitializeComponent();
        }

        nhanVien  getDataFrom()
        {
            nhanVien a= new nhanVien();
            a.Id = txtId.Text;
            a.Name = txtName.Text;
            a.SdtNv = txtSdt.Text;
            a.QueQuanNv = txtQueQuan.Text;
            a.NamSinh = dtpNgaySinh.Value.ToString();
            a.LuongCb = txtLuongCoBan.Text;
            a.TaiKhoan = txtTaiKhoan.Text;
            a.MatKhau = txtMatKhau.Text;
            a.Quyen = ccbQuyen.SelectedIndex.ToString();
            return a;


        }

        void xoaTextBox()
        {
            txtId.Text = "";
            txtName.Text = "";
            txtSdt.Text = "";
            txtQueQuan.Text = "";
            dtpNgaySinh.Value = DateTime.UtcNow;
            txtLuongCoBan.Text = "";
            txtTaiKhoan.Text = "";
            txtMatKhau.Text = "";
            ccbQuyen.SelectedIndex = 0;
            txtId.Enabled = true;


        }

        void load()
        {
            dgvDS.DataSource= nhanVienBLL.Instance.ds();
            btnBoQua.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(nhanVienBLL.Instance.them(getDataFrom()));
                load();
                xoaTextBox();
            }
            catch
            {
                MessageBox.Show("bạn phải nhập lại có thể bị trùng id");
            }

        }

        private void dgvDS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0) // kiểm tra hàng được click là hàng thực sự, không phải hàng tiêu đề
                {
                    DataGridViewRow row = dgvDS.Rows[e.RowIndex];

                    txtId.Text = row.Cells[0].Value.ToString();
                    txtName.Text = row.Cells[1].Value.ToString();
                    dtpNgaySinh.Text = row.Cells[2].Value.ToString();
                    txtQueQuan.Text = row.Cells[3].Value.ToString();
                    txtSdt.Text = row.Cells[4].Value.ToString();
                    txtLuongCoBan.Text = row.Cells[5].Value.ToString();
                    txtTaiKhoan.Text = row.Cells[6].Value.ToString();
                    txtMatKhau.Text = row.Cells[7].Value.ToString();
                    string asa = row.Cells[8].Value.ToString();
                    ccbQuyen.SelectedIndex = int.Parse(asa);




                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;

                    txtId.Enabled = false;
                    btnThem.Enabled = true;
                    btnBoQua.Enabled = true;
                }
            }
            catch { MessageBox.Show("lỗi"); }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(nhanVienBLL.Instance.sua(getDataFrom()));
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
                MessageBox.Show(nhanVienBLL.Instance.xoa(getDataFrom()));
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

        private void FQuanLyNhanVien_Load(object sender, EventArgs e)
        {
            load();
        }
    }
}
