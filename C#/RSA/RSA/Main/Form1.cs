using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using System.Net.Http.Headers;
using EulerAndFastPower.RSA;
using EulerAndFastPower.EratostheneSieve;

namespace EulerAndFastPower
{
    /*
     * This is just wrapper that have buttons
     * and call form for each button click
     */
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void fast_power_button_Click(object sender, EventArgs e)
        {
            FastPowForm form = new FastPowForm();
            form.Show();
        }


        private void extended_gcd_button_Click(object sender, EventArgs e)
        {
            ExtendedGCDForm form = new ExtendedGCDForm();
            form.Show();
        }

        
        private void primaryTestButton_Click(object sender, EventArgs e)
        {
            PrimaryTestForm form = new PrimaryTestForm();
            form.Show();
        }

        
        private void generatePrimeNumberButton_Click(object sender, EventArgs e)
        {
            GeneratePrimeForm form = new GeneratePrimeForm();
            form.Show();
        }

        
        private void rsaButton_Click(object sender, EventArgs e)
        {
            RSAForm form = new RSAForm();
            form.Show();
        }


        private void eratistheneSieveButton_Click(object sender, EventArgs e)
        {
            EratostheneSieveForm form = new EratostheneSieveForm();
            form.Show();
        }
    }
}
