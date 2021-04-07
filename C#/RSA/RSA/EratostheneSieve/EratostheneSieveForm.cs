using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// this typedef also used in EratostheneSieve so if change here, change there
using Int = System.Int64;

namespace EulerAndFastPower.EratostheneSieve
{
    public partial class EratostheneSieveForm : Form
    {
        public EratostheneSieveForm()
        {
            InitializeComponent();
        }

        private void findPrimesButton_Click(object sender, EventArgs e)
        {
            Int topBound;
            try
            {
                topBound = Int.Parse(maxNumberInput.Text);
            }
            catch
            {
                MessageBox.Show("Input correct max number!");
                return;
            }

            if (topBound <= 0)
            {
                MessageBox.Show("Max number should be more than 0!");
                return;
            }


            EratostheneSieve primeGetter = new EratostheneSieve();

            List<Int> primes = primeGetter.FindPrimes(topBound);

            // remove bad and old data from output
            primeNumbersOutput.Text = "";
            foreach (var primeNumber in primes)
                primeNumbersOutput.Text += primeNumber.ToString() + " ";
        }
    }
}
