namespace EulerAndFastPower
{
    partial class FastPowForm
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
            this.calc_button = new System.Windows.Forms.Button();
            this.number_label = new System.Windows.Forms.Label();
            this.number_textbox = new System.Windows.Forms.TextBox();
            this.power_textbox = new System.Windows.Forms.TextBox();
            this.power_label = new System.Windows.Forms.Label();
            this.module_label = new System.Windows.Forms.Label();
            this.module_textbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // calc_button
            // 
            this.calc_button.BackColor = System.Drawing.Color.DarkRed;
            this.calc_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.calc_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.calc_button.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.calc_button.Location = new System.Drawing.Point(227, 96);
            this.calc_button.Name = "calc_button";
            this.calc_button.Size = new System.Drawing.Size(100, 31);
            this.calc_button.TabIndex = 0;
            this.calc_button.Text = "Calculate";
            this.calc_button.UseVisualStyleBackColor = false;
            this.calc_button.Click += new System.EventHandler(this.calc_button_Click);
            // 
            // number_label
            // 
            this.number_label.AutoSize = true;
            this.number_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.number_label.ForeColor = System.Drawing.SystemColors.Control;
            this.number_label.Location = new System.Drawing.Point(45, 40);
            this.number_label.Name = "number_label";
            this.number_label.Size = new System.Drawing.Size(58, 17);
            this.number_label.TabIndex = 1;
            this.number_label.Text = "Number";
            // 
            // number_textbox
            // 
            this.number_textbox.Location = new System.Drawing.Point(48, 60);
            this.number_textbox.Name = "number_textbox";
            this.number_textbox.Size = new System.Drawing.Size(100, 20);
            this.number_textbox.TabIndex = 2;
            // 
            // power_textbox
            // 
            this.power_textbox.Location = new System.Drawing.Point(227, 60);
            this.power_textbox.Name = "power_textbox";
            this.power_textbox.Size = new System.Drawing.Size(100, 20);
            this.power_textbox.TabIndex = 3;
            // 
            // power_label
            // 
            this.power_label.AutoSize = true;
            this.power_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.power_label.ForeColor = System.Drawing.SystemColors.Control;
            this.power_label.Location = new System.Drawing.Point(224, 40);
            this.power_label.Name = "power_label";
            this.power_label.Size = new System.Drawing.Size(47, 17);
            this.power_label.TabIndex = 4;
            this.power_label.Text = "Power";
            // 
            // module_label
            // 
            this.module_label.AutoSize = true;
            this.module_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.module_label.ForeColor = System.Drawing.SystemColors.Control;
            this.module_label.Location = new System.Drawing.Point(382, 40);
            this.module_label.Name = "module_label";
            this.module_label.Size = new System.Drawing.Size(54, 17);
            this.module_label.TabIndex = 6;
            this.module_label.Text = "Module";
            // 
            // module_textbox
            // 
            this.module_textbox.Location = new System.Drawing.Point(385, 60);
            this.module_textbox.Name = "module_textbox";
            this.module_textbox.Size = new System.Drawing.Size(100, 20);
            this.module_textbox.TabIndex = 5;
            // 
            // FastPowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(532, 139);
            this.Controls.Add(this.module_label);
            this.Controls.Add(this.module_textbox);
            this.Controls.Add(this.power_label);
            this.Controls.Add(this.power_textbox);
            this.Controls.Add(this.number_textbox);
            this.Controls.Add(this.number_label);
            this.Controls.Add(this.calc_button);
            this.Name = "FastPowForm";
            this.Text = "FastPowForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button calc_button;
        private System.Windows.Forms.Label number_label;
        private System.Windows.Forms.TextBox number_textbox;
        private System.Windows.Forms.TextBox power_textbox;
        private System.Windows.Forms.Label power_label;
        private System.Windows.Forms.Label module_label;
        private System.Windows.Forms.TextBox module_textbox;
    }
}