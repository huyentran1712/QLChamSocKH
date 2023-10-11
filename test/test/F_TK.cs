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
    public partial class F_TK : Form
    {
        KNCSDL kn = new KNCSDL();
        public F_TK()
        {
            InitializeComponent();
        }

        private void F_TK_Load(object sender, EventArgs e)
        {
            NhanVien a = kn.LayThongTin1NhanVien();
            label5.Text = a.Manv;
            label6.Text = a.tennv;
            label7.Text = a.Sdtnv;
            label8.Text = a.Email;
        }
    }
}
