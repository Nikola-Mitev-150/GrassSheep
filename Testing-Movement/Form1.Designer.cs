namespace Testing_Movement
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
            SheepTimer = new System.Windows.Forms.Timer(components);
            label1 = new Label();
            ReTimer = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // SheepTimer
            // 
            SheepTimer.Enabled = true;
            SheepTimer.Interval = 20;
            SheepTimer.Tick += SheepTimer_Tick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 548);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 0;
            label1.Text = "label1";
            // 
            // ReTimer
            // 
            ReTimer.Enabled = true;
            ReTimer.Interval = 1000;
            ReTimer.Tick += ReTimeEvent;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1924, 81);
            Controls.Add(label1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Movement Test";
            Load += Form1_Load;
            Paint += PaintEvent;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer SheepTimer;
        private Label label1;
        private System.Windows.Forms.Timer ReTimer;
    }
}
