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
     * This is entry point for MillerRabbin algo
     */
    public partial class PrimaryTestForm : Form
    {
        private string soccessMessage = "It probably prime!";
        private string failMessage    = "It is not prime!";
        
        private IPrimaryTester tester;

        
        public PrimaryTestForm()
        {
            InitializeComponent();
        }


        /*
         * This function gets number from number textbox 
         * if it cant show message and return
         * if can get number check it ( <= 0 )
         * and if all is good call MillerRabbin
         * and place message in hidden label
         */
        private void testPrimeButton_Click(object sender, EventArgs e)
        {
            BigInteger number;
            tester = new RabbinMiller();
            
            try
            {
                number = BigInteger.Parse(numberInput.Text);
            }
            catch
            {
                MessageBox.Show("Input only digits!");
                return;
            }

            if (number <= 0)
            {
                MessageBox.Show("Input number more than 0!");
                return;
            }


            if (tester.TestPrime(number))
            {
                isPrimeLabel.Text = soccessMessage;
                return;
            }
            else
            {
                isPrimeLabel.Text = failMessage;
                return;
            }

        }
    }
}
