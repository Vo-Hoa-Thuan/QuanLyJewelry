using LiveCharts;
using LiveCharts.WinForms;
using LiveCharts.Wpf; // để dùng Axis, ColumnSeries, PieSeries
using ClosedXML.Excel;
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

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(
                (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2
            );

            // Wire up events (Designer did not attach handlers)
            this.cboNam.SelectedIndexChanged += cboNam_SelectedIndexChanged;
            this.cboThang.SelectedIndexChanged += cboThang_SelectedIndexChanged;
            this.btnLamMoi.Click += btnLamMoi_Click;
            this.btnXuatExcel.Click += btnXuatExcel_Click;
            this.btnInBaoCao.Click += btnInBaoCao_Click;
            this.printDocument1.PrintPage += printDocument1_PrintPage;
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
            DataTable dt = ThongKeBUS.Instance.LayDoanhThuTheoNam(nam);
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
                Values = new LiveCharts.ChartValues<double>()
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
                Labels = labels
            });

            chartDoanhThu.AxisY.Clear();
            chartDoanhThu.AxisY.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Doanh thu (đ)",
                LabelFormatter = value => value.ToString("N0")
            });
        }

        private void LoadDoanhThuTheoLoai()
        {
            int nam = (int)cboNam.SelectedItem;
            int thang = (int)cboThang.SelectedItem;

            DataTable dt = ThongKeBUS.Instance.LayDoanhThuTheoLoaiSP(nam, thang);
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

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int nam = (int)cboNam.SelectedItem;
            int thang = (int)cboThang.SelectedItem;
            var g = e.Graphics;
            int marginLeft = e.MarginBounds.Left;
            int y = e.MarginBounds.Top;

            using var titleFont = new Font("Segoe UI", 16, FontStyle.Bold);
            using var headerFont = new Font("Segoe UI", 12, FontStyle.Bold);
            using var textFont = new Font("Segoe UI", 10, FontStyle.Regular);

            g.DrawString($"BÁO CÁO THỐNG KÊ THÁNG {thang}/{nam}", titleFont, Brushes.Black, marginLeft, y);
            y += 40;

            // Tổng quan
            var dtTongQuan = ThongKeBUS.Instance.LayTongQuan(nam, thang);
            if (dtTongQuan != null && dtTongQuan.Rows.Count > 0)
            {
                var r = dtTongQuan.Rows[0];
                g.DrawString("Tổng quan", headerFont, Brushes.Black, marginLeft, y); y += 24;
                g.DrawString($"- Tổng số đơn hàng: {r["TongSoDonHang"]}", textFont, Brushes.Black, marginLeft, y); y += 18;
                g.DrawString($"- Tổng doanh thu: {Convert.ToDecimal(r["TongDoanhThu"]).ToString("N0")} đ", textFont, Brushes.Black, marginLeft, y); y += 18;
                g.DrawString($"- Đơn giá trung bình: {Convert.ToDecimal(r["DonGiaTrungBinh"]).ToString("N0")} đ", textFont, Brushes.Black, marginLeft, y); y += 18;
                g.DrawString($"- Số khách hàng: {r["SoKhachHang"]}", textFont, Brushes.Black, marginLeft, y); y += 24;
            }

            // Helper to print small table from a DataGridView
            void PrintGridPreview(DataGridView grid, string sectionTitle, int maxRows = 10)
            {
                g.DrawString(sectionTitle, headerFont, Brushes.Black, marginLeft, y);
                y += 22;
                if (grid.DataSource is DataTable dt && dt.Columns.Count > 0)
                {
                    // headers
                    int x = marginLeft;
                    int colWidth = Math.Max(120, e.MarginBounds.Width / Math.Min(4, dt.Columns.Count));
                    foreach (DataColumn col in dt.Columns)
                    {
                        g.DrawString(col.ColumnName, textFont, Brushes.Black, x, y);
                        x += colWidth;
                        if (x > e.MarginBounds.Right) break;
                    }
                    y += 16;

                    int printed = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        x = marginLeft;
                        foreach (DataColumn col in dt.Columns)
                        {
                            string val = row[col]?.ToString() ?? string.Empty;
                            g.DrawString(val, textFont, Brushes.Black, x, y);
                            x += colWidth;
                            if (x > e.MarginBounds.Right) break;
                        }
                        y += 16;
                        printed++;
                        if (printed >= maxRows) break;
                        if (y > e.MarginBounds.Bottom - 40)
                        {
                            e.HasMorePages = true;
                            return;
                        }
                    }
                }
                y += 10;
            }

            PrintGridPreview(dgvTopSanPham, "Top sản phẩm");
            if (e.HasMorePages) return;
            PrintGridPreview(dgvNhanVien, "Doanh thu theo nhân viên");
            if (e.HasMorePages) return;
            PrintGridPreview(dgvKhachHang, "Top khách hàng");
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

            var dtTongQuan = ThongKeBUS.Instance.LayTongQuan(nam, thang);
            var dtTopSP = (dgvTopSanPham.DataSource as DataTable) ?? ThongKeBUS.Instance.LayTopSanPham(10, nam, thang);
            var dtNV = (dgvNhanVien.DataSource as DataTable) ?? ThongKeBUS.Instance.LayDoanhThuNhanVien(nam, thang);
            var dtKH = (dgvKhachHang.DataSource as DataTable) ?? ThongKeBUS.Instance.LayTopKhachHang(10, nam, thang);

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
            var dtTongQuan = ThongKeBUS.Instance.LayTongQuan(nam, thang);
            var dtTopSP = (dgvTopSanPham.DataSource as DataTable) ?? ThongKeBUS.Instance.LayTopSanPham(10, nam, thang);
            var dtNV = (dgvNhanVien.DataSource as DataTable) ?? ThongKeBUS.Instance.LayDoanhThuNhanVien(nam, thang);
            var dtKH = (dgvKhachHang.DataSource as DataTable) ?? ThongKeBUS.Instance.LayTopKhachHang(10, nam, thang);

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

            var dtTongQuan = ThongKeBUS.Instance.LayTongQuan(nam, thang);
            var dtTopSP = (dgvTopSanPham.DataSource as DataTable) ?? ThongKeBUS.Instance.LayTopSanPham(10, nam, thang);
            var dtNV = (dgvNhanVien.DataSource as DataTable) ?? ThongKeBUS.Instance.LayDoanhThuNhanVien(nam, thang);
            var dtKH = (dgvKhachHang.DataSource as DataTable) ?? ThongKeBUS.Instance.LayTopKhachHang(10, nam, thang);

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
