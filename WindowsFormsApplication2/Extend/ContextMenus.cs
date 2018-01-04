using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProsecInc.Extend
{
    public class ContextMenus
    {
        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>ContextMenuStrip</returns>
        public ContextMenuStrip Create()
        {
            // Add the default menu options.
            ContextMenuStrip menu = new ContextMenuStrip();
            ToolStripMenuItem item;
            ToolStripSeparator sep;
            //var path = Application.StartupPath + "\\Data";
            //if (!Directory.Exists(path))
            //{
            //    Directory.CreateDirectory(path);
            //}
            //else
            //{
            //    var addressUtil = new AddressUtil();
            //    var addresses = addressUtil.Gets().ToList();
            //    foreach (var add in addresses)
            //    {
            //        item = new ToolStripMenuItem();
            //        item.Text = add.IPAddress + " port " + add.Port;
            //        item.Image = SystemIcons.Question.ToBitmap();
            //        menu.Items.Add(item);

            //        // Separator.
            //        sep = new ToolStripSeparator();
            //        menu.Items.Add(sep);
            //    }
            //}
            // About.
            item = new ToolStripMenuItem();
            item.Text = "Show";
            item.Click += new EventHandler(Show_Click);
            item.Image = SystemIcons.Application.ToBitmap();//Resources.About;
            menu.Items.Add(item);

            // Separator.
            sep = new ToolStripSeparator();
            menu.Items.Add(sep);

            // Exit.
            item = new ToolStripMenuItem();
            item.Text = "Exit";
            item.Click += new System.EventHandler(Exit_Click);
            //item.Image = Resources.Exit;
            menu.Items.Add(item);

            return menu;
        }

        /// <summary>
        /// Handles the Click event of the Explorer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void Explorer_Click(object sender, EventArgs e)
        {
            Process.Start("explorer", null);
        }

        /// <summary>
        /// Handles the Click event of the About control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void Show_Click(object sender, EventArgs e)
        {
            var form = new frmProcess();
            //if (form.Visible)
            //{
            form.ShowDialog();
            //}
        }

        /// <summary>
        /// Processes a menu item.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void Exit_Click(object sender, EventArgs e)
        {
            // Quit without further ado.
            Application.Exit();
        }
    }
}
