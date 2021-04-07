namespace EulerAndFastPower.EratostheneSieve
{
    partial class EratostheneSieveForm
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
            this.findPrimesButton = new System.Windows.Forms.Button();
            this.maxNumberInputLabel = new System.Windows.Forms.Label();
            this.primeNumbersOutput = new System.Windows.Forms.RichTextBox();
            this.maxNumberInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // findPrimesButton
            // 
            this.findPrimesButton.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.findPrimesButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.findPrimesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.findPrimesButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.findPrimesButton.Location = new System.Drawing.Point(283, 41);
            this.findPrimesButton.Name = "findPrimesButton";
            this.findPrimesButton.Size = new System.Drawing.Size(101, 36);
            this.findPrimesButton.TabIndex = 0;
            this.findPrimesButton.Text = "Find Primes";
            this.findPrimesButton.UseVisualStyleBackColor = false;
            this.findPrimesButton.Click += new System.EventHandler(this.findPrimesButton_Click);
            // 
            // maxNumberInputLabel
            // 
            this.maxNumberInputLabel.AutoSize = true;
            this.maxNumberInputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.maxNumberInputLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.maxNumberInputLabel.Location = new System.Drawing.Point(45, 32);
            this.maxNumberInputLabel.Name = "maxNumberInputLabel";
            this.maxNumberInputLabel.Size = new System.Drawing.Size(136, 15);
            this.maxNumberInputLabel.TabIndex = 1;
            this.maxNumberInputLabel.Text = "Upper bound for search";
            // 
            // primeNumbersOutput
            // 
            this.primeNumbersOutput.Location = new System.Drawing.Point(48, 116);
            this.primeNumbersOutput.Name = "primeNumbersOutput";
            this.primeNumbersOutput.Size = new System.Drawing.Size(336, 151);
            this.primeNumbersOutput.TabIndex = 2;
            this.primeNumbersOutput.Text = "";
            // 
            // maxNumberInput
            // 
            this.maxNumberInput.Location = new System.Drawing.Point(48, 50);
            this.maxNumberInput.Name = "maxNumberInput";
            this.maxNumberInput.Size = new System.Drawing.Size(133, 20);
            this.maxNumberInput.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(151, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Your prime numbers";
            // 
            // EratostheneSieveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(445, 303);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.maxNumberInput);
            this.Controls.Add(this.primeNumbersOutput);
            this.Controls.Add(this.maxNumberInputLabel);
            this.Controls.Add(this.findPrimesButton);
            this.Name = "EratostheneSieveForm";
            this.Text = "EratosheneSieve";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button findPrimesButton;
        private System.Windows.Forms.Label maxNumberInputLabel;
        private System.Windows.Forms.RichTextBox primeNumbersOutput;
        private System.Windows.Forms.TextBox maxNumberInput;
        private System.Windows.Forms.Label label2;
    }
}