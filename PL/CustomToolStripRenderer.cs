using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace PL
{
    public class CustomToolStripRenderer : ToolStripProfessionalRenderer
    {
        protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
        {
            // Kiểm tra nếu nút đang được hover
            if (e.Item.Selected)
            {
                // Lấy thông tin màu hover
                Color hoverColor = e.Item.BackColor;

                // Hiển thị thông tin màu hover trong Output Console (hoặc xử lý theo nhu cầu)
                Debug.WriteLine($"Màu hover: {hoverColor}");
            }

            // Gọi phương thức cơ sở để giữ nguyên các hành vi vẽ mặc định
            base.OnRenderButtonBackground(e);
        }
    }
}
