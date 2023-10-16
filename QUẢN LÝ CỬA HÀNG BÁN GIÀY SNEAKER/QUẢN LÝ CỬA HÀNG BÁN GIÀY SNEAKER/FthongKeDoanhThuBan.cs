using cuaHangBanRauCu;
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
    public partial class FthongKeDoanhThuBan : Form
    {
        public FthongKeDoanhThuBan()
        {
            InitializeComponent();
        }

        private void txtTongKe_Click(object sender, EventArgs e)
        {
            if (txtThang.Text == "" || txtNam.Text == "")
            {
                MessageBox.Show("nhập đẩu đủ");
            }
            else
            {
                dgvDsTk.DataSource= thongKeBLL.Instance.dsNhapNgay(txtThang.Text, txtNam.Text);
            }
        }

        private void txtInTK_Click(object sender, EventArgs e)
        {
            
                if (txtThang.Text == "" || txtNam.Text == "")
                {
                    MessageBox.Show("nhập đẩu đủ");
                }
                else
                {
                    thongKeBLL.Instance.inthongKethang(txtThang.Text, txtNam.Text);
                }
            
        }
    }
}
