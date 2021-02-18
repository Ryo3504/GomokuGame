namespace CaroGame
{
    partial class OptionPvC
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
            this.label1 = new System.Windows.Forms.Label();
            this.AcceptButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.PGFRadioButton = new System.Windows.Forms.RadioButton();
            this.CGFRadioButton = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Teal;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(261, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Who do you want to go \"First\"?";
            // 
            // AcceptButton
            // 
            this.AcceptButton.Location = new System.Drawing.Point(16, 83);
            this.AcceptButton.Name = "AcceptButton";
            this.AcceptButton.Size = new System.Drawing.Size(112, 41);
            this.AcceptButton.TabIndex = 3;
            this.AcceptButton.TabStop = false;
            this.AcceptButton.Text = "Accept";
            this.AcceptButton.UseVisualStyleBackColor = true;
            this.AcceptButton.Click += new System.EventHandler(this.AcceptButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(161, 83);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(112, 41);
            this.CancelButton.TabIndex = 4;
            this.CancelButton.TabStop = false;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // PGFRadioButton
            // 
            this.PGFRadioButton.AutoSize = true;
            this.PGFRadioButton.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PGFRadioButton.ForeColor = System.Drawing.Color.Brown;
            this.PGFRadioButton.Location = new System.Drawing.Point(16, 57);
            this.PGFRadioButton.Name = "PGFRadioButton";
            this.PGFRadioButton.Size = new System.Drawing.Size(126, 20);
            this.PGFRadioButton.TabIndex = 5;
            this.PGFRadioButton.Text = "Player go first";
            this.PGFRadioButton.UseVisualStyleBackColor = true;
            // 
            // CGFRadioButton
            // 
            this.CGFRadioButton.AutoSize = true;
            this.CGFRadioButton.Checked = true;
            this.CGFRadioButton.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CGFRadioButton.ForeColor = System.Drawing.Color.LimeGreen;
            this.CGFRadioButton.Location = new System.Drawing.Point(16, 31);
            this.CGFRadioButton.Name = "CGFRadioButton";
            this.CGFRadioButton.Size = new System.Drawing.Size(114, 20);
            this.CGFRadioButton.TabIndex = 6;
            this.CGFRadioButton.TabStop = true;
            this.CGFRadioButton.Text = "Com go first";
            this.CGFRadioButton.UseVisualStyleBackColor = true;
            // 
            // OptionPvC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(285, 136);
            this.ControlBox = false;
            this.Controls.Add(this.CGFRadioButton);
            this.Controls.Add(this.PGFRadioButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.AcceptButton);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "OptionPvC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Option";
            this.Load += new System.EventHandler(this.OptionPvC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private new System.Windows.Forms.Button CancelButton;
        private new System.Windows.Forms.Button AcceptButton;
        private System.Windows.Forms.RadioButton CGFRadioButton;
        private System.Windows.Forms.RadioButton PGFRadioButton;
    }
}