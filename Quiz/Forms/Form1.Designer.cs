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
            SuspendLayout();
            // 
            // lblTimer
            // 
            lblTimer.AutoSize = true;
            lblTimer.Location = new Point(1286, 125);
            lblTimer.Name = "lblTimer";
            lblTimer.Size = new Size(59, 25);
            lblTimer.TabIndex = 1;
            lblTimer.Text = "label1";
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // lblQuestion
            // 
            lblQuestion.AutoSize = true;
            lblQuestion.Location = new Point(273, 67);
            lblQuestion.Name = "lblQuestion";
            lblQuestion.Size = new Size(59, 25);
            lblQuestion.TabIndex = 2;
            lblQuestion.Text = "label1";
            // 
            // btnShowAnswer
            // 
            btnShowAnswer.Location = new Point(319, 362);
            btnShowAnswer.Name = "btnShowAnswer";
            btnShowAnswer.Size = new Size(154, 34);
            btnShowAnswer.TabIndex = 3;
            btnShowAnswer.Text = "Show Answer";
            btnShowAnswer.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            btnNext.Location = new Point(881, 402);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(112, 34);
            btnNext.TabIndex = 4;
            btnNext.Text = "Next";
            btnNext.UseVisualStyleBackColor = true;
            // 
            // lblOptionA
            // 
            lblOptionA.AutoSize = true;
            lblOptionA.Location = new Point(343, 227);
            lblOptionA.Name = "lblOptionA";
            lblOptionA.Size = new Size(24, 25);
            lblOptionA.TabIndex = 5;
            lblOptionA.Text = "A";
            // 
            // lblOptionB
            // 
            lblOptionB.AutoSize = true;
            lblOptionB.Location = new Point(561, 227);
            lblOptionB.Name = "lblOptionB";
            lblOptionB.Size = new Size(22, 25);
            lblOptionB.TabIndex = 6;
            lblOptionB.Text = "B";
            // 
            // lblOptionC
            // 
            lblOptionC.AutoSize = true;
            lblOptionC.Location = new Point(730, 229);
            lblOptionC.Name = "lblOptionC";
            lblOptionC.Size = new Size(23, 25);
            lblOptionC.TabIndex = 7;
            lblOptionC.Text = "C";
            // 
            // lblOptionD
            // 
            lblOptionD.AutoSize = true;
            lblOptionD.Location = new Point(917, 230);
            lblOptionD.Name = "lblOptionD";
            lblOptionD.Size = new Size(25, 25);
            lblOptionD.TabIndex = 8;
            lblOptionD.Text = "D";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1489, 595);
            Controls.Add(lblOptionD);
            Controls.Add(lblOptionC);
            Controls.Add(lblOptionB);
            Controls.Add(lblOptionA);
            Controls.Add(btnNext);
            Controls.Add(btnShowAnswer);
            Controls.Add(lblQuestion);
            Controls.Add(lblTimer);
            Name = "Form1";
            Text = "Form1";
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
    }
}
