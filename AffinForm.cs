using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace AffinTransformation
{
    public partial class AffinForm : Form
    {
        int deltaTrans = 10;
        int deltaDel = 2;
        float deltRot = 10;
        int X0 = 200, Y0 = 400, Z0 = 400;
        int axesLenght = 350;
        List<Painter> figurPainters;
        Painter axesPainter;

        public void AddFigure(Figure figure)
        {
            figurPainters.Add(new Painter(X0, Y0, Z0, figure));

        }
        PaintEventArgs paintEventArgs;
        public AffinForm()
        {
            figurPainters = new List<Painter>();
            Figure axes = new Figure();
            axes.AddDot(0, 0, 0);
            axes.AddDot(axesLenght, 0, 0);
            axes.AddDot(0, axesLenght, 0);
            axes.AddDot(0, 0, axesLenght);
            axes.AddLine(0, 1);
            axes.AddLine(0, 2);
            axes.AddLine(0, 3);
            axesPainter = new Painter(X0, Y0, Z0, axes);
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            paintEventArgs = e;
            axesPainter.Paint(new Pen(Color.Red, 1), e);
            foreach (Painter paint in figurPainters)
                paint.Paint(new Pen(Color.Black, 1), e);

        }

        private void buttonXAdd_Click(object sender, EventArgs e)
        {
            foreach (Painter fp in figurPainters)
            {
                fp.Translation(deltaTrans, 0, 0);
            }
            Refresh();
        }

        private void buttonZAdd_Click(object sender, EventArgs e)
        {
            foreach (Painter fp in figurPainters)
            {
                fp.Translation(0, 0, deltaTrans);
            }
            Refresh();
        }

        private void buttonZSubs_Click(object sender, EventArgs e)
        {
            foreach (Painter fp in figurPainters)
            {
                fp.Translation(0, 0, -deltaTrans);
            }
            Refresh();
        }

        private void buttonXSub_Click(object sender, EventArgs e)
        {
            foreach (Painter fp in figurPainters)
            {
                fp.Translation(-deltaTrans, 0, 0);
            }
            Refresh();
        }

        private void buttonYSubs_Click(object sender, EventArgs e)
        {
            foreach (Painter fp in figurPainters)
            {
                fp.Translation(0, -deltaTrans, 0);
            }
            Refresh();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            foreach (Painter fp in figurPainters)
            {
                fp.ResetTransformation();
            }
            Refresh();
        }

        private void AffinKeyPress(object sender, KeyPressEventArgs e)
        {
            Painter fp = figurPainters[0];

            switch (e.KeyChar)
            {
                case 'A': fp.Translation(-deltaTrans, 0, 0); break;
                case 'F': fp.Translation(deltaTrans, 0, 0); break;
                case 'E': fp.Translation(0, deltaTrans, 0); break;
                case 'X': fp.Translation(0, -deltaTrans, 0); break;
                case 'S': fp.Translation(0, 0, deltaTrans); break;
                case 'D': fp.Translation(0, 0, -deltaTrans); break;
            }
        }

        private void buttonYAdd_Click(object sender, MouseEventArgs e)
        {
            foreach (Painter fp in figurPainters)
            {
                fp.Translation(0, deltaTrans, 0);
            }
            Refresh();
        }

        private void buttonDurZAdd_Click(object sender, EventArgs e)
        {
            foreach (Painter fp in figurPainters)
            {
                fp.Dilatation(1, 1, deltaDel);
            }
            Refresh();
        }

        private void buttonDurZDel_Click(object sender, EventArgs e)
        {

            foreach (Painter fp in figurPainters)
            {
                fp.Dilatation(1,1, 1.0f/deltaDel);
            }
            Refresh();
        }

        private void DilatIncX_Click(object sender, EventArgs e)
        {
            foreach (Painter fp in figurPainters)
            {
                fp.Dilatation(deltaDel, 1, 1);
            }
            Refresh();
        }

        private void DilatDecrX_Click(object sender, EventArgs e)
        {
            foreach (Painter fp in figurPainters)
            {
                fp.Dilatation(1.0f/deltaDel, 1, 1);
            }
            Refresh();
        }

        private void DilatIncY_Click(object sender, EventArgs e)
        {
            foreach (Painter fp in figurPainters)
            {
                fp.Dilatation(1, deltaDel, 1);
            }
            Refresh();
        }

        private void DilatDecrY_Click(object sender, EventArgs e)
        {
            foreach (Painter fp in figurPainters)
            {
                fp.Dilatation(1, 1.0f / deltaDel, 1);
            }
            Refresh();
        }

        private void RotZPlus_Click(object sender, EventArgs e)
        {
            foreach (Painter fp in figurPainters)
            {
                fp.RotationZ(deltRot);
            }
            Refresh();
        }

        private void RotXPlus_Click(object sender, EventArgs e)
        {
            foreach (Painter fp in figurPainters)
            {
                fp.RotationX(deltRot);
            }
            Refresh();
        }

        private void RotXNeg_Click(object sender, EventArgs e)
        {
            foreach (Painter fp in figurPainters)
            {
                fp.RotationX(-deltRot);
            }
            Refresh();
        }

        private void RotZNeg(object sender, EventArgs e)
        {
            foreach (Painter fp in figurPainters)
            {
                fp.RotationZ(-deltRot);
            }
            Refresh();
        }

        private void RotYPos_Click(object sender, EventArgs e)
        {
            foreach (Painter fp in figurPainters)
            {
                fp.RotationY(deltRot);
            }
            Refresh();
        }

        private void RotYNeg_Click(object sender, EventArgs e)
        {
            foreach (Painter fp in figurPainters)
            {
                fp.RotationY(-deltRot);
            }
            Refresh();

        }

        private void RefXButton_Click(object sender, EventArgs e)
        {
            foreach (Painter fp in figurPainters)
            {
                fp.Reflection(true, false, false);
            }
            Refresh();
        }

        private void RefYButton_Click(object sender, EventArgs e)
        {
            foreach (Painter fp in figurPainters)
            {
                fp.Reflection(false, true, false);
            }
            Refresh();
        }

        private void RefZButton_Click(object sender, EventArgs e)
        {
            foreach (Painter fp in figurPainters)
            {
                fp.Reflection(false, false, true);
            }
            Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                TextReader tr = File.OpenText(openFileDialog1.FileName);
                Figure f = new Figure();
                f.Input(tr);
                tr.Close();
                AddFigure(f);
                this.Refresh();
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
