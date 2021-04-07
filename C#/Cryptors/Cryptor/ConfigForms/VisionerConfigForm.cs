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
    public partial class VisionerConfigForm : Form
    {
        string russian_alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        string english_alphabet = "abcdefghijklmnopqrstuvwxyz";

        Form1 form;

        public VisionerConfig conf;

        public VisionerConfigForm(Form1 parent)
        {
            form = parent;
            InitializeComponent();
        }

        
        private void end_config_button_Click(object sender, EventArgs e)
        {
            string alphabet;
            string key;


            if (keyword_textbox.Text == "")
            {
                MessageBox.Show("Input keyword!");
                return;
            }

            if (russian_lang_radiobutton.Checked)
                alphabet = russian_alphabet;
            else if (english_lang_radiobutton.Checked)
                alphabet = english_alphabet;
            else // default value
                alphabet = english_alphabet;

            key = keyword_textbox.Text;

            foreach (var letter in key)
                if (!alphabet.Contains(letter))
                {
                    MessageBox.Show("Input key of choosen alphabet!");
                    return;
                }

            conf = new VisionerConfig(alphabet, key);
            form.encrypt_button.Enabled = true;
            form.decrypt_button.Enabled = true;
            this.Close();
        }
    }
}
