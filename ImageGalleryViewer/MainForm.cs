using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ImageGalleryViewer
{
    public partial class MainForm : Form
    {
        private List<string> imagePaths = new List<string>();

        public MainForm()
        {
            InitializeComponent();
            Text = "🖼 Image Gallery Viewer";
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            LoadFromFolder();
        }

        private void LoadFromFolder()
        {
            if (folderBrowserDialog1.ShowDialog() != DialogResult.OK) return;

            var dir = folderBrowserDialog1.SelectedPath;
            lblPath.Text = dir;

            var exts = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            { ".jpg", ".jpeg", ".png", ".gif", ".bmp" };

            imagePaths = Directory.EnumerateFiles(dir, "*.*", SearchOption.TopDirectoryOnly)
                                  .Where(p => exts.Contains(Path.GetExtension(p)))
                                  .OrderBy(p => p, StringComparer.OrdinalIgnoreCase)
                                  .ToList();

            RenderThumbnails();
        }

        private void RenderThumbnails()
        {
            flowGrid.SuspendLayout();

            foreach (Control c in flowGrid.Controls)
                if (c is PictureBox pb && pb.Image != null) pb.Image.Dispose();

            flowGrid.Controls.Clear();

            const int thumbSize = 160;

            for (int i = 0; i < imagePaths.Count; i++)
            {
                string path = imagePaths[i];

                var pb = new PictureBox
                {
                    Width = thumbSize,
                    Height = thumbSize,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Cursor = Cursors.Hand,
                    Margin = new Padding(8),
                    Tag = i
                };

                using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (var img = Image.FromStream(fs))
                {
                    pb.Image = new Bitmap(img, new Size(thumbSize, thumbSize));
                }

                pb.Click += (s, _) =>
                {
                    int index = (int)((PictureBox)s).Tag;
                    new PreviewForm(imagePaths, index).ShowDialog(this);
                };

                flowGrid.Controls.Add(pb);
            }

            flowGrid.ResumeLayout();
        }
    }
}
