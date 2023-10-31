namespace FlowTimeConverter
{
    partial class Tools
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.FrameToMSBox = new System.Windows.Forms.NumericUpDown();
            this.ConsoleSelection = new System.Windows.Forms.ComboBox();
            this.ConsoleLabel = new System.Windows.Forms.Label();
            this.FramesLabel = new System.Windows.Forms.Label();
            this.FrameMSGroupBox = new System.Windows.Forms.GroupBox();
            this.MSToFramesGroupBox = new System.Windows.Forms.GroupBox();
            this.MStoFrameLabel = new System.Windows.Forms.Label();
            this.MStoFrameBox = new System.Windows.Forms.NumericUpDown();
            this.FrameMSCalcButton = new System.Windows.Forms.Button();
            this.MStoFrameCalcButton = new System.Windows.Forms.Button();
            this.FrameMSOutBox = new System.Windows.Forms.TextBox();
            this.MSFrameOutBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.FrameToMSBox)).BeginInit();
            this.FrameMSGroupBox.SuspendLayout();
            this.MSToFramesGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MStoFrameBox)).BeginInit();
            this.SuspendLayout();
            // 
            // FrameToMSBox
            // 
            this.FrameToMSBox.Location = new System.Drawing.Point(9, 51);
            this.FrameToMSBox.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.FrameToMSBox.Name = "FrameToMSBox";
            this.FrameToMSBox.Size = new System.Drawing.Size(121, 20);
            this.FrameToMSBox.TabIndex = 0;
            // 
            // ConsoleSelection
            // 
            this.ConsoleSelection.FormattingEnabled = true;
            this.ConsoleSelection.Items.AddRange(new object[] {
            "GBA",
            "NDS",
            "New 3DS",
            "Old 3DS",
            "60 FPS"});
            this.ConsoleSelection.Location = new System.Drawing.Point(99, 25);
            this.ConsoleSelection.Name = "ConsoleSelection";
            this.ConsoleSelection.Size = new System.Drawing.Size(121, 21);
            this.ConsoleSelection.TabIndex = 1;
            this.ConsoleSelection.SelectionChangeCommitted += new System.EventHandler(this.ConsoleSelection_SelectionChangeCommitted);
            // 
            // ConsoleLabel
            // 
            this.ConsoleLabel.AutoSize = true;
            this.ConsoleLabel.Location = new System.Drawing.Point(136, 9);
            this.ConsoleLabel.Name = "ConsoleLabel";
            this.ConsoleLabel.Size = new System.Drawing.Size(45, 13);
            this.ConsoleLabel.TabIndex = 2;
            this.ConsoleLabel.Text = "Console";
            // 
            // FramesLabel
            // 
            this.FramesLabel.AutoSize = true;
            this.FramesLabel.Location = new System.Drawing.Point(6, 35);
            this.FramesLabel.Name = "FramesLabel";
            this.FramesLabel.Size = new System.Drawing.Size(41, 13);
            this.FramesLabel.TabIndex = 3;
            this.FramesLabel.Text = "Frames";
            // 
            // FrameMSGroupBox
            // 
            this.FrameMSGroupBox.Controls.Add(this.FrameMSOutBox);
            this.FrameMSGroupBox.Controls.Add(this.FrameMSCalcButton);
            this.FrameMSGroupBox.Controls.Add(this.FramesLabel);
            this.FrameMSGroupBox.Controls.Add(this.FrameToMSBox);
            this.FrameMSGroupBox.Location = new System.Drawing.Point(18, 61);
            this.FrameMSGroupBox.Name = "FrameMSGroupBox";
            this.FrameMSGroupBox.Size = new System.Drawing.Size(140, 142);
            this.FrameMSGroupBox.TabIndex = 4;
            this.FrameMSGroupBox.TabStop = false;
            this.FrameMSGroupBox.Text = "Frame to MS";
            // 
            // MSToFramesGroupBox
            // 
            this.MSToFramesGroupBox.Controls.Add(this.MSFrameOutBox);
            this.MSToFramesGroupBox.Controls.Add(this.MStoFrameCalcButton);
            this.MSToFramesGroupBox.Controls.Add(this.MStoFrameLabel);
            this.MSToFramesGroupBox.Controls.Add(this.MStoFrameBox);
            this.MSToFramesGroupBox.Location = new System.Drawing.Point(164, 61);
            this.MSToFramesGroupBox.Name = "MSToFramesGroupBox";
            this.MSToFramesGroupBox.Size = new System.Drawing.Size(140, 142);
            this.MSToFramesGroupBox.TabIndex = 5;
            this.MSToFramesGroupBox.TabStop = false;
            this.MSToFramesGroupBox.Text = "MS to Frame";
            // 
            // MStoFrameLabel
            // 
            this.MStoFrameLabel.AutoSize = true;
            this.MStoFrameLabel.Location = new System.Drawing.Point(3, 35);
            this.MStoFrameLabel.Name = "MStoFrameLabel";
            this.MStoFrameLabel.Size = new System.Drawing.Size(62, 13);
            this.MStoFrameLabel.TabIndex = 3;
            this.MStoFrameLabel.Text = "Miliseconds";
            // 
            // MStoFrameBox
            // 
            this.MStoFrameBox.Location = new System.Drawing.Point(6, 51);
            this.MStoFrameBox.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.MStoFrameBox.Name = "MStoFrameBox";
            this.MStoFrameBox.Size = new System.Drawing.Size(121, 20);
            this.MStoFrameBox.TabIndex = 0;
            // 
            // FrameMSCalcButton
            // 
            this.FrameMSCalcButton.Location = new System.Drawing.Point(9, 77);
            this.FrameMSCalcButton.Name = "FrameMSCalcButton";
            this.FrameMSCalcButton.Size = new System.Drawing.Size(121, 23);
            this.FrameMSCalcButton.TabIndex = 4;
            this.FrameMSCalcButton.Text = "Calculate";
            this.FrameMSCalcButton.UseVisualStyleBackColor = true;
            this.FrameMSCalcButton.Click += new System.EventHandler(this.FrameMSCalcButton_Click);
            // 
            // MStoFrameCalcButton
            // 
            this.MStoFrameCalcButton.Location = new System.Drawing.Point(6, 77);
            this.MStoFrameCalcButton.Name = "MStoFrameCalcButton";
            this.MStoFrameCalcButton.Size = new System.Drawing.Size(121, 23);
            this.MStoFrameCalcButton.TabIndex = 5;
            this.MStoFrameCalcButton.Text = "Calculate";
            this.MStoFrameCalcButton.UseVisualStyleBackColor = true;
            this.MStoFrameCalcButton.Click += new System.EventHandler(this.MStoFrameCalcButton_Click);
            // 
            // FrameMSOutBox
            // 
            this.FrameMSOutBox.Location = new System.Drawing.Point(9, 107);
            this.FrameMSOutBox.Name = "FrameMSOutBox";
            this.FrameMSOutBox.Size = new System.Drawing.Size(121, 20);
            this.FrameMSOutBox.TabIndex = 5;
            // 
            // MSFrameOutBox
            // 
            this.MSFrameOutBox.Location = new System.Drawing.Point(6, 106);
            this.MSFrameOutBox.Name = "MSFrameOutBox";
            this.MSFrameOutBox.Size = new System.Drawing.Size(121, 20);
            this.MSFrameOutBox.TabIndex = 6;
            // 
            // Tools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 213);
            this.Controls.Add(this.MSToFramesGroupBox);
            this.Controls.Add(this.ConsoleSelection);
            this.Controls.Add(this.FrameMSGroupBox);
            this.Controls.Add(this.ConsoleLabel);
            this.Name = "Tools";
            this.Text = "Tools";
            this.Load += new System.EventHandler(this.Tools_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FrameToMSBox)).EndInit();
            this.FrameMSGroupBox.ResumeLayout(false);
            this.FrameMSGroupBox.PerformLayout();
            this.MSToFramesGroupBox.ResumeLayout(false);
            this.MSToFramesGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MStoFrameBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown FrameToMSBox;
        private System.Windows.Forms.ComboBox ConsoleSelection;
        private System.Windows.Forms.Label ConsoleLabel;
        private System.Windows.Forms.Label FramesLabel;
        private System.Windows.Forms.GroupBox FrameMSGroupBox;
        private System.Windows.Forms.GroupBox MSToFramesGroupBox;
        private System.Windows.Forms.Label MStoFrameLabel;
        private System.Windows.Forms.NumericUpDown MStoFrameBox;
        private System.Windows.Forms.TextBox FrameMSOutBox;
        private System.Windows.Forms.Button FrameMSCalcButton;
        private System.Windows.Forms.TextBox MSFrameOutBox;
        private System.Windows.Forms.Button MStoFrameCalcButton;
    }
}