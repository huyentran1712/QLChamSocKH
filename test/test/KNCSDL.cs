using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

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


        //(1)lấy danh sách khách hàng
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


        //(2)thêm khách hàng
        public bool ThemKhachHang(BsonDocument khach)
        {
            try
            {

                collection.InsertOne(khach.ToBsonDocument());

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        //(3)xóa khách hàng
        public bool XoaKhachHang(string id)
        {
            ObjectId objectId;
            if(ObjectId.TryParse(id,out objectId))
            {
                var filter = Builders<BsonDocument>.Filter.Eq("_id", objectId);
                var results = collection.DeleteOne(filter);
                return results.IsAcknowledged && results.DeletedCount > 0;
            }
            return false;
        }

        //(4)sửa khách hàng
        public bool SuaKhachHang(string id, KhachHang moi)
        {
            try
            {
                var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
                var update = Builders<BsonDocument>.Update
                    .Set("Tenkh", moi.Tenkh)
                    .Set("Sdt", moi.Sdt)
                    .Set("Phai", moi.Phai)
                    .Set("Diachi", moi.Diachi);

                var result = collection.UpdateOne(filter, update);

                return result.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu có
                return false;
            }
        }


        //------------ktra dang nhap----------

        //kiểm tra đăng nhập
        public bool KiemTraDangNhap(string email, string matKhau)
        {
            // Truy vấn để kiểm tra đăng nhập dựa trên email và mật khẩu
            var filter = Builders<BsonDocument>.Filter.Eq("NhanVien.Email", email) &
                         Builders<BsonDocument>.Filter.Eq("NhanVien.Matkhau", matKhau);
            var nhanVien = collection.Find(filter).FirstOrDefault();

            // Nếu tài khoản hợp lệ (tồn tại trong cơ sở dữ liệu), trả về true; ngược lại, trả về false
            return nhanVien != null;
        }

        //lấy tài khoản nhân viên
        public NhanVien LayThongTin1NhanVien()
        {
            var filter = Builders<BsonDocument>.Filter.Eq("NhanVien.Email", TTTK.Instance.Taikhoan) &
                         Builders<BsonDocument>.Filter.Eq("NhanVien.Matkhau", TTTK.Instance.Matkhau);
            var nhanVienDocument = collection.Find(filter).FirstOrDefault();
            if (nhanVienDocument != null)
            {
                var nhanVienBson = nhanVienDocument["NhanVien"].AsBsonDocument;
                var nhanVien = BsonSerializer.Deserialize<NhanVien>(nhanVienBson);
                return nhanVien;
            }
            return null;
        }

        //-----------xử lý nghiệp vụ----------

        //(1)lấy tên khách hàng load lên combobox
        public List<KhachHang> loadTenKH()
        {
            // Truy vấn danh sách tên khách hàng từ cơ sở dữ liệu MongoDB
            var projection = Builders<BsonDocument>.Projection.Include("_id").Include("Tenkh");
            var results = collection.Find(new BsonDocument()).Project(projection).ToList();

            List<KhachHang> khachHangList = new List<KhachHang>();
            foreach (var result in results)
            {
                KhachHang khachHang = new KhachHang
                {
                    id = result.GetValue("_id").AsObjectId.ToString(),
                    Tenkh = result.GetValue("Tenkh").AsString
                   


                };
                khachHangList.Add(khachHang);
            }

            return khachHangList;
        }

        //(2) lấy tất cả nhân viên
        public List<NhanVien> LayTatCaNhanVien()
        {
            var khachHangCollection = database.GetCollection<BsonDocument>("CSKH");
            List<NhanVien> danhSachNhanVien = new List<NhanVien>();
            var khachHangDocuments = khachHangCollection.Find(new BsonDocument()).ToList();
            foreach (var khachHangDocument in khachHangDocuments)
            {
                var nhanVienBson = khachHangDocument.GetValue("NhanVien").AsBsonDocument;
                NhanVien nhanVien = BsonSerializer.Deserialize<NhanVien>(nhanVienBson);

                danhSachNhanVien.Add(nhanVien);
            }

            return danhSachNhanVien;
        }

        //(3) lấy tất cả dịch vụ
        public List<Dichvu> LoadTatCaDichVu()
        {
            var filter = Builders<BsonDocument>.Filter.Empty;
            var projection = Builders<BsonDocument>.Projection.Include("Dichvu");
            var dichVuDocuments = collection.Find(filter).Project(projection).ToList();

            List<Dichvu> dichVuList = new List<Dichvu>();

            foreach (var dichVuDocument in dichVuDocuments)
            {
                var dichVuArray = dichVuDocument.GetValue("Dichvu").AsBsonArray;

                foreach (var dichVuBson in dichVuArray)
                {
                    var dichVu = BsonSerializer.Deserialize<Dichvu>(dichVuBson.AsBsonDocument);
                    dichVuList.Add(dichVu);
                }
            }

            return dichVuList;
        }

        //(4)lấy tên nhân viên có trong hóa đơn của khách hàng được chọn ở (1) lên combobox
        public List<NhanVien> LoadCboNv(string id)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id)); // Sử dụng ObjectId.Parse để chuyển đổi id thành kiểu ObjectId
            var projection = Builders<BsonDocument>.Projection.Include("NhanVien");
            var khachHangDocument = collection.Find(filter).Project(projection).FirstOrDefault();

            List<NhanVien> nhanVienList = new List<NhanVien>();

            if (khachHangDocument != null)
            {
                var nhanVienBson = khachHangDocument.GetValue("NhanVien").AsBsonDocument;
                var nhanVien = BsonSerializer.Deserialize<NhanVien>(nhanVienBson);
                nhanVienList.Add(nhanVien);
            }

            return nhanVienList;
        }

        //(5) lấy dịch vụ theo id khách hàng
        public List<Dichvu> LoadDichVuTheoKhachHang(string id)
        {

            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id)); // Sử dụng ObjectId.Parse để chuyển đổi id thành kiểu ObjectId
            var projection = Builders<BsonDocument>.Projection.Include("Dichvu");
            var khachHangDocument = collection.Find(filter).Project(projection).FirstOrDefault();

            if (khachHangDocument != null)
            {
                var dichVuArray = khachHangDocument.GetValue("Dichvu").AsBsonArray;
                var dichVuList = new List<Dichvu>();

                foreach (var dichVuBson in dichVuArray)
                {
                    var dichVu = BsonSerializer.Deserialize<Dichvu>(dichVuBson.AsBsonDocument);
                    dichVuList.Add(dichVu);
                }

                return dichVuList;
            }
            return new List<Dichvu>();
        }

        //(6) thêm dịch vụ theo id khách hàng
        public bool ThemDichVuChoKhachHang(string id, Dichvu dichVu)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
            var khachHangDocument = collection.Find(filter).FirstOrDefault();

            if (khachHangDocument != null)
            {
                var dichVuDocument = new BsonDocument
                {
                    { "Madv", dichVu.Madv },
                    { "Tendv", dichVu.Tendv },
                    { "Gia", dichVu.Gia }
                };
                var dichVuArray = khachHangDocument.GetValue("Dichvu").AsBsonArray;
                dichVuArray.Add(dichVuDocument);
                var update = Builders<BsonDocument>.Update.Set("Dichvu", dichVuArray);
                var result = collection.UpdateOne(filter, update);
                return result.ModifiedCount > 0;   // Kiểm tra xem việc cập nhật thành công hay không.
            }

            return false; // Không tìm thấy khách hàng.
        }

        //(7) xóa dịch vụ theo id khách hàng
        public bool XoaDichVuKhachHang(string id, string maDichVu)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
            var khachHangDocument = collection.Find(filter).FirstOrDefault();

            if (khachHangDocument != null)
            {
                var dichVuArray = khachHangDocument.GetValue("Dichvu").AsBsonArray;
                var dichVuToDelete = dichVuArray.FirstOrDefault(d => d["Madv"].AsString == maDichVu);

                if (dichVuToDelete != null)
                {
                    dichVuArray.Remove(dichVuToDelete);
                    var update = Builders<BsonDocument>.Update.Set("Dichvu", dichVuArray);
                    var result = collection.UpdateOne(filter, update);
                    return result.ModifiedCount > 0; // Kiểm tra xem việc cập nhật thành công hay không.
                }
            }
            return false; // Không tìm thấy khách hàng hoặc dịch vụ không tồn tại.
        }

        //(8) sửa dịch vụ theo id khách hàng
        public bool SuaDichVuKhachHang(string id, Dichvu dichVuSua)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
            var khachHangDocument = collection.Find(filter).FirstOrDefault();

            if (khachHangDocument != null)
            {
                var dichVuArray = khachHangDocument.GetValue("Dichvu").AsBsonArray;
                var dichVuToUpdate = dichVuArray.FirstOrDefault(dv => dv["Madv"].AsString == dichVuSua.Madv);

                if (dichVuToUpdate != null)
                {
                    dichVuToUpdate["Tendv"] = dichVuSua.Tendv;
                    dichVuToUpdate["Gia"] = dichVuSua.Gia;
                    var update = Builders<BsonDocument>.Update.Set("Dichvu", dichVuArray);
                    var result = collection.UpdateOne(filter, update);

                    return result.ModifiedCount > 0; // Kiểm tra xem việc cập nhật thành công hay không.
                }
            }
            return false; // Không tìm thấy khách hàng hoặc dịch vụ không tồn tại.
        }










    }
}
