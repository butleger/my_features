namespace cesaar
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
            this.encrypt_button = new System.Windows.Forms.Button();
            this.unciphered_text_label = new System.Windows.Forms.Label();
            this.ciphered_text_label = new System.Windows.Forms.Label();
            this.unciphered_text_box = new System.Windows.Forms.RichTextBox();
            this.ciphered_text = new System.Windows.Forms.RichTextBox();
            this.decrypt_button = new System.Windows.Forms.Button();
            this.configure_button = new System.Windows.Forms.Button();
            this.algo_chooser = new System.Windows.Forms.ComboBox();
            this.algo_label = new System.Windows.Forms.Label();
            this.binary_unciphered_text = new System.Windows.Forms.TextBox();
            this.binary_ciphered_text = new System.Windows.Forms.TextBox();
            this.binary_key_textbox = new System.Windows.Forms.TextBox();
            this.binary_key_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // encrypt_button
            // 
            this.encrypt_button.Enabled = false;
            this.encrypt_button.Location = new System.Drawing.Point(420, 36);
            this.encrypt_button.Name = "encrypt_button";
            this.encrypt_button.Size = new System.Drawing.Size(75, 23);
            this.encrypt_button.TabIndex = 0;
            this.encrypt_button.Text = "encrypt";
            this.encrypt_button.UseVisualStyleBackColor = true;
            this.encrypt_button.Click += new System.EventHandler(this.encrypt_button_Click);
            // 
            // unciphered_text_label
            // 
            this.unciphered_text_label.AutoSize = true;
            this.unciphered_text_label.Location = new System.Drawing.Point(96, 18);
            this.unciphered_text_label.Name = "unciphered_text_label";
            this.unciphered_text_label.Size = new System.Drawing.Size(80, 13);
            this.unciphered_text_label.TabIndex = 3;
            this.unciphered_text_label.Text = "unciphered text";
            // 
            // ciphered_text_label
            // 
            this.ciphered_text_label.AutoSize = true;
            this.ciphered_text_label.Location = new System.Drawing.Point(630, 18);
            this.ciphered_text_label.Name = "ciphered_text_label";
            this.ciphered_text_label.Size = new System.Drawing.Size(68, 13);
            this.ciphered_text_label.TabIndex = 4;
            this.ciphered_text_label.Text = "ciphered text";
            // 
            // unciphered_text_box
            // 
            this.unciphered_text_box.Location = new System.Drawing.Point(25, 36);
            this.unciphered_text_box.Name = "unciphered_text_box";
            this.unciphered_text_box.Size = new System.Drawing.Size(232, 118);
            this.unciphered_text_box.TabIndex = 5;
            this.unciphered_text_box.Text = "";
            // 
            // ciphered_text
            // 
            this.ciphered_text.Location = new System.Drawing.Point(545, 34);
            this.ciphered_text.Name = "ciphered_text";
            this.ciphered_text.Size = new System.Drawing.Size(232, 118);
            this.ciphered_text.TabIndex = 6;
            this.ciphered_text.Text = "";
            // 
            // decrypt_button
            // 
            this.decrypt_button.Enabled = false;
            this.decrypt_button.Location = new System.Drawing.Point(420, 65);
            this.decrypt_button.Name = "decrypt_button";
            this.decrypt_button.Size = new System.Drawing.Size(75, 23);
            this.decrypt_button.TabIndex = 11;
            this.decrypt_button.Text = "decrypt";
            this.decrypt_button.UseVisualStyleBackColor = true;
            this.decrypt_button.Click += new System.EventHandler(this.decrypt_button_Click);
            // 
            // configure_button
            // 
            this.configure_button.Location = new System.Drawing.Point(314, 109);
            this.configure_button.Name = "configure_button";
            this.configure_button.Size = new System.Drawing.Size(181, 33);
            this.configure_button.TabIndex = 12;
            this.configure_button.Text = "Configure";
            this.configure_button.UseVisualStyleBackColor = true;
            this.configure_button.Click += new System.EventHandler(this.configure_button_Click);
            // 
            // algo_chooser
            // 
            this.algo_chooser.FormattingEnabled = true;
            this.algo_chooser.Items.AddRange(new object[] {
            "Cesaar",
            "Visioner",
            "Xor"});
            this.algo_chooser.Location = new System.Drawing.Point(273, 38);
            this.algo_chooser.Name = "algo_chooser";
            this.algo_chooser.Size = new System.Drawing.Size(121, 21);
            this.algo_chooser.TabIndex = 13;
            // 
            // algo_label
            // 
            this.algo_label.AutoSize = true;
            this.algo_label.Location = new System.Drawing.Point(273, 18);
            this.algo_label.Name = "algo_label";
            this.algo_label.Size = new System.Drawing.Size(81, 13);
            this.algo_label.TabIndex = 14;
            this.algo_label.Text = "cipher algorithm";
            // 
            // binary_unciphered_text
            // 
            this.binary_unciphered_text.Location = new System.Drawing.Point(25, 161);
            this.binary_unciphered_text.Name = "binary_unciphered_text";
            this.binary_unciphered_text.ReadOnly = true;
            this.binary_unciphered_text.Size = new System.Drawing.Size(232, 20);
            this.binary_unciphered_text.TabIndex = 15;
            // 
            // binary_ciphered_text
            // 
            this.binary_ciphered_text.Location = new System.Drawing.Point(545, 159);
            this.binary_ciphered_text.Name = "binary_ciphered_text";
            this.binary_ciphered_text.ReadOnly = true;
            this.binary_ciphered_text.Size = new System.Drawing.Size(232, 20);
            this.binary_ciphered_text.TabIndex = 16;
            // 
            // binary_key_textbox
            // 
            this.binary_key_textbox.Location = new System.Drawing.Point(314, 159);
            this.binary_key_textbox.Name = "binary_key_textbox";
            this.binary_key_textbox.ReadOnly = true;
            this.binary_key_textbox.Size = new System.Drawing.Size(181, 20);
            this.binary_key_textbox.TabIndex = 17;
            // 
            // binary_key_label
            // 
            this.binary_key_label.AutoSize = true;
            this.binary_key_label.Location = new System.Drawing.Point(373, 182);
            this.binary_key_label.Name = "binary_key_label";
            this.binary_key_label.Size = new System.Drawing.Size(58, 13);
            this.binary_key_label.TabIndex = 18;
            this.binary_key_label.Text = "binary_key";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 261);
            this.Controls.Add(this.binary_key_label);
            this.Controls.Add(this.binary_key_textbox);
            this.Controls.Add(this.binary_ciphered_text);
            this.Controls.Add(this.binary_unciphered_text);
            this.Controls.Add(this.algo_label);
            this.Controls.Add(this.algo_chooser);
            this.Controls.Add(this.configure_button);
            this.Controls.Add(this.decrypt_button);
            this.Controls.Add(this.ciphered_text);
            this.Controls.Add(this.unciphered_text_box);
            this.Controls.Add(this.ciphered_text_label);
            this.Controls.Add(this.unciphered_text_label);
            this.Controls.Add(this.encrypt_button);
            this.Name = "Form1";
            this.Text = "Cipherer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button encrypt_button;
        private System.Windows.Forms.Label unciphered_text_label;
        private System.Windows.Forms.Label ciphered_text_label;
        private System.Windows.Forms.RichTextBox unciphered_text_box;
        private System.Windows.Forms.RichTextBox ciphered_text;
        public System.Windows.Forms.Button decrypt_button;
        private System.Windows.Forms.Button configure_button;
        private System.Windows.Forms.ComboBox algo_chooser;
        private System.Windows.Forms.Label algo_label;
        private System.Windows.Forms.TextBox binary_unciphered_text;
        private System.Windows.Forms.TextBox binary_ciphered_text;
        private System.Windows.Forms.TextBox binary_key_textbox;
        private System.Windows.Forms.Label binary_key_label;
    }
}

