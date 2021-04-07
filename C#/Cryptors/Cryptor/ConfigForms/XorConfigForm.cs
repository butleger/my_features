using cesaar.Configs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cesaar.ConfigForms
{
    public partial class XorConfigForm : Form
    {
        Form1 parent;

        public XorConfig conf;

        string russian_alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        string english_alphabet = "abcdefghijklmnopqrstuvwxyz";

        byte[] randomed_keys;

        public XorConfigForm(Form1 form)
        {
            InitializeComponent();
            parent = form;
        }

        private void ok_button_Click(object sender, EventArgs e)
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

            conf = new XorConfig(alphabet, randomed_keys);
            parent.encrypt_button.Enabled = true;
            parent.decrypt_button.Enabled = true;
            this.Close();
        }


        private void random_key_button_Click(object sender, EventArgs e)
        {
            int key_size = 100;
            try
            {
                key_size = int.Parse(keyword_textbox.Text);
            }
            catch
            {
                MessageBox.Show("Input amount of symbols!");
                return;
            }


            randomed_keys = XorStringGenerator.generate_random_sequence(key_size);

            string key = "";


            for (int i = 0; i < randomed_keys.Length; ++i)
                if (russian_lang_radiobutton.Checked)
                    key += russian_alphabet[randomed_keys[i] % russian_alphabet.Length];
                else if (english_lang_radiobutton.Checked)
                    key += english_alphabet[randomed_keys[i] % english_alphabet.Length];

            keyword_textbox.Text = key;
        }
    }
}
