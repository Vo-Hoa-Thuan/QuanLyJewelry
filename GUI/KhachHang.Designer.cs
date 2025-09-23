namespace QuanLyJewelry.GUI
{
    partial class frmKhachHang
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            txtTimKiem = new TextBox();
            btnLamMoi = new Button();
            groupBox2 = new GroupBox();
            lblMaKH = new Label();
            txtMaKH = new TextBox();
            label1 = new Label();
            txtHoTen = new TextBox();
            label2 = new Label();
            txtSoDienThoai = new TextBox();
            label3 = new Label();
            txtEmail = new TextBox();
            label4 = new Label();
            txtDiaChi = new TextBox();
            label5 = new Label();
            dtpNgayVao = new DateTimePicker();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            dgvKhachHang = new DataGridView();
            groupBox3 = new GroupBox();
            dgvSanPhamDaMua = new DataGridView();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKhachHang).BeginInit();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSanPhamDaMua).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtTimKiem);
            groupBox1.Controls.Add(btnLamMoi);
            groupBox1.Font = new Font("Cascadia Code", 11F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox1.Location = new Point(10, 10);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1000, 70);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Tìm kiếm";
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(10, 30);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(780, 29);
            txtTimKiem.TabIndex = 0;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = SystemColors.Highlight;
            btnLamMoi.Location = new Point(800, 25);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(100, 35);
            btnLamMoi.TabIndex = 1;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lblMaKH);
            groupBox2.Controls.Add(txtMaKH);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(txtHoTen);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(txtSoDienThoai);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(txtEmail);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(txtDiaChi);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(dtpNgayVao);
            groupBox2.Controls.Add(btnThem);
            groupBox2.Controls.Add(btnSua);
            groupBox2.Controls.Add(btnXoa);
            groupBox2.Controls.Add(dgvKhachHang);
            groupBox2.Font = new Font("Cascadia Code", 11F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox2.Location = new Point(10, 90);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1000, 700);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Thông tin khách hàng";
            // 
            // lblMaKH
            // 
            lblMaKH.AutoSize = true;
            lblMaKH.Location = new Point(10, 30);
            lblMaKH.Name = "lblMaKH";
            lblMaKH.Size = new Size(78, 25);
            lblMaKH.TabIndex = 0;
            lblMaKH.Text = "Mã KH:";
            // 
            // txtMaKH
            // 
            txtMaKH.Location = new Point(100, 30);
            txtMaKH.Name = "txtMaKH";
            txtMaKH.ReadOnly = true;
            txtMaKH.Size = new Size(150, 29);
            txtMaKH.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(270, 30);
            label1.Name = "label1";
            label1.Size = new Size(89, 25);
            label1.TabIndex = 2;
            label1.Text = "Họ tên:";
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(340, 30);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(300, 29);
            txtHoTen.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 70);
            label2.Name = "label2";
            label2.Size = new Size(166, 25);
            label2.TabIndex = 4;
            label2.Text = "Số điện thoại:";
            // 
            // txtSoDienThoai
            // 
            txtSoDienThoai.Location = new Point(150, 70);
            txtSoDienThoai.Name = "txtSoDienThoai";
            txtSoDienThoai.Size = new Size(200, 29);
            txtSoDienThoai.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(370, 70);
            label3.Name = "label3";
            label3.Size = new Size(78, 25);
            label3.TabIndex = 6;
            label3.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(430, 70);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(360, 29);
            txtEmail.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(10, 110);
            label4.Name = "label4";
            label4.Size = new Size(100, 25);
            label4.TabIndex = 8;
            label4.Text = "Địa chỉ:";
            // 
            // txtDiaChi
            // 
            txtDiaChi.Location = new Point(80, 110);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(710, 29);
            txtDiaChi.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(10, 150);
            label5.Name = "label5";
            label5.Size = new Size(111, 25);
            label5.TabIndex = 10;
            label5.Text = "Ngày vào:";
            // 
            // dtpNgayVao
            // 
            dtpNgayVao.Format = DateTimePickerFormat.Short;
            dtpNgayVao.Location = new Point(120, 150);
            dtpNgayVao.Name = "dtpNgayVao";
            dtpNgayVao.Size = new Size(150, 29);
            dtpNgayVao.TabIndex = 11;
            // 
            // btnThem
            // 
            btnThem.BackColor = SystemColors.Highlight;
            btnThem.Location = new Point(10, 190);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(100, 40);
            btnThem.TabIndex = 12;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.BackColor = SystemColors.Highlight;
            btnSua.Enabled = false;
            btnSua.ForeColor = SystemColors.ControlText;
            btnSua.Location = new Point(256, 190);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(352, 40);
            btnSua.TabIndex = 13;
            btnSua.Text = "Xem chi tiết sản phẩm đã mua";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = SystemColors.Highlight;
            btnXoa.Location = new Point(134, 190);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(100, 40);
            btnXoa.TabIndex = 14;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // dgvKhachHang
            // 
            dgvKhachHang.AllowUserToAddRows = false;
            dgvKhachHang.AllowUserToDeleteRows = false;
            dgvKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKhachHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKhachHang.Location = new Point(10, 240);
            dgvKhachHang.Name = "dgvKhachHang";
            dgvKhachHang.ReadOnly = true;
            dgvKhachHang.RowHeadersWidth = 51;
            dgvKhachHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKhachHang.Size = new Size(970, 450);
            dgvKhachHang.TabIndex = 16;
            dgvKhachHang.CellDoubleClick += dgvKhachHang_CellDoubleClick;
            dgvKhachHang.SelectionChanged += dgvKhachHang_SelectionChanged;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(dgvSanPhamDaMua);
            groupBox3.Font = new Font("Cascadia Code", 11F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox3.Location = new Point(1020, 90);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(600, 700);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Sản phẩm đã mua";
            // 
            // dgvSanPhamDaMua
            // 
            dgvSanPhamDaMua.AllowUserToAddRows = false;
            dgvSanPhamDaMua.AllowUserToDeleteRows = false;
            dgvSanPhamDaMua.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSanPhamDaMua.Dock = DockStyle.Fill;
            dgvSanPhamDaMua.Location = new Point(3, 25);
            dgvSanPhamDaMua.Name = "dgvSanPhamDaMua";
            dgvSanPhamDaMua.ReadOnly = true;
            dgvSanPhamDaMua.RowHeadersWidth = 51;
            dgvSanPhamDaMua.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSanPhamDaMua.Size = new Size(594, 672);
            dgvSanPhamDaMua.TabIndex = 0;
            // 
            // frmKhachHang
            // 
            ClientSize = new Size(1640, 800);
            Controls.Add(groupBox1);
            Controls.Add(groupBox2);
            Controls.Add(groupBox3);
            MinimumSize = new Size(1650, 840);
            Name = "frmKhachHang";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý khách hàng";
            Load += frmKhachHang_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKhachHang).EndInit();
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSanPhamDaMua).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblMaKH;
        private System.Windows.Forms.TextBox txtMaKH;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSoDienThoai;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpNgayVao;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnXemChiTiet;
        private System.Windows.Forms.DataGridView dgvKhachHang;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvSanPhamDaMua;
    }
}