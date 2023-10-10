using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;

namespace test
{
    public partial class frm_ThongKeKH : Form
    {
        private IMongoCollection<BsonDocument> hopDongCollection;
        private IMongoCollection<BsonDocument> hosoboithuongCollection;
        private MongoClient client;
        private IMongoDatabase database;

        public frm_ThongKeKH()
        {
            InitializeComponent();
        }

        private void btn_thongKe_Click(object sender, EventArgs e)
        {
            string connectionString = "mongodb://localhost:27017";
            client = new MongoClient(connectionString);
            database = client.GetDatabase("QLCSKH");
            hopDongCollection = database.GetCollection<BsonDocument>("CSKH");
            DateTime startTime = dateTimePicker1.Value;
            DateTime endTime = dateTimePicker2.Value;

            // Đổi tên trục x thành tháng/năm
            chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "MM/yyyy";

            // Hiển thị tiêu đề và hiển thị biểu đồ
            chart1.Titles.Add("Thống kê số lượng khách hàng");
            chart1.ChartAreas[0].RecalculateAxesScale();

            // Hiển thị biểu đồ trên form
            chart1.Visible = true;
        }
    }
}
