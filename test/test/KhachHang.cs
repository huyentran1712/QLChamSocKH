using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public class KhachHang
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id;
        public string Id { get => id; set => id = value; }
        public string Makh;
        public string Makh1 { get => Makh; set => Makh = value; }
        public string Tenkh;
        public string Tenkh1 { get => Tenkh; set => Tenkh = value; }
        public string Sdt;
        public string Sdt1 { get => Sdt; set => Sdt = value; }
        public string Phai;
        public string Phai1 { get => Phai; set => Phai = value; }
        public string Diachi;
        public string Diachi1 { get => Diachi; set => Diachi = value; }
        
        private NhanVien nhanVien;
        NhanVien NhanVien { get => nhanVien; set => nhanVien = value; }
      
        private List<Dichvu> dichvu;
        public List<Dichvu> Dichvu { get => dichvu; set => dichvu = value; }
        
    }
}
