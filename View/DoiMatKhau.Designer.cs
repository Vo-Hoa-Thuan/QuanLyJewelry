namespace QuanLyJewelry.View
{
    partial class frmDoiMatKhau
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDoiMatKhau));
            panelLeft = new Panel();
            lblCopyRight = new Label();
            lblAppName = new Label();
            lblWelcome = new Label();
            pictureBox1 = new PictureBox();
            labelTitle = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtMatKhauCu = new TextBox();
            txtMatKhauMoi = new TextBox();
            txtNhapLai = new TextBox();
            btnDoiMatKhau = new Button();
            btnClose = new Button();
            button1 = new Button();
            panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panelLeft
            // 
            panelLeft.BackColor = Color.OldLace;
            panelLeft.Controls.Add(lblCopyRight);
            panelLeft.Controls.Add(lblAppName);
            panelLeft.Controls.Add(lblWelcome);
            panelLeft.Controls.Add(pictureBox1);
            panelLeft.Dock = DockStyle.Left;
            panelLeft.Location = new Point(0, 0);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new Size(555, 765);
            panelLeft.TabIndex = 0;
            // 
            // lblCopyRight
            // 
            lblCopyRight.AutoSize = true;
            lblCopyRight.Font = new Font("Cascadia Code", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblCopyRight.Location = new Point(183, 684);
            lblCopyRight.Name = "lblCopyRight";
            lblCopyRight.Size = new Size(162, 20);
            lblCopyRight.TabIndex = 0;
            lblCopyRight.Text = "@Copyright by T&&T";
            // 
            // lblAppName
            // 
            lblAppName.AutoSize = true;
            lblAppName.Font = new Font("Cascadia Code", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lblAppName.ForeColor = Color.DarkGoldenrod;
            lblAppName.Location = new Point(40, 60);
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new Size(434, 32);
            lblAppName.TabIndex = 1;
            lblAppName.Text = "Phần mềm quản lý trang sức T&&T";
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Cascadia Code", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lblWelcome.ForeColor = Color.DarkGoldenrod;
            lblWelcome.Location = new Point(90, 20);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(308, 32);
            lblWelcome.TabIndex = 2;
            lblWelcome.Text = "Chào mừng bạn đến với";
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Bottom;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 109);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(555, 656);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Cascadia Code", 18F, FontStyle.Bold, GraphicsUnit.Point);
            labelTitle.ForeColor = Color.DarkGoldenrod;
            labelTitle.Location = new Point(743, 42);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(233, 40);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "ĐỔI MẬT KHẨU";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Cascadia Code", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.DarkGoldenrod;
            label1.Location = new Point(653, 109);
            label1.Name = "label1";
            label1.Size = new Size(156, 27);
            label1.TabIndex = 1;
            label1.Text = "Mật khẩu cũ:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Cascadia Code", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.DarkGoldenrod;
            label2.Location = new Point(653, 222);
            label2.Name = "label2";
            label2.Size = new Size(168, 27);
            label2.TabIndex = 2;
            label2.Text = "Mật khẩu mới:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Cascadia Code", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.DarkGoldenrod;
            label3.Location = new Point(653, 327);
            label3.Name = "label3";
            label3.Size = new Size(228, 27);
            label3.TabIndex = 3;
            label3.Text = "Nhập lại mật khẩu:";
            // 
            // txtMatKhauCu
            // 
            txtMatKhauCu.Location = new Point(653, 157);
            txtMatKhauCu.Name = "txtMatKhauCu";
            txtMatKhauCu.PasswordChar = '*';
            txtMatKhauCu.Size = new Size(401, 27);
            txtMatKhauCu.TabIndex = 4;
            // 
            // txtMatKhauMoi
            // 
            txtMatKhauMoi.Location = new Point(653, 262);
            txtMatKhauMoi.Name = "txtMatKhauMoi";
            txtMatKhauMoi.PasswordChar = '*';
            txtMatKhauMoi.Size = new Size(401, 27);
            txtMatKhauMoi.TabIndex = 5;
            // 
            // txtNhapLai
            // 
            txtNhapLai.Location = new Point(653, 371);
            txtNhapLai.Name = "txtNhapLai";
            txtNhapLai.PasswordChar = '*';
            txtNhapLai.Size = new Size(401, 27);
            txtNhapLai.TabIndex = 6;
            // 
            // btnDoiMatKhau
            // 
            btnDoiMatKhau.BackColor = Color.SandyBrown;
            btnDoiMatKhau.FlatStyle = FlatStyle.Flat;
            btnDoiMatKhau.Font = new Font("Cascadia Code", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnDoiMatKhau.Location = new Point(653, 469);
            btnDoiMatKhau.Name = "btnDoiMatKhau";
            btnDoiMatKhau.Size = new Size(207, 50);
            btnDoiMatKhau.TabIndex = 7;
            btnDoiMatKhau.Text = "Đổi mật khẩu";
            btnDoiMatKhau.UseVisualStyleBackColor = false;
            btnDoiMatKhau.Click += btnDoiMatKhau_Click;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.LightCoral;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Cascadia Code", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(908, 469);
            btnClose.Margin = new Padding(2, 3, 2, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(146, 50);
            btnClose.TabIndex = 8;
            btnClose.Text = "Đóng";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.Red;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = Color.White;
            button1.Location = new Point(1094, 0);
            button1.Margin = new Padding(2, 3, 2, 3);
            button1.Name = "button1";
            button1.Size = new Size(50, 40);
            button1.TabIndex = 30;
            button1.Text = "X";
            button1.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // frmDoiMatKhau
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1143, 765);
            Controls.Add(button1);
            Controls.Add(labelTitle);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(txtMatKhauCu);
            Controls.Add(txtMatKhauMoi);
            Controls.Add(txtNhapLai);
            Controls.Add(btnDoiMatKhau);
            Controls.Add(btnClose);
            Controls.Add(panelLeft);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmDoiMatKhau";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đổi mật khẩu";
            panelLeft.ResumeLayout(false);
            panelLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelLeft;
        private PictureBox pictureBox1;
        private Label lblWelcome;
        private Label lblAppName;
        private Label lblCopyRight;
        private Label labelTitle;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtMatKhauCu;
        private TextBox txtMatKhauMoi;
        private TextBox txtNhapLai;
        private Button btnDoiMatKhau;
        private Button btnClose;
        private Button button1;
    }
}
