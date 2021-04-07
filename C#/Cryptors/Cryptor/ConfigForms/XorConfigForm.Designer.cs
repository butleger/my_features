namespace cesaar.ConfigForms
{
    partial class XorConfigForm
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
            this.russian_lang_radiobutton = new System.Windows.Forms.RadioButton();
            this.english_lang_radiobutton = new System.Windows.Forms.RadioButton();
            this.ok_button = new System.Windows.Forms.Button();
            this.keyword_textbox = new System.Windows.Forms.TextBox();
            this.key_description = new System.Windows.Forms.Label();
            this.random_key_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // russian_lang_radiobutton
            // 
            this.russian_lang_radiobutton.AutoSize = true;
            this.russian_lang_radiobutton.Location = new System.Drawing.Point(12, 36);
            this.russian_lang_radiobutton.Name = "russian_lang_radiobutton";
            this.russian_lang_radiobutton.Size = new System.Drawing.Size(58, 17);
            this.russian_lang_radiobutton.TabIndex = 0;
            this.russian_lang_radiobutton.TabStop = true;
            this.russian_lang_radiobutton.Text = "russian";
            this.russian_lang_radiobutton.UseVisualStyleBackColor = true;
            // 
            // english_lang_radiobutton
            // 
            this.english_lang_radiobutton.AutoSize = true;
            this.english_lang_radiobutton.Location = new System.Drawing.Point(12, 60);
            this.english_lang_radiobutton.Name = "english_lang_radiobutton";
            this.english_lang_radiobutton.Size = new System.Drawing.Size(58, 17);
            this.english_lang_radiobutton.TabIndex = 1;
            this.english_lang_radiobutton.TabStop = true;
            this.english_lang_radiobutton.Text = "english";
            this.english_lang_radiobutton.UseVisualStyleBackColor = true;
            // 
            // ok_button
            // 
            this.ok_button.Location = new System.Drawing.Point(92, 96);
            this.ok_button.Name = "ok_button";
            this.ok_button.Size = new System.Drawing.Size(75, 23);
            this.ok_button.TabIndex = 2;
            this.ok_button.Text = "Ok";
            this.ok_button.UseVisualStyleBackColor = true;
            this.ok_button.Click += new System.EventHandler(this.ok_button_Click);
            // 
            // keyword_textbox
            // 
            this.keyword_textbox.Location = new System.Drawing.Point(152, 24);
            this.keyword_textbox.Name = "keyword_textbox";
            this.keyword_textbox.Size = new System.Drawing.Size(100, 20);
            this.keyword_textbox.TabIndex = 3;
            // 
            // key_description
            // 
            this.key_description.AutoSize = true;
            this.key_description.Location = new System.Drawing.Point(184, 3);
            this.key_description.Name = "key_description";
            this.key_description.Size = new System.Drawing.Size(24, 13);
            this.key_description.TabIndex = 4;
            this.key_description.Text = "key";
            this.key_description.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // random_key_button
            // 
            this.random_key_button.Location = new System.Drawing.Point(161, 50);
            this.random_key_button.Name = "random_key_button";
            this.random_key_button.Size = new System.Drawing.Size(75, 23);
            this.random_key_button.TabIndex = 5;
            this.random_key_button.Text = "random key";
            this.random_key_button.UseVisualStyleBackColor = true;
            this.random_key_button.Click += new System.EventHandler(this.random_key_button_Click);
            // 
            // XorConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 131);
            this.Controls.Add(this.random_key_button);
            this.Controls.Add(this.key_description);
            this.Controls.Add(this.keyword_textbox);
            this.Controls.Add(this.ok_button);
            this.Controls.Add(this.english_lang_radiobutton);
            this.Controls.Add(this.russian_lang_radiobutton);
            this.Name = "XorConfigForm";
            this.Text = "XorConfigForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton russian_lang_radiobutton;
        private System.Windows.Forms.RadioButton english_lang_radiobutton;
        private System.Windows.Forms.Button ok_button;
        private System.Windows.Forms.TextBox keyword_textbox;
        private System.Windows.Forms.Label key_description;
        private System.Windows.Forms.Button random_key_button;
    }
}