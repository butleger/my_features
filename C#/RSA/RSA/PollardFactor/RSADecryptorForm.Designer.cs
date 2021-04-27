namespace RSA.PollardFactor
{
    partial class RSADecryptorForm
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
            this.eInput = new System.Windows.Forms.TextBox();
            this.reportOutput = new System.Windows.Forms.RichTextBox();
            this.reportOutputLabel = new System.Windows.Forms.Label();
            this.nInput = new System.Windows.Forms.TextBox();
            this.eInputLabel = new System.Windows.Forms.Label();
            this.nInputLabel = new System.Windows.Forms.Label();
            this.cipheredTextLabel = new System.Windows.Forms.Label();
            this.uncipheredText = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.decryptButton = new System.Windows.Forms.Button();
            this.cipheredText = new System.Windows.Forms.RichTextBox();
            this.qOutputLabel = new System.Windows.Forms.Label();
            this.pOutputLabel = new System.Windows.Forms.Label();
            this.dOutputLabel = new System.Windows.Forms.Label();
            this.qOutput = new System.Windows.Forms.TextBox();
            this.pOutput = new System.Windows.Forms.TextBox();
            this.dOutput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // eInput
            // 
            this.eInput.Location = new System.Drawing.Point(176, 19);
            this.eInput.Name = "eInput";
            this.eInput.Size = new System.Drawing.Size(194, 20);
            this.eInput.TabIndex = 1;
            // 
            // reportOutput
            // 
            this.reportOutput.Location = new System.Drawing.Point(528, 42);
            this.reportOutput.Name = "reportOutput";
            this.reportOutput.Size = new System.Drawing.Size(273, 73);
            this.reportOutput.TabIndex = 3;
            this.reportOutput.Text = "";
            // 
            // reportOutputLabel
            // 
            this.reportOutputLabel.AutoSize = true;
            this.reportOutputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.reportOutputLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.reportOutputLabel.Location = new System.Drawing.Point(635, 14);
            this.reportOutputLabel.Name = "reportOutputLabel";
            this.reportOutputLabel.Size = new System.Drawing.Size(69, 25);
            this.reportOutputLabel.TabIndex = 4;
            this.reportOutputLabel.Text = "Report";
            // 
            // nInput
            // 
            this.nInput.Location = new System.Drawing.Point(176, 47);
            this.nInput.Name = "nInput";
            this.nInput.Size = new System.Drawing.Size(194, 20);
            this.nInput.TabIndex = 6;
            // 
            // eInputLabel
            // 
            this.eInputLabel.AutoSize = true;
            this.eInputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.eInputLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.eInputLabel.Location = new System.Drawing.Point(23, 15);
            this.eInputLabel.Name = "eInputLabel";
            this.eInputLabel.Size = new System.Drawing.Size(147, 25);
            this.eInputLabel.TabIndex = 7;
            this.eInputLabel.Text = "Open exponent";
            // 
            // nInputLabel
            // 
            this.nInputLabel.AutoSize = true;
            this.nInputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nInputLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.nInputLabel.Location = new System.Drawing.Point(23, 42);
            this.nInputLabel.Name = "nInputLabel";
            this.nInputLabel.Size = new System.Drawing.Size(26, 25);
            this.nInputLabel.TabIndex = 8;
            this.nInputLabel.Text = "N";
            // 
            // cipheredTextLabel
            // 
            this.cipheredTextLabel.AutoSize = true;
            this.cipheredTextLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cipheredTextLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.cipheredTextLabel.Location = new System.Drawing.Point(124, 202);
            this.cipheredTextLabel.Name = "cipheredTextLabel";
            this.cipheredTextLabel.Size = new System.Drawing.Size(128, 25);
            this.cipheredTextLabel.TabIndex = 9;
            this.cipheredTextLabel.Text = "Ciphered key";
            // 
            // uncipheredText
            // 
            this.uncipheredText.Location = new System.Drawing.Point(528, 230);
            this.uncipheredText.Name = "uncipheredText";
            this.uncipheredText.Size = new System.Drawing.Size(273, 73);
            this.uncipheredText.TabIndex = 10;
            this.uncipheredText.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(592, 202);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(156, 25);
            this.label4.TabIndex = 11;
            this.label4.Text = "Unciphered Text";
            // 
            // decryptButton
            // 
            this.decryptButton.BackColor = System.Drawing.Color.MediumVioletRed;
            this.decryptButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.decryptButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.decryptButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.decryptButton.Location = new System.Drawing.Point(367, 263);
            this.decryptButton.Name = "decryptButton";
            this.decryptButton.Size = new System.Drawing.Size(105, 40);
            this.decryptButton.TabIndex = 12;
            this.decryptButton.Text = "Decrypt";
            this.decryptButton.UseVisualStyleBackColor = false;
            this.decryptButton.Click += new System.EventHandler(this.decryptButton_Click);
            // 
            // cipheredText
            // 
            this.cipheredText.Location = new System.Drawing.Point(56, 230);
            this.cipheredText.Name = "cipheredText";
            this.cipheredText.Size = new System.Drawing.Size(273, 73);
            this.cipheredText.TabIndex = 13;
            this.cipheredText.Text = "";
            // 
            // qOutputLabel
            // 
            this.qOutputLabel.AutoSize = true;
            this.qOutputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.qOutputLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.qOutputLabel.Location = new System.Drawing.Point(124, 119);
            this.qOutputLabel.Name = "qOutputLabel";
            this.qOutputLabel.Size = new System.Drawing.Size(23, 25);
            this.qOutputLabel.TabIndex = 15;
            this.qOutputLabel.Text = "q";
            // 
            // pOutputLabel
            // 
            this.pOutputLabel.AutoSize = true;
            this.pOutputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pOutputLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.pOutputLabel.Location = new System.Drawing.Point(124, 92);
            this.pOutputLabel.Name = "pOutputLabel";
            this.pOutputLabel.Size = new System.Drawing.Size(23, 25);
            this.pOutputLabel.TabIndex = 14;
            this.pOutputLabel.Text = "p";
            // 
            // dOutputLabel
            // 
            this.dOutputLabel.AutoSize = true;
            this.dOutputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dOutputLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.dOutputLabel.Location = new System.Drawing.Point(124, 144);
            this.dOutputLabel.Name = "dOutputLabel";
            this.dOutputLabel.Size = new System.Drawing.Size(23, 25);
            this.dOutputLabel.TabIndex = 16;
            this.dOutputLabel.Text = "d";
            // 
            // qOutput
            // 
            this.qOutput.Location = new System.Drawing.Point(176, 119);
            this.qOutput.Name = "qOutput";
            this.qOutput.Size = new System.Drawing.Size(194, 20);
            this.qOutput.TabIndex = 18;
            // 
            // pOutput
            // 
            this.pOutput.Location = new System.Drawing.Point(176, 92);
            this.pOutput.Name = "pOutput";
            this.pOutput.Size = new System.Drawing.Size(194, 20);
            this.pOutput.TabIndex = 17;
            // 
            // dOutput
            // 
            this.dOutput.Location = new System.Drawing.Point(176, 146);
            this.dOutput.Name = "dOutput";
            this.dOutput.Size = new System.Drawing.Size(194, 20);
            this.dOutput.TabIndex = 19;
            // 
            // RSADecryptorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(833, 331);
            this.Controls.Add(this.dOutput);
            this.Controls.Add(this.qOutput);
            this.Controls.Add(this.pOutput);
            this.Controls.Add(this.dOutputLabel);
            this.Controls.Add(this.qOutputLabel);
            this.Controls.Add(this.pOutputLabel);
            this.Controls.Add(this.cipheredText);
            this.Controls.Add(this.decryptButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.uncipheredText);
            this.Controls.Add(this.cipheredTextLabel);
            this.Controls.Add(this.nInputLabel);
            this.Controls.Add(this.eInputLabel);
            this.Controls.Add(this.nInput);
            this.Controls.Add(this.reportOutputLabel);
            this.Controls.Add(this.reportOutput);
            this.Controls.Add(this.eInput);
            this.Name = "RSADecryptorForm";
            this.Text = "RSADecryptorForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox eInput;
        private System.Windows.Forms.RichTextBox reportOutput;
        private System.Windows.Forms.Label reportOutputLabel;
        private System.Windows.Forms.TextBox nInput;
        private System.Windows.Forms.Label eInputLabel;
        private System.Windows.Forms.Label nInputLabel;
        private System.Windows.Forms.Label cipheredTextLabel;
        private System.Windows.Forms.RichTextBox uncipheredText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button decryptButton;
        private System.Windows.Forms.RichTextBox cipheredText;
        private System.Windows.Forms.Label qOutputLabel;
        private System.Windows.Forms.Label pOutputLabel;
        private System.Windows.Forms.Label dOutputLabel;
        private System.Windows.Forms.TextBox qOutput;
        private System.Windows.Forms.TextBox pOutput;
        private System.Windows.Forms.TextBox dOutput;
    }
}