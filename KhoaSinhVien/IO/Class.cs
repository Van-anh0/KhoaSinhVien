using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhoaSinhVien.IO
{
    public class Class
    {
        public string Name { get; set; }

        public List<Student> students { get; set; }

        public Class()
        {
            students = new List<Student>();
        }

        public void AddStudent(Student newStudent)
        {
            students.Add(newStudent);
        }

        public void DeleteSudent(string studentMS)
        {
            students.RemoveAll(p => p.maSo == studentMS);
        }

    }
}
