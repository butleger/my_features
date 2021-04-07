namespace EulerAndFastPower
{
    partial class GeneratePrimeForm
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
            this.generatePrimeButton = new System.Windows.Forms.Button();
            this.bitsNumberLabel = new System.Windows.Forms.Label();
            this.bitsNumberInput = new System.Windows.Forms.TextBox();
            this.primeNumberOut = new System.Windows.Forms.RichTextBox();
            this.primeNumberOutLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // generatePrimeButton
            // 
            this.generatePrimeButton.BackColor = System.Drawing.Color.Teal;
            this.generatePrimeButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.generatePrimeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.generatePrimeButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.generatePrimeButton.Location = new System.Drawing.Point(49, 100);
            this.generatePrimeButton.Name = "generatePrimeButton";
            this.generatePrimeButton.Size = new System.Drawing.Size(162, 57);
            this.generatePrimeButton.TabIndex = 0;
            this.generatePrimeButton.Text = "Generate Prime Number";
            this.generatePrimeButton.UseVisualStyleBackColor = false;
            this.generatePrimeButton.Click += new System.EventHandler(this.generatePrimeButton_Click);
            // 
            // bitsNumberLabel
            // 
            this.bitsNumberLabel.AutoSize = true;
            this.bitsNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bitsNumberLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.bitsNumberLabel.Location = new System.Drawing.Point(79, 44);
            this.bitsNumberLabel.Name = "bitsNumberLabel";
            this.bitsNumberLabel.Size = new System.Drawing.Size(100, 17);
            this.bitsNumberLabel.TabIndex = 1;
            this.bitsNumberLabel.Text = "Number of bits";
            // 
            // bitsNumberInput
            // 
            this.bitsNumberInput.Location = new System.Drawing.Point(49, 64);
            this.bitsNumberInput.Name = "bitsNumberInput";
            this.bitsNumberInput.Size = new System.Drawing.Size(161, 20);
            this.bitsNumberInput.TabIndex = 2;
            // 
            // primeNumberOut
            // 
            this.primeNumberOut.Location = new System.Drawing.Point(251, 43);
            this.primeNumberOut.Name = "primeNumberOut";
            this.primeNumberOut.Size = new System.Drawing.Size(420, 113);
            this.primeNumberOut.TabIndex = 3;
            this.primeNumberOut.Text = "";
            // 
            // primeNumberOutLabel
            // 
            this.primeNumberOutLabel.AutoSize = true;
            this.primeNumberOutLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.primeNumberOutLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.primeNumberOutLabel.Location = new System.Drawing.Point(398, 20);
            this.primeNumberOutLabel.Name = "primeNumberOutLabel";
            this.primeNumberOutLabel.Size = new System.Drawing.Size(109, 20);
            this.primeNumberOutLabel.TabIndex = 4;
            this.primeNumberOutLabel.Text = "Prime Number";
            // 
            // GeneratePrimeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(714, 185);
            this.Controls.Add(this.primeNumberOutLabel);
            this.Controls.Add(this.primeNumberOut);
            this.Controls.Add(this.bitsNumberInput);
            this.Controls.Add(this.bitsNumberLabel);
            this.Controls.Add(this.generatePrimeButton);
            this.Name = "GeneratePrimeForm";
            this.Text = "GeneratePrime";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button generatePrimeButton;
        private System.Windows.Forms.Label bitsNumberLabel;
        private System.Windows.Forms.TextBox bitsNumberInput;
        private System.Windows.Forms.RichTextBox primeNumberOut;
        private System.Windows.Forms.Label primeNumberOutLabel;
    }
}