using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test
{
    public partial class DangNhap : Form
    {
        KNCSDL dl = new KNCSDL();
        public DangNhap()
        {
            InitializeComponent();
        }

     

        private void DangNhap_Load(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = dl.LayDanhSachNhanVien();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if( dl.KiemTraDangNhap(textBox1.Text, textBox2.Text))
            {
                MessageBox.Show("Đăng nhập thành công");
                this.Hide();
                Main a = new Main();
                a.Show();

            }   
            else
            {
                MessageBox.Show("Đăng nhập không thành công. Vui lòng kiểm tra lại tài khoản và mật khẩu.");

            }
        }
    }
}
