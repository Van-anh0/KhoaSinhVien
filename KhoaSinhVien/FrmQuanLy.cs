using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Spreadsheet;
using KhoaSinhVien.IO;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Office.Interop.Excel;
using Newtonsoft.Json;
using app = Microsoft.Office.Interop.Excel.Application;
using Worksheet = Microsoft.Office.Interop.Excel.Worksheet;

namespace KhoaSinhVien
{
    public partial class FrmQuanLy : Form
    {
        private ImportExport _importExport;
       
        public FrmQuanLy()
        {
            _importExport = new ImportExport();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
            ShowOnTreeView(_importExport.GetDepartments());
        }

        private void ShowOnTreeView(List<Department> departments)
        {
            tvwDepartment.Nodes.Clear();
            foreach (var department in departments)
            {
                var departmentNode = tvwDepartment.Nodes.Add(department.name);
                foreach (var cls in department.classes )
                {
                    departmentNode.Nodes.Add(cls.Name);
                }

            }
            tvwDepartment.ExpandAll();
        }

        private void tvwDepartment_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
            if (e.Node.Level == 1)
            {
                var students = _importExport.GetStudents(e.Node.Parent.Text, e.Node.Text);
                LoadLV(students);
            }
        }

        private void AddStudentLV(Student sv)
        {
            ListViewItem lvitem = new ListViewItem(sv.maSo);
            lvitem.SubItems.Add(sv.hoLot);
            lvitem.SubItems.Add(sv.ten);
            lvitem.SubItems.Add(sv.gioiTinh);
            lvitem.SubItems.Add(sv.ngaySinh.ToString("dd/MM/yyyy"));
            lvitem.SubItems.Add(sv.sdt);
            lvitem.SubItems.Add(sv.lop);
            lvInformation.Items.Add(lvitem);
        }

        private void LoadLV(List<Student> students)
        {
            lvInformation.Items.Clear();
            foreach (var sv in students)
            {
                AddStudentLV(sv);
            }
        }
        private void tsmiDeleteStudent_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Bạn có chắc muốn xóa hay không? Một khi đã xóa sẽ không lấy lại dữ liệu được nữa!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialog == DialogResult.Yes)
            {
                string department = tvwDepartment.SelectedNode.Parent.Text;
                string clss = tvwDepartment.SelectedNode.Text;



                var listDe = _importExport.GetDepartments();
                Department khoa = listDe.Find(p => p.name == department);
                var lop = khoa.classes.Find(p => p.Name == clss);


                var listItemsCheck = lvInformation.CheckedItems;

                foreach (ListViewItem item in listItemsCheck)
                {
                    var maSo = item.SubItems[0].Text;
                    lop.DeleteSudent(maSo);

                }

                List<Student> students = _importExport.GetStudents(department, clss);
                LoadLV(students);
               
            }
           
        }

   
        private List<Student> ReturnAllStudents()
        {
            
            var departments = _importExport.GetDepartments();
            List<Student> students = new List<Student>();

            foreach (var k in departments)
            {
                foreach (var l in k.classes)
                {
                    foreach (var sv in l.students)
                    {
                        students.Add(sv);
                    }
                }
            }
            return students;

            // lấy danh sách đã thay đổi thì mới tìm kiếm ra mấy sinh viên sửa,
            //không phải lấy ds ban đầu
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
           if (e.KeyChar == 13)
            {

                List<Student> students = ReturnAllStudents();

                List<Student> dsSearch = new List<Student>();

                if (rdbHoTen.Checked)
                {
                    var hoTen = txtSearch.Text.Trim().ToLower();
                
                    List<Student> kq = new List<Student>();
                    foreach (var sv in students)
                    {
                        if (sv.hoLot.ToLower() +" "+ sv.ten.ToLower() == hoTen)
                        {
                            kq.Add(sv);
                            continue;
                        }

                        if (sv.ten.ToLower() == hoTen)
                        {
                            kq.Add(sv);
                            continue;
                        }

                        if (sv.hoLot.ToLower().StartsWith(hoTen))
                        {
                            kq.Add(sv);
                            continue;
                        }

                        //if (sv.hoLot.ToLower().Contains(hoTen))
                        //{
                        //    kq.Add(sv);
                        //    continue;
                        //}

                        int vt = sv.hoLot.LastIndexOf(' ') + 1;
                        string tenDem = sv.hoLot.Substring(vt).ToLower();
                        if (tenDem + " " + sv.ten.ToLower() == hoTen)
                        {
                            kq.Add(sv);
                        }
                    }
                    dsSearch = kq;


                    //var list = students.FindAll(p =>  p.ten == hoTen ||  p.hoLot == hoTen);
                    //|| p.hoLot.StartsWith(hoTen) || p.hoLot.EndsWith(hoTen)
                    
                }
                if (rdbMSSV.Checked)
                {
                    var maSo = txtSearch.Text;
                    var list1 = students.FindAll(p => p.maSo == maSo);
                    dsSearch = list1;
                }
                if (rdbSDT.Checked)
                {
                    var sdt = txtSearch.Text;
                    var list2 = students.FindAll(p => p.sdt == sdt);
                    dsSearch = list2;
                }
                
                if(dsSearch.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy kết quả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                LoadLV(dsSearch);
            }
        }

        private void tsmiAddStudent_Click(object sender, EventArgs e)
        {

            string department = tvwDepartment.SelectedNode.Parent.Text;
            string clss = tvwDepartment.SelectedNode.Text;
            List<Student> ds;
            var dialog = new FrmStudent(_importExport);

            dialog.ComboboxDepartment(department);
            dialog.ComboboxClass(clss);
            dialog.ShowDialog(this);
            
            if (dialog.hasChange)
            {
                ds = _importExport.GetStudents(department, clss);
                LoadLV(ds);
               
            }

        }

        private void lvInformation_DoubleClick(object sender, EventArgs e)
        {
            var dialog = new FrmStudent(_importExport, true);

            List<Student> listStudents = ReturnAllStudents();
            int cout = lvInformation.SelectedItems.Count;
            if (cout > 0)
            {
                string ma = lvInformation.SelectedItems[0].SubItems[0].Text;
                var kq = listStudents.FirstOrDefault(x => x.maSo == ma);
                if (kq != null)
                {
                    ma = kq.maSo;
                    string holot = kq.hoLot;
                    string ten = kq.ten;
                    string gt = kq.gioiTinh;
                    DateTime ns = kq.ngaySinh;
                    string lop = kq.lop;
                    string sdt = kq.sdt;
                    string khoa = kq.khoa;
                    string diaChi = kq.diaChi;
                    dialog.returnStudent = new Student(ma,holot,ten,lop,khoa,gt,ns,sdt,diaChi);
                }
            }
            dialog.ShowDialog();
            if (dialog.hasChange)
            {
                string department = tvwDepartment.SelectedNode.Parent.Text;
                string clss = tvwDepartment.SelectedNode.Text;
                List<Student> ds;
                ds = _importExport.GetStudents(department, clss);
                LoadLV(ds);
                
            }
        }


        private void tsmiSaveExcel_Click(object sender, EventArgs e)
        {
            app obj = new app();
            var wb = obj.Workbooks.Add(XlSheetType.xlWorksheet);
            var ws = (Worksheet)obj.ActiveSheet;
            obj.Columns.ColumnWidth = 20;

            var department = tvwDepartment.SelectedNode.Parent.Text;
            var clss = tvwDepartment.SelectedNode.Text;
            List<Student> ds = _importExport.GetStudents(department, clss);
            using (SaveFileDialog saveFile = new SaveFileDialog())
            {
                saveFile.Filter = "Excel |*.xlsx";
                saveFile.InitialDirectory = @"D:\";
                saveFile.Title = "Chọn mục cần lưu";
                saveFile.FileName = clss+".xlsx";

                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    ws.Name = clss;
                    ws.Cells[1,1] = "MSSV";
                    ws.Cells[1,2] = "Họ và tên lót";
                    ws.Cells[1,3] = "Tên";
                    ws.Cells[1,4] = "Giới tính";
                    ws.Cells[1,5] = "Ngày sinh";
                    ws.Cells[1,6] = "Số điện thoại";
                    ws.Cells[1,7] = "Địa chỉ";
                    ws.Cells[1,8] = "Lớp";
                    ws.Cells[1,9] = "Khoa";

                    
                    ws.Cells.Style.Font.Size = 13;

                    for (int i = 0; i < ds.Count; i++)
                    {
                        
                        ws.Cells[i+2, 1] = ds[i].maSo;
                        ws.Cells[i+2, 2] = ds[i].hoLot;
                        ws.Cells[i+2, 3] = ds[i].ten;
                        ws.Cells[i+2, 4] = ds[i].gioiTinh;
                        ws.Cells[i+2, 5] = ds[i].ngaySinh.ToString("dd/MM/yyyy");
                        ws.Cells[i+2, 6] = ds[i].sdt;
                        ws.Cells[i+2, 7] = ds[i].diaChi;
                        ws.Cells[i+2, 8] = ds[i].lop;
                        ws.Cells[i+2, 9] = ds[i].khoa;


                    }

                    wb.SaveAs(saveFile.FileName, XlFileFormat.xlWorkbookDefault,
                        Type.Missing, Type.Missing,false,false,XlSaveAsAccessMode.xlShared); 
                    MessageBox.Show("Lưu thành công","Thông báo");
                }
               
            } 
        }

        private void SaveJson(List<Student> ds, string fileName)
        {
            using (StreamWriter file = File.CreateText(fileName))
            {
                JsonSerializer js = new JsonSerializer();
                js.Serialize(file, ds);

            }
        }

        private void tsmiSaveJson_Click(object sender, EventArgs e)
        {

            var department = tvwDepartment.SelectedNode.Parent.Text;
            var clss = tvwDepartment.SelectedNode.Text;
            List<Student> ds = _importExport.GetStudents(department, clss);
            using (SaveFileDialog saveFile = new SaveFileDialog())
            {
                saveFile.Filter = "Json File(json) |*.json";
                saveFile.InitialDirectory = @"D:\";
                saveFile.Title = "Chọn mục cần lưu";
                saveFile.FileName = clss + ".json";

                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    SaveJson(ds, saveFile.FileName);
                    MessageBox.Show("Lưu thành công", "Thông báo");
                }
                
                
            }
        }

        
    }
}
