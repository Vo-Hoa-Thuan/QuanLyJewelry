using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace QuanLyJewelry.View
{
    internal static class UITheme
    {
        public static void StyleDataGrid(DataGridView grid)
        {
            if (grid == null) return;
            SetDoubleBuffered(grid);
            grid.EnableHeadersVisualStyles = false;
            grid.BackgroundColor = Color.White;
            grid.BorderStyle = BorderStyle.None;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(34, 40, 70);
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            grid.ColumnHeadersHeight = 36;
            grid.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 248, 255);
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 234, 247);
            grid.DefaultCellStyle.SelectionForeColor = Color.Black;
            grid.RowHeadersVisible = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.AllowUserToResizeRows = false;
        }

        public static void StyleHeaderPanel(Panel panel, string titleText)
        {
            if (panel == null) return;
            panel.Dock = DockStyle.Top;
            panel.Height = 48;
            panel.BackColor = Color.FromArgb(238, 244, 252);
            panel.Padding = new Padding(12, 10, 12, 10);

            if (!string.IsNullOrEmpty(titleText))
            {
                var lbl = new Label
                {
                    AutoSize = true,
                    Text = titleText,
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    ForeColor = Color.FromArgb(34, 40, 70)
                };
                panel.Controls.Add(lbl);
            }
        }

        private static void SetDoubleBuffered(Control control)
        {
            try
            {
                var prop = typeof(Control).GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance);
                prop?.SetValue(control, true, null);
            }
            catch { }
        }
    }
}


