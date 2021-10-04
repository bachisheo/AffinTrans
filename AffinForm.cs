using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AffinTransformation
{
    public partial class AffinForm : Form
    {
        int X0 = 100, Y0 = 200, Z0 = 100;
        int axesLenght = 100;

        Painter painter;
        public void AddFigure(Figure figure)
        {
            painter.AddFigure(figure);
        }
        PaintEventArgs paintEventArgs;
        public AffinForm()
        {
            painter = new Painter(X0, Y0, Z0);
            Figure axes = new Figure();
            axes.AddDot(0, 0, 0);
            axes.AddDot(axesLenght, 0, 0);
            axes.AddDot(0, axesLenght, 0);
            axes.AddDot(0, 0, axesLenght);
            axes.AddLine(0, 1);
            axes.AddLine(0, 2);
            axes.AddLine(0, 3);
            AddFigure(axes);
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            paintEventArgs = e;
            painter.PaintAll(new Pen(Color.Black, 3), e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                TextReader tr = File.OpenText(openFileDialog1.FileName);
                Figure f = new Figure();
                f.Input(tr);
                tr.Close();
                painter.AddFigure(f);
                painter.AddFigure(f.Translation(100, 100, 100));
                painter.AddFigure(f.Translation(10, 0, 0));
                this.Refresh();
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
