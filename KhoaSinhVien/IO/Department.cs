using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhoaSinhVien.IO
{
    public class Department
    {
        public string name { get; set; }
        public List<Class> classes { get; set; }

        public Department()
        {
            classes = new List<Class>();
        }


    }
}
