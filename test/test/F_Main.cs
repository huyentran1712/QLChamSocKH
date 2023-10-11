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
    public partial class F_Main : Form
    {
        public F_Main()
        {
            InitializeComponent();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_KhachHang kh = new F_KhachHang();
            kh.MdiParent = this;
            kh.Show();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_NhanVien frm = new frm_NhanVien();
            frm.MdiParent = this;
            frm.Show();
        }

        private void khácToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_QL frm = new F_QL();
            frm.MdiParent = this;
            frm.Show();
        }

        private void tàiKhoảnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            F_TK frm = new F_TK();
            frm.MdiParent = this;
            frm.Show();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            F_DangNhap a = new F_DangNhap();
            a.Show();
        }

        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_ThongKe frm = new frm_ThongKe();
            frm.MdiParent = this;
            frm.Show();
        }

        private void dịchVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_DichVu frm = new frm_DichVu();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
