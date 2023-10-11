using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Driver;
using MongoDB.Bson;
namespace test
{
    public partial class F_KhachHang : Form
    {
        KNCSDL kn = new KNCSDL();
        public F_KhachHang()
        {
            InitializeComponent();
        }

        private void F_KhachHang_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = kn.LoadAll_KH();

            NhanVien a = kn.LayThongTin1NhanVien();
            //cboNV.DataSource = a;
            txtnv.Text = a.tennv;
            txtnv.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ObjectId newId = ObjectId.GenerateNewId();
            BsonDocument addKH = new BsonDocument().Add("Makh", txtMaKH.Text)
                                                    .Add("Tenkh", txtTenKH.Text)
                                                    .Add("Sdt", txtSdtKh.Text)
                                                    .Add("Phai", txtPhaiKH.Text)
                                                    .Add("Diachi", txtDiaChi.Text);
            NhanVien nv = kn.LayThongTin1NhanVien();
            BsonDocument Nhanvien = new BsonDocument().Add("Manv", nv.Manv)
                                                      .Add("tennv", nv.tennv)
                                                      .Add("Sdtnv", nv.Sdtnv)
                                                      .Add("Email", nv.Email)
                                                      .Add("Matkhau", nv.Matkhau);


            BsonArray Dichvu = new BsonArray();
            addKH.Add("NhanVien", Nhanvien);
            addKH.Add("Dichvu", Dichvu);
            if (string.IsNullOrEmpty(txtMaKH.Text) || string.IsNullOrEmpty(txtTenKH.Text) || string.IsNullOrEmpty(txtSdtKh.Text))
            {
                MessageBox.Show("Vui lòng điển thông tin khách hàng");
            }
            else
            {
                if (kn.ThemKhachHang(addKH))
                {
                    MessageBox.Show("Thêm thành công");
                    dataGridView1.DataSource = kn.LoadAll_KH();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại");
                }
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXoaKH_Click(object sender, EventArgs e)
        {
            string id = "";
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                if (selectedRow.Cells[0].Value != null)
                {
                    id = selectedRow.Cells[0].Value.ToString();
                }
            }
            if (kn.XoaKhachHang(id))
            {
                MessageBox.Show("Xóa thành công");
                dataGridView1.DataSource = kn.LoadAll_KH();
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }
            

            
        }


        private void btnSuaKh_Click(object sender, EventArgs e)
        {
            KhachHang a = new KhachHang();
            a.Makh = txtMaKH.Text;
            a.Tenkh = txtTenKH.Text;
            a.Sdt = txtSdtKh.Text;
            a.Phai = txtSdtKh.Text;
            a.Diachi = txtDiaChi.Text;
            string id = "";
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                if (selectedRow.Cells[0].Value != null)
                {
                    id = selectedRow.Cells[0].Value.ToString();
                }
            }
            if (kn.SuaKhachHang(id,a))
            {
                MessageBox.Show("Sửa thành công");
                dataGridView1.DataSource = kn.LoadAll_KH();
            }
            else
            {
                MessageBox.Show("Sửa thất bại");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaKH.DataBindings.Clear();
            txtTenKH.DataBindings.Clear();
            txtSdtKh.DataBindings.Clear();
            txtPhaiKH.DataBindings.Clear();
            txtDiaChi.DataBindings.Clear();

            txtMaKH.DataBindings.Add("Text", dataGridView1.DataSource, "Makh1");
            txtTenKH.DataBindings.Add("Text", dataGridView1.DataSource, "Tenkh1");
            txtSdtKh.DataBindings.Add("Text", dataGridView1.DataSource, "Sdt1");
            txtPhaiKH.DataBindings.Add("Text", dataGridView1.DataSource, "Phai1");
            txtDiaChi.DataBindings.Add("Text", dataGridView1.DataSource, "Diachi1");

        }
    }
}
