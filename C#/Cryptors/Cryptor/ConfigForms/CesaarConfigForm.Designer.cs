namespace cesaar
{
    partial class CesaarConfigForm
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
            this.end_config_button = new System.Windows.Forms.Button();
            this.russian_language_checkbox = new System.Windows.Forms.RadioButton();
            this.english_language_checkbox = new System.Windows.Forms.RadioButton();
            this.key_textbox = new System.Windows.Forms.TextBox();
            this.key_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // end_config_button
            // 
            this.end_config_button.Location = new System.Drawing.Point(94, 96);
            this.end_config_button.Name = "end_config_button";
            this.end_config_button.Size = new System.Drawing.Size(75, 23);
            this.end_config_button.TabIndex = 0;
            this.end_config_button.Text = "ok";
            this.end_config_button.UseVisualStyleBackColor = true;
            this.end_config_button.Click += new System.EventHandler(this.end_config_button_Click);
            // 
            // russian_language_checkbox
            // 
            this.russian_language_checkbox.AutoSize = true;
            this.russian_language_checkbox.Location = new System.Drawing.Point(12, 44);
            this.russian_language_checkbox.Name = "russian_language_checkbox";
            this.russian_language_checkbox.Size = new System.Drawing.Size(58, 17);
            this.russian_language_checkbox.TabIndex = 1;
            this.russian_language_checkbox.Text = "russian";
            this.russian_language_checkbox.UseVisualStyleBackColor = true;
            // 
            // english_language_checkbox
            // 
            this.english_language_checkbox.AutoSize = true;
            this.english_language_checkbox.Checked = true;
            this.english_language_checkbox.Location = new System.Drawing.Point(12, 68);
            this.english_language_checkbox.Name = "english_language_checkbox";
            this.english_language_checkbox.Size = new System.Drawing.Size(58, 17);
            this.english_language_checkbox.TabIndex = 2;
            this.english_language_checkbox.TabStop = true;
            this.english_language_checkbox.Text = "english";
            this.english_language_checkbox.UseVisualStyleBackColor = true;
            // 
            // key_textbox
            // 
            this.key_textbox.Location = new System.Drawing.Point(151, 56);
            this.key_textbox.Name = "key_textbox";
            this.key_textbox.Size = new System.Drawing.Size(100, 20);
            this.key_textbox.TabIndex = 3;
            // 
            // key_label
            // 
            this.key_label.AutoSize = true;
            this.key_label.Location = new System.Drawing.Point(184, 40);
            this.key_label.Name = "key_label";
            this.key_label.Size = new System.Drawing.Size(24, 13);
            this.key_label.TabIndex = 4;
            this.key_label.Text = "key";
            // 
            // CesaarConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 131);
            this.Controls.Add(this.key_label);
            this.Controls.Add(this.key_textbox);
            this.Controls.Add(this.english_language_checkbox);
            this.Controls.Add(this.russian_language_checkbox);
            this.Controls.Add(this.end_config_button);
            this.Name = "CesaarConfigForm";
            this.Text = "Cesaar config";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button end_config_button;
        private System.Windows.Forms.RadioButton russian_language_checkbox;
        private System.Windows.Forms.RadioButton english_language_checkbox;
        private System.Windows.Forms.TextBox key_textbox;
        private System.Windows.Forms.Label key_label;
    }
}