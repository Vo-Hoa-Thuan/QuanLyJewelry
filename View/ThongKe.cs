using LiveCharts;
using LiveCharts.WinForms;
using LiveCharts.Wpf; // để dùng Axis, ColumnSeries, PieSeries
using QuanLyJewelry.Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyJewelry.View
{
    public partial class frmThongKe : Form
    {
        public frmThongKe()
        {
            InitializeComponent();
            InitializeCustomCharts();
            LoadNamThongKe();
            LoadThongKeTongQuan();
        }

        #region Khởi tạo Charts
        private void InitializeCustomCharts()
        {
            // Chart Doanh Thu
            chartDoanhThu.Series = new SeriesCollection();
            chartDoanhThu.AxisX.Clear();
            chartDoanhThu.AxisY.Clear();

            chartDoanhThu.AxisX.Add(new Axis
            {
                Title = "Tháng",
                Labels = new List<string>()
            });
            chartDoanhThu.AxisY.Add(new Axis
            {
                Title = "Doanh thu (đ)",
                LabelFormatter = value => value.ToString("N0")
            });

            // Chart Loại SP
            chartLoaiSP.Series = new SeriesCollection();
        }
        #endregion

        #region Load dữ liệu
        private void LoadNamThongKe()
        {
            cboNam.Items.Clear();
            for (int i = DateTime.Now.Year - 5; i <= DateTime.Now.Year; i++)
                cboNam.Items.Add(i);
            cboNam.SelectedItem = DateTime.Now.Year;

            cboThang.Items.Clear();
            for (int i = 1; i <= 12; i++)
                cboThang.Items.Add(i);
            cboThang.SelectedItem = DateTime.Now.Month;
        }

        private void LoadThongKeTongQuan()
        {
            if (cboNam.SelectedItem == null || cboThang.SelectedItem == null) return;

            int nam = (int)cboNam.SelectedItem;
            int thang = (int)cboThang.SelectedItem;

            DataTable dtTongQuan = ThongKeBUS.Instance.LayTongQuan(nam, thang);
            if (dtTongQuan != null && dtTongQuan.Rows.Count > 0)
            {
                lblTongDonHang.Text = dtTongQuan.Rows[0]["TongSoDonHang"].ToString();
                lblTongDoanhThu.Text = $"{Convert.ToDecimal(dtTongQuan.Rows[0]["TongDoanhThu"]):N0} đ";
                lblDonGiaTB.Text = $"{Convert.ToDecimal(dtTongQuan.Rows[0]["DonGiaTrungBinh"]):N0} đ";
                lblSoKhachHang.Text = dtTongQuan.Rows[0]["SoKhachHang"].ToString();
            }

            //LoadBieuDoDoanhThu();
            //LoadDoanhThuTheoLoai();
            LoadTopSanPham();
            LoadDoanhThuNhanVien();
            LoadTopKhachHang();
        }


        #endregion

        #region Load Biểu đồ
        //private void LoadBieuDoDoanhThu()
        //{
        //    if (cboNam.SelectedItem == null) return;
        //    int nam = (int)cboNam.SelectedItem;
        //    DataTable dt = ThongKeBUS.Instance.LayDoanhThuTheoNam(nam);
        //    if (dt == null || dt.Rows.Count == 0)
        //    {
        //        // clear chart nếu không có dữ liệu
        //        chartDoanhThu.Series = new LiveCharts.SeriesCollection();
        //        chartDoanhThu.AxisX.Clear();
        //        chartDoanhThu.AxisY.Clear();
        //        return;
        //    }

        //    // đặt tên biến khác để tránh xung đột
        //    var colSeries = new LiveCharts.Wpf.ColumnSeries
        //    {
        //        Title = "Doanh thu",
        //        Values = new LiveCharts.ChartValues<decimal>()
        //        // nếu muốn màu: Fill = (System.Windows.Media.Brush)new System.Windows.Media.BrushConverter().ConvertFromString("#4682B4")
        //        // nhưng chỉ thêm Fill nếu bạn đã add PresentationFramework reference / UseWPF=true
        //    };

        //    var labels = new List<string>();

        //    foreach (DataRow row in dt.Rows)
        //    {
        //        decimal v = 0;
        //        decimal.TryParse(row["DoanhThu"].ToString(), out v);
        //        colSeries.Values.Add(v);
        //        labels.Add($"Tháng {row["Thang"]}");
        //    }

        //    // dùng tên đầy đủ để tránh ambiguous
        //    chartDoanhThu.Series = new LiveCharts.SeriesCollection { colSeries };

        //    // Axis X
        //    chartDoanhThu.AxisX.Clear();
        //    chartDoanhThu.AxisX.Add(new LiveCharts.Wpf.Axis
        //    {
        //        Title = "Tháng",
        //        Labels = labels
        //    });

        //    // Axis Y
        //    chartDoanhThu.AxisY.Clear();
        //    chartDoanhThu.AxisY.Add(new LiveCharts.Wpf.Axis
        //    {
        //        Title = "Doanh thu (đ)",
        //        LabelFormatter = value => value.ToString("N0")
        //    });
        //}

        //private void LoadDoanhThuTheoLoai()
        //{
        //    int nam = (int)cboNam.SelectedItem;
        //    int thang = (int)cboThang.SelectedItem;

        //    DataTable dt = ThongKeBUS.Instance.LayDoanhThuTheoLoaiSP(nam, thang);
        //    if (dt == null || dt.Rows.Count == 0) return;

        //    dgvLoaiSP.DataSource = dt;
        //    FormatGridLoaiSP();

        //    var seriesCollection = new SeriesCollection();
        //    foreach (DataRow row in dt.Rows)
        //    {
        //        seriesCollection.Add(new PieSeries
        //        {
        //            Title = row["LoaiSanPham"].ToString(),
        //            Values = new ChartValues<decimal> { Convert.ToDecimal(row["DoanhThu"]) },
        //            DataLabels = true,
        //            LabelPoint = chartPoint => $"{chartPoint.SeriesView.Title}: {chartPoint.Y:N0} đ"
        //        });
        //    }
        //    chartLoaiSP.Series = seriesCollection;
        //}
        #endregion

        #region Load DataGridView
        private void LoadTopSanPham()
        {
            dgvTopSanPham.DataSource = ThongKeBUS.Instance.LayTopSanPham(10, (int)cboNam.SelectedItem, (int)cboThang.SelectedItem);
            FormatGridSanPham();
        }

        private void LoadDoanhThuNhanVien()
        {
            dgvNhanVien.DataSource = ThongKeBUS.Instance.LayDoanhThuNhanVien((int)cboNam.SelectedItem, (int)cboThang.SelectedItem);
            FormatGridNhanVien();
        }

        private void LoadTopKhachHang()
        {
            dgvKhachHang.DataSource = ThongKeBUS.Instance.LayTopKhachHang(10, (int)cboNam.SelectedItem, (int)cboThang.SelectedItem);
            FormatGridKhachHang();
        }
        #endregion

        #region Format Grid
        private void FormatGridSanPham()
        {
            if (dgvTopSanPham.Columns.Count == 0) return;
            dgvTopSanPham.Columns["TenSanPham"].HeaderText = "Tên sản phẩm";
            dgvTopSanPham.Columns["LoaiSanPham"].HeaderText = "Loại";
            dgvTopSanPham.Columns["SoLuongBan"].HeaderText = "Số lượng";
            dgvTopSanPham.Columns["DoanhThu"].HeaderText = "Doanh thu";
            dgvTopSanPham.Columns["DoanhThu"].DefaultCellStyle.Format = "N0";
        }

        private void FormatGridNhanVien()
        {
            if (dgvNhanVien.Columns.Count == 0) return;
            dgvNhanVien.Columns["TenNhanVien"].HeaderText = "Nhân viên";
            dgvNhanVien.Columns["SoDonHang"].HeaderText = "Số đơn";
            dgvNhanVien.Columns["DoanhThu"].HeaderText = "Doanh thu";
            dgvNhanVien.Columns["DonGiaTrungBinh"].HeaderText = "Đơn giá TB";
            dgvNhanVien.Columns["DoanhThu"].DefaultCellStyle.Format = "N0";
            dgvNhanVien.Columns["DonGiaTrungBinh"].DefaultCellStyle.Format = "N0";
        }

        private void FormatGridKhachHang()
        {
            if (dgvKhachHang.Columns.Count == 0) return;
            dgvKhachHang.Columns["TenKhachHang"].HeaderText = "Khách hàng";
            dgvKhachHang.Columns["SoLanMua"].HeaderText = "Số lần mua";
            dgvKhachHang.Columns["TongChiTieu"].HeaderText = "Tổng chi tiêu";
            dgvKhachHang.Columns["LanMuaGanNhat"].HeaderText = "Lần mua gần nhất";
            dgvKhachHang.Columns["TongChiTieu"].DefaultCellStyle.Format = "N0";
            dgvKhachHang.Columns["LanMuaGanNhat"].DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        private void FormatGridLoaiSP()
        {
            if (dgvLoaiSP.Columns.Count == 0) return;
            dgvLoaiSP.Columns["LoaiSanPham"].HeaderText = "Loại sản phẩm";
            dgvLoaiSP.Columns["SoLuongBan"].HeaderText = "Số lượng";
            dgvLoaiSP.Columns["DoanhThu"].HeaderText = "Doanh thu";
            dgvLoaiSP.Columns["DoanhThu"].DefaultCellStyle.Format = "N0";
        }
        #endregion

        #region Sự kiện Controls
        private void cboNam_SelectedIndexChanged(object sender, EventArgs e) => LoadThongKeTongQuan();
        private void cboThang_SelectedIndexChanged(object sender, EventArgs e) => LoadThongKeTongQuan();
        private void btnLamMoi_Click(object sender, EventArgs e) => LoadThongKeTongQuan();

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            using SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Files|*.xlsx";
            saveFileDialog.Title = "Xuất báo cáo Excel";
            saveFileDialog.FileName = $"BaoCaoThongKe_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                MessageBox.Show("Xuất Excel thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnInBaoCao_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }
        #endregion
    }
}
