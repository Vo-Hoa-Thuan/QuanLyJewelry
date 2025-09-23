namespace QuanLyJewelry.View
{
    partial class frmThongKe
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThongKe));

            // Khởi tạo controls
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chartDoanhThu = new LiveCharts.WinForms.CartesianChart();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTongDonHang = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTongDoanhThu = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblDonGiaTB = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSoKhachHang = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvTopSanPham = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgvNhanVien = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dgvKhachHang = new System.Windows.Forms.DataGridView();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvLoaiSP = new System.Windows.Forms.DataGridView();
            this.chartLoaiSP = new LiveCharts.WinForms.PieChart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.btnInBaoCao = new System.Windows.Forms.Button();
            this.cboThang = new System.Windows.Forms.ComboBox();
            this.cboNam = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();

            // 
            // frmThongKe
            // 
            this.ClientSize = new System.Drawing.Size(1300, 800); // Tăng kích thước form
            this.MinimumSize = new System.Drawing.Size(1250,750);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thống kê báo cáo";
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            // 
            // panel1
            // 
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Height = 60; // Tăng chiều cao panel
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Padding = new System.Windows.Forms.Padding(15);

            // 
            // label5
            // 
            this.label5 = new System.Windows.Forms.Label();
            this.label5.Text = "Tháng:";
            this.label5.Location = new System.Drawing.Point(30, 18);
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);

            // 
            // cboThang
            // 
            this.cboThang = new System.Windows.Forms.ComboBox();
            this.cboThang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboThang.Location = new System.Drawing.Point(100, 15);
            this.cboThang.Size = new System.Drawing.Size(100, 28); // Tăng kích thước
            this.cboThang.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboThang.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" });

            // 
            // label6
            // 
            this.label6 = new System.Windows.Forms.Label();
            this.label6.Text = "Năm:";
            this.label6.Location = new System.Drawing.Point(220, 18);
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);

            // 
            // cboNam
            // 
            this.cboNam = new System.Windows.Forms.ComboBox();
            this.cboNam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNam.Location = new System.Drawing.Point(270, 15);
            this.cboNam.Size = new System.Drawing.Size(120, 28); // Tăng kích thước
            this.cboNam.Font = new System.Drawing.Font("Segoe UI", 10F);

            // 
            // btnLamMoi
            // 
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.Location = new System.Drawing.Point(420, 12);
            this.btnLamMoi.Size = new System.Drawing.Size(120, 35); // Tăng kích thước
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLamMoi.BackColor = System.Drawing.Color.SteelBlue;
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;

            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.btnXuatExcel.Text = "Xuất Excel";
            this.btnXuatExcel.Location = new System.Drawing.Point(560, 12);
            this.btnXuatExcel.Size = new System.Drawing.Size(120, 35);
            this.btnXuatExcel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnXuatExcel.BackColor = System.Drawing.Color.SteelBlue;
            this.btnXuatExcel.ForeColor = System.Drawing.Color.White;
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);

            // 
            // btnInBaoCao
            // 
            this.btnInBaoCao = new System.Windows.Forms.Button();
            this.btnInBaoCao.Text = "In báo cáo";
            this.btnInBaoCao.Location = new System.Drawing.Point(700, 12);
            this.btnInBaoCao.Size = new System.Drawing.Size(120, 35);
            this.btnInBaoCao.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnInBaoCao.BackColor = System.Drawing.Color.SteelBlue;
            this.btnInBaoCao.ForeColor = System.Drawing.Color.White;
            this.btnInBaoCao.Click += new System.EventHandler(this.btnInBaoCao_Click);

            // Thêm controls vào panel
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cboThang);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cboNam);
            this.panel1.Controls.Add(this.btnLamMoi);
            this.panel1.Controls.Add(this.btnXuatExcel);
            this.panel1.Controls.Add(this.btnInBaoCao);

            // 
            // tabControl1
            // 
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 60);
            this.tabControl1.Size = new System.Drawing.Size(1300, 740);
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.ItemSize = new System.Drawing.Size(180, 40); // Tăng kích thước tab

            // Khởi tạo và thêm các tab pages
            this.InitializeTabPages();

            // Thêm controls vào Form
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);

            this.ResumeLayout(false);
        }

        private void InitializeTabPages()
        {
            // TabPage1 - Tổng quan
            this.tabPage1.Text = "TỔNG QUAN";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(15);
            this.tabPage1.BackColor = System.Drawing.Color.WhiteSmoke;

            // GroupBox2 - Doanh thu theo tháng
            this.groupBox2.Text = "BIỂU ĐỒ DOANH THU THEO THÁNG";
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(380, 15);
            this.groupBox2.Size = new System.Drawing.Size(897, 672);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.groupBox2.ForeColor = System.Drawing.Color.DarkSlateBlue;

            // Chart doanh thu
            this.chartDoanhThu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartDoanhThu.Location = new System.Drawing.Point(3, 25);
            this.groupBox2.Controls.Add(this.chartDoanhThu);

            // GroupBox1 - Thống kê tổng quan
            this.groupBox1.Text = "THỐNG KÊ TỔNG QUAN";
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(15, 15);
            this.groupBox1.Size = new System.Drawing.Size(400, 672);
            this.groupBox1.Padding = new System.Windows.Forms.Padding(15);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.DarkSlateBlue;

            // Labels trong groupBox1 - Tăng kích thước và khoảng cách
            int startY = 40;
            int spacing = 70;

            this.label1.Text = "Tổng số đơn hàng:";
            this.label1.Location = new System.Drawing.Point(25, startY);
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);

            this.lblTongDonHang.Text = "0";
            this.lblTongDonHang.Location = new System.Drawing.Point(250, startY);
            this.lblTongDonHang.AutoSize = true;
            this.lblTongDonHang.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular);
            this.lblTongDonHang.ForeColor = System.Drawing.Color.DarkBlue;

            this.label2.Text = "Tổng doanh thu:";
            this.label2.Location = new System.Drawing.Point(25, startY + spacing);
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);

            this.lblTongDoanhThu.Text = "0 đ";
            this.lblTongDoanhThu.Location = new System.Drawing.Point(250, startY + spacing);
            this.lblTongDoanhThu.AutoSize = true;
            this.lblTongDoanhThu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular);
            this.lblTongDoanhThu.ForeColor = System.Drawing.Color.DarkBlue;

            this.label3.Text = "Đơn giá trung bình:";
            this.label3.Location = new System.Drawing.Point(25, startY + spacing * 2);
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);

            this.lblDonGiaTB.Text = "0 đ";
            this.lblDonGiaTB.Location = new System.Drawing.Point(250, startY + spacing * 2);
            this.lblDonGiaTB.AutoSize = true;
            this.lblDonGiaTB.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular);
            this.lblDonGiaTB.ForeColor = System.Drawing.Color.DarkBlue;

            this.label4.Text = "Số khách hàng:";
            this.label4.Location = new System.Drawing.Point(25, startY + spacing * 3);
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);

            this.lblSoKhachHang.Text = "0";
            this.lblSoKhachHang.Location = new System.Drawing.Point(250, startY + spacing * 3);
            this.lblSoKhachHang.AutoSize = true;
            this.lblSoKhachHang.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular);
            this.lblSoKhachHang.ForeColor = System.Drawing.Color.DarkBlue;

            // Thêm controls vào groupBox1
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblTongDonHang);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblTongDoanhThu);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblDonGiaTB);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblSoKhachHang);

            // Thêm controls vào tabPage1
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.groupBox2);

            // TabPage2 - Top sản phẩm
            this.tabPage2.Text = "TOP SẢN PHẨM";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(10);
            this.tabPage2.BackColor = System.Drawing.Color.WhiteSmoke;

            this.dgvTopSanPham.Dock = DockStyle.Fill;
            this.dgvTopSanPham.ReadOnly = true;
            this.dgvTopSanPham.RowHeadersVisible = false;
            this.dgvTopSanPham.ColumnHeadersHeight = 40;
            this.dgvTopSanPham.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvTopSanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTopSanPham.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dgvTopSanPham.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Lavender;
            this.dgvTopSanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvTopSanPham.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            this.tabPage2.Controls.Add(this.dgvTopSanPham);

            // TabPage3 - Doanh thu nhân viên
            this.tabPage3.Text = "DOANH THU NHÂN VIÊN";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(10);
            this.tabPage3.BackColor = System.Drawing.Color.WhiteSmoke;

            this.dgvNhanVien.Dock = DockStyle.Fill;
            this.dgvNhanVien.ReadOnly = true;
            this.dgvNhanVien.RowHeadersVisible = false;
            this.dgvNhanVien.ColumnHeadersHeight = 40;
            this.dgvNhanVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNhanVien.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dgvNhanVien.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Lavender;
            this.dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvNhanVien.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            this.tabPage3.Controls.Add(this.dgvNhanVien);

            // TabPage4 - Top khách hàng
            this.tabPage4.Text = "TOP KHÁCH HÀNG";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(10);
            this.tabPage4.BackColor = System.Drawing.Color.WhiteSmoke;

            this.dgvKhachHang.Dock = DockStyle.Fill;
            this.dgvKhachHang.ReadOnly = true;
            this.dgvKhachHang.RowHeadersVisible = false;
            this.dgvKhachHang.ColumnHeadersHeight = 40;
            this.dgvKhachHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKhachHang.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dgvKhachHang.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Lavender;
            this.dgvKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvKhachHang.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvKhachHang.DoubleClick += new System.EventHandler(this.dgvKhachHang_DoubleClick);
            this.tabPage4.Controls.Add(this.dgvKhachHang);

            // TabPage5 - Doanh thu theo loại
            this.tabPage5.Text = "DOANH THU THEO LOẠI";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(10);
            this.tabPage5.BackColor = System.Drawing.Color.WhiteSmoke;

            this.splitContainer1.Dock = DockStyle.Fill;
            this.splitContainer1.SplitterDistance = 500; // Tăng kích thước splitter

            this.dgvLoaiSP.Dock = DockStyle.Fill;
            this.dgvLoaiSP.ReadOnly = true;
            this.dgvLoaiSP.RowHeadersVisible = false;
            this.dgvLoaiSP.ColumnHeadersHeight = 40;
            this.dgvLoaiSP.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLoaiSP.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dgvLoaiSP.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvLoaiSP.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvLoaiSP.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Lavender;

            this.chartLoaiSP.Dock = DockStyle.Fill;

            this.splitContainer1.Panel1.Controls.Add(this.dgvLoaiSP);
            this.splitContainer1.Panel2.Controls.Add(this.chartLoaiSP);

            this.tabPage5.Controls.Add(this.splitContainer1);

            // Thêm các tab pages vào tab control
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);

            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.UseAntiAlias = true;
        }

        // Controls declarations

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox2;
        private LiveCharts.WinForms.CartesianChart chartDoanhThu;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTongDonHang;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTongDoanhThu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblDonGiaTB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblSoKhachHang;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvTopSanPham;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dgvNhanVien;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView dgvKhachHang;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvLoaiSP;
        private LiveCharts.WinForms.PieChart chartLoaiSP;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnXuatExcel;
        private System.Windows.Forms.Button btnInBaoCao;
        private System.Windows.Forms.ComboBox cboThang;
        private System.Windows.Forms.ComboBox cboNam;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
    }
}