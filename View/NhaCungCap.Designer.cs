namespace QuanLyJewelry.View
{
    partial class frmNhaCungCap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNhaCungCap));
            gbThongTinNCC = new GroupBox();
            label5 = new Label();
            btnXuatE = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnReset = new Button();
            btnThem = new Button();
            btnTimKiem = new Button();
            txtTimKiem = new TextBox();
            txtTenNCC = new TextBox();
            txtSDTNCC = new TextBox();
            txtDiaChiNCC = new TextBox();
            txtMaNCC = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            gbDanhSachNCC = new GroupBox();
            dtgrDSNCC = new DataGridView();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            label6 = new Label();
            label7 = new Label();
            txtEmail = new TextBox();
            txtNguoiDaiDien = new TextBox();
            gbThongTinNCC.SuspendLayout();
            gbDanhSachNCC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgrDSNCC).BeginInit();
            SuspendLayout();
            // 
            // gbThongTinNCC
            // 
            gbThongTinNCC.Controls.Add(txtNguoiDaiDien);
            gbThongTinNCC.Controls.Add(txtEmail);
            gbThongTinNCC.Controls.Add(label7);
            gbThongTinNCC.Controls.Add(label6);
            gbThongTinNCC.Controls.Add(label5);
            gbThongTinNCC.Controls.Add(btnXuatE);
            gbThongTinNCC.Controls.Add(btnSua);
            gbThongTinNCC.Controls.Add(btnXoa);
            gbThongTinNCC.Controls.Add(btnReset);
            gbThongTinNCC.Controls.Add(btnThem);
            gbThongTinNCC.Controls.Add(btnTimKiem);
            gbThongTinNCC.Controls.Add(txtTimKiem);
            gbThongTinNCC.Controls.Add(txtTenNCC);
            gbThongTinNCC.Controls.Add(txtSDTNCC);
            gbThongTinNCC.Controls.Add(txtDiaChiNCC);
            gbThongTinNCC.Controls.Add(txtMaNCC);
            gbThongTinNCC.Controls.Add(label4);
            gbThongTinNCC.Controls.Add(label3);
            gbThongTinNCC.Controls.Add(label2);
            gbThongTinNCC.Controls.Add(label7);
            gbThongTinNCC.Controls.Add(label6);

            gbThongTinNCC.Controls.Add(label1);
            gbThongTinNCC.Font = new Font("Cascadia Code", 11F, FontStyle.Bold, GraphicsUnit.Point);
            gbThongTinNCC.Location = new Point(10, 33);
            gbThongTinNCC.Margin = new Padding(3, 2, 3, 2);
            gbThongTinNCC.Name = "gbThongTinNCC";
            gbThongTinNCC.Padding = new Padding(3, 2, 3, 2);
            gbThongTinNCC.Size = new Size(1146, 303);
            gbThongTinNCC.TabIndex = 0;
            gbThongTinNCC.TabStop = false;
            gbThongTinNCC.Text = "Thông tin Nhà Cung Cấp hhhhhhhhhhh";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Cascadia Code", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(539, 201);
            label5.Name = "label5";
            label5.Size = new Size(110, 22);
            label5.TabIndex = 10;
            label5.Text = "Nhập tncc:";
            // 
            // btnXuatE
            // 
            btnXuatE.BackColor = Color.FromArgb(0, 122, 204);
            btnXuatE.FlatAppearance.BorderSize = 0;
            btnXuatE.FlatStyle = FlatStyle.Flat;
            btnXuatE.Font = new Font("Cascadia Code", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnXuatE.ForeColor = Color.White;
            btnXuatE.Location = new Point(972, 235);
            btnXuatE.Margin = new Padding(2);
            btnXuatE.Name = "btnXuatE";
            btnXuatE.Size = new Size(120, 40);
            btnXuatE.TabIndex = 9;
            btnXuatE.Text = "Xuất Excel";
            btnXuatE.UseVisualStyleBackColor = false;
            btnXuatE.Click += btnXuatE_Click;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.FromArgb(0, 122, 204);
            btnSua.FlatAppearance.BorderSize = 0;
            btnSua.FlatStyle = FlatStyle.Flat;
            btnSua.Font = new Font("Cascadia Code", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnSua.ForeColor = Color.White;
            btnSua.Location = new Point(972, 78);
            btnSua.Margin = new Padding(2);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(120, 40);
            btnSua.TabIndex = 6;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.FromArgb(0, 122, 204);
            btnXoa.FlatAppearance.BorderSize = 0;
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.Font = new Font("Cascadia Code", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnXoa.ForeColor = Color.White;
            btnXoa.Location = new Point(972, 131);
            btnXoa.Margin = new Padding(2);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(120, 40);
            btnXoa.TabIndex = 7;
            btnXoa.Text = "Xóa ";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnReset
            // 
            btnReset.BackColor = Color.FromArgb(0, 122, 204);
            btnReset.FlatAppearance.BorderSize = 0;
            btnReset.FlatStyle = FlatStyle.Flat;
            btnReset.Font = new Font("Cascadia Code", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnReset.ForeColor = Color.White;
            btnReset.Location = new Point(972, 183);
            btnReset.Margin = new Padding(2);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(120, 40);
            btnReset.TabIndex = 8;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = false;
            btnReset.Click += btnReset_Click;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.FromArgb(0, 122, 204);
            btnThem.FlatAppearance.BorderSize = 0;
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.Font = new Font("Cascadia Code", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(972, 26);
            btnThem.Margin = new Padding(2);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(120, 40);
            btnThem.TabIndex = 5;
            btnThem.Text = "Thêm ";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // btnTimKiem
            // 
            btnTimKiem.BackColor = Color.Gray;
            btnTimKiem.FlatAppearance.BorderSize = 0;
            btnTimKiem.FlatStyle = FlatStyle.Flat;
            btnTimKiem.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnTimKiem.Image = (Image)resources.GetObject("btnTimKiem.Image");
            btnTimKiem.ImageAlign = ContentAlignment.MiddleLeft;
            btnTimKiem.Location = new Point(769, 229);
            btnTimKiem.Margin = new Padding(2);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(94, 49);
            btnTimKiem.TabIndex = 9;
            btnTimKiem.Text = "Tìm";
            btnTimKiem.TextAlign = ContentAlignment.MiddleRight;
            btnTimKiem.UseVisualStyleBackColor = false;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // txtTimKiem
            // 
            txtTimKiem.BackColor = Color.White;
            txtTimKiem.Font = new Font("Cascadia Code", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtTimKiem.ForeColor = SystemColors.GrayText;
            txtTimKiem.Location = new Point(539, 239);
            txtTimKiem.Margin = new Padding(2);
            txtTimKiem.Multiline = true;
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(219, 36);
            txtTimKiem.TabIndex = 4;
            // 
            // txtTenNCC
            // 
            txtTenNCC.Location = new Point(205, 124);
            txtTenNCC.Margin = new Padding(2);
            txtTenNCC.Multiline = true;
            txtTenNCC.Name = "txtTenNCC";
            txtTenNCC.Size = new Size(214, 28);
            txtTenNCC.ScrollBars = ScrollBars.Vertical; // có thanh cuộn
            txtTenNCC.WordWrap = true; // tự xuống dòng

            // 
            // txtSDTNCC
            // 
            txtSDTNCC.Location = new Point(633, 56);
            txtSDTNCC.Margin = new Padding(2);
            txtSDTNCC.Name = "txtSDTNCC";
            txtSDTNCC.Size = new Size(230, 29);
  
            // 
            // txtDiaChiNCC
            // 
            txtDiaChiNCC.Location = new Point(633, 124);
            txtDiaChiNCC.Margin = new Padding(2);
            txtDiaChiNCC.Multiline = true;
            txtDiaChiNCC.Name = "txtDiaChiNCC";
            txtDiaChiNCC.Size = new Size(230, 27);
            txtDiaChiNCC.ScrollBars = ScrollBars.Vertical; // có thanh cuộn
            txtDiaChiNCC.WordWrap = true; // tự xuống dòng

            // 
            // txtMaNCC
            // 
            txtMaNCC.Location = new Point(205, 58);
            txtMaNCC.Margin = new Padding(2);
            txtMaNCC.Name = "txtMaNCC";
            txtMaNCC.Size = new Size(214, 29);
            txtMaNCC.TabIndex = 0;

            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Cascadia Code", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(539, 124);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(90, 22);
            label4.TabIndex = 3;
            label4.Text = "Địa chỉ:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Cascadia Code", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(579, 61);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(50, 22);
            label3.TabIndex = 2;
            label3.Text = "SDT:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Cascadia Code", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(21, 129);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(180, 22);
            label2.TabIndex = 1;
            label2.Text = "Tên Nhà cung cấp:";

            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Cascadia Code", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(31, 63);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(170, 22);
            label1.TabIndex = 0;
            label1.Text = "Mã Nhà cung cấp:";
            label1.Click += label1_Click;
            // 
            // gbDanhSachNCC
            // 
            gbDanhSachNCC.Controls.Add(dtgrDSNCC);
            gbDanhSachNCC.Font = new Font("Cascadia Code", 10F, FontStyle.Bold, GraphicsUnit.Point);
            gbDanhSachNCC.Location = new Point(10, 349);
            gbDanhSachNCC.Margin = new Padding(2);
            gbDanhSachNCC.Name = "gbDanhSachNCC";
            gbDanhSachNCC.Padding = new Padding(2);
            gbDanhSachNCC.Size = new Size(1147, 383);
            gbDanhSachNCC.TabIndex = 2;
            gbDanhSachNCC.TabStop = false;
            gbDanhSachNCC.Text = "Danh Sách Nhà cung cấp ";
            // 
            // dtgrDSNCC
            // 
            dtgrDSNCC.AllowUserToAddRows = false;
            dtgrDSNCC.AllowUserToDeleteRows = false;
            dtgrDSNCC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgrDSNCC.BackgroundColor = Color.White;
            dtgrDSNCC.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgrDSNCC.Location = new Point(4, 25);
            dtgrDSNCC.Margin = new Padding(2);
            dtgrDSNCC.Name = "dtgrDSNCC";
            dtgrDSNCC.ReadOnly = true;
            dtgrDSNCC.RowHeadersVisible = false;
            dtgrDSNCC.RowHeadersWidth = 62;
            dtgrDSNCC.RowTemplate.Height = 33;
            dtgrDSNCC.Size = new Size(1139, 348);
            dtgrDSNCC.TabIndex = 0;
            dtgrDSNCC.CellClick += dtgrDSNCC_CellClick;
            dtgrDSNCC.SelectionChanged += dtgrDSNCC_SelectionChanged;

            // label7 - Người đại diện
            label7.AutoSize = true;
            label7.Font = new Font("Cascadia Code", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(21, 192);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(170, 22);
            label7.TabIndex = 12;
            label7.Text = "Người Đại Diện:";

            // textNguoiDaiDien
            txtNguoiDaiDien.Location = new Point(205, 187);
            txtNguoiDaiDien.Margin = new Padding(2);
            txtNguoiDaiDien.Multiline = true;
            txtNguoiDaiDien.Name = "textNguoiDaiDien";
            txtNguoiDaiDien.Size = new Size(214, 28);
            txtNguoiDaiDien.TabIndex = 14;
            txtNguoiDaiDien.ScrollBars = ScrollBars.Vertical; // có thanh cuộn
            txtNguoiDaiDien.WordWrap = true; // tự xuống dòng



            // label6 - Email
            label6.AutoSize = true;
            label6.Font = new Font("Cascadia Code", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(21, 250);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(170, 22);
            label6.TabIndex = 11;
            label6.Text = "Email:";

            // textEmail
            txtEmail.Location = new Point(205, 250);
            txtEmail.Margin = new Padding(2);
            txtEmail.Multiline = true;
            txtEmail.Name = "textEmail";
            txtEmail.Size = new Size(214, 28);
            txtEmail.TabIndex = 13;
            txtEmail.ScrollBars = ScrollBars.Vertical; // có thanh cuộn
            txtEmail.WordWrap = true; // tự xuống dòng


            // 
            // frmNhaCungCap
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1168, 770);
            Controls.Add(gbDanhSachNCC);
            Controls.Add(gbThongTinNCC);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(2);
            Name = "frmNhaCungCap";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NhaCungCap";
            Load += frmNhaCungCap_Load;
            gbThongTinNCC.ResumeLayout(false);
            gbThongTinNCC.PerformLayout();
            gbDanhSachNCC.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dtgrDSNCC).EndInit();
            ResumeLayout(false);


        }

        #endregion

        private GroupBox gbThongTinNCC;
        private Button btnXuatE;
        private Button btnSua;
        private Button btnXoa;
        private Button btnReset;
        private Button btnThem;
        private Button btnTimKiem;
        private TextBox txtTimKiem;
        private TextBox txtTenNCC;
        private TextBox txtSDTNCC;
        private TextBox txtDiaChiNCC;
        private TextBox txtMaNCC;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private GroupBox gbDanhSachNCC;
        private DataGridView dtgrDSNCC;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Label label5;
        private TextBox txtNguoiDaiDien;
        private TextBox txtEmail;
        private Label label7;
        private Label label6;
    }
}