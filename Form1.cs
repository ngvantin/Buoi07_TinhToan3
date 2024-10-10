using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Buoi07_TinhToan3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtSo1.Text = txtSo2.Text = "0";
            radCong.Checked = true;             //đầu tiên chọn phép cộng
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Bạn có thực sự muốn thoát không?",
                                 "Thông báo", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
                this.Close();
        }

        private void btnTinh_Click(object sender, EventArgs e)
        {
            //lấy giá trị của 2 ô số
            double so1, so2, kq = 0;
           
            if (string.IsNullOrWhiteSpace(txtSo1.Text))
            {
                MessageBox.Show("Vui lòng nhập số thứ nhất.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSo1.Focus();
                return;
            }

            // Kiểm tra nếu ô số 2 trống
            if (string.IsNullOrWhiteSpace(txtSo2.Text))
            {
                MessageBox.Show("Vui lòng nhập số thứ hai.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSo2.Focus();
                return;
            }

            // Kiểm tra xem giá trị nhập vào có phải là số hợp lệ hay không
            if (!double.TryParse(txtSo1.Text, out so1))
            {
                MessageBox.Show("Số thứ nhất không hợp lệ. Vui lòng nhập một số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSo1.Clear();
                txtSo1.Focus();
                return;
            }

            if (!double.TryParse(txtSo2.Text, out so2))
            {
                MessageBox.Show("Số thứ hai không hợp lệ. Vui lòng nhập một số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSo2.Clear();
                txtSo2.Focus();
                return;
            }

            //Thực hiện phép tính dựa vào phép toán được chọn
            if (radCong.Checked) kq = so1 + so2;
            else if (radTru.Checked) kq = so1 - so2;
            else if (radNhan.Checked) kq = so1 * so2;
            else if (radChia.Checked && so2 != 0) kq = so1 / so2;
            //Hiển thị kết quả lên trên ô kết quả
            txtKq.Text = kq.ToString();
        }
    }
}
