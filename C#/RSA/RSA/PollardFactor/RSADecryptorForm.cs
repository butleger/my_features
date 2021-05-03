using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EulerAndFastPower.RSA;

namespace RSA.PollardFactor
{
    public partial class RSADecryptorForm : Form
    {
        // offset using in Mubarakov encryption
        private const int MUBARAKOB_ENCODING_OFFSET = 16;


        public RSADecryptorForm()
        {
            InitializeComponent();
        }


        /*
         * This is entry point for PollardAlgo, it should 
         * find all needed value for cryptografic functions
         * and take care of correct values in GUI
         */
        private void decryptButton_Click(object sender, EventArgs eventArg)
        {
            BigInteger N, e;
            try
            {
                e = BigInteger.Parse(eInput.Text);
                N = BigInteger.Parse(nInput.Text);
            }
            catch
            {
                MessageBox.Show("N or E is incorrect!");
                return;
            }

            if (N < 2 || e < 2)
            {
                MessageBox.Show("N and E should be more than 1!");
                return;
            }

            PollardFactor factorer = new PollardFactor();

            BigInteger factor;
            BigInteger iterations;
            Logger timeLog = new Logger(reportOutput);
            (factor, iterations) = factorer.GetOneDivider( N, timeLog );

            BigInteger p, q;
            
            p = factor;
            q = N / p;
            RSACryptor rsa = RSACryptor.UnsafeFactory(p, q, e);

            pOutput.Text = p.ToString();
            qOutput.Text = q.ToString();
            dOutput.Text = rsa.D.ToString();

            BigInteger ciphered;
            try
            {
                ciphered = BigInteger.Parse(cipheredText.Text);
            }
            catch
            {
                MessageBox.Show("Bad ciphered text");
                return;
            }

            BigInteger encodedText = new BigInteger(rsa.Decrypt(ciphered));
            uncipheredText.Text = BigIntToMubarakov(encodedText);
        }


        /*
         * This is convertion of one deciphered BigInteger 
         * to chars using encryptions of Mubarakov
         */
        private static string BigIntToMubarakov(BigInteger encodedText)
        {
            string alphabet = "АБВГДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдежзийклмнопрстуфхцчшщъыьэюя";
            int offset = MUBARAKOB_ENCODING_OFFSET;
            string result = "";


            while (encodedText != 0)
            {
                int encodedIndex = (int)(encodedText % 100) - offset;
                encodedText /= 100;
                result = alphabet[encodedIndex] + result;

            }
            return result;
        }
    }
}
