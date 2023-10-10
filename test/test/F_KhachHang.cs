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
    public partial class F_KhachHang : Form
    {
        KNCSDL a = new KNCSDL();
        public F_KhachHang()
        {
            InitializeComponent();
        }

        private void F_KhachHang_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = a.LoadAll_KH();
        }
    }
}
