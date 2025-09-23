using LiveCharts;
using LiveCharts.WinForms;
using LiveCharts.Wpf; // để dùng Axis, ColumnSeries, PieSeries
using ClosedXML.Excel;
using QuanLyJewelry.BLL;
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


            // Wire up events (Designer did not attach handlers)
            this.cboNam.SelectedIndexChanged += cboNam_SelectedIndexChanged;
            this.cboThang.SelectedIndexChanged += cboThang_SelectedIndexChanged;
            this.btnLamMoi.Click += btnLamMoi_Click;
            this.btnXuatExcel.Click += btnXuatExcel_Click;
            this.btnInBaoCao.Click += btnInBaoCao_Click;
            this.printDocument1.PrintPage += printDocument1_PrintPage;
            this.Shown += frmThongKe_Shown;

        }

        private void frmThongKe_Shown(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(
                (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2
            );
        }



        #region Khởi tạo Charts
        private void InitializeCustomCharts()
        {
            // Chart Doanh Thu
            chartDoanhThu.Series = new SeriesCollection();
            chartDoanhThu.AxisX.Clear();
            chartDoanhThu.AxisY.Clear();
            chartDoanhThu.Zoom = LiveCharts.ZoomingOptions.X;
            chartDoanhThu.Pan = LiveCharts.PanningOptions.X;
            chartDoanhThu.LegendLocation = LiveCharts.LegendLocation.None;
            chartDoanhThu.Hoverable = false;

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
            chartLoaiSP.LegendLocation = LiveCharts.LegendLocation.Right;
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

            DataTable dtTongQuan = ThongKeBLL.Instance.LayTongQuan(nam, thang);
            if (dtTongQuan != null && dtTongQuan.Rows.Count > 0)
            {
                lblTongDonHang.Text = dtTongQuan.Rows[0]["TongSoDonHang"].ToString();
                lblTongDoanhThu.Text = $"{Convert.ToDecimal(dtTongQuan.Rows[0]["TongDoanhThu"]):N0} đ";
                lblDonGiaTB.Text = $"{Convert.ToDecimal(dtTongQuan.Rows[0]["DonGiaTrungBinh"]):N0} đ";
                lblSoKhachHang.Text = dtTongQuan.Rows[0]["SoKhachHang"].ToString();
            }

            LoadBieuDoDoanhThu();
            LoadDoanhThuTheoLoai();
            LoadTopSanPham();
            LoadDoanhThuNhanVien();
            LoadTopKhachHang();
        }


        #endregion

        #region Load Biểu đồ
        private void LoadBieuDoDoanhThu()
        {
            if (cboNam.SelectedItem == null) return;
            int nam = (int)cboNam.SelectedItem;
            DataTable dt = ThongKeBLL.Instance.LayDoanhThuTheoNam(nam);
            var doanhThuTheoThang = new double[12];
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    int th;
                    if (int.TryParse(row["Thang"].ToString(), out th) && th >= 1 && th <= 12)
                    {
                        doanhThuTheoThang[th - 1] = Convert.ToDouble(row["DoanhThu"]);
                    }
                }
            }

            var colSeries = new LiveCharts.Wpf.ColumnSeries
            {
                Title = "Doanh thu",
                Values = new LiveCharts.ChartValues<double>(),
                DataLabels = true,
                MaxColumnWidth = 40,
                ColumnPadding = 5
            };

            var labels = new List<string>();

            for (int i = 0; i < 12; i++)
            {
                colSeries.Values.Add(doanhThuTheoThang[i]);
                labels.Add($"Tháng {i + 1}");
            }

            chartDoanhThu.Series = new LiveCharts.SeriesCollection { colSeries };

            chartDoanhThu.AxisX.Clear();
            chartDoanhThu.AxisX.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Tháng",
                Labels = labels,
                LabelsRotation = 0,
                Separator = new LiveCharts.Wpf.Separator { Step = 1, StrokeThickness = 0.5 }
            });

            chartDoanhThu.AxisY.Clear();
            chartDoanhThu.AxisY.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Doanh thu (đ)",
                LabelFormatter = value => value.ToString("N0"),
                Separator = new LiveCharts.Wpf.Separator { StrokeThickness = 0.5 }
            });

            chartDoanhThu.DisableAnimations = true;
        }

        private void LoadDoanhThuTheoLoai()
        {
            int nam = (int)cboNam.SelectedItem;
            int thang = (int)cboThang.SelectedItem;

            DataTable dt = ThongKeBLL.Instance.LayDoanhThuTheoLoaiSP(nam, thang);
            if (dt == null || dt.Rows.Count == 0)
            {
                chartLoaiSP.Series = new SeriesCollection();
                dgvLoaiSP.DataSource = null;
                return;
            }

            dgvLoaiSP.DataSource = dt;
            FormatGridLoaiSP();

            var seriesCollection = new SeriesCollection();
            foreach (DataRow row in dt.Rows)
            {
                seriesCollection.Add(new LiveCharts.Wpf.PieSeries
                {
                    Title = row["LoaiSanPham"].ToString(),
                    Values = new LiveCharts.ChartValues<double> { Convert.ToDouble(row["DoanhThu"]) },
                    DataLabels = true,
                    LabelPoint = chartPoint => $"{chartPoint.SeriesView.Title}: {chartPoint.Y:N0} đ"
                });
            }
            chartLoaiSP.Series = seriesCollection;
        }
        #endregion

        #region Load DataGridView
        private void LoadTopSanPham()
        {
            dgvTopSanPham.DataSource = ThongKeBLL.Instance.LayTopSanPham(10, (int)cboNam.SelectedItem, (int)cboThang.SelectedItem);
            FormatGridSanPham();
        }

        private void LoadDoanhThuNhanVien()
        {
            dgvNhanVien.DataSource = ThongKeBLL.Instance.LayDoanhThuNhanVien((int)cboNam.SelectedItem, (int)cboThang.SelectedItem);
            FormatGridNhanVien();
        }

        private void LoadTopKhachHang()
        {
            dgvKhachHang.DataSource = ThongKeBLL.Instance.LayTopKhachHang(10, (int)cboNam.SelectedItem, (int)cboThang.SelectedItem);
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
            saveFileDialog.Filter = "Excel Workbook (*.xlsx)|*.xlsx|Excel 97-2003 (*.xls)|*.xls|CSV (*.csv)|*.csv";
            saveFileDialog.Title = "Xuất báo cáo";
            saveFileDialog.FileName = $"BaoCaoThongKe_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    switch (saveFileDialog.FilterIndex)
                    {
                        case 1:
                            ExportReportAsXlsx(saveFileDialog.FileName);
                            break;
                        case 2:
                            ExportReportAsExcelHtml(saveFileDialog.FileName);
                            break;
                        default:
                            ExportReportAsCsv(saveFileDialog.FileName);
                            break;
                    }
                    MessageBox.Show("Xuất báo cáo thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Xuất báo cáo thất bại: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnInBaoCao_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void dgvKhachHang_DoubleClick(object sender, EventArgs e)
        {
            if (dgvKhachHang.CurrentRow == null) return;
            var drv = dgvKhachHang.CurrentRow.DataBoundItem as DataRowView;
            if (drv == null || !drv.Row.Table.Columns.Contains("MaKhachHang"))
            {
                MessageBox.Show("Không xác định được khách hàng.");
                return;
            }
            int maKh = Convert.ToInt32(drv.Row["MaKhachHang"]);
            int nam = (int)cboNam.SelectedItem;
            int thang = (int)cboThang.SelectedItem;
            using var f = new frmKhachHangMuaHang(maKh, nam, thang);
            f.ShowDialog();
        }

        // Thay thế nguyên hàm này vào frmThongKe.cs
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // đảm bảo có tháng/năm
            if (cboNam.SelectedItem == null || cboThang.SelectedItem == null)
            {
                e.HasMorePages = false;
                return;
            }

            int nam = (int)cboNam.SelectedItem;
            int thang = (int)cboThang.SelectedItem;

            Graphics g = e.Graphics;
            Rectangle margin = e.MarginBounds;
            int x = margin.Left;
            int y = margin.Top;

            using (var titleFont = new Font("Segoe UI", 16, FontStyle.Bold))
            using (var headerFont = new Font("Segoe UI", 12, FontStyle.Bold))
            using (var textFont = new Font("Segoe UI", 10, FontStyle.Regular))
            {
                // Tiêu đề
                string title = $"BÁO CÁO THỐNG KÊ THÁNG {thang}/{nam}";
                g.DrawString(title, titleFont, Brushes.Black, x, y);
                y += (int)g.MeasureString(title, titleFont).Height + 8;

                // Tổng quan (lấy từ BUS — giống code của bạn)
                var dtTongQuan = ThongKeBLL.Instance.LayTongQuan(nam, thang);
                if (dtTongQuan != null && dtTongQuan.Rows.Count > 0)
                {
                    var r = dtTongQuan.Rows[0];
                    g.DrawString("Tổng quan", headerFont, Brushes.Black, x, y);
                    y += (int)g.MeasureString("T", headerFont).Height + 4;

                    g.DrawString($"- Tổng số đơn hàng: {r["TongSoDonHang"]}", textFont, Brushes.Black, x, y);
                    y += (int)g.MeasureString("T", textFont).Height + 2;

                    g.DrawString($"- Tổng doanh thu: {Convert.ToDecimal(r["TongDoanhThu"]):N0} đ", textFont, Brushes.Black, x, y);
                    y += (int)g.MeasureString("T", textFont).Height + 2;

                    g.DrawString($"- Đơn giá trung bình: {Convert.ToDecimal(r["DonGiaTrungBinh"]):N0} đ", textFont, Brushes.Black, x, y);
                    y += (int)g.MeasureString("T", textFont).Height + 2;

                    g.DrawString($"- Số khách hàng: {r["SoKhachHang"]}", textFont, Brushes.Black, x, y);
                    y += (int)g.MeasureString("T", textFont).Height + 8;
                }

                // Lấy dữ liệu (không lấy trực tiếp từ DataGridView)
                var dtTopSP = ThongKeBLL.Instance.LayTopSanPham(50, nam, thang); // lấy nhiều để in
                var dtNV = ThongKeBLL.Instance.LayDoanhThuNhanVien(nam, thang);
                var dtKH = ThongKeBLL.Instance.LayTopKhachHang(50, nam, thang);

                // In từng bảng (nếu muốn thay maxRows, chỉnh tham số cuối)
                PrintTable(e, dtTopSP, "Top sản phẩm", ref y, margin, headerFont, textFont, maxRows: 15);
                if (e.HasMorePages) return;

                PrintTable(e, dtNV, "Doanh thu theo nhân viên", ref y, margin, headerFont, textFont, maxRows: 15);
                if (e.HasMorePages) return;

                PrintTable(e, dtKH, "Top khách hàng", ref y, margin, headerFont, textFont, maxRows: 15);
                if (e.HasMorePages) return;

                // Ký tên
                y += 20;
                g.DrawString("Người lập báo cáo", textFont, Brushes.Black, margin.Right - 150, y);
            }
        }

        // Thêm 2 phương thức hỗ trợ sau vào cùng class (frmThongKe)
        private void PrintTable(System.Drawing.Printing.PrintPageEventArgs e, DataTable dt, string title,
            ref int y, Rectangle marginBounds, Font headerFont, Font textFont, int maxRows = 10)
        {
            var g = e.Graphics;
            int x = marginBounds.Left;

            g.DrawString(title, headerFont, Brushes.Black, x, y);
            y += (int)g.MeasureString("T", headerFont).Height + 6;

            if (dt == null || dt.Columns.Count == 0)
            {
                y += 6;
                return;
            }

            // Chỉ in tối đa 4 cột cho đẹp trên trang giấy
            int colCount = Math.Min(4, dt.Columns.Count);

            // Phân bố chiều rộng cột:
            int totalW = marginBounds.Width;
            int firstColW = colCount > 1 ? (int)(totalW * 0.45) : totalW;
            int otherW = colCount > 1 ? (totalW - firstColW) / (colCount - 1) : 0;
            int[] colWidths = new int[colCount];
            for (int i = 0; i < colCount; i++)
            {
                colWidths[i] = (i == 0 && colCount > 1) ? firstColW : (otherW == 0 ? totalW : otherW);
            }

            // Vẽ header cột (in tên cột)
            int hx = x;
            using (var colHeaderFont = new Font(textFont, FontStyle.Bold))
            {
                for (int i = 0; i < colCount; i++)
                {
                    var rectH = new RectangleF(hx, y, colWidths[i], colHeaderFont.GetHeight(g) + 4);
                    var sfh = new StringFormat { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Near };
                    g.DrawString(dt.Columns[i].ColumnName, colHeaderFont, Brushes.Black, rectH, sfh);
                    hx += colWidths[i];
                }
                y += (int)colHeaderFont.GetHeight(g) + 6;
            }

            // Vẽ từng dòng, tính rowHeight là max chiều cao của từng ô (hỗ trợ wrap)
            int printed = 0;
            for (int r = 0; r < dt.Rows.Count; r++)
            {
                var row = dt.Rows[r];
                // đo chiều cao mỗi ô
                int rowHeight = 0;
                for (int c = 0; c < colCount; c++)
                {
                    string val = row[c]?.ToString() ?? "";
                    SizeF s = g.MeasureString(val, textFont, colWidths[c]);
                    int h = (int)Math.Ceiling(s.Height);
                    if (h > rowHeight) rowHeight = h;
                }
                if (rowHeight < (int)textFont.GetHeight(g)) rowHeight = (int)textFont.GetHeight(g);

                // Nếu vượt trang => báo tiếp trang
                if (y + rowHeight > marginBounds.Bottom - 40)
                {
                    e.HasMorePages = true;
                    return;
                }

                int cx = x;
                for (int c = 0; c < colCount; c++)
                {
                    string val = row[c]?.ToString() ?? "";
                    RectangleF rect = new RectangleF(cx, y, colWidths[c], rowHeight);
                    var sf = new StringFormat
                    {
                        Alignment = IsNumericColumn(dt.Columns[c].ColumnName) ? StringAlignment.Far : StringAlignment.Near,
                        LineAlignment = StringAlignment.Near,
                        Trimming = StringTrimming.EllipsisCharacter,
                        FormatFlags = StringFormatFlags.LineLimit
                    };
                    g.DrawString(val, textFont, Brushes.Black, rect, sf);
                    cx += colWidths[c];
                }

                y += rowHeight + 6;
                printed++;
                if (printed >= maxRows) break;
            }

            y += 8;
        }

        // Helper: nhận biết tên cột là số/tiền để canh phải
        private bool IsNumericColumn(string columnName)
        {
            if (string.IsNullOrEmpty(columnName)) return false;
            string lower = columnName.ToLower();
            return lower.Contains("doanhthu") || lower.Contains("tong") || lower.Contains("gia") ||
                   lower.Contains("don") || lower.Contains("gia") || lower.Contains("soluong") ||
                   lower.Contains("so") || lower.Contains("tongchi") || lower.Contains("thanhtien");
        }

        private void ExportReportAsExcelHtml(string filePath)
        {
            int nam = (int)cboNam.SelectedItem;
            int thang = (int)cboThang.SelectedItem;

            string HtmlEncode(string s)
            {
                return System.Net.WebUtility.HtmlEncode(s ?? string.Empty);
            }

            string TableFromDataTable(DataTable dt, string title)
            {
                if (dt == null) return string.Empty;
                var sb = new System.Text.StringBuilder();
                sb.AppendLine($"<h3>{HtmlEncode(title)}</h3>");
                sb.AppendLine("<table border='1' cellspacing='0' cellpadding='5'>");
                sb.AppendLine("<tr>");
                foreach (DataColumn col in dt.Columns)
                    sb.Append($"<th style='background:#e6eef8'>{HtmlEncode(col.ColumnName)}</th>");
                sb.AppendLine("</tr>");
                foreach (DataRow row in dt.Rows)
                {
                    sb.AppendLine("<tr>");
                    foreach (DataColumn col in dt.Columns)
                    {
                        string cell = row[col] == DBNull.Value ? string.Empty : row[col].ToString();
                        bool isNumber = col.ColumnName.Contains("DoanhThu", StringComparison.OrdinalIgnoreCase)
                                        || col.ColumnName.Contains("TrungBinh", StringComparison.OrdinalIgnoreCase)
                                        || col.ColumnName.Contains("SoLuong", StringComparison.OrdinalIgnoreCase)
                                        || col.ColumnName.Contains("Tong", StringComparison.OrdinalIgnoreCase)
                                        || decimal.TryParse(cell, out _);
                        string style = isNumber ? " style='mso-number-format:\\#\\,\\#\\#0' align='right'" : string.Empty;
                        sb.Append($"<td{style}>{HtmlEncode(cell)}</td>");
                    }
                    sb.AppendLine("</tr>");
                }
                sb.AppendLine("</table>");
                return sb.ToString();
            }

            var dtTongQuan = ThongKeBLL.Instance.LayTongQuan(nam, thang);
            var dtTopSP = (dgvTopSanPham.DataSource as DataTable) ?? ThongKeBLL.Instance.LayTopSanPham(10, nam, thang);
            var dtNV = (dgvNhanVien.DataSource as DataTable) ?? ThongKeBLL.Instance.LayDoanhThuNhanVien(nam, thang);
            var dtKH = (dgvKhachHang.DataSource as DataTable) ?? ThongKeBLL.Instance.LayTopKhachHang(10, nam, thang);

            var sbHtml = new System.Text.StringBuilder();
            sbHtml.AppendLine("<html><head><meta charset='utf-8'><title>Báo cáo</title></head><body>");
            sbHtml.AppendLine($"<h2 style='font-family:Segoe UI'>BÁO CÁO THỐNG KÊ THÁNG {thang}/{nam}</h2>");

            if (dtTongQuan != null && dtTongQuan.Rows.Count > 0)
            {
                var r = dtTongQuan.Rows[0];
                sbHtml.AppendLine("<h3>Tổng quan</h3>");
                sbHtml.AppendLine("<table border='1' cellspacing='0' cellpadding='5'>");
                sbHtml.AppendLine($"<tr><td>Tổng số đơn hàng</td><td align='right'>{HtmlEncode(r["TongSoDonHang"].ToString())}</td></tr>");
                sbHtml.AppendLine($"<tr><td>Tổng doanh thu</td><td align='right'>{Convert.ToDecimal(r["TongDoanhThu"]).ToString("N0")}</td></tr>");
                sbHtml.AppendLine($"<tr><td>Đơn giá trung bình</td><td align='right'>{Convert.ToDecimal(r["DonGiaTrungBinh"]).ToString("N0")}</td></tr>");
                sbHtml.AppendLine($"<tr><td>Số khách hàng</td><td align='right'>{HtmlEncode(r["SoKhachHang"].ToString())}</td></tr>");
                sbHtml.AppendLine("</table>");
            }

            sbHtml.AppendLine(TableFromDataTable(dtTopSP, "Top sản phẩm"));
            sbHtml.AppendLine(TableFromDataTable(dtNV, "Doanh thu theo nhân viên"));
            sbHtml.AppendLine(TableFromDataTable(dtKH, "Top khách hàng"));

            sbHtml.AppendLine("</body></html>");
            System.IO.File.WriteAllText(filePath, sbHtml.ToString(), System.Text.Encoding.UTF8);
        }

        private void ExportReportAsCsv(string filePath)
        {
            int nam = (int)cboNam.SelectedItem;
            int thang = (int)cboThang.SelectedItem;
            var dtTongQuan = ThongKeBLL.Instance.LayTongQuan(nam, thang);
            var dtTopSP = (dgvTopSanPham.DataSource as DataTable) ?? ThongKeBLL.Instance.LayTopSanPham(10, nam, thang);
            var dtNV = (dgvNhanVien.DataSource as DataTable) ?? ThongKeBLL.Instance.LayDoanhThuNhanVien(nam, thang);
            var dtKH = (dgvKhachHang.DataSource as DataTable) ?? ThongKeBLL.Instance.LayTopKhachHang(10, nam, thang);

            using var sw = new System.IO.StreamWriter(filePath, false, System.Text.Encoding.UTF8);
            sw.WriteLine($"Bao cao thong ke thang {thang}/{nam}");
            sw.WriteLine();
            if (dtTongQuan != null && dtTongQuan.Rows.Count > 0)
            {
                var r = dtTongQuan.Rows[0];
                sw.WriteLine("Tong quan");
                sw.WriteLine($"Tong so don hang,{r["TongSoDonHang"]}");
                sw.WriteLine($"Tong doanh thu,{Convert.ToDecimal(r["TongDoanhThu"]).ToString("N0")}");
                sw.WriteLine($"Don gia trung binh,{Convert.ToDecimal(r["DonGiaTrungBinh"]).ToString("N0")}");
                sw.WriteLine($"So khach hang,{r["SoKhachHang"]}");
            }

            void WriteCsv(DataTable dt, string title)
            {
                if (dt == null) return;
                sw.WriteLine();
                sw.WriteLine(title);
                // headers
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    sw.Write(dt.Columns[i].ColumnName);
                    if (i < dt.Columns.Count - 1) sw.Write(',');
                }
                sw.WriteLine();
                // rows
                foreach (DataRow row in dt.Rows)
                {
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        string cell = row[i]?.ToString()?.Replace('"', '\'') ?? string.Empty;
                        if (cell.Contains(',') || cell.Contains('"'))
                        {
                            cell = '"' + cell.Replace("\"", "\"\"") + '"';
                        }
                        sw.Write(cell);
                        if (i < dt.Columns.Count - 1) sw.Write(',');
                    }
                    sw.WriteLine();
                }
            }

            WriteCsv(dtTopSP, "Top san pham");
            WriteCsv(dtNV, "Doanh thu theo nhan vien");
            WriteCsv(dtKH, "Top khach hang");
        }

        private void ExportReportAsXlsx(string filePath)
        {
            int nam = (int)cboNam.SelectedItem;
            int thang = (int)cboThang.SelectedItem;

            var dtTongQuan = ThongKeBLL.Instance.LayTongQuan(nam, thang);
            var dtTopSP = (dgvTopSanPham.DataSource as DataTable) ?? ThongKeBLL.Instance.LayTopSanPham(10, nam, thang);
            var dtNV = (dgvNhanVien.DataSource as DataTable) ?? ThongKeBLL.Instance.LayDoanhThuNhanVien(nam, thang);
            var dtKH = (dgvKhachHang.DataSource as DataTable) ?? ThongKeBLL.Instance.LayTopKhachHang(10, nam, thang);

            using var wb = new XLWorkbook();

            // Sheet Tổng quan
            var wsSummary = wb.Worksheets.Add("TongQuan");
            wsSummary.Cell(1, 1).Value = $"BÁO CÁO THỐNG KÊ THÁNG {thang}/{nam}";
            wsSummary.Cell(1, 1).Style.Font.Bold = true;
            wsSummary.Cell(1, 1).Style.Font.FontSize = 16;
            int row = 3;
            if (dtTongQuan != null && dtTongQuan.Rows.Count > 0)
            {
                var r = dtTongQuan.Rows[0];
                wsSummary.Cell(row, 1).Value = "Tổng số đơn hàng"; wsSummary.Cell(row, 2).Value = Convert.ToInt32(r["TongSoDonHang"] == DBNull.Value ? 0 : r["TongSoDonHang"]); row++;
                wsSummary.Cell(row, 1).Value = "Tổng doanh thu"; wsSummary.Cell(row, 2).Value = Convert.ToDecimal(r["TongDoanhThu"]); wsSummary.Cell(row, 2).Style.NumberFormat.Format = "#,##0"; row++;
                wsSummary.Cell(row, 1).Value = "Đơn giá trung bình"; wsSummary.Cell(row, 2).Value = Convert.ToDecimal(r["DonGiaTrungBinh"]); wsSummary.Cell(row, 2).Style.NumberFormat.Format = "#,##0"; row++;
                wsSummary.Cell(row, 1).Value = "Số khách hàng"; wsSummary.Cell(row, 2).Value = Convert.ToInt32(r["SoKhachHang"] == DBNull.Value ? 0 : r["SoKhachHang"]); row++;
                wsSummary.Range(3, 1, row - 1, 2).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                wsSummary.Range(3, 1, row - 1, 2).Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                wsSummary.Columns().AdjustToContents();
            }

            // Helper to add DataTable as table on a sheet
            void AddTableSheet(string sheetName, DataTable dt)
            {
                if (dt == null) return;
                var ws = wb.Worksheets.Add(sheetName);
                ws.Cell(1, 1).InsertTable(dt, true);
                ws.Columns().AdjustToContents();
                // Format numeric-looking columns
                for (int c = 1; c <= dt.Columns.Count; c++)
                {
                    var colName = dt.Columns[c - 1].ColumnName.ToLower();
                    if (colName.Contains("doanhthu") || colName.Contains("trungbinh") || colName.Contains("soluong") || colName.Contains("tong"))
                    {
                        ws.Column(c).Style.NumberFormat.Format = "#,##0";
                    }
                }
            }

            AddTableSheet("TopSanPham", dtTopSP);
            AddTableSheet("NhanVien", dtNV);
            AddTableSheet("KhachHang", dtKH);

            wb.SaveAs(filePath);
        }
        #endregion
    }
}
