namespace EulerAndFastPower
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.extended_gcd_button = new System.Windows.Forms.Button();
            this.fast_power_button = new System.Windows.Forms.Button();
            this.primaryTestButton = new System.Windows.Forms.Button();
            this.generatePrimeNumberButton = new System.Windows.Forms.Button();
            this.rsaButton = new System.Windows.Forms.Button();
            this.eratistheneSieveButton = new System.Windows.Forms.Button();
            this.pollardFactorButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // extended_gcd_button
            // 
            this.extended_gcd_button.BackColor = System.Drawing.Color.Firebrick;
            this.extended_gcd_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.extended_gcd_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.extended_gcd_button.ForeColor = System.Drawing.Color.Linen;
            this.extended_gcd_button.Location = new System.Drawing.Point(373, 44);
            this.extended_gcd_button.Name = "extended_gcd_button";
            this.extended_gcd_button.Size = new System.Drawing.Size(144, 118);
            this.extended_gcd_button.TabIndex = 1;
            this.extended_gcd_button.Text = "Extended GCD";
            this.extended_gcd_button.UseVisualStyleBackColor = false;
            this.extended_gcd_button.Click += new System.EventHandler(this.extended_gcd_button_Click);
            // 
            // fast_power_button
            // 
            this.fast_power_button.BackColor = System.Drawing.Color.MidnightBlue;
            this.fast_power_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.fast_power_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fast_power_button.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.fast_power_button.Location = new System.Drawing.Point(107, 44);
            this.fast_power_button.Name = "fast_power_button";
            this.fast_power_button.Size = new System.Drawing.Size(144, 118);
            this.fast_power_button.TabIndex = 2;
            this.fast_power_button.Text = "Fast Power";
            this.fast_power_button.UseVisualStyleBackColor = false;
            this.fast_power_button.Click += new System.EventHandler(this.fast_power_button_Click);
            // 
            // primaryTestButton
            // 
            this.primaryTestButton.BackColor = System.Drawing.Color.ForestGreen;
            this.primaryTestButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.primaryTestButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.primaryTestButton.ForeColor = System.Drawing.Color.Linen;
            this.primaryTestButton.Location = new System.Drawing.Point(107, 188);
            this.primaryTestButton.Name = "primaryTestButton";
            this.primaryTestButton.Size = new System.Drawing.Size(144, 118);
            this.primaryTestButton.TabIndex = 3;
            this.primaryTestButton.Text = "Primary Test";
            this.primaryTestButton.UseVisualStyleBackColor = false;
            this.primaryTestButton.Click += new System.EventHandler(this.primaryTestButton_Click);
            // 
            // generatePrimeNumberButton
            // 
            this.generatePrimeNumberButton.BackColor = System.Drawing.Color.Teal;
            this.generatePrimeNumberButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.generatePrimeNumberButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.generatePrimeNumberButton.ForeColor = System.Drawing.Color.Linen;
            this.generatePrimeNumberButton.Location = new System.Drawing.Point(373, 188);
            this.generatePrimeNumberButton.Name = "generatePrimeNumberButton";
            this.generatePrimeNumberButton.Size = new System.Drawing.Size(144, 118);
            this.generatePrimeNumberButton.TabIndex = 4;
            this.generatePrimeNumberButton.Text = "Random Prime Generator";
            this.generatePrimeNumberButton.UseVisualStyleBackColor = false;
            this.generatePrimeNumberButton.Click += new System.EventHandler(this.generatePrimeNumberButton_Click);
            // 
            // rsaButton
            // 
            this.rsaButton.BackColor = System.Drawing.Color.Purple;
            this.rsaButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rsaButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rsaButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rsaButton.Location = new System.Drawing.Point(613, 44);
            this.rsaButton.Name = "rsaButton";
            this.rsaButton.Size = new System.Drawing.Size(144, 118);
            this.rsaButton.TabIndex = 5;
            this.rsaButton.Text = "RSA";
            this.rsaButton.UseVisualStyleBackColor = false;
            this.rsaButton.Click += new System.EventHandler(this.rsaButton_Click);
            // 
            // eratistheneSieveButton
            // 
            this.eratistheneSieveButton.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.eratistheneSieveButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.eratistheneSieveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.eratistheneSieveButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.eratistheneSieveButton.Location = new System.Drawing.Point(613, 188);
            this.eratistheneSieveButton.Name = "eratistheneSieveButton";
            this.eratistheneSieveButton.Size = new System.Drawing.Size(144, 118);
            this.eratistheneSieveButton.TabIndex = 6;
            this.eratistheneSieveButton.Text = "Eratosthene Sieve";
            this.eratistheneSieveButton.UseVisualStyleBackColor = false;
            this.eratistheneSieveButton.Click += new System.EventHandler(this.eratistheneSieveButton_Click);
            // 
            // pollardFactorButton
            // 
            this.pollardFactorButton.BackColor = System.Drawing.Color.MediumVioletRed;
            this.pollardFactorButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.pollardFactorButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pollardFactorButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.pollardFactorButton.Location = new System.Drawing.Point(107, 335);
            this.pollardFactorButton.Name = "pollardFactorButton";
            this.pollardFactorButton.Size = new System.Drawing.Size(650, 41);
            this.pollardFactorButton.TabIndex = 7;
            this.pollardFactorButton.Text = "RSA decryptor";
            this.pollardFactorButton.UseVisualStyleBackColor = false;
            this.pollardFactorButton.Click += new System.EventHandler(this.pollardFactorButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(877, 418);
            this.Controls.Add(this.pollardFactorButton);
            this.Controls.Add(this.eratistheneSieveButton);
            this.Controls.Add(this.rsaButton);
            this.Controls.Add(this.generatePrimeNumberButton);
            this.Controls.Add(this.primaryTestButton);
            this.Controls.Add(this.fast_power_button);
            this.Controls.Add(this.extended_gcd_button);
            this.Name = "Form1";
            this.Text = "Pick!";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button extended_gcd_button;
        private System.Windows.Forms.Button fast_power_button;
        private System.Windows.Forms.Button primaryTestButton;
        private System.Windows.Forms.Button generatePrimeNumberButton;
        private System.Windows.Forms.Button rsaButton;
        private System.Windows.Forms.Button eratistheneSieveButton;
        private System.Windows.Forms.Button pollardFactorButton;
    }
}

