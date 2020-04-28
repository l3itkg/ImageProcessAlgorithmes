using System;
using System.Linq;
using System.Windows.Forms;

namespace Plugins.CustomFilter
{
    public partial class CustomFilterParametrForm : Form
    {
        private TableLayoutPanel _panel;

        public CustomFilterParametrForm()
        {
            InitializeComponent();
        }

        public double[,] Matrix { get; private set; }



        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ProcessResize();
        }

        private void ProcessResize()
        {
            int x, y;
            if (!int.TryParse(textBox1.Text, out y) || !int.TryParse(textBox2.Text, out x))
                return;
            var emboss = checkBox1.Checked;
            Matrix = new double[y, x];
            _panel = new TableLayoutPanel();
            _panel.RowCount = y;
            _panel.ColumnCount = x;
            for (var i = 0; i < y; i++)
            {
                for (var j = 0; j < x; j++)
                {
                    Matrix[i, j] = emboss
                        ? (i < j ? 1 : i > j ? -1 : 0)
                        : 0;
                    var txt = new TextBox {Name = $"{i},{j}", Text = Matrix[i, j].ToString()};
                    txt.TextChanged += Txt_TextChanged;
                    _panel.Controls.Add(txt);
                }
            }
            _panel.Height = panel1.Height;
            _panel.Width = panel1.Width;
            _panel.Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Top;
            panel1.Controls.Add(_panel);
        }

        private void Txt_TextChanged(object sender, EventArgs e)
        {
            var txt = (TextBox)sender;
            var values = txt.Name.Split(',').Select(int.Parse).ToArray();
            double val;
            if (double.TryParse(txt.Text, out val))
            {
                Matrix[values[0], values[1]] = val;
                return;
            }
            MessageBox.Show("Only numbers allowed!");
            txt.Text = string.Empty;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            ProcessResize();
        }
    }
}
