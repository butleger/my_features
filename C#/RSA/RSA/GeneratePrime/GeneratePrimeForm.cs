using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EulerAndFastPower
{
    /*
     * Entry point for My Prime Generator
     */
    public partial class GeneratePrimeForm : Form
    {
        public GeneratePrimeForm()
        {
            InitializeComponent();
        }


        /*
         * Get amount of bits from textbox, if all is good call Generator
         * and place number from it into another textbox
         */
        private void generatePrimeButton_Click(object sender, EventArgs e)
        {
            int amountOfBits;

            try
            {
                amountOfBits = int.Parse(bitsNumberInput.Text);
            }
            catch
            {
                MessageBox.Show("Input amount if bits!");
                return;
            }

            if (amountOfBits <= 0)
            {
                MessageBox.Show("Number should be more than 0!");
                return;
            }

            PrimeNumberRandomizer primeRandom = new PrimeNumberRandomizer();
            BigInteger primeNumber = primeRandom.GetRandom(amountOfBits);

            primeNumberOut.Text = primeNumber.ToString();
        }
    }
}
