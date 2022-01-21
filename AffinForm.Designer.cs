
namespace AffinTransformation
{
    partial class AffinForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.buttonXAdd = new System.Windows.Forms.Button();
            this.buttonXSub = new System.Windows.Forms.Button();
            this.buttonYAdd = new System.Windows.Forms.Button();
            this.buttonYSubs = new System.Windows.Forms.Button();
            this.buttonZAdd = new System.Windows.Forms.Button();
            this.buttonZSubs = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.DilatIncX = new System.Windows.Forms.Button();
            this.DilatDecrX = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DilatDecrY = new System.Windows.Forms.Button();
            this.DilatIncY = new System.Windows.Forms.Button();
            this.RotYIncr = new System.Windows.Forms.Button();
            this.RotYDecr = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.RotXNeg = new System.Windows.Forms.Button();
            this.RotXPlus = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.RotZPlus = new System.Windows.Forms.Button();
            this.RefZButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.RefYButton = new System.Windows.Forms.Button();
            this.RefXButton = new System.Windows.Forms.Button();
            this.MoveByLine = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.labA = new System.Windows.Forms.Label();
            this.labB = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(23, 12);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(123, 48);
            this.buttonLoad.TabIndex = 0;
            this.buttonLoad.Text = "Загрузить файл";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.AddNewFigure);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // buttonXAdd
            // 
            this.buttonXAdd.Location = new System.Drawing.Point(1127, 185);
            this.buttonXAdd.Name = "buttonXAdd";
            this.buttonXAdd.Size = new System.Drawing.Size(75, 48);
            this.buttonXAdd.TabIndex = 1;
            this.buttonXAdd.Text = "+X";
            this.buttonXAdd.UseVisualStyleBackColor = true;
            this.buttonXAdd.Click += new System.EventHandler(this.Transfer_Click);
            // 
            // buttonXSub
            // 
            this.buttonXSub.Location = new System.Drawing.Point(934, 185);
            this.buttonXSub.Name = "buttonXSub";
            this.buttonXSub.Size = new System.Drawing.Size(77, 48);
            this.buttonXSub.TabIndex = 2;
            this.buttonXSub.Text = "--X";
            this.buttonXSub.UseVisualStyleBackColor = true;
            this.buttonXSub.Click += new System.EventHandler(this.Transfer_Click);
            // 
            // buttonYAdd
            // 
            this.buttonYAdd.Location = new System.Drawing.Point(1028, 131);
            this.buttonYAdd.Name = "buttonYAdd";
            this.buttonYAdd.Size = new System.Drawing.Size(84, 48);
            this.buttonYAdd.TabIndex = 3;
            this.buttonYAdd.Text = "+Y";
            this.buttonYAdd.UseVisualStyleBackColor = true;
            this.buttonYAdd.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Transfer_Click);
            // 
            // buttonYSubs
            // 
            this.buttonYSubs.Location = new System.Drawing.Point(1028, 239);
            this.buttonYSubs.Name = "buttonYSubs";
            this.buttonYSubs.Size = new System.Drawing.Size(84, 48);
            this.buttonYSubs.TabIndex = 4;
            this.buttonYSubs.Text = "--Y";
            this.buttonYSubs.UseVisualStyleBackColor = true;
            this.buttonYSubs.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Transfer_Click);
            // 
            // buttonZAdd
            // 
            this.buttonZAdd.Location = new System.Drawing.Point(1017, 185);
            this.buttonZAdd.Name = "buttonZAdd";
            this.buttonZAdd.Size = new System.Drawing.Size(48, 48);
            this.buttonZAdd.TabIndex = 5;
            this.buttonZAdd.Text = "+Z";
            this.buttonZAdd.UseVisualStyleBackColor = true;
            this.buttonZAdd.Click += new System.EventHandler(this.Transfer_Click);
            // 
            // buttonZSubs
            // 
            this.buttonZSubs.Location = new System.Drawing.Point(1071, 185);
            this.buttonZSubs.Name = "buttonZSubs";
            this.buttonZSubs.Size = new System.Drawing.Size(50, 48);
            this.buttonZSubs.TabIndex = 6;
            this.buttonZSubs.Text = "--Z";
            this.buttonZSubs.UseVisualStyleBackColor = true;
            this.buttonZSubs.Click += new System.EventHandler(this.Transfer_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(165, 12);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(159, 48);
            this.buttonReset.TabIndex = 7;
            this.buttonReset.Text = "Отменить изменения";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1019, 331);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(48, 48);
            this.button1.TabIndex = 8;
            this.button1.Text = "Z";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Dialatation_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1073, 331);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(48, 48);
            this.button2.TabIndex = 9;
            this.button2.Text = "z";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Dialatation_Click);
            // 
            // DilatIncX
            // 
            this.DilatIncX.Location = new System.Drawing.Point(1019, 385);
            this.DilatIncX.Name = "DilatIncX";
            this.DilatIncX.Size = new System.Drawing.Size(48, 48);
            this.DilatIncX.TabIndex = 10;
            this.DilatIncX.Text = "X";
            this.DilatIncX.UseVisualStyleBackColor = true;
            this.DilatIncX.Click += new System.EventHandler(this.Dialatation_Click);
            // 
            // DilatDecrX
            // 
            this.DilatDecrX.Location = new System.Drawing.Point(1073, 385);
            this.DilatDecrX.Name = "DilatDecrX";
            this.DilatDecrX.Size = new System.Drawing.Size(48, 48);
            this.DilatDecrX.TabIndex = 11;
            this.DilatDecrX.Text = "x";
            this.DilatDecrX.UseVisualStyleBackColor = true;
            this.DilatDecrX.Click += new System.EventHandler(this.Dialatation_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1019, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Перемещение";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1005, 311);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "Масштабирование";
            // 
            // DilatDecrY
            // 
            this.DilatDecrY.Location = new System.Drawing.Point(1073, 439);
            this.DilatDecrY.Name = "DilatDecrY";
            this.DilatDecrY.Size = new System.Drawing.Size(48, 48);
            this.DilatDecrY.TabIndex = 14;
            this.DilatDecrY.Text = "y";
            this.DilatDecrY.UseVisualStyleBackColor = true;
            this.DilatDecrY.Click += new System.EventHandler(this.Dialatation_Click);
            // 
            // DilatIncY
            // 
            this.DilatIncY.Location = new System.Drawing.Point(1019, 439);
            this.DilatIncY.Name = "DilatIncY";
            this.DilatIncY.Size = new System.Drawing.Size(48, 48);
            this.DilatIncY.TabIndex = 15;
            this.DilatIncY.Text = "Y";
            this.DilatIncY.UseVisualStyleBackColor = true;
            this.DilatIncY.Click += new System.EventHandler(this.Dialatation_Click);
            // 
            // RotYIncr
            // 
            this.RotYIncr.Location = new System.Drawing.Point(1019, 642);
            this.RotYIncr.Name = "RotYIncr";
            this.RotYIncr.Size = new System.Drawing.Size(48, 48);
            this.RotYIncr.TabIndex = 29;
            this.RotYIncr.Text = "+Y";
            this.RotYIncr.UseVisualStyleBackColor = true;
            this.RotYIncr.Click += new System.EventHandler(this.Rotation_Click);
            // 
            // RotYDecr
            // 
            this.RotYDecr.Location = new System.Drawing.Point(1073, 642);
            this.RotYDecr.Name = "RotYDecr";
            this.RotYDecr.Size = new System.Drawing.Size(48, 48);
            this.RotYDecr.TabIndex = 28;
            this.RotYDecr.Text = "-Y";
            this.RotYDecr.UseVisualStyleBackColor = true;
            this.RotYDecr.Click += new System.EventHandler(this.Rotation_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1039, 514);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 17);
            this.label3.TabIndex = 27;
            this.label3.Text = "Поворот";
            // 
            // RotXNeg
            // 
            this.RotXNeg.Location = new System.Drawing.Point(1073, 588);
            this.RotXNeg.Name = "RotXNeg";
            this.RotXNeg.Size = new System.Drawing.Size(48, 48);
            this.RotXNeg.TabIndex = 26;
            this.RotXNeg.Text = "-X";
            this.RotXNeg.UseVisualStyleBackColor = true;
            this.RotXNeg.Click += new System.EventHandler(this.Rotation_Click);
            // 
            // RotXPlus
            // 
            this.RotXPlus.Location = new System.Drawing.Point(1019, 588);
            this.RotXPlus.Name = "RotXPlus";
            this.RotXPlus.Size = new System.Drawing.Size(48, 48);
            this.RotXPlus.TabIndex = 25;
            this.RotXPlus.Text = "+X";
            this.RotXPlus.UseVisualStyleBackColor = true;
            this.RotXPlus.Click += new System.EventHandler(this.Rotation_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(1073, 534);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(48, 48);
            this.button7.TabIndex = 24;
            this.button7.Text = "-Z";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.Rotation_Click);
            // 
            // RotZPlus
            // 
            this.RotZPlus.Location = new System.Drawing.Point(1019, 534);
            this.RotZPlus.Name = "RotZPlus";
            this.RotZPlus.Size = new System.Drawing.Size(48, 48);
            this.RotZPlus.TabIndex = 23;
            this.RotZPlus.Text = "+Z";
            this.RotZPlus.UseVisualStyleBackColor = true;
            this.RotZPlus.Click += new System.EventHandler(this.Rotation_Click);
            // 
            // RefZButton
            // 
            this.RefZButton.Location = new System.Drawing.Point(1100, 49);
            this.RefZButton.Name = "RefZButton";
            this.RefZButton.Size = new System.Drawing.Size(48, 48);
            this.RefZButton.TabIndex = 33;
            this.RefZButton.Text = "Z";
            this.RefZButton.UseVisualStyleBackColor = true;
            this.RefZButton.Click += new System.EventHandler(this.RefButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1029, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 17);
            this.label4.TabIndex = 32;
            this.label4.Text = "Отражение";
            // 
            // RefYButton
            // 
            this.RefYButton.Location = new System.Drawing.Point(1046, 49);
            this.RefYButton.Name = "RefYButton";
            this.RefYButton.Size = new System.Drawing.Size(48, 48);
            this.RefYButton.TabIndex = 31;
            this.RefYButton.Text = "Y";
            this.RefYButton.UseVisualStyleBackColor = true;
            this.RefYButton.Click += new System.EventHandler(this.RefButton_Click);
            // 
            // RefXButton
            // 
            this.RefXButton.Location = new System.Drawing.Point(992, 49);
            this.RefXButton.Name = "RefXButton";
            this.RefXButton.Size = new System.Drawing.Size(48, 48);
            this.RefXButton.TabIndex = 30;
            this.RefXButton.Text = "X";
            this.RefXButton.UseVisualStyleBackColor = true;
            this.RefXButton.Click += new System.EventHandler(this.RefButton_Click);
            // 
            // MoveByLine
            // 
            this.MoveByLine.Location = new System.Drawing.Point(632, 12);
            this.MoveByLine.Name = "MoveByLine";
            this.MoveByLine.Size = new System.Drawing.Size(206, 48);
            this.MoveByLine.TabIndex = 34;
            this.MoveByLine.Text = "Переметсить по прямой (переместите точки А и В)";
            this.MoveByLine.UseVisualStyleBackColor = true;
            this.MoveByLine.Click += new System.EventHandler(this.MoveByLine_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 5;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // labA
            // 
            this.labA.AutoSize = true;
            this.labA.Location = new System.Drawing.Point(876, 28);
            this.labA.Name = "labA";
            this.labA.Size = new System.Drawing.Size(17, 17);
            this.labA.TabIndex = 35;
            this.labA.Text = "A";
            this.labA.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labA_MouseDown);
            this.labA.MouseMove += new System.Windows.Forms.MouseEventHandler(this.labA_MouseMove);
            this.labA.MouseUp += new System.Windows.Forms.MouseEventHandler(this.labA_MouseUp);
            // 
            // labB
            // 
            this.labB.AutoSize = true;
            this.labB.Location = new System.Drawing.Point(908, 28);
            this.labB.Name = "labB";
            this.labB.Size = new System.Drawing.Size(17, 17);
            this.labB.TabIndex = 36;
            this.labB.Text = "B";
            this.labB.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labB_MouseDown);
            this.labB.MouseMove += new System.Windows.Forms.MouseEventHandler(this.labB_MouseMove);
            this.labB.MouseUp += new System.Windows.Forms.MouseEventHandler(this.labB_MouseUp);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(632, 95);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(206, 48);
            this.button3.TabIndex = 37;
            this.button3.Text = "жмяк";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // timer2
            // 
            this.timer2.Interval = 1;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // AffinForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1230, 722);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.labB);
            this.Controls.Add(this.labA);
            this.Controls.Add(this.MoveByLine);
            this.Controls.Add(this.RefZButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.RefYButton);
            this.Controls.Add(this.RefXButton);
            this.Controls.Add(this.RotYIncr);
            this.Controls.Add(this.RotYDecr);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.RotXNeg);
            this.Controls.Add(this.RotXPlus);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.RotZPlus);
            this.Controls.Add(this.DilatIncY);
            this.Controls.Add(this.DilatDecrY);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DilatDecrX);
            this.Controls.Add(this.DilatIncX);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonZSubs);
            this.Controls.Add(this.buttonZAdd);
            this.Controls.Add(this.buttonYSubs);
            this.Controls.Add(this.buttonYAdd);
            this.Controls.Add(this.buttonXSub);
            this.Controls.Add(this.buttonXAdd);
            this.Controls.Add(this.buttonLoad);
            this.DoubleBuffered = true;
            this.Name = "AffinForm";
            this.Text = "Аффинный преобразователь";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button buttonXAdd;
        private System.Windows.Forms.Button buttonXSub;
        private System.Windows.Forms.Button buttonYAdd;
        private System.Windows.Forms.Button buttonYSubs;
        private System.Windows.Forms.Button buttonZAdd;
        private System.Windows.Forms.Button buttonZSubs;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button DilatIncX;
        private System.Windows.Forms.Button DilatDecrX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button DilatDecrY;
        private System.Windows.Forms.Button DilatIncY;
        private System.Windows.Forms.Button RotYIncr;
        private System.Windows.Forms.Button RotYDecr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button RotXNeg;
        private System.Windows.Forms.Button RotXPlus;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button RotZPlus;
        private System.Windows.Forms.Button RefZButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button RefYButton;
        private System.Windows.Forms.Button RefXButton;
        private System.Windows.Forms.Button MoveByLine;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label labA;
        private System.Windows.Forms.Label labB;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Timer timer2;
    }
}

