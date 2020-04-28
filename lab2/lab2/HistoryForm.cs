using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using lab2.Core.Models;
using ZedGraph;

namespace lab2
{
    public partial class HistoryForm : Form
    {
        public HistoryForm(Histogram histogram)
        {
            InitializeComponent();
            rHist.GraphPane.Title.Text = "Red channel";
            gHist.GraphPane.Title.Text = "Green channel";
            bHist.GraphPane.Title.Text = "Blue channel";
            DrawHistogram(rHist.GraphPane, histogram.ValuesR);
            DrawHistogram(gHist.GraphPane, histogram.ValuesG);
            DrawHistogram(bHist.GraphPane, histogram.ValuesB);
            rHist.AxisChange();
            gHist.AxisChange();
            bHist.AxisChange();
        }

        private void DrawHistogram(GraphPane pane, int[] values)
        {
            pane.XAxis.Title.Text = "Brightness";

            pane.YAxis.Title.Text = "Frequency";
            var data = values.Select((x, i) => new { item = (double)x, index = (double)i }).ToList();
            var pointPairList = new PointPairList(data.Select(x => x.index).ToArray(),
                data.Select(x => x.item).ToArray());
            pane.AddCurve("", pointPairList, Color.Blue, SymbolType.Circle);
        }
    }
}
