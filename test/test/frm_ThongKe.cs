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
using static test.frm_ThongKe;

namespace test
{
    public partial class frm_ThongKe : Form
    {
        MongoClient client;
        IMongoCollection<BsonDocument> collection;
        IMongoDatabase database;

        public frm_ThongKe()
        {
            InitializeComponent();
            string connectionString = "mongodb://localhost:27017";
            client = new MongoClient(connectionString);
            database = client.GetDatabase("QLCSKH");
            collection = database.GetCollection<BsonDocument>("CSKH");

            lb1.Text = "";
            lb2.Text = "";
        }

        private void frm_ThongKeKH_Load(object sender, EventArgs e)
        {
            countDocument();
            countKH();
            countNV();
            countDV();
            doanhThu();
        }
        //sô document hiện có
        public void countDocument()
        {
            var filter = Builders<BsonDocument>.Filter.Exists("_id");
            var count = collection.CountDocuments(filter);

            lb1.Text = "Số document hiện có: " + count.ToString();
        }

        // tổng số lượng khách hàng
        public void countKH()
        {
            var filter = Builders<BsonDocument>.Filter.Empty;

            var distinctField = "Makh";

            var distinctValues = collection.Distinct<string>(
                distinctField,
                filter).ToList();

            var count = distinctValues.Count;
            lb2.Text = "Số lượng khách hàng: " + count.ToString();
        }

        // đếm số nhân viên
        public void countNV()
        {
            var filter = Builders<BsonDocument>.Filter.Empty;
            var pipeline = new[] {
                new BsonDocument("$group", new BsonDocument{
                    { "_id", "$NhanVien.tennv" },
                    { "count", new BsonDocument("$sum", 1) }
                }),
            };

            var result = collection.Aggregate<BsonDocument>(pipeline).ToList();

            if (result.Count > 0)
            {
                var count = result.First()["count"].ToInt32();

                lb3.Text = "Số lượng nhân viên phục vụ khách hàng: " + count.ToString();
            }
            else
            {
                lb3.Text = "Không có nhân viên";
            }
        }

        // đếm số dịch vụ
        public void countDV()
        {
            var filter = Builders<BsonDocument>.Filter.Empty;
            var pipeline = new[] {
                new BsonDocument("$unwind", "$Dichvu"),
                new BsonDocument("$group", new BsonDocument{
                    { "_id", "$Dichvu.Madv" },
                    { "count", new BsonDocument("$sum", 1) }
                }),
            };

            var result = collection.Aggregate<BsonDocument>(pipeline).ToList();

            if (result.Count > 0)
            {
                var count = result.First()["count"].ToInt32();

                lb4.Text = "Số lượng dịch vụ hiện có: " + count.ToString();
            }
            else
            {
                lb4.Text = "Không có dịch vụ.";
            }
        }

        // doanh thu
        public void doanhThu()
        {
            var filter = Builders<BsonDocument>.Filter.Empty;

            // Truy vấn để tính tổng doanh thu
            var pipeline = new BsonDocument[]
            {
                BsonDocument.Parse("{ $unwind: '$Dichvu' }"),
                BsonDocument.Parse("{ $group: { _id: null, total: { $sum: '$Dichvu.Gia' } } }"),
                BsonDocument.Parse("{ $project: { _id: 0 } }") // Loại bỏ trường _id trong kết quả trả về
            };
            var aggregateResults = collection.Aggregate<BsonDocument>(pipeline).ToList();
            double total = aggregateResults.FirstOrDefault()?["total"].AsInt32 ?? 0;

            lb5.Text = "Tổng tiền trong dịch vụ: " + total;
        }
    }
}
