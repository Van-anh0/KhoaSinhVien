using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KhoaSinhVien.IO;

namespace KhoaSinhVien
{
    
    public partial class FrmStudent : Form
    {
        private readonly ImportExport _importExport;
        private bool _upDate;
        public Student returnStudent;
        public bool hasChange { get; set; }

        //private bool load = false;
        public FrmStudent(ImportExport importExport, bool upDate = false)
        {
            _importExport = importExport;
            _upDate = upDate;
            InitializeComponent();
        }

        private void FrmStudent_Load(object sender, EventArgs e)
        {
            var departments = _importExport.GetDepartments();
           // List<Class> lop = new List<Class>();


            rdbNam.Checked = true;

            if (_upDate)
            {
                UpdateInfo();
            }

            
            foreach (var de in departments)
            {
                cbbKhoa.Items.Add(de.name);

                foreach (var cls in de.classes)
                {
                    cbbLop.Items.Add(cls.Name);
                }
            }
          

        }

        private void UpdateInfo()
        {
            mtbMSSV.Text = returnStudent.maSo;
            mtbMSSV.Enabled = false;
            txtHoLot.Text = returnStudent.hoLot;
            txtTen.Text = returnStudent.ten;
            if (returnStudent.gioiTinh == "Nam")
            {
                rdbNam.Checked = true;
            }
            else
            {
                rdbNu.Checked = true;
            }

            if (returnStudent.ngaySinh == new DateTime(0001, 1, 1))
            {
                dtpNS.Value = DateTime.Now;
            }
            else
            {
                dtpNS.Value = returnStudent.ngaySinh;
            }

            cbbKhoa.Text = returnStudent.khoa;
            cbbLop.Text = returnStudent.lop;
            mtbSDT.Text = returnStudent.sdt;
            txtDiaChi.Text = returnStudent.diaChi;
        }

        public Student GetStudent()
        {
            Student a = new Student();
            a.maSo = mtbMSSV.Text;
            a.hoLot = txtHoLot.Text;
            a.ten = txtTen.Text;
            a.ngaySinh = dtpNS.Value;
            a.sdt = mtbSDT.Text;
            a.diaChi = txtDiaChi.Text;
            a.gioiTinh = "Nam";
            if (rdbNu.Checked)
            {
                a.gioiTinh = "Nữ";
            }
            a.lop = cbbLop.Text;
            a.khoa = cbbKhoa.Text;
            return a;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            Student sv = GetStudent();
            if (string.IsNullOrWhiteSpace(sv.maSo) || string.IsNullOrWhiteSpace(sv.hoLot) || string.IsNullOrWhiteSpace(sv.ten))
            {
                MessageBox.Show("Bạn phải nhập đầy đủ thông tin cần thiết để lưu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            var listDe = _importExport.GetDepartments();
            var khoa = listDe.Find(p => p.name == sv.khoa);
            Class clss = khoa.classes.FirstOrDefault(p => p.Name == sv.lop);
            if (clss != null)
            {
                Student s = clss.students.FirstOrDefault(p => p.maSo == sv.maSo);
                if (s == null)
                {
                    clss.AddStudent(sv);
                   // return;
                }
                else
                {
                    // cập nhật
                    s.UpdateStudentInfo(sv.maSo, sv.hoLot, sv.ten, sv.lop, sv.khoa, sv.gioiTinh, sv.ngaySinh, sv.sdt, sv.diaChi);
                }
                hasChange = true;
                Close();
            }
        }

        public void ComboboxClass(string className)
        {
            cbbLop.Text = className;
        }

        public void ComboboxDepartment(string departmentName)
        {
            cbbKhoa.Text = departmentName;
        }

        //private void cbbKhoa_SelectedValueChanged(object sender, EventArgs e)
        //{
        //    load = true;
        //    FrmStudent_Load(sender, e);
        //    load = false;
        //}
    }
}
