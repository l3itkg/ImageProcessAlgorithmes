using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using lab3.Core;
using ZedGraph;

namespace lab3
{
    public partial class Form1 : Form
    {
        private readonly FunctionGenerator _functionGenerator;
        private readonly Random _random = new Random();
        private readonly DftProcessor _dftProcessor;
        private readonly FftProcessor _fftProcessor;
        private double _dt = 0.7;
        private double _from;
        private double _to = 480;
        private Complex[] _fftResult;

        public Form1()
        {
            InitializeComponent();
            _functionGenerator = new FunctionGenerator();
            _dftProcessor = new DftProcessor();
            _fftProcessor = new FftProcessor();
        }

        private void DrawGraph(ZedGraphControl control, double[] values, double[] times = null)
        {
            var pane = control.GraphPane;
            pane.XAxis.Title.Text = "Time";
            pane.YAxis.Title.Text = "Value";
            var t = _from;
            var data = values.Select((x, i) => new { item = x, index = t += _dt })
                .ToList();
            var pointPairList = new PointPairList(times ?? data.Select(x => x.index).ToArray(),
                data.Select(x => x.item).ToArray());
            pane.AddCurve("", pointPairList, GetRandomColor(), SymbolType.None);
            control.AxisChange();
            control.Invalidate();
        }

        private void btnDFT_Click(object sender, EventArgs e)
        {
            Clear();
            DrawGraph(functionChart, _functionGenerator.Generate(_from, _to, _dt));
            var result = _dftProcessor.Transform(_functionGenerator.Generate(_from, _to, _dt), false);
            var t = result.Select((_, i) => (double)1 / (i / _dt / result.Length)).ToArray();
            DrawGraph(fourierChartA,
                result.Select(x => Math.Sqrt(Math.Pow(x.Real, 2) + Math.Pow(x.Imaginary, 2)) / result.Length).ToArray(),
                t);

            DrawGraph(fourierChartP, result.Select(x => Math.Atan2(x.Imaginary, x.Real)).ToArray(), t);
            fourierChartA.AxisChange();
            fourierChartP.AxisChange();
            fourierChartP.Invalidate();
            fourierChartA.Invalidate();
        }

        private void btnFFT_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Clear()
        {
            functionChart.GraphPane.CurveList.Clear();
            fourierChartP.GraphPane.CurveList.Clear();
            fourierChartA.GraphPane.CurveList.Clear();
        }

        private void txtDt_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(txtDt.Text, out var value))
                _dt = value;
        }

        private void txtTo_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(txtTo.Text, out var value))
                _to = value;
        }

        private void txtFrom_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(txtFrom.Text, out var value))
                _from = value;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnFFTwoRec_Click(object sender, EventArgs e)
        {
            try
            {
                Clear();
                var generated = _functionGenerator.Generate(_from, _to, _dt);

                generated = generated.Take((int)Math.Pow(2, (int)Math.Log(generated.Length, 2))).ToArray();

                DrawGraph(functionChart, generated);
                _fftResult = _fftProcessor.Process(generated.Select(x => new Complex(x, 0)).ToArray(), false);
                var t = _fftResult.Select((_, i) => (double)1 / (i / _dt / _fftResult.Length)).ToArray();
                DrawGraph(fourierChartA,
                    _fftResult.Select(x => Math.Sqrt(Math.Pow(x.Real, 2) + Math.Pow(x.Imaginary, 2)) / _fftResult.Length).ToArray(),
                    t);

                DrawGraph(fourierChartP, _fftResult.Select(x => Math.Atan2(x.Imaginary, x.Real)).ToArray(), t);
                btnFFTRev.Enabled = true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DrawGraph(functionChart, _functionGenerator.Generate(_from, _to, _dt));
        }

        private Color GetRandomColor()
        {
            return Color.FromArgb(_random.Next(256), _random.Next(256), _random.Next(256));
        }

        private void btnFFTRev_Click(object sender, EventArgs e)
        {
            var reversed = _fftProcessor.Process(_fftResult, true);
            functionChart.GraphPane.CurveList.Clear();
            functionChart.Invalidate();
            DrawGraph(functionChart, reversed.Select(x => x.Real).ToArray());
        }
    }
}
