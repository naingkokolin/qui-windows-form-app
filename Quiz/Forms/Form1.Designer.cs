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
            panelBlank = new Panel();
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
            // lblQuestion
            // 
            lblQuestion.AutoSize = true;
            lblQuestion.Location = new Point(273, 67);
            lblQuestion.Name = "lblQuestion";
            lblQuestion.Size = new Size(59, 25);
            lblQuestion.TabIndex = 2;
            lblQuestion.Text = "label1";
            // 
            // panelBlank
            // 
            panelBlank.BackColor = SystemColors.ActiveCaptionText;
            panelBlank.Location = new Point(312, 212);
            panelBlank.Name = "panelBlank";
            panelBlank.Size = new Size(725, 213);
            panelBlank.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1489, 595);
            Controls.Add(panelBlank);
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
        private Panel panelBlank;
    }
}
