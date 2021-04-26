using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EulerAndFastPower.RSA
{
    /*
     * RSA form handler
     */
    public partial class RSAForm : Form
    {
        RSACryptor cryptor;


        public RSAForm()
        {
            InitializeComponent();
        }


        /*
         * This click activate RSACryptor that generates values
         * and forms initialize by this values, also in this method 
         * added features with calculating time of 2 rsa constructors :
         *      one threaded(syncronized)
         *      multy threaded(asyncronized)
         * and showing report about this
         */
        private void generateKeysButton_Click(object sender, EventArgs e)
        {
            int keyLength;
            try
            {
                keyLength = int.Parse(keyLengthInput.Text);
            }
            catch
            {
                MessageBox.Show("Input keylength!");
                return;
            }

            if (keyLength < 64)
            {
                MessageBox.Show("Length of key should be more than 63!");
                return;
            }

            Stopwatch timer = new Stopwatch();
            timer.Start();
            cryptor = new RSACryptor(keyLength);
            timer.Stop();

            pIO.Text = cryptor.P.ToString();
            qIO.Text = cryptor.Q.ToString();

            NOutput.Text = cryptor.N.ToString();
            eulerFunctionOutput.Text = cryptor.EulerValue.ToString();
            eOutput.Text = cryptor.E.ToString();
            dOutput.Text = cryptor.D.ToString();

            MessageBox.Show("Start calculating sync constructor");

            TimeSpan rsaSyncTime = GetTimeOfSyncConstructor(keyLength); 
            string timeReport = GetTimeReport(timer.Elapsed, rsaSyncTime);
            MessageBox.Show(timeReport);
        }

        
        /*
         * Incapsulate logic of calculating 
         * timing of syncronized constructor
         */
        private TimeSpan GetTimeOfSyncConstructor(int keyLength)
        {
            Task<TimeSpan> syncRSATimeCounterTask = new Task<TimeSpan>(() => {
                return RSACryptor.TimeOfRSASynchronizedConstructor(keyLength);
            });
            syncRSATimeCounterTask.Start();
            syncRSATimeCounterTask.Wait();
            return syncRSATimeCounterTask.Result;
        }


        /*
         * Prepare report for timing( make it beauty and incapsulated )
         */
        private string GetTimeReport(TimeSpan asyncRSATime, TimeSpan syncRSATime)
        {
            string result = "";
            result += $"Asyncronize time : {asyncRSATime}\n";
            result += $"Syncronize time  :  {syncRSATime}\n";
            return result;
        }


        /*
         * Just encrypt text in unciphered textbox
         */
        private void cipherButton_Click(object sender, EventArgs e)
        {
            cipheredTextIO.Text = cryptor.Encrypt(uncipheredTextIO.Text);
        }


        /*
         * Just decrypt text in ciphered textbox 
         * Take care! Decrypt may throw exception if it cant 
         * parse text in unciphered textbox
         */
        private void uncipherButton_Click(object sender, EventArgs e)
        {
            try
            {
                uncipheredTextIO.Text = cryptor.Decrypt(cipheredTextIO.Text);
            }
            catch
            {
                MessageBox.Show("Some bad things occured!");
                return;
            }
        }
    }
}
