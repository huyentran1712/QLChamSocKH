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
    public partial class F_QL : Form
    {
        KNCSDL kn = new KNCSDL();
        public F_QL()
        {
            InitializeComponent();
        }

        private void loadall()
        {
            //load cbo kh
            List<KhachHang> a = kn.loadTenKH();
            cbokh.DataSource = a;

            cbokh.DisplayMember = "Tenkh1";
            cbokh.ValueMember = "id";
            

            //load all nhanvien
            List<NhanVien> x = kn.LayTatCaNhanVien();
            cboNV.DataSource = x;
            cboNV.ValueMember = "Tennv";

            //load all dichvu
            List<Dichvu> c = kn.LoadTatCaDichVu();
            dataGridView1.DataSource = c;

            //khóa
            //txtMaDV.Enabled = false;
            cboNV.Enabled = false;
            textBox1.Enabled = false;
        }
        private void F_QL_Load(object sender, EventArgs e)
        {
            loadall();
        }

        private void cbokh_SelectedIndexChanged(object sender, EventArgs e)
        {
            string i = cbokh.SelectedValue.ToString();
            textBox1.Text = i;
            string id = cbokh.SelectedValue as string;
             if(id==null)
            {
                Console.WriteLine("Chưa lấy được id");
                
            } 
             else
            {
                //load cbo nv
                List<NhanVien> x = kn.LoadCboNv(id);
                cboNV.DataSource = x;

                cboNV.ValueMember = "Tennv";

                List<Dichvu> c = kn.LoadDichVuTheoKhachHang(id);
                dataGridView1.DataSource = c;
            }    
           
        }

        private void btnThemdv_Click(object sender, EventArgs e)
        {
            string id = cbokh.SelectedValue as string;
            Dichvu a = new Dichvu();
            a.Tendv = txtTenDV.Text;
            a.Madv = txtMaDV.Text;
            a.Gia = int.Parse(txtGiaDV.Text);
            if (id == null)
            {
                Console.WriteLine("Chưa lấy được id");
            }
            else
            {
                if(a==null)
                {
                    MessageBox.Show("Vui lòng chọn dịch vụ");
                      
                }
                else
                {
                    if (kn.ThemDichVuChoKhachHang(id, a))
                    {
                        MessageBox.Show("Thêm thành công");
                        List<Dichvu> c = kn.LoadDichVuTheoKhachHang(id);
                        dataGridView1.DataSource = c;
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại");
                    }
                }
            }
            txtGiaDV.Clear();
            txtMaDV.Clear();
            txtTenDV.Clear();
                
        }

        private void btnXoadv_Click(object sender, EventArgs e)
        {
            string madv = "";
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                if (selectedRow.Cells[0].Value != null)
                {
                    madv = selectedRow.Cells[0].Value.ToString();
                }
            }

            string id = cbokh.SelectedValue as string;
            if (id == null)
            {
                Console.WriteLine("Chưa lấy được id");
            }
            else
            { 
                    if (madv == "")
                    {
                        MessageBox.Show("Vui lòng chọn dịch vụ");
                    }
                    if (kn.XoaDichVuKhachHang(id, madv))
                    {
                        MessageBox.Show("Xóa thành công");
                        List<Dichvu> c = kn.LoadDichVuTheoKhachHang(id);
                        dataGridView1.DataSource = c;
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại");
            }
            
            }






             
        }

        private void btnSuadv_Click(object sender, EventArgs e)
        {
            string id = cbokh.SelectedValue as string;
            string madv = "";
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                if (selectedRow.Cells[0].Value != null)
                {
                    madv = selectedRow.Cells[0].Value.ToString();
                }
            }

            Dichvu a = new Dichvu();
            a.Tendv = txtTenDV.Text;
            a.Madv = madv;
            a.Gia = int.Parse(txtGiaDV.Text);

            if (id == null)
            {
                Console.WriteLine("Chưa lấy được id");
            }
            else
            {
                if(a.Tendv==null || a.gia==null)
                {
                    MessageBox.Show("Vui lòng nhập thông tin muốn sửa");
                }    
                else
                {
                    if (kn.SuaDichVuKhachHang(id, a))
                    {
                        MessageBox.Show("Sửa thành công");
                        List<Dichvu> c = kn.LoadDichVuTheoKhachHang(id);
                        dataGridView1.DataSource = c;
                    }
                    else
                    {
                        MessageBox.Show("Sửa thất bại");
                    }
                }
                
            }    



        }

        private void txtGiaDV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Loại bỏ ký tự không phải số
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            //F_KhachHang frm = new F_KhachHang();
            //frm.MdiParent = this;
            //frm.Show();
            F_KhachHang a = new F_KhachHang();
            a.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadall ();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtMaDV_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
