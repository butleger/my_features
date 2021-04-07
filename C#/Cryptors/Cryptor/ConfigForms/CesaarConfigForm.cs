using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cesaar
{
    public partial class CesaarConfigForm : Form
    {
        string russian_alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        string english_alphabet = "abcdefghijklmnopqrstuvwxyz";

        Form1 form;

        public CesaarConfig conf;

        public CesaarConfigForm(Form1 form)
        {
            InitializeComponent();
            this.form = form;
        }

        private void end_config_button_Click(object sender, EventArgs e)
        {
            int key = 0;
            string alphabet = "";

            try
            {
                key = int.Parse(key_textbox.Text);
            }
            catch
            {
                MessageBox.Show("Input key number!");
                return;
            }


            if (russian_language_checkbox.Checked)
                alphabet = russian_alphabet;
            if (english_language_checkbox.Checked)
                alphabet = english_alphabet;
            else
                alphabet = english_alphabet; // default value

            conf = new CesaarConfig(alphabet, key);
            form.encrypt_button.Enabled = true;
            form.decrypt_button.Enabled = true;
            this.Close();
        }
    }
}
