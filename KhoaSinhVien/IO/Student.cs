using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhoaSinhVien.IO
{
    public class Student
    {
        public string maSo { get; set; }
        public string hoLot { get; set; }
        public string ten { get; set; }
        public string lop { get; set; }
        public string khoa { get; set; }

        public string gioiTinh { get; set; }
        public DateTime ngaySinh { get; set; }
        public string sdt { get; set; }

        public string diaChi { get; set; }

        public Student()
        {

        }

        public Student(string ms, string hl, string t, string l, string k, string gt, DateTime ns, string sdt, string dc)
        {
            maSo = ms;
            hoLot = hl;
            ten = t;
            lop = l;
            khoa = k;
            gioiTinh = gt;
            ngaySinh = ns;
            this.sdt = sdt;
            this.diaChi = dc;
        }

        public void UpdateStudentInfo(string ms, string hl, string t, string l, string k, string gt, DateTime ns, string sdt, string dc)
        {
            maSo = ms;
            hoLot = hl;
            ten = t;
            lop = l;
            khoa = k;
            gioiTinh = gt;
            ngaySinh = ns;
            this.sdt = sdt;
            this.diaChi = dc;
        }
    }
}
