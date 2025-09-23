namespace QuanLyJewelry.GUI
{
    partial class frmNhapSP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNhapSP));
            lblNhapSP = new Label();
            groupBox1 = new GroupBox();
            pbHinhAnh = new PictureBox();
            gbThongTin = new GroupBox();
            txtMoTa = new TextBox();
            label2 = new Label();
            btnLưu = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnReset = new Button();
            btnThem = new Button();
            cbLoaiSP = new ComboBox();
            txtGiaBan = new TextBox();
            txtTenSP = new TextBox();
            txtMaSP = new TextBox();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label3 = new Label();
            gbDanhSachSP = new GroupBox();
            dtgvDSSP = new DataGridView();
            txtTimKiem = new TextBox();
            btnTimKiem = new Button();
            label1 = new Label();
            btnChon = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbHinhAnh).BeginInit();
            gbThongTin.SuspendLayout();
            gbDanhSachSP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgvDSSP).BeginInit();
            SuspendLayout();
            // 
            // lblNhapSP
            // 
            lblNhapSP.AutoSize = true;
            lblNhapSP.Font = new Font("Cascadia Code", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lblNhapSP.Location = new Point(503, 9);
            lblNhapSP.Margin = new Padding(2, 0, 2, 0);
            lblNhapSP.Name = "lblNhapSP";
            lblNhapSP.Size = new Size(210, 32);
            lblNhapSP.TabIndex = 0;
            lblNhapSP.Text = "Nhập Sản Phẩm ";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(pbHinhAnh);
            groupBox1.Font = new Font("Cascadia Code SemiBold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox1.Location = new Point(123, 52);
            groupBox1.Margin = new Padding(2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(2);
            groupBox1.Size = new Size(246, 222);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Hình ảnh ";
            // 
            // pbHinhAnh
            // 
            pbHinhAnh.Location = new Point(4, 24);
            pbHinhAnh.Margin = new Padding(2);
            pbHinhAnh.Name = "pbHinhAnh";
            pbHinhAnh.Size = new Size(238, 194);
            pbHinhAnh.TabIndex = 0;
            pbHinhAnh.TabStop = false;
            // 
            // gbThongTin
            // 
            gbThongTin.Controls.Add(txtMoTa);
            gbThongTin.Controls.Add(label2);
            gbThongTin.Controls.Add(btnLưu);
            gbThongTin.Controls.Add(btnSua);
            gbThongTin.Controls.Add(btnXoa);
            gbThongTin.Controls.Add(btnReset);
            gbThongTin.Controls.Add(btnThem);
            gbThongTin.Controls.Add(cbLoaiSP);
            gbThongTin.Controls.Add(txtGiaBan);
            gbThongTin.Controls.Add(txtTenSP);
            gbThongTin.Controls.Add(txtMaSP);
            gbThongTin.Controls.Add(label8);
            gbThongTin.Controls.Add(label7);
            gbThongTin.Controls.Add(label6);
            gbThongTin.Controls.Add(label3);
            gbThongTin.Font = new Font("Cascadia Code SemiBold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            gbThongTin.ForeColor = Color.Black;
            gbThongTin.Location = new Point(503, 52);
            gbThongTin.Margin = new Padding(2);
            gbThongTin.Name = "gbThongTin";
            gbThongTin.Padding = new Padding(2);
            gbThongTin.Size = new Size(579, 316);
            gbThongTin.TabIndex = 2;
            gbThongTin.TabStop = false;
            gbThongTin.Text = "Thông tin";
            // 
            // txtMoTa
            // 
            txtMoTa.Location = new Point(262, 82);
            txtMoTa.Margin = new Padding(2);
            txtMoTa.Multiline = true;
            txtMoTa.Name = "txtMoTa";
            txtMoTa.Size = new Size(279, 179);
            txtMoTa.TabIndex = 22;
            txtMoTa.ScrollBars = ScrollBars.Vertical; // có thanh cuộn
            txtMoTa.WordWrap = true; // tự xuống dòng
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(361, 42);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(70, 22);
            label2.TabIndex = 21;
            label2.Text = "Mô tả:";
            // 
            // btnLưu
            // 
            btnLưu.BackColor = Color.FromArgb(0, 122, 204);
            btnLưu.FlatAppearance.BorderSize = 0;
            btnLưu.FlatStyle = FlatStyle.Flat;
            btnLưu.ForeColor = Color.White;
            btnLưu.Location = new Point(452, 269);
            btnLưu.Margin = new Padding(2);
            btnLưu.Name = "btnLưu";
            btnLưu.Size = new Size(105, 37);
            btnLưu.TabIndex = 20;
            btnLưu.Text = "Xuất Excel";
            btnLưu.UseVisualStyleBackColor = false;
            btnLưu.Click += btnLưu_Click;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.FromArgb(0, 122, 204);
            btnSua.FlatAppearance.BorderSize = 0;
            btnSua.FlatStyle = FlatStyle.Flat;
            btnSua.ForeColor = Color.White;
            btnSua.Location = new Point(127, 269);
            btnSua.Margin = new Padding(2);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(90, 37);
            btnSua.TabIndex = 19;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.FromArgb(0, 122, 204);
            btnXoa.FlatAppearance.BorderSize = 0;
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.ForeColor = Color.White;
            btnXoa.Location = new Point(238, 269);
            btnXoa.Margin = new Padding(2);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(90, 37);
            btnXoa.TabIndex = 18;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnReset
            // 
            btnReset.BackColor = Color.FromArgb(0, 122, 204);
            btnReset.FlatAppearance.BorderSize = 0;
            btnReset.FlatStyle = FlatStyle.Flat;
            btnReset.ForeColor = Color.White;
            btnReset.Location = new Point(349, 269);
            btnReset.Margin = new Padding(2);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(82, 37);
            btnReset.TabIndex = 17;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = false;
            btnReset.Click += btnReset_Click;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.FromArgb(0, 122, 204);
            btnThem.FlatAppearance.BorderSize = 0;
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(16, 269);
            btnThem.Margin = new Padding(2);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(90, 37);
            btnThem.TabIndex = 16;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // cbLoaiSP
            // 
            cbLoaiSP.DropDownStyle = ComboBoxStyle.DropDownList;
            cbLoaiSP.FormattingEnabled = true;
            cbLoaiSP.Location = new Point(45, 175);
            cbLoaiSP.Margin = new Padding(2);
            cbLoaiSP.Name = "cbLoaiSP";
            cbLoaiSP.Size = new Size(174, 30);
            cbLoaiSP.TabIndex = 11;
            // 
            // txtGiaBan
            // 
            txtGiaBan.Location = new Point(45, 233);
            txtGiaBan.Margin = new Padding(2);
            txtGiaBan.Multiline = true;
            txtGiaBan.Name = "txtGiaBan";
            txtGiaBan.Size = new Size(174, 28);
            txtGiaBan.TabIndex = 10;
            // 
            // txtTenSP
            // 
            txtTenSP.Location = new Point(43, 114);
            txtTenSP.Margin = new Padding(2);
            txtTenSP.Multiline = true;
            txtTenSP.Name = "txtTenSP";
            txtTenSP.Size = new Size(174, 28);
            txtTenSP.TabIndex = 8;
            txtTenSP.ScrollBars = ScrollBars.Vertical; // có thanh cuộn
            txtTenSP.WordWrap = true; // tự xuống dòng
            // 
            // txtMaSP
            // 
            txtMaSP.Location = new Point(43, 54);
            txtMaSP.Margin = new Padding(2);
            txtMaSP.Multiline = true;
            txtMaSP.Name = "txtMaSP";
            txtMaSP.Size = new Size(174, 28);
            txtMaSP.TabIndex = 6;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(83, 211);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(90, 22);
            label8.TabIndex = 5;
            label8.Text = "Giá bán:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(60, 90);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(140, 22);
            label7.TabIndex = 4;
            label7.Text = "Tên sản phẩm:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(57, 148);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(150, 22);
            label6.TabIndex = 3;
            label6.Text = "Loại sản phẩm:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(65, 29);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(130, 22);
            label3.TabIndex = 0;
            label3.Text = "Mã sản phẩm:";
            // 
            // gbDanhSachSP
            // 
            gbDanhSachSP.Controls.Add(dtgvDSSP);
            gbDanhSachSP.Font = new Font("Cascadia Code SemiBold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            gbDanhSachSP.Location = new Point(22, 372);
            gbDanhSachSP.Margin = new Padding(2);
            gbDanhSachSP.Name = "gbDanhSachSP";
            gbDanhSachSP.Padding = new Padding(2);
            gbDanhSachSP.Size = new Size(1123, 369);
            gbDanhSachSP.TabIndex = 3;
            gbDanhSachSP.TabStop = false;
            gbDanhSachSP.Text = "Danh sách SP";
            // 
            // dtgvDSSP
            // 
            dtgvDSSP.AllowUserToAddRows = false;
            dtgvDSSP.AllowUserToDeleteRows = false;
            dtgvDSSP.AllowUserToResizeColumns = false;
            dtgvDSSP.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvDSSP.BackgroundColor = SystemColors.Control;
            dtgvDSSP.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgvDSSP.GridColor = Color.FromArgb(224, 224, 224);
            dtgvDSSP.Location = new Point(9, 26);
            dtgvDSSP.Margin = new Padding(2);
            dtgvDSSP.Name = "dtgvDSSP";
            dtgvDSSP.ReadOnly = true;
            dtgvDSSP.RowHeadersVisible = false;
            dtgvDSSP.RowHeadersWidth = 62;
            dtgvDSSP.RowTemplate.Height = 33;
            dtgvDSSP.Size = new Size(1114, 339);
            dtgvDSSP.TabIndex = 0;
            dtgvDSSP.CellClick += dtgvDSSP_CellClick;
            dtgvDSSP.SelectionChanged += dtgvDSSP_SelectionChanged;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Font = new Font("Cascadia Code Light", 8F, FontStyle.Regular, GraphicsUnit.Point);
            txtTimKiem.ForeColor = SystemColors.WindowFrame;
            txtTimKiem.Location = new Point(221, 329);
            txtTimKiem.Margin = new Padding(2);
            txtTimKiem.Multiline = true;
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(209, 34);
            txtTimKiem.TabIndex = 4;
            // 
            // btnTimKiem
            // 
            btnTimKiem.FlatAppearance.BorderSize = 0;
            btnTimKiem.FlatStyle = FlatStyle.Flat;
            btnTimKiem.Image = (Image)resources.GetObject("btnTimKiem.Image");
            btnTimKiem.Location = new Point(434, 323);
            btnTimKiem.Margin = new Padding(2);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(44, 45);
            btnTimKiem.TabIndex = 5;
            btnTimKiem.UseCompatibleTextRendering = true;
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(97, 329);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(120, 25);
            label1.TabIndex = 20;
            label1.Text = "Nhập tên sp:";
            // 
            // btnChon
            // 
            btnChon.BackColor = Color.FromArgb(0, 122, 204);
            btnChon.FlatAppearance.BorderSize = 0;
            btnChon.FlatStyle = FlatStyle.Flat;
            btnChon.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnChon.ForeColor = Color.White;
            btnChon.Location = new Point(199, 278);
            btnChon.Margin = new Padding(2);
            btnChon.Name = "btnChon";
            btnChon.Size = new Size(90, 37);
            btnChon.TabIndex = 22;
            btnChon.Text = "Chọn";
            btnChon.UseVisualStyleBackColor = false;
            btnChon.Click += btnChon_Click;
            // 
            // frmNhapSP
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1168, 770);
            Controls.Add(btnChon);
            Controls.Add(label1);
            Controls.Add(btnTimKiem);
            Controls.Add(txtTimKiem);
            Controls.Add(gbDanhSachSP);
            Controls.Add(gbThongTin);
            Controls.Add(groupBox1);
            Controls.Add(lblNhapSP);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(2);
            Name = "frmNhapSP";
            Text = "NhapSP";
            Load += frmNhapSP_Load;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbHinhAnh).EndInit();
            gbThongTin.ResumeLayout(false);
            gbThongTin.PerformLayout();
            gbDanhSachSP.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dtgvDSSP).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNhapSP;
        private GroupBox groupBox1;
        private PictureBox pbHinhAnh;
        private GroupBox gbThongTin;
        private Label label3;
        private ComboBox cbLoaiSP;
        private TextBox txtGiaBan;
        private TextBox txtTenSP;
        private TextBox txtMaSP;
        private Label label8;
        private Label label7;
        private Label label6;
        private Button btnSua;
        private Button btnXoa;
        private Button btnReset;
        private Button btnThem;
        private GroupBox gbDanhSachSP;
        private DataGridView dtgvDSSP;
        private TextBox txtTimKiem;
        private Button btnTimKiem;
        private Label label1;
        private Button btnChon;
        private Button btnLưu;
        private TextBox txtMoTa;
        private Label label2;
    }
}