namespace QuanLyJewelry.View
{
    partial class frmHome
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

        /// <summary    
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHome));
            panel1 = new Panel();
            pbNhanVien = new PictureBox();
            lblChucVu = new Label();
            label6 = new Label();
            btnClose = new Button();
            taskbar = new Panel();
            btnThoat = new Button();
            btnThongKe = new Button();
            btnNhanVien = new Button();
            btnKhachHang = new Button();
            btnSP = new Button();
            btnNhaCC = new Button();
            btnGiaoDich = new Button();
            btnTrangChu = new Button();
            PBody = new Panel();
            label1 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbNhanVien).BeginInit();
            taskbar.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.BlanchedAlmond;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pbNhanVien);
            panel1.Controls.Add(lblChucVu);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(btnClose);
            panel1.Dock = DockStyle.Top;
            panel1.Font = new Font("Cascadia Code", 8F, FontStyle.Bold, GraphicsUnit.Point);
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1506, 81);
            panel1.TabIndex = 0;
            // 
            // pbNhanVien
            // 
            pbNhanVien.BackgroundImageLayout = ImageLayout.Stretch;
            pbNhanVien.Image = (Image)resources.GetObject("pbNhanVien.Image");
            pbNhanVien.Location = new Point(2, 6);
            pbNhanVien.Margin = new Padding(2, 3, 2, 3);
            pbNhanVien.Name = "pbNhanVien";
            pbNhanVien.Size = new Size(98, 75);
            pbNhanVien.SizeMode = PictureBoxSizeMode.StretchImage;
            pbNhanVien.TabIndex = 7;
            pbNhanVien.TabStop = false;
            // 
            // lblChucVu
            // 
            lblChucVu.AutoSize = true;
            lblChucVu.Font = new Font("Cascadia Code", 11F, FontStyle.Bold, GraphicsUnit.Point);
            lblChucVu.ForeColor = Color.Black;
            lblChucVu.Location = new Point(218, 32);
            lblChucVu.Margin = new Padding(2, 0, 2, 0);
            lblChucVu.Name = "lblChucVu";
            lblChucVu.Size = new Size(56, 25);
            lblChucVu.TabIndex = 6;
            lblChucVu.Text = "NULL";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Cascadia Code", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(104, 31);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(100, 25);
            label6.TabIndex = 5;
            label6.Text = "Chức vụ:";
            // 
            // btnClose
            // 
            btnClose.BackgroundImage = (Image)resources.GetObject("btnClose.BackgroundImage");
            btnClose.BackgroundImageLayout = ImageLayout.Stretch;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(1464, 0);
            btnClose.Margin = new Padding(2, 3, 2, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(40, 44);
            btnClose.TabIndex = 2;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // taskbar
            // 
            taskbar.BackColor = Color.FromArgb(52, 73, 94);
            taskbar.Controls.Add(btnThoat);
            taskbar.Controls.Add(btnThongKe);
            taskbar.Controls.Add(btnNhanVien);
            taskbar.Controls.Add(btnKhachHang);
            taskbar.Controls.Add(btnSP);
            taskbar.Controls.Add(btnNhaCC);
            taskbar.Controls.Add(btnGiaoDich);
            taskbar.Controls.Add(btnTrangChu);
            taskbar.Dock = DockStyle.Left;
            taskbar.Location = new Point(0, 81);
            taskbar.Margin = new Padding(2);
            taskbar.Name = "taskbar";
            taskbar.Size = new Size(323, 669);
            taskbar.TabIndex = 5;
            // 
            // btnThoat
            // 
            btnThoat.FlatAppearance.BorderSize = 0;
            btnThoat.FlatStyle = FlatStyle.Flat;
            btnThoat.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnThoat.ForeColor = Color.White;
            btnThoat.Image = (Image)resources.GetObject("btnThoat.Image");
            btnThoat.ImageAlign = ContentAlignment.MiddleLeft;
            btnThoat.Location = new Point(11, 600);
            btnThoat.Margin = new Padding(2);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(299, 57);
            btnThoat.TabIndex = 8;
            btnThoat.Text = " Đăng Xuất";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnThongKe
            // 
            btnThongKe.FlatAppearance.BorderSize = 0;
            btnThongKe.FlatStyle = FlatStyle.Flat;
            btnThongKe.Font = new Font("Cascadia Code", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnThongKe.ForeColor = Color.White;
            btnThongKe.Image = (Image)resources.GetObject("btnThongKe.Image");
            btnThongKe.ImageAlign = ContentAlignment.MiddleLeft;
            btnThongKe.Location = new Point(10, 518);
            btnThongKe.Margin = new Padding(2);
            btnThongKe.Name = "btnThongKe";
            btnThongKe.Size = new Size(299, 54);
            btnThongKe.TabIndex = 7;
            btnThongKe.Text = "Thống kê ";
            btnThongKe.UseVisualStyleBackColor = true;
            btnThongKe.Click += btnThongKe_Click_1;
            //// 
            // btnNhanVien
            // 
            btnNhanVien.FlatAppearance.BorderSize = 0;
            btnNhanVien.FlatStyle = FlatStyle.Flat;
            btnNhanVien.Font = new Font("Cascadia Code", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnNhanVien.ForeColor = Color.White;
            btnNhanVien.Image = (Image)resources.GetObject("btnNhanVien.Image");
            btnNhanVien.ImageAlign = ContentAlignment.MiddleLeft;
            btnNhanVien.Location = new Point(10, 433);
            btnNhanVien.Margin = new Padding(2);
            btnNhanVien.Name = "btnNhanVien";
            btnNhanVien.Size = new Size(299, 54);
            btnNhanVien.TabIndex = 6;
            btnNhanVien.Text = "Nhân Viên";
            btnNhanVien.UseVisualStyleBackColor = true;
            btnNhanVien.Click += btnNhanVien_Click;
            //// 
           
            //// 
            btnKhachHang.FlatAppearance.BorderSize = 0;
            btnKhachHang.FlatStyle = FlatStyle.Flat;
            btnKhachHang.Font = new Font("Cascadia Code", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnKhachHang.ForeColor = Color.White;
            btnKhachHang.Image = (Image)resources.GetObject("btnKoHang.Image");
            btnKhachHang.ImageAlign = ContentAlignment.MiddleLeft;
            btnKhachHang.Location = new Point(10, 347);
            btnKhachHang.Margin = new Padding(2);
            btnKhachHang.Name = "btnKhachHang";
            btnKhachHang.Size = new Size(299, 54);
            btnKhachHang.TabIndex = 5;
            btnKhachHang.Text = "Khách Hàng";
            btnKhachHang.UseVisualStyleBackColor = true;
            btnKhachHang.Click += btnKhachHang_Click;
            // 
            // btnSP
            // 
            btnSP.FlatAppearance.BorderSize = 0;
            btnSP.FlatStyle = FlatStyle.Flat;
            btnSP.Font = new Font("Cascadia Code", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnSP.ForeColor = Color.White;
            btnSP.Image = (Image)resources.GetObject("btnSP.Image");
            btnSP.ImageAlign = ContentAlignment.MiddleLeft;
            btnSP.Location = new Point(10, 90);
            btnSP.Margin = new Padding(2);
            btnSP.Name = "btnSP";
            btnSP.Size = new Size(299, 58);
            btnSP.TabIndex = 4;
            btnSP.Text = "Sản Phẩm";
            btnSP.UseVisualStyleBackColor = true;
            btnSP.Click += btnSP_Click;
            // 
            // btnNhaCC
            // 
            btnNhaCC.FlatAppearance.BorderSize = 0;
            btnNhaCC.FlatStyle = FlatStyle.Flat;
            btnNhaCC.Font = new Font("Cascadia Code", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnNhaCC.ForeColor = Color.White;
            btnNhaCC.Image = (Image)resources.GetObject("btnNhaCC.Image");
            btnNhaCC.ImageAlign = ContentAlignment.MiddleLeft;
            btnNhaCC.Location = new Point(10, 176);
            btnNhaCC.Margin = new Padding(2);
            btnNhaCC.Name = "btnNhaCC";
            btnNhaCC.Size = new Size(299, 54);
            btnNhaCC.TabIndex = 3;
            btnNhaCC.Text = "Nhà Cung Cấp";
            btnNhaCC.UseVisualStyleBackColor = true;
            btnNhaCC.Click += btnNhaCC_Click;
            //// 
            //// btnGiaoDich
            //// 
            btnGiaoDich.FlatAppearance.BorderSize = 0;
            btnGiaoDich.FlatStyle = FlatStyle.Flat;
            btnGiaoDich.Font = new Font("Cascadia Code", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnGiaoDich.ForeColor = Color.White;
            btnGiaoDich.Image = (Image)resources.GetObject("btnTaoDon.Image");
            btnGiaoDich.ImageAlign = ContentAlignment.MiddleLeft;
            btnGiaoDich.Location = new Point(10, 262);
            btnGiaoDich.Margin = new Padding(2);
            btnGiaoDich.Name = "btnGiaoDich";
            btnGiaoDich.Size = new Size(299, 54);
            btnGiaoDich.TabIndex = 1;
            btnGiaoDich.Text = "Giao Dịch";
            btnGiaoDich.UseVisualStyleBackColor = true;
            btnGiaoDich.Click += btnGiaoDich_Click;
            // 
            // btnTrangChu
            // 
            btnTrangChu.FlatAppearance.BorderSize = 0;
            btnTrangChu.FlatStyle = FlatStyle.Flat;
            btnTrangChu.Font = new Font("Cascadia Code", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnTrangChu.ForeColor = Color.White;
            btnTrangChu.Image = (Image)resources.GetObject("btnTrangChu.Image");
            btnTrangChu.ImageAlign = ContentAlignment.MiddleLeft;
            btnTrangChu.Location = new Point(10, 5);
            btnTrangChu.Margin = new Padding(2);
            btnTrangChu.Name = "btnTrangChu";
            btnTrangChu.Size = new Size(299, 54);
            btnTrangChu.TabIndex = 0;
            btnTrangChu.Text = "Trang Chủ";
            btnTrangChu.UseVisualStyleBackColor = true;
            btnTrangChu.Click += btnTrangChu_Click;
            // 
            // PBody
            // 
            PBody.BorderStyle = BorderStyle.FixedSingle;
            PBody.Dock = DockStyle.Fill;
            PBody.Location = new Point(323, 81);
            PBody.Name = "PBody";
            PBody.Size = new Size(1183, 669);
            PBody.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Cascadia Code", 15F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(689, 24);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(465, 33);
            label1.TabIndex = 9;
            label1.Text = "PHẦN MỀM QUẢN LÝ TRANG SỨC T&&T";
            // 
            // frmHome
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(1506, 750);
            Controls.Add(PBody);
            Controls.Add(taskbar);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(2);
            Name = "frmHome";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dashboard01";
            Load += frmHome_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbNhanVien).EndInit();
            taskbar.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnClose;
        private Panel taskbar;
        private Label lblChucVu;
        private Label label6;
        private PictureBox pbNhanVien;
        private Button btnTrangChu;
        private Button btnNhanVien;
        private Button btnKhachHang;
        private Button btnSP;
        private Button btnNhaCC;
        private Button btnGiaoDich;
        private Button btnThongKe;
        private Button btnThoat;
        private Panel PBody;
        private Label label1;
    }
}