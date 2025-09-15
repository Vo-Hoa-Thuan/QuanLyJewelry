using HtmlAgilityPack;
using QuanLyJewelry.DAO;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyJewelry.View
{
    public partial class frmTrangChu : Form
    {
        public frmTrangChu()
        {
            InitializeComponent();
        }

        private async void frmTrangChu_Load(object sender, EventArgs e)
        {
            lblTongDoanhThu.Text = KetNoiSql.Instance.getTongDoanhThu() + " VND";
            lblTongSPDaBan.Text = KetNoiSql.Instance.getTongSanPhamDaBan() + " SP";
            lblTongKH.Text = KetNoiSql.Instance.getTongKhachHang() + " Người";

            // Load bảng giá vàng siêu nhanh
            await LoadGiaVangListView();
        }

        private async Task LoadGiaVangListView()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string html = await client.GetStringAsync("https://webgia.com/gia-vang/sjc/");
                    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(html);

                    var rows = doc.DocumentNode.SelectNodes("//table//tbody//tr");

                    listView1.BeginUpdate();
                    listView1.Items.Clear();

                    string currentRegion = "";
                    foreach (var row in rows)
                    {
                        var th = row.SelectSingleNode("./th");
                        var tds = row.SelectNodes("./td");

                        if (th != null)
                        {
                            currentRegion = th.InnerText.Trim();
                            if (tds != null && tds.Count > 0)
                            {
                                AddItemToList(currentRegion, tds);
                            }
                            continue;
                        }

                        if (tds != null && tds.Count > 0)
                        {
                            AddItemToList(currentRegion, tds);
                        }
                    }

                    listView1.EndUpdate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void AddItemToList(string region, HtmlNodeCollection tds)
        {
            string loai = tds[0].InnerText.Trim();
            string mua = "-";
            string ban = "-";

            // lọc ra giá trị có dạng số (chứa số hoặc dấu chấm)
            var values = tds.Skip(1)
                            .Select(td => td.InnerText.Trim())
                            .Where(v => v.Any(char.IsDigit)) // chỉ lấy giá trị có số
                            .Take(2)
                            .ToList();

            if (values.Count > 0) mua = values[0];
            if (values.Count > 1) ban = values[1];

            // bỏ qua nếu không có số nào (toàn link quảng cáo)
            if (mua == "-" && ban == "-") return;

            var item = new ListViewItem(region);
            item.SubItems.Add(loai);
            item.SubItems.Add(mua);
            item.SubItems.Add(ban);
            listView1.Items.Add(item);
        }

    }
}
