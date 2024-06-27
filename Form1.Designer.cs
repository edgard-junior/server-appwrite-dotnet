using System.Windows.Forms;

namespace SDKAppWrite
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
            lstDataBase = new CheckedListBox();
            button1 = new Button();
            pnlTop = new Panel();
            label1 = new Label();
            progressBar1 = new ProgressBar();
            button2 = new Button();
            pnlTop.SuspendLayout();
            SuspendLayout();
            // 
            // lstDataBase
            // 
            lstDataBase.FormattingEnabled = true;
            lstDataBase.Location = new Point(1, 110);
            lstDataBase.Name = "lstDataBase";
            lstDataBase.Size = new Size(712, 418);
            lstDataBase.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(613, 529);
            button1.Name = "button1";
            button1.Size = new Size(99, 33);
            button1.TabIndex = 1;
            button1.Text = "Update";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Button1_Click;
            // 
            // pnlTop
            // 
            pnlTop.BackColor = SystemColors.ControlDark;
            pnlTop.Controls.Add(label1);
            pnlTop.Font = new Font("Arial", 8.25F);
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(724, 41);
            pnlTop.TabIndex = 2;
            pnlTop.TabStop = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 16F, FontStyle.Bold);
            label1.ForeColor = SystemColors.ControlText;
            label1.Location = new Point(243, 9);
            label1.Name = "label1";
            label1.Size = new Size(301, 26);
            label1.TabIndex = 0;
            label1.Text = "Update DataBases AppWrite";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(1, 534);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(586, 23);
            progressBar1.TabIndex = 3;
            // 
            // button2
            // 
            button2.Location = new Point(1, 58);
            button2.Name = "button2";
            button2.Size = new Size(99, 33);
            button2.TabIndex = 4;
            button2.Tag = "0";
            button2.Text = "CheckedAll";
            button2.UseVisualStyleBackColor = true;
            button2.Click += Button2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(724, 574);
            Controls.Add(button2);
            Controls.Add(progressBar1);
            Controls.Add(pnlTop);
            Controls.Add(button1);
            Controls.Add(lstDataBase);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            Text = "SDK AppWrite";
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private CheckedListBox lstDataBase;
        private Button button1;
        private Panel pnlTop;
        private Label label1;
        private ProgressBar progressBar1;
        private Button button2;
    }
}
