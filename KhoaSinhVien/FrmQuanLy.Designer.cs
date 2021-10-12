
namespace KhoaSinhVien
{
    partial class FrmQuanLy
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.nhậpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lưuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSaveExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSaveJson = new System.Windows.Forms.ToolStripMenuItem();
            this.inToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.tvwDepartment = new System.Windows.Forms.TreeView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lvInformation = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiAddStudent = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteStudent = new System.Windows.Forms.ToolStripMenuItem();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.rdbSDT = new System.Windows.Forms.RadioButton();
            this.rdbHoTen = new System.Windows.Forms.RadioButton();
            this.rdbMSSV = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nhậpToolStripMenuItem,
            this.lưuToolStripMenuItem,
            this.inToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1227, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // nhậpToolStripMenuItem
            // 
            this.nhậpToolStripMenuItem.Name = "nhậpToolStripMenuItem";
            this.nhậpToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.nhậpToolStripMenuItem.Text = "Nhập";
            // 
            // lưuToolStripMenuItem
            // 
            this.lưuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSaveExcel,
            this.tsmiSaveJson});
            this.lưuToolStripMenuItem.Name = "lưuToolStripMenuItem";
            this.lưuToolStripMenuItem.Size = new System.Drawing.Size(47, 24);
            this.lưuToolStripMenuItem.Text = "Lưu";
            // 
            // tsmiSaveExcel
            // 
            this.tsmiSaveExcel.Name = "tsmiSaveExcel";
            this.tsmiSaveExcel.Size = new System.Drawing.Size(126, 26);
            this.tsmiSaveExcel.Text = "Excel";
            this.tsmiSaveExcel.Click += new System.EventHandler(this.tsmiSaveExcel_Click);
            // 
            // tsmiSaveJson
            // 
            this.tsmiSaveJson.Name = "tsmiSaveJson";
            this.tsmiSaveJson.Size = new System.Drawing.Size(126, 26);
            this.tsmiSaveJson.Text = "Json";
            this.tsmiSaveJson.Click += new System.EventHandler(this.tsmiSaveJson_Click);
            // 
            // inToolStripMenuItem
            // 
            this.inToolStripMenuItem.Name = "inToolStripMenuItem";
            this.inToolStripMenuItem.Size = new System.Drawing.Size(35, 24);
            this.inToolStripMenuItem.Text = "In";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Chọn lớp để hiển thị danh sách sinh viên";
            // 
            // tvwDepartment
            // 
            this.tvwDepartment.Location = new System.Drawing.Point(16, 106);
            this.tvwDepartment.Name = "tvwDepartment";
            this.tvwDepartment.Size = new System.Drawing.Size(367, 709);
            this.tvwDepartment.TabIndex = 2;
            this.tvwDepartment.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwDepartment_AfterSelect);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lvInformation);
            this.groupBox1.Controls.Add(this.txtSearch);
            this.groupBox1.Controls.Add(this.rdbSDT);
            this.groupBox1.Controls.Add(this.rdbHoTen);
            this.groupBox1.Controls.Add(this.rdbMSSV);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(390, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(825, 798);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm kiếm";
            // 
            // lvInformation
            // 
            this.lvInformation.CheckBoxes = true;
            this.lvInformation.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.lvInformation.ContextMenuStrip = this.contextMenuStrip1;
            this.lvInformation.FullRowSelect = true;
            this.lvInformation.GridLines = true;
            this.lvInformation.HideSelection = false;
            this.lvInformation.Location = new System.Drawing.Point(7, 74);
            this.lvInformation.Name = "lvInformation";
            this.lvInformation.Size = new System.Drawing.Size(812, 718);
            this.lvInformation.TabIndex = 5;
            this.lvInformation.UseCompatibleStateImageBehavior = false;
            this.lvInformation.View = System.Windows.Forms.View.Details;
            this.lvInformation.DoubleClick += new System.EventHandler(this.lvInformation_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "MSSV";
            this.columnHeader1.Width = 102;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Họ và tên lót";
            this.columnHeader2.Width = 143;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Tên";
            this.columnHeader3.Width = 115;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Giới tính";
            this.columnHeader4.Width = 114;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Ngày sinh";
            this.columnHeader5.Width = 120;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Số điện thoại";
            this.columnHeader6.Width = 122;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Lớp";
            this.columnHeader7.Width = 104;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAddStudent,
            this.tsmiDeleteStudent});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(116, 52);
            // 
            // tsmiAddStudent
            // 
            this.tsmiAddStudent.Name = "tsmiAddStudent";
            this.tsmiAddStudent.Size = new System.Drawing.Size(115, 24);
            this.tsmiAddStudent.Text = "Thêm";
            this.tsmiAddStudent.Click += new System.EventHandler(this.tsmiAddStudent_Click);
            // 
            // tsmiDeleteStudent
            // 
            this.tsmiDeleteStudent.Name = "tsmiDeleteStudent";
            this.tsmiDeleteStudent.Size = new System.Drawing.Size(115, 24);
            this.tsmiDeleteStudent.Text = "Xóa";
            this.tsmiDeleteStudent.Click += new System.EventHandler(this.tsmiDeleteStudent_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(165, 48);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(376, 22);
            this.txtSearch.TabIndex = 4;
           
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // rdbSDT
            // 
            this.rdbSDT.AutoSize = true;
            this.rdbSDT.Location = new System.Drawing.Point(429, 20);
            this.rdbSDT.Name = "rdbSDT";
            this.rdbSDT.Size = new System.Drawing.Size(112, 21);
            this.rdbSDT.TabIndex = 3;
            this.rdbSDT.TabStop = true;
            this.rdbSDT.Text = "Số điện thoại";
            this.rdbSDT.UseVisualStyleBackColor = true;
            // 
            // rdbHoTen
            // 
            this.rdbHoTen.AutoSize = true;
            this.rdbHoTen.Location = new System.Drawing.Point(299, 21);
            this.rdbHoTen.Name = "rdbHoTen";
            this.rdbHoTen.Size = new System.Drawing.Size(71, 21);
            this.rdbHoTen.TabIndex = 2;
            this.rdbHoTen.TabStop = true;
            this.rdbHoTen.Text = "Họ tên";
            this.rdbHoTen.UseVisualStyleBackColor = true;
            // 
            // rdbMSSV
            // 
            this.rdbMSSV.AutoSize = true;
            this.rdbMSSV.Location = new System.Drawing.Point(165, 20);
            this.rdbMSSV.Name = "rdbMSSV";
            this.rdbMSSV.Size = new System.Drawing.Size(67, 21);
            this.rdbMSSV.TabIndex = 1;
            this.rdbMSSV.TabStop = true;
            this.rdbMSSV.Text = "MSSV";
            this.rdbMSSV.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tìm theo:";
            // 
            // FrmQuanLy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1227, 842);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tvwDepartment);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmQuanLy";
            this.Text = "Quản lý sinh viên";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem nhậpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lưuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView tvwDepartment;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lvInformation;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.RadioButton rdbSDT;
        private System.Windows.Forms.RadioButton rdbHoTen;
        private System.Windows.Forms.RadioButton rdbMSSV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddStudent;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteStudent;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveExcel;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveJson;
    }
}

