using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public  class TTTK
    {
        public TTTK()
        {

        }
         string  taikhoan;
         string matkhau;

        public  string Taikhoan { get => taikhoan; set => taikhoan = value; }
        public  string Matkhau { get => matkhau; set => matkhau = value; }

        private static TTTK instance;
        public static TTTK Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TTTK();
                }
                return instance;
            }
        }




}
}
