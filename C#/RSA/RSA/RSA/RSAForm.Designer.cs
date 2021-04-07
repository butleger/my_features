namespace EulerAndFastPower.RSA
{
    partial class RSAForm
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
            this.pLabel = new System.Windows.Forms.Label();
            this.pIO = new System.Windows.Forms.RichTextBox();
            this.generateKeysButton = new System.Windows.Forms.Button();
            this.qIO = new System.Windows.Forms.RichTextBox();
            this.qLabel = new System.Windows.Forms.Label();
            this.eulerFunctionOutput = new System.Windows.Forms.RichTextBox();
            this.eulerFunctionLabel = new System.Windows.Forms.Label();
            this.NOutput = new System.Windows.Forms.RichTextBox();
            this.NLabel = new System.Windows.Forms.Label();
            this.eOutput = new System.Windows.Forms.RichTextBox();
            this.eLabel = new System.Windows.Forms.Label();
            this.dOutput = new System.Windows.Forms.RichTextBox();
            this.dLabel = new System.Windows.Forms.Label();
            this.uncipheredTextIO = new System.Windows.Forms.RichTextBox();
            this.uncipheredTextLabel = new System.Windows.Forms.Label();
            this.cipheredTextIO = new System.Windows.Forms.RichTextBox();
            this.cipheredTextLabel = new System.Windows.Forms.Label();
            this.cipherButton = new System.Windows.Forms.Button();
            this.uncipherButton = new System.Windows.Forms.Button();
            this.numberOfBitsLabel = new System.Windows.Forms.Label();
            this.keyLengthInput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // pLabel
            // 
            this.pLabel.AutoSize = true;
            this.pLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.pLabel.Location = new System.Drawing.Point(22, 28);
            this.pLabel.Name = "pLabel";
            this.pLabel.Size = new System.Drawing.Size(18, 20);
            this.pLabel.TabIndex = 0;
            this.pLabel.Text = "p";
            // 
            // pIO
            // 
            this.pIO.Location = new System.Drawing.Point(61, 30);
            this.pIO.Name = "pIO";
            this.pIO.Size = new System.Drawing.Size(552, 27);
            this.pIO.TabIndex = 1;
            this.pIO.Text = "";
            // 
            // generateKeysButton
            // 
            this.generateKeysButton.BackColor = System.Drawing.Color.Purple;
            this.generateKeysButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.generateKeysButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.generateKeysButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.generateKeysButton.Location = new System.Drawing.Point(663, 28);
            this.generateKeysButton.Name = "generateKeysButton";
            this.generateKeysButton.Size = new System.Drawing.Size(76, 60);
            this.generateKeysButton.TabIndex = 2;
            this.generateKeysButton.Text = "Generate Keys";
            this.generateKeysButton.UseVisualStyleBackColor = false;
            this.generateKeysButton.Click += new System.EventHandler(this.generateKeysButton_Click);
            // 
            // qIO
            // 
            this.qIO.Location = new System.Drawing.Point(61, 63);
            this.qIO.Name = "qIO";
            this.qIO.Size = new System.Drawing.Size(552, 27);
            this.qIO.TabIndex = 4;
            this.qIO.Text = "";
            // 
            // qLabel
            // 
            this.qLabel.AutoSize = true;
            this.qLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.qLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.qLabel.Location = new System.Drawing.Point(22, 61);
            this.qLabel.Name = "qLabel";
            this.qLabel.Size = new System.Drawing.Size(18, 20);
            this.qLabel.TabIndex = 3;
            this.qLabel.Text = "q";
            // 
            // eulerFunctionOutput
            // 
            this.eulerFunctionOutput.Location = new System.Drawing.Point(61, 154);
            this.eulerFunctionOutput.Name = "eulerFunctionOutput";
            this.eulerFunctionOutput.Size = new System.Drawing.Size(552, 27);
            this.eulerFunctionOutput.TabIndex = 8;
            this.eulerFunctionOutput.Text = "";
            // 
            // eulerFunctionLabel
            // 
            this.eulerFunctionLabel.AutoSize = true;
            this.eulerFunctionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.eulerFunctionLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.eulerFunctionLabel.Location = new System.Drawing.Point(22, 152);
            this.eulerFunctionLabel.Name = "eulerFunctionLabel";
            this.eulerFunctionLabel.Size = new System.Drawing.Size(35, 20);
            this.eulerFunctionLabel.TabIndex = 7;
            this.eulerFunctionLabel.Text = "f(N)";
            // 
            // NOutput
            // 
            this.NOutput.Location = new System.Drawing.Point(61, 121);
            this.NOutput.Name = "NOutput";
            this.NOutput.Size = new System.Drawing.Size(552, 27);
            this.NOutput.TabIndex = 6;
            this.NOutput.Text = "";
            // 
            // NLabel
            // 
            this.NLabel.AutoSize = true;
            this.NLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.NLabel.Location = new System.Drawing.Point(22, 119);
            this.NLabel.Name = "NLabel";
            this.NLabel.Size = new System.Drawing.Size(20, 20);
            this.NLabel.TabIndex = 5;
            this.NLabel.Text = "N";
            // 
            // eOutput
            // 
            this.eOutput.Location = new System.Drawing.Point(61, 187);
            this.eOutput.Name = "eOutput";
            this.eOutput.Size = new System.Drawing.Size(552, 27);
            this.eOutput.TabIndex = 10;
            this.eOutput.Text = "";
            // 
            // eLabel
            // 
            this.eLabel.AutoSize = true;
            this.eLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.eLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.eLabel.Location = new System.Drawing.Point(22, 185);
            this.eLabel.Name = "eLabel";
            this.eLabel.Size = new System.Drawing.Size(18, 20);
            this.eLabel.TabIndex = 9;
            this.eLabel.Text = "e";
            // 
            // dOutput
            // 
            this.dOutput.Location = new System.Drawing.Point(61, 220);
            this.dOutput.Name = "dOutput";
            this.dOutput.Size = new System.Drawing.Size(552, 27);
            this.dOutput.TabIndex = 12;
            this.dOutput.Text = "";
            // 
            // dLabel
            // 
            this.dLabel.AutoSize = true;
            this.dLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.dLabel.Location = new System.Drawing.Point(22, 218);
            this.dLabel.Name = "dLabel";
            this.dLabel.Size = new System.Drawing.Size(18, 20);
            this.dLabel.TabIndex = 11;
            this.dLabel.Text = "d";
            // 
            // uncipheredTextIO
            // 
            this.uncipheredTextIO.Location = new System.Drawing.Point(50, 307);
            this.uncipheredTextIO.Name = "uncipheredTextIO";
            this.uncipheredTextIO.Size = new System.Drawing.Size(327, 113);
            this.uncipheredTextIO.TabIndex = 14;
            this.uncipheredTextIO.Text = "";
            // 
            // uncipheredTextLabel
            // 
            this.uncipheredTextLabel.AutoSize = true;
            this.uncipheredTextLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.uncipheredTextLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.uncipheredTextLabel.Location = new System.Drawing.Point(153, 284);
            this.uncipheredTextLabel.Name = "uncipheredTextLabel";
            this.uncipheredTextLabel.Size = new System.Drawing.Size(125, 20);
            this.uncipheredTextLabel.TabIndex = 13;
            this.uncipheredTextLabel.Text = "Unciphered Text";
            // 
            // cipheredTextIO
            // 
            this.cipheredTextIO.Location = new System.Drawing.Point(418, 307);
            this.cipheredTextIO.Name = "cipheredTextIO";
            this.cipheredTextIO.Size = new System.Drawing.Size(345, 113);
            this.cipheredTextIO.TabIndex = 16;
            this.cipheredTextIO.Text = "";
            // 
            // cipheredTextLabel
            // 
            this.cipheredTextLabel.AutoSize = true;
            this.cipheredTextLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cipheredTextLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.cipheredTextLabel.Location = new System.Drawing.Point(537, 284);
            this.cipheredTextLabel.Name = "cipheredTextLabel";
            this.cipheredTextLabel.Size = new System.Drawing.Size(107, 20);
            this.cipheredTextLabel.TabIndex = 15;
            this.cipheredTextLabel.Text = "Ciphered Text";
            // 
            // cipherButton
            // 
            this.cipherButton.BackColor = System.Drawing.Color.Purple;
            this.cipherButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cipherButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cipherButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.cipherButton.Location = new System.Drawing.Point(112, 426);
            this.cipherButton.Name = "cipherButton";
            this.cipherButton.Size = new System.Drawing.Size(207, 35);
            this.cipherButton.TabIndex = 17;
            this.cipherButton.Text = "Cipher";
            this.cipherButton.UseVisualStyleBackColor = false;
            this.cipherButton.Click += new System.EventHandler(this.cipherButton_Click);
            // 
            // uncipherButton
            // 
            this.uncipherButton.BackColor = System.Drawing.Color.Purple;
            this.uncipherButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.uncipherButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.uncipherButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.uncipherButton.Location = new System.Drawing.Point(497, 425);
            this.uncipherButton.Name = "uncipherButton";
            this.uncipherButton.Size = new System.Drawing.Size(206, 36);
            this.uncipherButton.TabIndex = 18;
            this.uncipherButton.Text = "Uncipher";
            this.uncipherButton.UseVisualStyleBackColor = false;
            this.uncipherButton.Click += new System.EventHandler(this.uncipherButton_Click);
            // 
            // numberOfBitsLabel
            // 
            this.numberOfBitsLabel.AutoSize = true;
            this.numberOfBitsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numberOfBitsLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.numberOfBitsLabel.Location = new System.Drawing.Point(651, 102);
            this.numberOfBitsLabel.Name = "numberOfBitsLabel";
            this.numberOfBitsLabel.Size = new System.Drawing.Size(101, 17);
            this.numberOfBitsLabel.TabIndex = 19;
            this.numberOfBitsLabel.Text = "Length of keys";
            // 
            // keyLengthInput
            // 
            this.keyLengthInput.Location = new System.Drawing.Point(654, 122);
            this.keyLengthInput.Name = "keyLengthInput";
            this.keyLengthInput.Size = new System.Drawing.Size(100, 20);
            this.keyLengthInput.TabIndex = 20;
            // 
            // RSAForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(800, 492);
            this.Controls.Add(this.keyLengthInput);
            this.Controls.Add(this.numberOfBitsLabel);
            this.Controls.Add(this.uncipherButton);
            this.Controls.Add(this.cipherButton);
            this.Controls.Add(this.cipheredTextIO);
            this.Controls.Add(this.cipheredTextLabel);
            this.Controls.Add(this.uncipheredTextIO);
            this.Controls.Add(this.uncipheredTextLabel);
            this.Controls.Add(this.dOutput);
            this.Controls.Add(this.dLabel);
            this.Controls.Add(this.eOutput);
            this.Controls.Add(this.eLabel);
            this.Controls.Add(this.eulerFunctionOutput);
            this.Controls.Add(this.eulerFunctionLabel);
            this.Controls.Add(this.NOutput);
            this.Controls.Add(this.NLabel);
            this.Controls.Add(this.qIO);
            this.Controls.Add(this.qLabel);
            this.Controls.Add(this.generateKeysButton);
            this.Controls.Add(this.pIO);
            this.Controls.Add(this.pLabel);
            this.Name = "RSAForm";
            this.Text = "RSA";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label pLabel;
        private System.Windows.Forms.RichTextBox pIO;
        private System.Windows.Forms.Button generateKeysButton;
        private System.Windows.Forms.RichTextBox qIO;
        private System.Windows.Forms.Label qLabel;
        private System.Windows.Forms.RichTextBox eulerFunctionOutput;
        private System.Windows.Forms.Label eulerFunctionLabel;
        private System.Windows.Forms.RichTextBox NOutput;
        private System.Windows.Forms.Label NLabel;
        private System.Windows.Forms.RichTextBox eOutput;
        private System.Windows.Forms.Label eLabel;
        private System.Windows.Forms.RichTextBox dOutput;
        private System.Windows.Forms.Label dLabel;
        private System.Windows.Forms.RichTextBox uncipheredTextIO;
        private System.Windows.Forms.Label uncipheredTextLabel;
        private System.Windows.Forms.RichTextBox cipheredTextIO;
        private System.Windows.Forms.Label cipheredTextLabel;
        private System.Windows.Forms.Button cipherButton;
        private System.Windows.Forms.Button uncipherButton;
        private System.Windows.Forms.Label numberOfBitsLabel;
        private System.Windows.Forms.TextBox keyLengthInput;
    }
}