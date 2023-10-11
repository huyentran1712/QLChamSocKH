using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;

namespace test
{
    public partial class F_DichVu : Form
    {
        // Đối tượng collection để tương tác với MongoDB
        private IMongoCollection<BsonDocument> collection;

        public F_DichVu()
        {
            InitializeComponent();

            // Khởi tạo kết nối tới MongoDB
            MongoClient mongoClient = new MongoClient("mongodb://localhost:27017");
            IMongoDatabase db = mongoClient.GetDatabase("QLCSKH");
            collection = db.GetCollection<BsonDocument>("CSKH");

            // Load danh sách dịch vụ lên DataGridView khi form khởi tạo
            LoadDataToDataGridView();

            // Thêm sự kiện SelectionChanged cho DataGridView
            dvg_dichvu.SelectionChanged += DataGridView_SelectionChanged;
        }

        // Hàm load dữ liệu từ MongoDB lên DataGridView
        private void LoadDataToDataGridView()
        {
            List<BsonDocument> documents = collection.Find(new BsonDocument()).ToList();
            dvg_dichvu.DataSource = documents;
        }
        private void DataGridView_SelectionChanged(object sender, EventArgs e)
        {
            // Xử lý sự kiện khi người dùng chọn một dòng trên DataGridView
            if (dvg_dichvu.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dvg_dichvu.SelectedRows[0];
                txt_Madv.Text = row.Cells["Madv"].Value.ToString();
                txt_Tendv.Text = row.Cells["Tendv"].Value.ToString();
                txt_Giadv.Text = row.Cells["Gia"].Value.ToString();
            }
        }

        private void F_DichVu_Load(object sender, EventArgs e)
        {

        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            string makh = txt_Makh.Text;
            string madv = txt_Madv.Text;
            string tendv = txt_Tendv.Text;
            double gia = 0;

            if (!string.IsNullOrEmpty(txt_Giadv.Text) && double.TryParse(txt_Giadv.Text, out gia))
            {
                if (!string.IsNullOrEmpty(makh) && !string.IsNullOrEmpty(madv) && !string.IsNullOrEmpty(tendv) && gia > 0)
                {
                    BsonDocument newService = new BsonDocument
                {
                    { "Madv", madv },
                    { "Tendv", tendv },
                    { "Gia", gia }
                };

                    var filter = Builders<BsonDocument>.Filter.Eq("Makh", makh);
                    var customer = collection.Find(filter).FirstOrDefault();

                    if (customer != null)
                    {
                        var dichvuArray = customer["Dichvu"].AsBsonArray;
                        dichvuArray.Add(newService);

                        var update = Builders<BsonDocument>.Update.Set("Dichvu", dichvuArray);
                        collection.UpdateOne(filter, update);

                        LoadDataToDataGridView();
                        MessageBox.Show("Thêm dịch vụ thành công.");
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy khách hàng.");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập thông tin dịch vụ hợp lệ.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập giá dịch vụ hợp lệ.");
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            string makh = txt_Makh.Text;
            string madv = txt_Madv.Text;

            var filter = Builders<BsonDocument>.Filter.Eq("Makh", makh);
            var customer = collection.Find(filter).FirstOrDefault();

            if (customer != null)
            {
                var dichvuArray = customer["Dichvu"].AsBsonArray;
                var serviceToRemove = dichvuArray.FirstOrDefault(d => d["Madv"].AsString == madv);

                if (serviceToRemove != null)
                {
                    dichvuArray.Remove(serviceToRemove);

                    var update = Builders<BsonDocument>.Update.Set("Dichvu", dichvuArray);
                    collection.UpdateOne(filter, update);

                    LoadDataToDataGridView();
                    MessageBox.Show("Xóa dịch vụ thành công.");
                }
                else
                {
                    MessageBox.Show("Không tìm thấy dịch vụ.");
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy khách hàng.");
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            string makh = txt_Makh.Text;
            string madv = txt_Madv.Text;
            string tendv = txt_Tendv.Text;
            double gia = 0;

            if (!string.IsNullOrEmpty(txt_Giadv.Text) && double.TryParse(txt_Giadv.Text, out gia))
            {
                if (!string.IsNullOrEmpty(makh) && !string.IsNullOrEmpty(madv) && !string.IsNullOrEmpty(tendv) && gia > 0)
                {
                    var filter = Builders<BsonDocument>.Filter.Eq("Makh", makh);
                    var customer = collection.Find(filter).FirstOrDefault();

                    if (customer != null)
                    {
                        var dichvuArray = customer["Dichvu"].AsBsonArray;
                        var serviceToUpdate = dichvuArray.FirstOrDefault(d => d["Madv"].AsString == madv);

                        if (serviceToUpdate != null)
                        {
                            serviceToUpdate["Tendv"] = tendv;
                            serviceToUpdate["Gia"] = gia;

                            var update = Builders<BsonDocument>.Update.Set("Dichvu", dichvuArray);
                            collection.UpdateOne(filter, update);

                            LoadDataToDataGridView();
                            MessageBox.Show("Cập nhật dịch vụ thành công.");
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy dịch vụ.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy khách hàng.");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập thông tin dịch vụ hợp lệ.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập giá dịch vụ hợp lệ.");
            }
        }
    }
}
