using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhoaSinhVien.IO
{
    public class ImportExport
    {
        private List<Department> _departments;
        private const string FilePath = "Data\\ds.txt";
      //  private const string FilePath1 = "Data\\danhsach.txt";
        public ImportExport()
        {
        }

        private List<Student> ImportFromFile()
        {
            List<Student> ds = new List<Student>();
          
            string line;
            string[] s;
            try
            {
                using (var stream = new FileStream(FilePath, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = new StreamReader(stream))
                    {
                        while ((line = reader.ReadLine())!=null)
                        {
                            s = line.Split('\t');
                            Student a = new Student();
                            a.maSo = s[0];
                            a.hoLot = s[1];
                            a.ten = s[2];
                            a.lop = s[3];
                            a.khoa = s[4];
                            a.gioiTinh = "Nam";
                            a.ngaySinh = new DateTime(0001, 1, 1);
                            a.sdt = "";
                            a.diaChi = "";

                            var kt = ds.FindAll(p => p.maSo == a.maSo);
                            if (kt.Count == 0)
                            {
                                ds.Add(a);
                            }
                        }
                    }
                }
            }
            catch
            {

            }
            return ds;
        }

        private List<Department> ListDepartments(List<Student> ds)
        {
            List<Department> dsDep = new List<Department>();

            foreach (var sv in ds)
            {
                Department k = new Department();
                k.name = sv.khoa;

                var kq = dsDep.FindAll(p => p.name == k.name);
                if (kq.Count == 0)
                {
                    dsDep.Add(k);
                }

                foreach (var khoa in dsDep)
                {
                    if (khoa.name == sv.khoa)
                    {
                        Class a = new Class();
                        a.Name = sv.lop;
                        var kt = khoa.classes.FindAll(p => p.Name == sv.lop);
                        if (kt.Count == 0)
                        {
                            khoa.classes.Add(a);
                        }
                    }


                    foreach (var lop in khoa.classes)
                    {
                        if (lop.Name == sv.lop)
                        {
                            lop.students.Add(sv);
                            break;
                        }

                    }
                }
            }



            // sắp xếp danh sách
            foreach (var khoa in dsDep)
            {
                khoa.classes.Sort((x1, x2) => x1.Name.CompareTo(x2.Name));
            }
            return dsDep;
        }

       
        public List<Department> GetDepartments()
        {
            if (_departments == null)
            {
                _departments = ListDepartments(ImportFromFile());
            }
            return _departments;
        }

        public List<Student> GetStudents(string departmentName, string className)
        {
            

            var department = _departments.Find(x => x.name == departmentName);
            if (department == null) return new List<Student>();

            var clss = department.classes.Find(x => x.Name == className);
            if (clss == null) return new List<Student>();
            else
            {
               return  clss.students;
            }
            
        }

        //public void SaveStudents(List<Student> students)
        //{
        //    using (var stream = new FileStream(FilePath1, FileMode.Create, FileAccess.Write))
        //    {
        //        using (var writer = new StreamWriter(stream))
        //        {
        //            foreach (var item in students)
        //            {
        //                writer.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t{9}",item.maSo,item.hoLot,
        //                    item.ten,item.lop,item.khoa,item.gioiTinh,item.ngaySinh,item.sdt,item.diaChi);
        //            }
        //        }
        //    }
        //}
    }
}
