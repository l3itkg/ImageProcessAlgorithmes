using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Common;
using Common.Interfaces;

namespace lab1
{
    public partial class Form1 : Form
    {
        private readonly Dictionary<Guid, IFactory> _pluginFactories;
        private DirectBitmap _directBitmap;

        public Form1()
        {
            InitializeComponent();
            var plugins = new PluginLoader<IFactory>();
            _pluginFactories = new Dictionary<Guid, IFactory>();
            cbPlugins.DisplayMember = "Text";
            cbPlugins.ValueMember = "Value";
            plugins.Plugins.ForEach(x => _pluginFactories.Add(Guid.NewGuid(), x));
            cbPlugins.DataSource =
                _pluginFactories.Select(x => new { Text = x.Value.Name(), Value = x.Key.ToString() }).ToArray();
            panel1.Controls.Add(pbImage);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dialogue = new OpenFileDialog())
            {
                if (dialogue.ShowDialog() == DialogResult.OK)
                {
                    var bitmap = Image.FromFile(dialogue.FileName);
                    _directBitmap = new DirectBitmap((Bitmap)bitmap);
                    pbImage.Image = _directBitmap.Bitmap;
                }
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            var item = cbPlugins.SelectedValue;

            if (_directBitmap != null && item != null)
            {
                var guid = Guid.Parse(item.ToString());
                var p = _pluginFactories[guid].CreateParameters();
                p.Configure();
                var f = _pluginFactories[guid].CreatePlugin();
                f.Process(_directBitmap, p);
                pbImage.Image = _directBitmap.Bitmap;
                pbImage.Refresh();
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_directBitmap == null)
                return;
            using (
                var dialogue = new SaveFileDialog()
                {
                    Filter = "Bitmap Image (.bmp)|*.bmp|JPEG Image (.jpeg)|*.jpg|Png Image (.png)|*.png"
                })
            {
                if (dialogue.ShowDialog() == DialogResult.OK)
                {
                    var filename = dialogue.FileName;
                    ImageFormat format = ImageFormat.Png;
                    switch (Path.GetExtension(filename))
                    {
                        case ".jpg":
                            format = ImageFormat.Jpeg;
                            break;
                        case ".bmp":
                            format = ImageFormat.Bmp;
                            break;
                    }
                    using (var stream = new FileStream(filename, FileMode.Create))
                    {
                        _directBitmap.Bitmap.Save(stream, format);
                    }
                }
            }
        }
    }
}
