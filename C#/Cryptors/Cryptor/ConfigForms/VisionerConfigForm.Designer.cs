namespace cesaar
{
    partial class VisionerConfigForm
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
            this.english_lang_radiobutton = new System.Windows.Forms.RadioButton();
            this.russian_lang_radiobutton = new System.Windows.Forms.RadioButton();
            this.end_config_button = new System.Windows.Forms.Button();
            this.keyword_label = new System.Windows.Forms.Label();
            this.keyword_textbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // english_lang_radiobutton
            // 
            this.english_lang_radiobutton.AutoSize = true;
            this.english_lang_radiobutton.Checked = true;
            this.english_lang_radiobutton.Location = new System.Drawing.Point(12, 61);
            this.english_lang_radiobutton.Name = "english_lang_radiobutton";
            this.english_lang_radiobutton.Size = new System.Drawing.Size(58, 17);
            this.english_lang_radiobutton.TabIndex = 0;
            this.english_lang_radiobutton.TabStop = true;
            this.english_lang_radiobutton.Text = "english";
            this.english_lang_radiobutton.UseVisualStyleBackColor = true;
            // 
            // russian_lang_radiobutton
            // 
            this.russian_lang_radiobutton.AutoSize = true;
            this.russian_lang_radiobutton.Location = new System.Drawing.Point(12, 38);
            this.russian_lang_radiobutton.Name = "russian_lang_radiobutton";
            this.russian_lang_radiobutton.Size = new System.Drawing.Size(58, 17);
            this.russian_lang_radiobutton.TabIndex = 1;
            this.russian_lang_radiobutton.Text = "russian";
            this.russian_lang_radiobutton.UseVisualStyleBackColor = true;
            // 
            // end_config_button
            // 
            this.end_config_button.Location = new System.Drawing.Point(95, 96);
            this.end_config_button.Name = "end_config_button";
            this.end_config_button.Size = new System.Drawing.Size(75, 23);
            this.end_config_button.TabIndex = 2;
            this.end_config_button.Text = "ok";
            this.end_config_button.UseVisualStyleBackColor = true;
            this.end_config_button.Click += new System.EventHandler(this.end_config_button_Click);
            // 
            // keyword_label
            // 
            this.keyword_label.AutoSize = true;
            this.keyword_label.Location = new System.Drawing.Point(161, 33);
            this.keyword_label.Name = "keyword_label";
            this.keyword_label.Size = new System.Drawing.Size(47, 13);
            this.keyword_label.TabIndex = 3;
            this.keyword_label.Text = "keyword";
            // 
            // keyword_textbox
            // 
            this.keyword_textbox.Location = new System.Drawing.Point(135, 49);
            this.keyword_textbox.Name = "keyword_textbox";
            this.keyword_textbox.Size = new System.Drawing.Size(100, 20);
            this.keyword_textbox.TabIndex = 4;
            // 
            // VisionerConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 131);
            this.Controls.Add(this.keyword_textbox);
            this.Controls.Add(this.keyword_label);
            this.Controls.Add(this.end_config_button);
            this.Controls.Add(this.russian_lang_radiobutton);
            this.Controls.Add(this.english_lang_radiobutton);
            this.Name = "VisionerConfigForm";
            this.Text = "Visioner config";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton english_lang_radiobutton;
        private System.Windows.Forms.RadioButton russian_lang_radiobutton;
        private System.Windows.Forms.Button end_config_button;
        private System.Windows.Forms.Label keyword_label;
        private System.Windows.Forms.TextBox keyword_textbox;
    }
}