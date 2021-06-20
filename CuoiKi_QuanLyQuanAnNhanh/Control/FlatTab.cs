using System;
using System.Windows.Forms;

namespace CuoiKi_QuanLyQuanAnNhanh.Control
{
    public class FlatTab : TabControl
    {
        // Xóa tab header
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x1328 && !DesignMode)
                m.Result = (IntPtr)1;
            else
                base.WndProc(ref m);
        }

        public void AddFrom(TabPage page, Form form)
        {
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.AutoScaleMode = AutoScaleMode.Dpi;

            if (!page.Controls.Contains(form))
            {
                page.Controls.Add(form);
                form.Dock = DockStyle.Fill;
                form.Show();
                Refresh();
            }
            Refresh();
        }
    }
}
