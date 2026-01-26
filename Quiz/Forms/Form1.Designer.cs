namespace Quiz
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblTimer = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            lblQuestion = new Label();
            btnShowAnswer = new Button();
            btnNext = new Button();
            lblOptionA = new Label();
            lblOptionB = new Label();
            lblOptionC = new Label();
            lblOptionD = new Label();
            pictureBox1 = new PictureBox();
            pbTimer = new ProgressBar();
            btnStop = new Button();
            lblCorrectAnswer = new Label();
            btnJetpot = new Button();
            panelWelcome = new Panel();
            btnStartQuiz = new Button();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelWelcome.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // lblTimer
            // 
            lblTimer.AutoSize = true;
            lblTimer.Font = new Font("MS Reference Sans Serif", 48F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTimer.Location = new Point(1558, 792);
            lblTimer.Name = "lblTimer";
            lblTimer.Size = new Size(306, 118);
            lblTimer.TabIndex = 1;
            lblTimer.Text = "timer";
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // lblQuestion
            // 
            lblQuestion.AutoSize = true;
            lblQuestion.Font = new Font("Arial Narrow", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblQuestion.Location = new Point(342, 49);
            lblQuestion.Name = "lblQuestion";
            lblQuestion.Size = new Size(184, 57);
            lblQuestion.TabIndex = 2;
            lblQuestion.Text = "Question";
            // 
            // btnShowAnswer
            // 
            btnShowAnswer.Location = new Point(334, 948);
            btnShowAnswer.Name = "btnShowAnswer";
            btnShowAnswer.Size = new Size(167, 53);
            btnShowAnswer.TabIndex = 3;
            btnShowAnswer.Text = "Show Answer";
            btnShowAnswer.UseVisualStyleBackColor = true;
            btnShowAnswer.Click += btnShowAnswer_Click;
            // 
            // btnNext
            // 
            btnNext.Location = new Point(613, 948);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(134, 53);
            btnNext.TabIndex = 4;
            btnNext.Text = "Next";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // lblOptionA
            // 
            lblOptionA.AutoSize = true;
            lblOptionA.Font = new Font("Arial Narrow", 24F);
            lblOptionA.Location = new Point(344, 369);
            lblOptionA.Name = "lblOptionA";
            lblOptionA.Size = new Size(51, 57);
            lblOptionA.TabIndex = 5;
            lblOptionA.Text = "A";
            // 
            // lblOptionB
            // 
            lblOptionB.AutoSize = true;
            lblOptionB.Font = new Font("Arial Narrow", 24F);
            lblOptionB.Location = new Point(344, 518);
            lblOptionB.Name = "lblOptionB";
            lblOptionB.Size = new Size(51, 57);
            lblOptionB.TabIndex = 6;
            lblOptionB.Text = "B";
            // 
            // lblOptionC
            // 
            lblOptionC.AutoSize = true;
            lblOptionC.Font = new Font("Arial Narrow", 24F);
            lblOptionC.Location = new Point(342, 660);
            lblOptionC.Name = "lblOptionC";
            lblOptionC.Size = new Size(53, 57);
            lblOptionC.TabIndex = 7;
            lblOptionC.Text = "C";
            // 
            // lblOptionD
            // 
            lblOptionD.AutoSize = true;
            lblOptionD.Font = new Font("Arial Narrow", 24F);
            lblOptionD.Location = new Point(342, 792);
            lblOptionD.Name = "lblOptionD";
            lblOptionD.Size = new Size(53, 57);
            lblOptionD.TabIndex = 8;
            lblOptionD.Text = "D";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.mst_logo_png;
            pictureBox1.Location = new Point(12, 17);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(294, 359);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // pbTimer
            // 
            pbTimer.Location = new Point(1541, 948);
            pbTimer.Maximum = 60;
            pbTimer.Name = "pbTimer";
            pbTimer.Size = new Size(323, 49);
            pbTimer.Style = ProgressBarStyle.Continuous;
            pbTimer.TabIndex = 10;
            pbTimer.Value = 60;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(872, 948);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(134, 53);
            btnStop.TabIndex = 11;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // lblCorrectAnswer
            // 
            lblCorrectAnswer.AutoSize = true;
            lblCorrectAnswer.Font = new Font("Arial Narrow", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCorrectAnswer.Location = new Point(680, 323);
            lblCorrectAnswer.Name = "lblCorrectAnswer";
            lblCorrectAnswer.Size = new Size(444, 83);
            lblCorrectAnswer.TabIndex = 12;
            lblCorrectAnswer.Text = "Correct Answer";
            // 
            // btnJetpot
            // 
            btnJetpot.Enabled = false;
            btnJetpot.Location = new Point(1092, 948);
            btnJetpot.Name = "btnJetpot";
            btnJetpot.Size = new Size(175, 53);
            btnJetpot.TabIndex = 13;
            btnJetpot.Text = "Jetpot Question";
            btnJetpot.UseVisualStyleBackColor = true;
            // 
            // panelWelcome
            // 
            panelWelcome.Controls.Add(btnStartQuiz);
            panelWelcome.Controls.Add(pictureBox2);
            panelWelcome.Dock = DockStyle.Fill;
            panelWelcome.Location = new Point(0, 0);
            panelWelcome.Name = "panelWelcome";
            panelWelcome.Size = new Size(1910, 1071);
            panelWelcome.TabIndex = 16;
            // 
            // btnStartQuiz
            // 
            btnStartQuiz.Location = new Point(843, 845);
            btnStartQuiz.Name = "btnStartQuiz";
            btnStartQuiz.Size = new Size(200, 61);
            btnStartQuiz.TabIndex = 1;
            btnStartQuiz.Text = "Start Quiz";
            btnStartQuiz.UseVisualStyleBackColor = true;
            btnStartQuiz.Click += btnStartQuiz_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.home;
            pictureBox2.Location = new Point(0, 0);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(1920, 1080);
            pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(1910, 1071);
            Controls.Add(panelWelcome);
            Controls.Add(btnJetpot);
            Controls.Add(lblCorrectAnswer);
            Controls.Add(btnStop);
            Controls.Add(pbTimer);
            Controls.Add(pictureBox1);
            Controls.Add(lblOptionD);
            Controls.Add(lblOptionC);
            Controls.Add(lblOptionB);
            Controls.Add(lblOptionA);
            Controls.Add(btnNext);
            Controls.Add(btnShowAnswer);
            Controls.Add(lblQuestion);
            Controls.Add(lblTimer);
            Name = "Form1";
            Text = "M.S.T College Quiz";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelWelcome.ResumeLayout(false);
            panelWelcome.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblTimer;
        private System.Windows.Forms.Timer timer1;
        private Label lblQuestion;
        private Button btnShowAnswer;
        private Button btnNext;
        private Label lblOptionA;
        private Label lblOptionB;
        private Label lblOptionC;
        private Label lblOptionD;
        private PictureBox pictureBox1;
        private ProgressBar pbTimer;
        private Button btnStop;
        private Label lblCorrectAnswer;
        private Button btnJetpot;
        private Panel panelWelcome;
        private Button btnStartQuiz;
        private PictureBox pictureBox2;
    }
}
