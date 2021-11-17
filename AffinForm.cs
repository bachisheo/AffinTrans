using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using AF = AffinTransformation.AffinTransformation;

namespace AffinTransformation
{
    public partial class AffinForm : Form
    {
        private int deltaTrans = 10;
        private int deltaDel = 2;
        private float deltRot = 10;
        private int axesLenght = 350;
        private const int animTick = 75;
        private int currentTick;
        //animated distance
        private Dot animated;
        private Dot diff;
        private int _movableId;
        private List<Figure> figurs;
        private Figure _emptyFigure;
        private Figure _movableFigure
        {
            set => figurs[_movableId] = value;
            get => figurs[_movableId];
        }
    
        Figure axes;
        //speed - delta points in one timer's tik
        Dot DeltaA = new Dot(0, 0, 0, 1), DeltaB = new Dot(0, 0, 0, 1);
        bool mbA = false, mbB = false;
        Dot A = new Dot(0, 0, 0, 1), B = new Dot(0, 0, 0, 1);
        public AffinForm()
        {

            figurs = new List<Figure>();
            _emptyFigure = new Figure();
            _emptyFigure.AddDot(0,0,0);
            _movableId = 0;
            figurs.Add(_emptyFigure);
            axes = new Figure();
            axes.AddDot(0, 0, 0);
            axes.AddDot(axesLenght, 0, 0);
            axes.AddDot(0, axesLenght, 0);
            axes.AddDot(0, 0, axesLenght);
            axes.AddDot(-15, 100, 0);
            axes.AddDot(15, 100, 0);
            axes.AddLine(0, 1);
            axes.AddLine(0, 2);
            axes.AddLine(0, 3);
            axes.AddLine(4, 5);
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            AF.Paint(axes, new Pen(Color.Red, 1), e);
            foreach(var fig in figurs)
                AF.Paint(fig, new Pen(fig.Color, 1), e);
                AF.Paint(_movableFigure, new Pen(_movableFigure.Color, 1), e);
        }
        private void Transfer_Click(object sender, EventArgs e)
        {
            Button but = (Button)sender;
            switch (but.Text)
            {
                case "+X": _movableFigure = AF.Translation(_movableFigure, deltaTrans, 0, 0); break;
                case "+Y": _movableFigure = AF.Translation(_movableFigure, 0, deltaTrans, 0); break;
                case "+Z": _movableFigure = AF.Translation(_movableFigure, 0, 0, deltaTrans); break;
                case "--X": _movableFigure = AF.Translation(_movableFigure, -deltaTrans, 0, 0); break;
                case "--Y": _movableFigure = AF.Translation(_movableFigure, 0, -deltaTrans, 0); break;
                case "--Z": _movableFigure = AF.Translation(_movableFigure, 0, 0, -deltaTrans); break;
            }
            Refresh();
        }
       
        private void buttonReset_Click(object sender, EventArgs e)
        {
            _movableFigure.Reset();
            Refresh();
        }

        
        private void Dialatation_Click(object sender, EventArgs e)
        {
            Button but = (Button)sender;
            switch (but.Text)
            {
                case "X": _movableFigure = AF.Dilatation(_movableFigure, deltaDel, 1, 1); break;
                case "Y": _movableFigure = AF.Dilatation(_movableFigure, 1, deltaDel, 1); break;
                case "Z": _movableFigure = AF.Dilatation(_movableFigure, 1, 1, deltaDel); break;
                case "x": _movableFigure = AF.Dilatation(_movableFigure, 1.0f / deltaDel, 1, 1); break;
                case "y": _movableFigure = AF.Dilatation(_movableFigure, 1, 1.0f / deltaDel, 1); break;
                case "z": _movableFigure = AF.Dilatation(_movableFigure, 1, 1, 1.0f / deltaDel); break;
            }
            Refresh();
        } 
        private void Rotation_Click(object sender, EventArgs e)
        {
            Button but = (Button)sender;
            switch (but.Text)
            {
                case "-Y": _movableFigure = AF.Rotation(_movableFigure, 'y', -deltRot); break;
                case "+Y": _movableFigure = AF.Rotation(_movableFigure, 'y', deltRot); break;
                case "-X": _movableFigure = AF.Rotation(_movableFigure, 'x', -deltRot); break;
                case "+X": _movableFigure = AF.Rotation(_movableFigure, 'x', deltRot); break;
                case "-Z": _movableFigure = AF.Rotation(_movableFigure, 'z', -deltRot); break;
                case "+Z": _movableFigure = AF.Rotation(_movableFigure, 'z', deltRot); break;
            }
            Refresh();
        }

        private void RefButton_Click(object sender, EventArgs e)
        {
            Button but = (Button)sender;
            switch (but.Text)
            {
                case "Z": _movableFigure = AF.Reflection(_movableFigure, false, false, true); break;
                case "X": _movableFigure = AF.Reflection(_movableFigure, true, false, false); break;
                case "Y": _movableFigure = AF.Reflection(_movableFigure, false, true, false); break;
            }
            Refresh();
        }

    
        private void MoveByLine_Click(object sender, EventArgs e)
        {
            Dot div = new Dot(AF.x0, AF.y0, 0, 0);
            A.x = labA.Left - (int)AF.x0;
            A.y = -(labA.Top - (int)AF.y0);
            B.x = labB.Left - (int)AF.x0;
            B.y = -(labB.Top - (int)AF.y0);

            animated = new Dot(0,0,0,1);
            _movableFigure = AF.Translation(_movableFigure,  _movableFigure.GetBaseDot(0) - _movableFigure.GetDot(0));
      
            _movableFigure = AF.Translation(_movableFigure, A);
            diff = B - A;
            currentTick = 0;
            this.timer1.Start();
           Refresh();
        }

        float Progress(int curTick)
        {
            float x = (1f * curTick) / animTick;
            return -(x - 1)*(x - 1) + 1; 
        }
        Dot CurrentDelta(float progr)
        {
            Dot cur = progr * diff;
            Dot delta = cur - animated;
            animated = cur;
            return delta;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(++currentTick == animTick)
            {
                timer1.Stop();
            }
            _movableFigure = AF.Translation(_movableFigure, CurrentDelta(Progress(currentTick)));
            Refresh();
        }

        private void AddNewFigure(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                TextReader tr = File.OpenText(openFileDialog1.FileName);

                figurs.Add(new Figure());
                _movableId = figurs.Count - 1;
                _movableFigure.Input(tr);
                tr.Close();
                this.Refresh();
            }
        }

        private void labA_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) //Если нажата левая кнопка мыши
            {
                mbA = true; //Запоминаем статус нажатости
                DeltaA.x = Cursor.Position.X - labA.Location.X; //Запоминаем значения дельта
                DeltaA.y = Cursor.Position.Y - labA.Location.Y;
            }

        }

        private void labB_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left) //Если нажата левая кнопка мыши
            {
                mbB = true; //Запоминаем статус нажатости
                DeltaB.x = Cursor.Position.X - labB.Location.X; //Запоминаем значения дельта
                DeltaB.y = Cursor.Position.Y - labB.Location.Y;
            }
        }

        private void labB_MouseMove(object sender, MouseEventArgs e)
        {
            if (mbB) //Если нажата и удерживается левая кнопка мыши
            {
                labB.Left = Cursor.Position.X - (int)DeltaB.x; //устанавливаем лейбл в новом месте относительно нового положения курсора экрана
                labB.Top = Cursor.Position.Y - (int)DeltaB.y;
            }
        }

        private void labB_MouseUp(object sender, MouseEventArgs e)
        {
            mbB = false;
            DeltaB.x = 0;
            DeltaB.y = 0;
        }

        private void labA_MouseMove(object sender, MouseEventArgs e)
        {

            if (mbA) //Если нажата и удерживается левая кнопка мыши
            {
                labA.Left = Cursor.Position.X - (int)DeltaA.x; //устанавливаем лейбл в новом месте относительно нового положения курсора экрана
                labA.Top = Cursor.Position.Y - (int)DeltaA.y;
            }
        }

        private void labA_MouseUp(object sender, MouseEventArgs e)
        {
            mbA = false;
            DeltaA.x = 0;
            DeltaA.y = 0;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
