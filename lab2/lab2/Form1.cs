using System;
using System.Drawing;
using System.Windows.Forms;
using lab2.Core;

namespace lab2
{
    public partial class Form1 : Form
    {
        private DirectBitmap _currentImage;
        private readonly HistogramGenerator _histogramGenerator;
        private readonly SegmentationProcessor _segmentationProcessor;
        private readonly DynamicSegmentationProcessor _dynamicSegmentationProcessor;

        public Form1()
        {
            InitializeComponent();
            _histogramGenerator = new HistogramGenerator();
            _segmentationProcessor = new SegmentationProcessor();
            _dynamicSegmentationProcessor = new DynamicSegmentationProcessor();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            using (var dialogue = new OpenFileDialog())
            {
                if (dialogue.ShowDialog() == DialogResult.OK)
                {
                    var bitmap = Image.FromFile(dialogue.FileName);
                    _currentImage = new DirectBitmap((Bitmap)bitmap);
                    pbMain.Image = _currentImage.Bitmap;
                }
            }
        }

        private void btnGist_Click(object sender, EventArgs e)
        {
            if (_currentImage == null)
                return;
            new HistoryForm(_histogramGenerator.Generate(_currentImage)).Show();
        }

        private void btnSmoothGist_Click(object sender, EventArgs e)
        {
            if (_currentImage == null)
                return;
            new HistoryForm(_histogramGenerator.Smooth(_histogramGenerator.Generate(_currentImage), 40)).Show();
        }

        private void btnSegmentate_Click(object sender, EventArgs e)
        {
            if (_currentImage == null)
                return;
            _currentImage = _segmentationProcessor.Segment(_currentImage);
            pbMain.Image = _currentImage.Bitmap;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_currentImage == null || !double.TryParse(textBox1.Text, out var treshoId))
                return;
            var result = _dynamicSegmentationProcessor.Segment(_currentImage, treshoId, chkHighlight.Checked);
            MessageBox.Show($"Processed {result.SegmentsCount} segments");
            _currentImage = result.Image;
            pbMain.Image = _currentImage.Bitmap;
        }
    }
}
