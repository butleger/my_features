namespace EulerAndFastPower
{
    partial class ExtendedGCDForm
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
            this.x_label = new System.Windows.Forms.Label();
            this.first_number_textbox = new System.Windows.Forms.TextBox();
            this.second_number_textbox = new System.Windows.Forms.TextBox();
            this.y_label = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.multy_label = new System.Windows.Forms.Label();
            this.plus_label = new System.Windows.Forms.Label();
            this.second_multy_label = new System.Windows.Forms.Label();
            this.gcd_textbox = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // calc_button
            // 
            this.calc_button.BackColor = System.Drawing.Color.Maroon;
            this.calc_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.calc_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.calc_button.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.calc_button.Location = new System.Drawing.Point(25, 106);
            this.calc_button.Name = "calc_button";
            this.calc_button.Size = new System.Drawing.Size(109, 41);
            this.calc_button.TabIndex = 0;
            this.calc_button.Text = "calculate";
            this.calc_button.UseVisualStyleBackColor = false;
            this.calc_button.Click += new System.EventHandler(this.calc_button_Click);
            // 
            // x_label
            // 
            this.x_label.AutoSize = true;
            this.x_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.x_label.Location = new System.Drawing.Point(251, 16);
            this.x_label.Name = "x_label";
            this.x_label.Size = new System.Drawing.Size(17, 17);
            this.x_label.TabIndex = 1;
            this.x_label.Text = "X";
            // 
            // first_number_textbox
            // 
            this.first_number_textbox.Location = new System.Drawing.Point(61, 13);
            this.first_number_textbox.Name = "first_number_textbox";
            this.first_number_textbox.Size = new System.Drawing.Size(167, 20);
            this.first_number_textbox.TabIndex = 2;
            // 
            // second_number_textbox
            // 
            this.second_number_textbox.Location = new System.Drawing.Point(61, 69);
            this.second_number_textbox.Name = "second_number_textbox";
            this.second_number_textbox.Size = new System.Drawing.Size(167, 20);
            this.second_number_textbox.TabIndex = 3;
            // 
            // y_label
            // 
            this.y_label.AutoSize = true;
            this.y_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.y_label.Location = new System.Drawing.Point(251, 69);
            this.y_label.Name = "y_label";
            this.y_label.Size = new System.Drawing.Size(17, 17);
            this.y_label.TabIndex = 4;
            this.y_label.Text = "Y";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(248, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "=";
            // 
            // multy_label
            // 
            this.multy_label.AutoSize = true;
            this.multy_label.Location = new System.Drawing.Point(234, 12);
            this.multy_label.Name = "multy_label";
            this.multy_label.Size = new System.Drawing.Size(11, 13);
            this.multy_label.TabIndex = 8;
            this.multy_label.Text = "*";
            // 
            // plus_label
            // 
            this.plus_label.AutoSize = true;
            this.plus_label.Location = new System.Drawing.Point(232, 43);
            this.plus_label.Name = "plus_label";
            this.plus_label.Size = new System.Drawing.Size(13, 13);
            this.plus_label.TabIndex = 9;
            this.plus_label.Text = "+";
            // 
            // second_multy_label
            // 
            this.second_multy_label.AutoSize = true;
            this.second_multy_label.Location = new System.Drawing.Point(234, 69);
            this.second_multy_label.Name = "second_multy_label";
            this.second_multy_label.Size = new System.Drawing.Size(11, 13);
            this.second_multy_label.TabIndex = 10;
            this.second_multy_label.Text = "*";
            // 
            // gcd_textbox
            // 
            this.gcd_textbox.AutoSize = true;
            this.gcd_textbox.Location = new System.Drawing.Point(261, 134);
            this.gcd_textbox.Name = "gcd_textbox";
            this.gcd_textbox.Size = new System.Drawing.Size(0, 13);
            this.gcd_textbox.TabIndex = 11;
            // 
            // ExtendedGCDForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(343, 158);
            this.Controls.Add(this.gcd_textbox);
            this.Controls.Add(this.second_multy_label);
            this.Controls.Add(this.plus_label);
            this.Controls.Add(this.multy_label);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.y_label);
            this.Controls.Add(this.second_number_textbox);
            this.Controls.Add(this.first_number_textbox);
            this.Controls.Add(this.x_label);
            this.Controls.Add(this.calc_button);
            this.Name = "ExtendedGCDForm";
            this.Text = "ExtendedGCDForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button calc_button;
        private System.Windows.Forms.Label x_label;
        private System.Windows.Forms.TextBox first_number_textbox;
        private System.Windows.Forms.TextBox second_number_textbox;
        private System.Windows.Forms.Label y_label;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label multy_label;
        private System.Windows.Forms.Label plus_label;
        private System.Windows.Forms.Label second_multy_label;
        private System.Windows.Forms.Label gcd_textbox;
    }
}