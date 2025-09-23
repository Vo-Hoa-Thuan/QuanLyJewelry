
namespace QuanLyJewelry.GUI
{
    partial class frmNhanVien
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
            btnXuatExel = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            btnThem = new Button();
            btnReset = new Button();
            txtMaNV = new TextBox();
            label6 = new Label();
            txtSDT = new TextBox();
            txtHoTen = new TextBox();
            txtEmail = new TextBox();
            txtDiaChi = new TextBox();
            txtCCCD = new TextBox();
            label7 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            btnUpload = new Button();
            pbAvatar = new PictureBox();
            gbThongTinNV = new GroupBox();
            dtgvNhanVien = new DataGridView();
            groupBox1 = new GroupBox();
            cbQuyen = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)pbAvatar).BeginInit();
            gbThongTinNV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgvNhanVien).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnXuatExel
            // 
            btnXuatExel.BackColor = Color.FromArgb(0, 122, 204);
            btnXuatExel.FlatStyle = FlatStyle.Flat;
            btnXuatExel.Font = new Font("Cascadia Code", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnXuatExel.ForeColor = Color.White;
            btnXuatExel.Location = new Point(571, 246);
            btnXuatExel.Margin = new Padding(2, 3, 2, 3);
            btnXuatExel.Name = "btnXuatExel";
            btnXuatExel.Size = new Size(125, 45);
            btnXuatExel.TabIndex = 58;
            btnXuatExel.Text = "Xuất Exel";
            btnXuatExel.UseVisualStyleBackColor = false;
            btnXuatExel.Click += btnXuatExel_Click;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.FromArgb(0, 122, 204);
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.Font = new Font("Cascadia Code", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnXoa.ForeColor = Color.White;
            btnXoa.Location = new Point(434, 246);
            btnXoa.Margin = new Padding(2, 3, 2, 3);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(125, 45);
            btnXoa.TabIndex = 57;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.FromArgb(0, 122, 204);
            btnSua.FlatStyle = FlatStyle.Flat;
            btnSua.Font = new Font("Cascadia Code", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnSua.ForeColor = Color.White;
            btnSua.Location = new Point(297, 246);
            btnSua.Margin = new Padding(2, 3, 2, 3);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(125, 45);
            btnSua.TabIndex = 56;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.FromArgb(0, 122, 204);
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.Font = new Font("Cascadia Code", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(160, 246);
            btnThem.Margin = new Padding(2, 3, 2, 3);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(125, 45);
            btnThem.TabIndex = 55;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // btnReset
            // 
            btnReset.BackColor = Color.FromArgb(0, 122, 204);
            btnReset.FlatStyle = FlatStyle.Flat;
            btnReset.Font = new Font("Cascadia Code", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnReset.ForeColor = Color.White;
            btnReset.Location = new Point(23, 246);
            btnReset.Margin = new Padding(2, 3, 2, 3);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(125, 45);
            btnReset.TabIndex = 54;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = false;
            btnReset.Click += btnReset_Click;
            // 
            // txtMaNV
            // 
            txtMaNV.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            txtMaNV.Location = new Point(188, 28);
            txtMaNV.Margin = new Padding(2, 3, 2, 3);
            txtMaNV.Multiline = true;
            txtMaNV.Name = "txtMaNV";
            txtMaNV.Size = new Size(243, 36);
            txtMaNV.TabIndex = 51;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Cascadia Code", 13F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(527, 86);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(70, 22);
            label6.TabIndex = 50;
            label6.Text = "Email:";
            // 
            // txtSDT
            // 
            txtSDT.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            txtSDT.Location = new Point(188, 183);
            txtSDT.Margin = new Padding(2, 3, 2, 3);
            txtSDT.Multiline = true;
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(243, 36);
            txtSDT.TabIndex = 49;
            // 
            // txtHoTen
            // 
            txtHoTen.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            txtHoTen.Location = new Point(188, 130);
            txtHoTen.Margin = new Padding(2, 3, 2, 3);
            txtHoTen.Multiline = true;
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(243, 36);
            txtHoTen.TabIndex = 47;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            txtEmail.Location = new Point(624, 77);
            txtEmail.Margin = new Padding(2, 3, 2, 3);
            txtEmail.Multiline = true;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(247, 36);
            txtEmail.TabIndex = 46;
            // 
            // txtDiaChi
            // 
            txtDiaChi.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            txtDiaChi.Location = new Point(624, 28);
            txtDiaChi.Margin = new Padding(2, 3, 2, 3);
            txtDiaChi.Multiline = true;
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(247, 36);
            txtDiaChi.TabIndex = 45;
            // 
            // txtCCCD
            // 
            txtCCCD.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            txtCCCD.Location = new Point(624, 137);
            txtCCCD.Margin = new Padding(2, 3, 2, 3);
            txtCCCD.Multiline = true;
            txtCCCD.Name = "txtCCCD";
            txtCCCD.Size = new Size(247, 36);
            txtCCCD.TabIndex = 44;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Cascadia Code", 13F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(486, 134);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(143, 29);
            label7.TabIndex = 41;
            label7.Text = "CCCD/CMND:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Cascadia Code", 13F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(104, 80);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(91, 29);
            label5.TabIndex = 40;
            label5.Text = "Quyền:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Cascadia Code", 13F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(91, 130);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(104, 29);
            label4.TabIndex = 39;
            label4.Text = "Họ Tên:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Cascadia Code", 13F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(3, 189);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(195, 29);
            label3.TabIndex = 38;
            label3.Text = "Số Điện Thoại:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Cascadia Code", 13F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(512, 31);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(117, 29);
            label2.TabIndex = 37;
            label2.Text = "Địa chỉ:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Cascadia Code", 13F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(13, 35);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(182, 29);
            label1.TabIndex = 36;
            label1.Text = "Mã Nhân Viên:";
            // 
            // btnUpload
            // 
            btnUpload.BackColor = Color.FromArgb(0, 122, 204);
            btnUpload.FlatStyle = FlatStyle.Flat;
            btnUpload.Font = new Font("Cascadia Code", 13F, FontStyle.Bold, GraphicsUnit.Point);
            btnUpload.ForeColor = Color.White;
            btnUpload.Location = new Point(947, 246);
            btnUpload.Margin = new Padding(2, 3, 2, 3);
            btnUpload.Name = "btnUpload";
            btnUpload.Size = new Size(125, 45);
            btnUpload.TabIndex = 35;
            btnUpload.Text = "Upload";
            btnUpload.UseVisualStyleBackColor = false;
            btnUpload.Click += btnUpload_Click;
            // 
            // pbAvatar
            // 
            pbAvatar.Location = new Point(5, 23);
            pbAvatar.Margin = new Padding(2, 3, 2, 3);
            pbAvatar.Name = "pbAvatar";
            pbAvatar.Size = new Size(201, 178);
            pbAvatar.TabIndex = 34;
            pbAvatar.TabStop = false;
            // 
            // gbThongTinNV
            // 
            gbThongTinNV.Controls.Add(dtgvNhanVien);
            gbThongTinNV.Font = new Font("Cascadia Code", 10F, FontStyle.Bold, GraphicsUnit.Point);
            gbThongTinNV.Location = new Point(13, 305);
            gbThongTinNV.Margin = new Padding(2);
            gbThongTinNV.Name = "gbThongTinNV";
            gbThongTinNV.Padding = new Padding(2);
            gbThongTinNV.Size = new Size(1144, 430);
            gbThongTinNV.TabIndex = 59;
            gbThongTinNV.TabStop = false;
            gbThongTinNV.Text = "Thông Tin Nhân Viên";
            // 
            // dtgvNhanVien
            // 
            dtgvNhanVien.AllowUserToAddRows = false;
            dtgvNhanVien.AllowUserToDeleteRows = false;
            dtgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvNhanVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgvNhanVien.Location = new Point(4, 25);
            dtgvNhanVien.Margin = new Padding(2, 3, 2, 3);
            dtgvNhanVien.Name = "dtgvNhanVien";
            dtgvNhanVien.ReadOnly = true;
            dtgvNhanVien.RowHeadersVisible = false;
            dtgvNhanVien.RowHeadersWidth = 62;
            dtgvNhanVien.RowTemplate.Height = 28;
            dtgvNhanVien.Size = new Size(1136, 397);
            dtgvNhanVien.TabIndex = 53;
            dtgvNhanVien.CellClick += dtgvNhanVien_CellClick;
            dtgvNhanVien.SelectionChanged += dtgvNhanVien_SelectionChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(pbAvatar);
            groupBox1.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox1.Location = new Point(902, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(211, 207);
            groupBox1.TabIndex = 60;
            groupBox1.TabStop = false;
            groupBox1.Text = "Hình ảnh:";
            // 
            // cbQuyen
            // 
            cbQuyen.DropDownStyle = ComboBoxStyle.DropDownList;
            cbQuyen.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            cbQuyen.FormattingEnabled = true;
            cbQuyen.Location = new Point(188, 77);
            cbQuyen.Name = "cbQuyen";
            cbQuyen.Size = new Size(243, 38);
            cbQuyen.TabIndex = 61;
            // 
            // frmNhanVien
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(1168, 770);
            Controls.Add(cbQuyen);
            Controls.Add(groupBox1);
            Controls.Add(gbThongTinNV);
            Controls.Add(btnXuatExel);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(btnReset);
            Controls.Add(txtMaNV);
            Controls.Add(label6);
            Controls.Add(txtSDT);
            Controls.Add(txtHoTen);
            Controls.Add(txtEmail);
            Controls.Add(txtDiaChi);
            Controls.Add(txtCCCD);
            Controls.Add(label7);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnUpload);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(2, 3, 2, 3);
            Name = "frmNhanVien";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Nhân Viên";
            Load += frmNhanVien_Load;
            ((System.ComponentModel.ISupportInitialize)pbAvatar).EndInit();
            gbThongTinNV.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dtgvNhanVien).EndInit();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private Button btnXuatExel;
        private Button btnXoa;
        private Button btnSua;
        private Button btnThem;
        private Button btnReset;
        private TextBox txtMaNV;
        private Label label6;
        private TextBox txtSDT;
        private TextBox txtHoTen;
        private TextBox txtEmail;
        private TextBox txtDiaChi;
        private TextBox txtCCCD;
        private Label label7;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnUpload;
        private PictureBox pbAvatar;
        private GroupBox gbThongTinNV;
        private DataGridView dtgvNhanVien;
        private GroupBox groupBox1;
        private ComboBox cbQuyen;
    }
}