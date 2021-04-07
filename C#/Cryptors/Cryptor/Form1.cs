using cesaar.ConfigForms;
using cesaar.Cryptors;
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
    public partial class Form1 : Form
    {
        ICryptor letter_cryptor;
        ICryptor numeric_cryptor;


        string alphabet = "";
        string numeric_alphabet = "0123456789";


        public Form1()
        {
            InitializeComponent();
        }

        
        private void encrypt_button_Click(object sender, EventArgs e)
        {
            string text = unciphered_text_box.Text;
            
            for (int i = 0; i < text.Length; ++i)
                if (not_allowed_symbol(text[i]))
                {
                    MessageBox.Show("Input only number, syms of specified aphabet or spaces!");
                    return;
                }

            text = letter_cryptor.encrypt(text);
            ciphered_text.Text = numeric_cryptor.encrypt(text);

            binary_ciphered_text.Text = get_binary_string(ciphered_text.Text);
        }


        private bool not_allowed_symbol(char sym)
        {
            sym = Char.ToLower(sym);
            return !alphabet.Contains(sym) && !numeric_alphabet.Contains(sym) && sym != ' ' && sym != '\n';
        }

        
        private void decrypt_button_Click(object sender, EventArgs e)
        {
            string text = ciphered_text.Text;
            
            for (int i = 0; i < text.Length; ++i)
                if (not_allowed_symbol(text[i]))
                {
                    MessageBox.Show("Input only number, syms of specified aphabet or spaces!");
                    return;
                }

            text = letter_cryptor.decrypt(text);
            unciphered_text_box.Text = numeric_cryptor.decrypt(text);

            binary_unciphered_text.Text = get_binary_string(unciphered_text_box.Text);
        }

        
        private void configure_button_Click(object sender, EventArgs e) 
        {
            string algo_name;

            try
            {
                algo_name = algo_chooser.SelectedItem.ToString();
            }
            catch
            {
                MessageBox.Show("Input cipher algorithm!");
                return;
            }

            if (algo_name == "Cesaar")
                cesaar_crypto_logic();
            else if (algo_name == "Visioner")
                visioner_crypto_logic();
            else if (algo_name == "Xor")
                xor_crypto_logic();
            
        }


        private void cesaar_crypto_logic()
        {
            CesaarConfigForm config_form = new CesaarConfigForm(this);
            CesaarConfig conf;

            config_form.ShowDialog(this);
            conf = config_form.conf;

            if (conf == null)
            {
                MessageBox.Show("Dont close configuration window!");
                return;
            }

            alphabet = conf.Alphabet;
            letter_cryptor = new Cesaar_Cryptor(conf);
            numeric_cryptor = new Cesaar_Cryptor(conf.Key, numeric_alphabet);

        }


        private void visioner_crypto_logic()
        {
            VisionerConfigForm config_form = new VisionerConfigForm(this);
            VisionerConfig conf;

            config_form.ShowDialog(this);
            conf = config_form.conf;

            if (conf == null)
            {
                MessageBox.Show("Dont close configuration window!");
                return;
            }

            alphabet = conf.Alphabet;
            letter_cryptor = new Visioner_Cryptor(conf);
            numeric_cryptor = new Visioner_Cryptor(conf.Keys, numeric_alphabet);
        }


        private void xor_crypto_logic()
        {
            XorConfigForm config_form = new XorConfigForm(this);
            Configs.XorConfig conf;

            config_form.ShowDialog(this);
            conf = config_form.conf;

            if (conf == null)
            {
                MessageBox.Show("Dont close configuration window!");
                return;
            }


            alphabet = conf.Alphabet;
            letter_cryptor = new XorCryptor(conf);
            numeric_cryptor = new XorCryptor(numeric_alphabet, conf.Keys);

            binary_key_textbox.Text = get_binary_string(conf.Keys);
        }


        public void keygen_button_Click(object sender, EventArgs e)
        {
            int text_size = Math.Max(unciphered_text_box.Text.Length, ciphered_text.Text.Length);
            byte[] proxy_keys = XorStringGenerator.generate_random_sequence(text_size);
            int[] keys = new int[text_size];

            for (int i = 0; i < text_size; ++i)
                keys[i] = (int)proxy_keys[i];

            letter_cryptor = new XorCryptor(alphabet, keys);
            numeric_cryptor = new XorCryptor(numeric_alphabet, keys);
        }


        private string get_binary_string(int[] keys)
        {
            string result = "";

            foreach (var key in keys)
                result += Convert.ToString(key, 2).PadLeft(8, '0') + " ";

            return result;
        }


        private string get_binary_string(string keys)
        {
            int[] int_keys = new int[keys.Length];

            for (int i = 0; i < keys.Length; ++i)
            {
                if (numeric_alphabet.Contains(keys[i]))
                    int_keys[i] = numeric_alphabet.IndexOf(keys[i]);
                else if (alphabet.Contains(keys[i]))
                    int_keys[i] = alphabet.IndexOf(keys[i]);
            }

            return get_binary_string(int_keys);
        }
    }
}
