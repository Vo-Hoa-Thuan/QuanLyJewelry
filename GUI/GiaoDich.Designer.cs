

namespace QuanLyJewelry.View
{
    partial class frmGiaoDich
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            grpThongTin = new GroupBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            lblLoaiGD = new Label();
            cboLoaiGD = new ComboBox();
            lblKhachHang = new Label();
            cboKhachHang = new ComboBox();
            lblNhanVien = new Label();
            cboNhanVien = new ComboBox();
            lblNgayGD = new Label();
            txtNgayGD = new TextBox();
            lblTongTien = new Label();
            txtTongTien = new TextBox();
            grpChiTiet = new GroupBox();
            dgvChiTiet = new DataGridView();
            colMaSP = new DataGridViewComboBoxColumn();
            colSoLuong = new DataGridViewTextBoxColumn();
            colDonGia = new DataGridViewTextBoxColumn();
            colThanhTien = new DataGridViewTextBoxColumn();
            panelButtons = new Panel();
            btnThemSanPham = new Button();
            btnXoaSanPham = new Button();
            btnLuuDonHang = new Button();
            btnDong = new Button();
            grpThongTin.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            grpChiTiet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChiTiet).BeginInit();
            panelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // grpThongTin
            // 
            grpThongTin.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpThongTin.Controls.Add(tableLayoutPanel1);
            grpThongTin.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            grpThongTin.Location = new Point(12, 12);
            grpThongTin.Name = "grpThongTin";
            grpThongTin.Size = new Size(760, 150);
            grpThongTin.TabIndex = 0;
            grpThongTin.TabStop = false;
            grpThongTin.Text = "Thông tin giao dịch";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tableLayoutPanel1.Controls.Add(lblLoaiGD, 0, 0);
            tableLayoutPanel1.Controls.Add(cboLoaiGD, 1, 0);
            tableLayoutPanel1.Controls.Add(lblKhachHang, 0, 1);
            tableLayoutPanel1.Controls.Add(cboKhachHang, 1, 1);
            tableLayoutPanel1.Controls.Add(lblNhanVien, 0, 2);
            tableLayoutPanel1.Controls.Add(cboNhanVien, 1, 2);
            tableLayoutPanel1.Controls.Add(lblNgayGD, 2, 0);
            tableLayoutPanel1.Controls.Add(txtNgayGD, 3, 0);
            tableLayoutPanel1.Controls.Add(lblTongTien, 2, 1);
            tableLayoutPanel1.Controls.Add(txtTongTien, 3, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 32);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333F));
            tableLayoutPanel1.Size = new Size(754, 115);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // lblLoaiGD
            // 
            lblLoaiGD.Anchor = AnchorStyles.Right;
            lblLoaiGD.AutoSize = true;
            lblLoaiGD.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            lblLoaiGD.Location = new Point(5, 0);
            lblLoaiGD.Name = "lblLoaiGD";
            lblLoaiGD.Size = new Size(105, 38);
            lblLoaiGD.TabIndex = 0;
            lblLoaiGD.Text = "Loại GD: *";
            // 
            // cboLoaiGD
            // 
            cboLoaiGD.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cboLoaiGD.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLoaiGD.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            cboLoaiGD.FormattingEnabled = true;
            cboLoaiGD.Items.AddRange(new object[] { "MUA_VAO", "BAN_RA" });
            cboLoaiGD.Location = new Point(116, 3);
            cboLoaiGD.Name = "cboLoaiGD";
            cboLoaiGD.Size = new Size(257, 38);
            cboLoaiGD.TabIndex = 1;
            // 
            // lblKhachHang
            // 
            lblKhachHang.Anchor = AnchorStyles.Right;
            lblKhachHang.AutoSize = true;
            lblKhachHang.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            lblKhachHang.Location = new Point(23, 38);
            lblKhachHang.Name = "lblKhachHang";
            lblKhachHang.Size = new Size(87, 38);
            lblKhachHang.TabIndex = 2;
            lblKhachHang.Text = "Khách hàng: *";
            // 
            // cboKhachHang
            // 
            cboKhachHang.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cboKhachHang.DropDownStyle = ComboBoxStyle.DropDownList;
            cboKhachHang.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            cboKhachHang.FormattingEnabled = true;
            cboKhachHang.Location = new Point(116, 41);
            cboKhachHang.Name = "cboKhachHang";
            cboKhachHang.Size = new Size(257, 38);
            cboKhachHang.TabIndex = 3;
            // 
            // lblNhanVien
            // 
            lblNhanVien.Anchor = AnchorStyles.Right;
            lblNhanVien.AutoSize = true;
            lblNhanVien.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            lblNhanVien.Location = new Point(32, 76);
            lblNhanVien.Name = "lblNhanVien";
            lblNhanVien.Size = new Size(78, 39);
            lblNhanVien.TabIndex = 4;
            lblNhanVien.Text = "Nhân viên: *";
            // 
            // cboNhanVien
            // 
            cboNhanVien.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cboNhanVien.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNhanVien.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            cboNhanVien.FormattingEnabled = true;
            cboNhanVien.Location = new Point(116, 79);
            cboNhanVien.Name = "cboNhanVien";
            cboNhanVien.Size = new Size(257, 38);
            cboNhanVien.TabIndex = 5;
            // 
            // lblNgayGD
            // 
            lblNgayGD.Anchor = AnchorStyles.Right;
            lblNgayGD.AutoSize = true;
            lblNgayGD.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            lblNgayGD.Location = new Point(412, 0);
            lblNgayGD.Name = "lblNgayGD";
            lblNgayGD.Size = new Size(74, 38);
            lblNgayGD.TabIndex = 6;
            lblNgayGD.Text = "Ngày GD:";
            // 
            // txtNgayGD
            // 
            txtNgayGD.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtNgayGD.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            txtNgayGD.Location = new Point(492, 3);
            txtNgayGD.Name = "txtNgayGD";
            txtNgayGD.ReadOnly = true;
            txtNgayGD.Size = new Size(259, 36);
            txtNgayGD.TabIndex = 7;
            // 
            // lblTongTien
            // 
            lblTongTien.Anchor = AnchorStyles.Right;
            lblTongTien.AutoSize = true;
            lblTongTien.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            lblTongTien.Location = new Point(414, 38);
            lblTongTien.Name = "lblTongTien";
            lblTongTien.Size = new Size(72, 38);
            lblTongTien.TabIndex = 8;
            lblTongTien.Text = "Tổng tiền:";
            // 
            // txtTongTien
            // 
            txtTongTien.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtTongTien.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            txtTongTien.Location = new Point(492, 41);
            txtTongTien.Name = "txtTongTien";
            txtTongTien.ReadOnly = true;
            txtTongTien.Size = new Size(259, 36);
            txtTongTien.TabIndex = 9;
            txtTongTien.TextAlign = HorizontalAlignment.Right;
            // 
            // grpChiTiet
            // 
            grpChiTiet.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpChiTiet.Controls.Add(dgvChiTiet);
            grpChiTiet.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            grpChiTiet.Location = new Point(12, 168);
            grpChiTiet.Name = "grpChiTiet";
            grpChiTiet.Size = new Size(650, 270);
            grpChiTiet.TabIndex = 1;
            grpChiTiet.TabStop = false;
            grpChiTiet.Text = "Chi tiết giao dịch";
            // 
            // dgvChiTiet
            // 
            dgvChiTiet.AllowUserToResizeRows = false;
            dgvChiTiet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChiTiet.BackgroundColor = SystemColors.Window;
            dgvChiTiet.BorderStyle = BorderStyle.None;
            dgvChiTiet.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvChiTiet.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new Padding(0, 5, 0, 5);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvChiTiet.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvChiTiet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChiTiet.Columns.AddRange(new DataGridViewColumn[] { colMaSP, colSoLuong, colDonGia, colThanhTien });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvChiTiet.DefaultCellStyle = dataGridViewCellStyle2;
            dgvChiTiet.Dock = DockStyle.Fill;
            dgvChiTiet.EnableHeadersVisualStyles = false;
            dgvChiTiet.Location = new Point(3, 32);
            dgvChiTiet.Name = "dgvChiTiet";
            dgvChiTiet.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvChiTiet.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvChiTiet.RowHeadersVisible = false;
            dgvChiTiet.RowHeadersWidth = 51;
            dataGridViewCellStyle4.Padding = new Padding(5, 0, 0, 0);
            dgvChiTiet.RowsDefaultCellStyle = dataGridViewCellStyle4;
            dgvChiTiet.RowTemplate.Height = 30;
            dgvChiTiet.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvChiTiet.Size = new Size(644, 235);
            dgvChiTiet.TabIndex = 0;
            dgvChiTiet.CellEndEdit += dgvChiTiet_CellEndEdit;
            dgvChiTiet.CellFormatting += DgvChiTiet_CellFormatting;
            dgvChiTiet.EditingControlShowing += DgvChiTiet_EditingControlShowing;
            // 
            // colMaSP
            // 
            colMaSP.HeaderText = "Sản phẩm *";
            colMaSP.MinimumWidth = 6;
            colMaSP.Name = "colMaSP";
            // 
            // colSoLuong
            // 
            colSoLuong.HeaderText = "Số lượng *";
            colSoLuong.MinimumWidth = 6;
            colSoLuong.Name = "colSoLuong";
            // 
            // colDonGia
            // 
            colDonGia.HeaderText = "Đơn giá *";
            colDonGia.MinimumWidth = 6;
            colDonGia.Name = "colDonGia";
            // 
            // colThanhTien
            // 
            colThanhTien.HeaderText = "Thành tiền";
            colThanhTien.MinimumWidth = 6;
            colThanhTien.Name = "colThanhTien";
            colThanhTien.ReadOnly = true;
            // 
            // panelButtons
            // 
            panelButtons.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panelButtons.Controls.Add(btnThemSanPham);
            panelButtons.Controls.Add(btnXoaSanPham);
            panelButtons.Controls.Add(btnLuuDonHang);
            panelButtons.Controls.Add(btnDong);
            panelButtons.Location = new Point(668, 168);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(104, 270);
            panelButtons.TabIndex = 2;
            // 
            // btnThemSanPham
            // 
            btnThemSanPham.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnThemSanPham.BackColor = Color.SteelBlue;
            btnThemSanPham.FlatAppearance.BorderSize = 0;
            btnThemSanPham.FlatStyle = FlatStyle.Flat;
            btnThemSanPham.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            btnThemSanPham.ForeColor = Color.White;
            btnThemSanPham.Location = new Point(0, 10);
            btnThemSanPham.Name = "btnThemSanPham";
            btnThemSanPham.Size = new Size(104, 30);
            btnThemSanPham.TabIndex = 0;
            btnThemSanPham.Text = "Thêm SP";
            btnThemSanPham.UseVisualStyleBackColor = false;
            btnThemSanPham.Click += btnThemSanPham_Click;
            // 
            // btnXoaSanPham
            // 
            btnXoaSanPham.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnXoaSanPham.BackColor = Color.IndianRed;
            btnXoaSanPham.FlatAppearance.BorderSize = 0;
            btnXoaSanPham.FlatStyle = FlatStyle.Flat;
            btnXoaSanPham.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            btnXoaSanPham.ForeColor = Color.White;
            btnXoaSanPham.Location = new Point(0, 50);
            btnXoaSanPham.Name = "btnXoaSanPham";
            btnXoaSanPham.Size = new Size(104, 30);
            btnXoaSanPham.TabIndex = 1;
            btnXoaSanPham.Text = "Xóa SP";
            btnXoaSanPham.UseVisualStyleBackColor = false;
            btnXoaSanPham.Click += btnXoaSanPham_Click;
            // 
            // btnLuuDonHang
            // 
            btnLuuDonHang.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnLuuDonHang.BackColor = Color.SeaGreen;
            btnLuuDonHang.FlatAppearance.BorderSize = 0;
            btnLuuDonHang.FlatStyle = FlatStyle.Flat;
            btnLuuDonHang.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            btnLuuDonHang.ForeColor = Color.White;
            btnLuuDonHang.Location = new Point(0, 120);
            btnLuuDonHang.Name = "btnLuuDonHang";
            btnLuuDonHang.Size = new Size(104, 30);
            btnLuuDonHang.TabIndex = 2;
            btnLuuDonHang.Text = "Lưu";
            btnLuuDonHang.UseVisualStyleBackColor = false;
            btnLuuDonHang.Click += btnLuuDonHang_Click;
            // 
            // btnDong
            // 
            btnDong.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnDong.BackColor = Color.Gray;
            btnDong.FlatAppearance.BorderSize = 0;
            btnDong.FlatStyle = FlatStyle.Flat;
            btnDong.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            btnDong.ForeColor = Color.White;
            btnDong.Location = new Point(0, 160);
            btnDong.Name = "btnDong";
            btnDong.Size = new Size(104, 30);
            btnDong.TabIndex = 3;
            btnDong.Text = "Đóng";
            btnDong.UseVisualStyleBackColor = false;
            btnDong.Click += BtnDong_Click;
            // 
            // frmGiaoDich
            // 
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(784, 461);
            Controls.Add(panelButtons);
            Controls.Add(grpChiTiet);
            Controls.Add(grpThongTin);
            Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            MinimumSize = new Size(800, 500);
            Name = "frmGiaoDich";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý giao dịch";
            Load += frmGiaoDich_Load;
            grpThongTin.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            grpChiTiet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvChiTiet).EndInit();
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblLoaiGD;
        private System.Windows.Forms.ComboBox cboLoaiGD;
        private System.Windows.Forms.Label lblKhachHang;
        private System.Windows.Forms.ComboBox cboKhachHang;
        private System.Windows.Forms.Label lblNhanVien;
        private System.Windows.Forms.ComboBox cboNhanVien;
        private System.Windows.Forms.Label lblNgayGD;
        private System.Windows.Forms.TextBox txtNgayGD;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.GroupBox grpChiTiet;
        private System.Windows.Forms.DataGridView dgvChiTiet;
        private System.Windows.Forms.DataGridViewComboBoxColumn colMaSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDonGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThanhTien;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnThemSanPham;
        private System.Windows.Forms.Button btnXoaSanPham;
        private System.Windows.Forms.Button btnLuuDonHang;
        private System.Windows.Forms.Button btnDong;
        private EventHandler btnDong_Click;
        private DataGridViewCellFormattingEventHandler dgvChiTiet_CellFormatting;
        private DataGridViewEditingControlShowingEventHandler dgvChiTiet_EditingControlShowing;
    }
}