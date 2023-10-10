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
using MongoDB.Bson.Serialization;
using static test.frm_NhanVien;

namespace test
{
    public partial class frm_NhanVien : Form
    {
        private IMongoCollection<BsonDocument> collection;
        private MongoClient client;
        private IMongoDatabase database;
        private DataTable dataTable;

        public frm_NhanVien()
        {
            InitializeComponent();
            string connectionString = "mongodb://localhost:27017";
            client = new MongoClient(connectionString);
            database = client.GetDatabase("QLCSKH");
            collection = database.GetCollection<BsonDocument>("CSKH");

            dataTable = new DataTable();

            dataTable.Columns.Add("ID khách hàng", typeof(string));
            dataTable.Columns.Add("Mã nhân viên", typeof(string));
            dataTable.Columns.Add("Tên nhân viên", typeof(string));
            dataTable.Columns.Add("SDT nhân viên", typeof(string));
            dataTable.Columns.Add("Email nhân viên", typeof(string));

            loadDL();
        }

        private void loadDL()
        {
            // Xóa dữ liệu hiện có trong DataTable
            dataTable.Clear();

            // Lấy dữ liệu từ collection
            var filter = Builders<BsonDocument>.Filter.Empty;
            var documents = collection.Find(filter).ToList();

            // Duyệt qua tất cả các tài liệu và thêm vào DataTable
            foreach (BsonDocument document in documents)
            {
                // Truy cập vào collection nhúng
                var idKH = document.GetValue("_id").AsObjectId.ToString();
                var nv = document["NhanVien"].AsBsonDocument;

                // Lấy dữ liệu từ collection nhân viên
                var maNV = nv["Manv"].ToString();
                var tenNV = nv["tennv"].AsString;
                var sdtNV = nv["Sdtnv"].AsString;
                var emailNV = nv["Email"].AsString;

                // Thêm dòng vào DataTable
                dataTable.Rows.Add(idKH, maNV, tenNV, sdtNV, emailNV);
            }

            // Hiển thị DataTable trên DataGridView
            dataGridView1.DataSource = dataTable;
        }

        private void btn_lamMoi_Click(object sender, EventArgs e)
        {
            loadDL();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ collection
            var filter = Builders<BsonDocument>.Filter.Empty;
            var documents = collection.Find(filter).ToList();

            //kết nối mongodb
            string connectionString = "mongodb://localhost:27017";
            client = new MongoClient(connectionString);
            database = client.GetDatabase("QLCSKH");
            collection = database.GetCollection<BsonDocument>("CSKH");

            BsonDocument document = new BsonDocument();
            var manv = document.Add("Manv", txt_maNV.Text);
            var tennv = document.Add("tennv", txt_tenNV.Text);
            var sdt = document.Add("Sdtnv", txt_sdt.Text);
            var email = document.Add("Email", txt_email.Text);

            // thêm dữ liệu
            collection.InsertOne(document);

            // Thêm dòng vào DataTable
            dataTable.Rows.Add(manv, tennv, sdt, email);

            // hiển thị DataTable trên DataGridView
            dataGridView1.DataSource = dataTable;

            MessageBox.Show("Thêm dữ liệu thành công !!");
            //loadDL();
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {

        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            // Kiểm tra có dòng được chọn trong DataGridView không
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Lấy id khách hàng từ hàng được chọn
                string idKH = dataGridView1.SelectedRows[0].Cells["ID khách hàng"].Value.ToString();

                // Lấy thông tin nhân viên từ các textbox
                string maNV = txt_maNV.Text.Trim();
                string tenNV = txt_tenNV.Text.Trim();
                string sdt = txt_sdt.Text.Trim();
                string email = txt_email.Text.Trim();

                // Lấy thông tin nhân viên hiện tại từ MongoDB
                var filter = Builders<BsonDocument>.Filter.Eq("_id", idKH);
                var document = collection.Find(filter).FirstOrDefault();

                if (document != null)
                {
                    var nv = document["NhanVien"].AsBsonDocument;

                    // Kiểm tra và sử dụng lại dữ liệu cũ nếu trường thông tin bị bỏ trống
                    if (string.IsNullOrWhiteSpace(maNV))
                    {
                        maNV = nv["Manv"].AsString;
                    }
                    if (string.IsNullOrWhiteSpace(tenNV))
                    {
                        tenNV = nv["tennv"].AsString;
                    }
                    if (string.IsNullOrWhiteSpace(sdt))
                    {
                        sdt = nv["Sdt"].AsString;
                    }
                    if (string.IsNullOrWhiteSpace(email))
                    {
                        email = nv["Email"].AsString;
                    }


                    // Cập nhật thông tin khách hàng trong MongoDB
                    var update = Builders<BsonDocument>.Update
                        .Set("NhanVien.Manv", maNV)
                        .Set("NhanVien.tennv", tenNV)
                        .Set("NhanVien.Sdt", sdt)
                        .Set("NhanVien.Email", email);

                    collection.UpdateOne(filter, update);

                    // Hiển thị thông báo thành công
                    MessageBox.Show("Cập nhật dữ liệu thành công !!!");

                    // Refresh DataGridView
                    loadDL();
                }
                else
                {
                    MessageBox.Show("Thông tin không tồn tại !!!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa thông tin !!!");
            }
            ClearTextBox();
        }

        private void ClearTextBox()
        {
            txt_maNV.Text = "";
            txt_tenNV.Text = "";
            txt_sdt.Text = "";
            txt_email.Text = "";
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Close();
        }
    }
}
