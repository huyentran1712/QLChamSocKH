using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using static test.KhachHang;
namespace test
{
    public class KNCSDL
    {
        MongoClient client;
        IMongoCollection<BsonDocument> collection;
        IMongoDatabase database;
        public KNCSDL()
        {
            string connectionString = "mongodb://localhost:27017";
            client = new MongoClient(connectionString);
            database = client.GetDatabase("QLCSKH");
            collection = database.GetCollection<BsonDocument>("CSKH");
        }


        //------------Khach hang----------


        public List<KhachHang> LoadAll_KH()//lấy thông tin khách hàng (k có nhân viên và dịch vụ)
        {
            collection = database.GetCollection<BsonDocument>("CSKH");
            var filter = Builders<BsonDocument>.Filter.Empty;
            var projection = Builders<BsonDocument>.Projection.Include("Makh")
                                                              .Include("Tenkh")
                                                              .Include("Sdt")
                                                              .Include("Phai")
                                                              .Include("Diachi");

            var khachHangDocuments = collection.Find(filter).Project(projection).ToList();
            var khachHangList = khachHangDocuments.Select(khachHangDocument => BsonSerializer.Deserialize<KhachHang>(khachHangDocument)).ToList();
            return khachHangList;
        }




        //------------ktra dang nhap----------


        public bool KiemTraDangNhap(string email, string matKhau)
        {
            // Truy vấn để kiểm tra đăng nhập dựa trên email và mật khẩu
            var filter = Builders<BsonDocument>.Filter.Eq("NhanVien.Email", email) &
                         Builders<BsonDocument>.Filter.Eq("NhanVien.Matkhau", matKhau);
            var nhanVien = collection.Find(filter).FirstOrDefault();

            // Nếu tài khoản hợp lệ (tồn tại trong cơ sở dữ liệu), trả về true; ngược lại, trả về false
            return nhanVien != null;
        }






    }
}
