using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using lab4.Core;
using ZedGraph;

namespace lab4
{
    public partial class Form1 : Form
    {
        private readonly FunctionGenerator _functionGenerator;
        private readonly Random _random;
        private readonly WaveletProcessor _waveletProcessor;

        public Form1()
        {
            InitializeComponent();
            _functionGenerator = new FunctionGenerator();
            _random = new Random();
            _waveletProcessor = new WaveletProcessor();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DrawGraph(functionChart, _functionGenerator.Generate(0, 1023, 1));
            DrawScalogram();
        }

        private void DrawScalogram()
        {
            var result = _waveletProcessor.Process(_functionGenerator.Generate(0, 1023, 1));
            scalogram.Image = ColorVisualizer.DrawGraphic(result, 100);
            ColorVisualizer.DrawSignatureTwoPowers(System.Drawing.Graphics.FromImage(scalogram.Image), scalogram.Image,
                0, 1023, 0, 250);

        }

        private Color GetRandomColor()
        {
            return Color.FromArgb(_random.Next(256), _random.Next(256), _random.Next(256));
        }

        private void DrawGraph(ZedGraphControl control, double[] values, double[] times = null)
        {
            var pane = control.GraphPane;
            pane.XAxis.Title.Text = "Time";
            pane.YAxis.Title.Text = "Value";
            var t = 0.0;
            var data = values.Select((x, i) => new {item = x, index = t += 1.0})
                .ToList();
            var pointPairList = new PointPairList(times ?? data.Select(x => x.index).ToArray(),
                data.Select(x => x.item).ToArray());
            pane.AddCurve("", pointPairList, GetRandomColor(), SymbolType.None);
            control.AxisChange();
            control.Invalidate();
        }
    }
}