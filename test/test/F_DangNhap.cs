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
    public partial class F_DangNhap : Form
    {
        KNCSDL kn = new KNCSDL();
        
        public F_DangNhap()
        {
            InitializeComponent();
        }

     

        private void DangNhap_Load(object sender, EventArgs e)
        {
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
          
            if( kn.KiemTraDangNhap(textBox1.Text, textBox2.Text))
            {
                TTTK.Instance.Taikhoan = textBox1.Text;
                TTTK.Instance.Matkhau = textBox2.Text;
                MessageBox.Show("Đăng nhập thành công");
                this.Hide();
                F_Main a = new F_Main();
                a.Show();

            }   
            else
            {
                MessageBox.Show("Đăng nhập không thành công. Vui lòng kiểm tra lại tài khoản và mật khẩu.");

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }
    }
}
