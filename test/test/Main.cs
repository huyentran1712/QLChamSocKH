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
    public partial class Main : Form
    {
        public Main()
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

        private void thốngKêKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_ThongKeKH frm = new frm_ThongKeKH();
            frm.MdiParent = this;
            frm.Show();
        }

        private void dịchVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_DichVu kh = new F_DichVu();
            kh.MdiParent = this;
            kh.Show();
        }
    }
}
