using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ImageGalleryViewer
{
    public class PreviewForm : Form
    {
        private readonly List<string> images;
        private int index;
        private readonly PictureBox viewer;
        private readonly Button btnPrev, btnNext;

        public PreviewForm(List<string> images, int startIndex)
        {
            this.images = images ?? new List<string>();
            if (this.images.Count == 0) startIndex = 0;
            index = Math.Max(0, Math.Min(startIndex, this.images.Count > 0 ? this.images.Count - 1 : 0));

            Text = $"Preview ({(this.images.Count == 0 ? 0 : index + 1)}/{this.images.Count}) — ← / →, Esc";
            WindowState = FormWindowState.Maximized;
            BackColor = Color.Black;

            viewer = new PictureBox { Dock = DockStyle.Fill, SizeMode = PictureBoxSizeMode.Zoom, BackColor = Color.Black };
            Controls.Add(viewer);

            btnPrev = new Button { Text = "◀", Width = 48, Height = 48, Top = 20, Left = 20 };
            btnNext = new Button { Text = "▶", Width = 48, Height = 48, Top = 20, Left = 80 };
            btnPrev.Click += (_, __) => Navigate(-1);
            btnNext.Click += (_, __) => Navigate(+1);

            var overlay = new Panel { Dock = DockStyle.Top, Height = 70, BackColor = Color.FromArgb(80, 0, 0, 0) };
            overlay.Controls.Add(btnPrev);
            overlay.Controls.Add(btnNext);
            Controls.Add(overlay);
            overlay.BringToFront();

            KeyPreview = true;
            KeyDown += (_, e) =>
            {
                if (e.KeyCode == Keys.Escape) Close();
                if (e.KeyCode == Keys.Left) Navigate(-1);
                if (e.KeyCode == Keys.Right) Navigate(+1);
            };

            LoadImage();
        }

        private void Navigate(int delta)
        {
            if (images.Count == 0) return;
            index = (index + delta + images.Count) % images.Count;
            LoadImage();
        }

        private void LoadImage()
        {
            if (images.Count == 0)
            {
                viewer.Image?.Dispose();
                viewer.Image = null;
                Text = "Preview (0/0)";
                return;
            }

            string path = images[index];
            Text = $"Preview ({index + 1}/{images.Count}) — {Path.GetFileName(path)}";

            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var bmp = (Bitmap)Image.FromStream(fs))
            {
                viewer.Image?.Dispose();
                viewer.Image = new Bitmap(bmp);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                viewer.Image?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
