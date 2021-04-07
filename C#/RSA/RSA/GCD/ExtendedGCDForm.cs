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
     * Entry point for extended GCD
     */
    public partial class ExtendedGCDForm : Form
    {
        public ExtendedGCDForm()
        {
            InitializeComponent();
        }


        /*
         * This function just parse textboxes with 
         * numbers, check it for the right values,
         * call ExtendedGCD and put values from its result
         * to the form
         */
        private void calc_button_Click(object sender, EventArgs e)
        {
            BigInteger a, b;
            try
            {
                a = BigInteger.Parse(first_number_textbox.Text);
                b = BigInteger.Parse(second_number_textbox.Text);
            }
            catch
            {
                MessageBox.Show("Input first and second number!");
                return;
            }

            if (a <= 0 || b <= 0)
            {
                MessageBox.Show("both number should be more than 0");
                return;
            }

            ExtendedGCD solver = new ExtendedGCD(a, b);
            ExtendedGCDResult result = solver.Result;

            gcd_textbox.Text = result.Nod.ToString();
            x_label.Text = result.X.ToString();
            y_label.Text = result.Y.ToString();

        }
    }
}
