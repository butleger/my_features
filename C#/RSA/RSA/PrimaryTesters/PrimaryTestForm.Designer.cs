namespace EulerAndFastPower
{
    partial class PrimaryTestForm
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
            this.testPrimeButton = new System.Windows.Forms.Button();
            this.isPrimeLabel = new System.Windows.Forms.Label();
            this.numberInput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // testPrimeButton
            // 
            this.testPrimeButton.BackColor = System.Drawing.Color.ForestGreen;
            this.testPrimeButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.testPrimeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.testPrimeButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.testPrimeButton.Location = new System.Drawing.Point(148, 70);
            this.testPrimeButton.Name = "testPrimeButton";
            this.testPrimeButton.Size = new System.Drawing.Size(108, 36);
            this.testPrimeButton.TabIndex = 0;
            this.testPrimeButton.Text = "Test Number";
            this.testPrimeButton.UseVisualStyleBackColor = false;
            this.testPrimeButton.Click += new System.EventHandler(this.testPrimeButton_Click);
            // 
            // isPrimeLabel
            // 
            this.isPrimeLabel.AutoSize = true;
            this.isPrimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.isPrimeLabel.Location = new System.Drawing.Point(210, 29);
            this.isPrimeLabel.Name = "isPrimeLabel";
            this.isPrimeLabel.Size = new System.Drawing.Size(0, 17);
            this.isPrimeLabel.TabIndex = 1;
            // 
            // numberInput
            // 
            this.numberInput.Location = new System.Drawing.Point(12, 26);
            this.numberInput.Name = "numberInput";
            this.numberInput.Size = new System.Drawing.Size(161, 20);
            this.numberInput.TabIndex = 2;
            // 
            // PrimaryTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(417, 116);
            this.Controls.Add(this.numberInput);
            this.Controls.Add(this.isPrimeLabel);
            this.Controls.Add(this.testPrimeButton);
            this.Name = "PrimaryTestForm";
            this.Text = "Primary Test";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button testPrimeButton;
        private System.Windows.Forms.Label isPrimeLabel;
        private System.Windows.Forms.TextBox numberInput;
    }
}