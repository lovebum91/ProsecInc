using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProsecInc.Extend
{
    /// <para>Description: Lớp chứa các hàm xử lý các thay đổi đặc biệt với Controls (Buttons, Labels, CheckBoxs, ...) trên giao diện</para>
    public class MultiControlProcess
    {
        /// <summary>
        /// Visible Controls theo giá trị truyền vào
        /// </summary>
        /// <param name="enable">Thuộc tính Enable</param>
        /// <param name="controls">Các controls</param>
        public static void VisibleControls(bool enable, params Control[] controls)
        {
            foreach (var control in controls)
            {
                control.Visible = enable;
            }
        }
    }
}
