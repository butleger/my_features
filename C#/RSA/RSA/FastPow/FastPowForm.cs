using Microsoft.Win32;
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
     * Entry point for FastPowResolver
     */
    public partial class FastPowForm : Form
    {
        public FastPowForm()
        {
            InitializeComponent();
        }


        /*
         * Just check values from textboxes,
         * if something goes wrong call messageboxes
         * if all is good calc fastpower and output it into
         * messagebox
         */
        private void calc_button_Click(object sender, EventArgs e)
        {
            BigInteger number, power, module;
            
            try
            {
                module = BigInteger.Parse(module_textbox.Text);
                number = BigInteger.Parse(number_textbox.Text);
                power  = BigInteger.Parse(power_textbox.Text );
            }
            catch
            {
                MessageBox.Show("Input module, power and number");
                return;
            }

            if (module <= 0 || power < 0 || number <= 0)
            {
                MessageBox.Show("Module should be more than 0 and power more than -1 and number more than 0");
                return;
            }

            FastPowResolver calc = new FastPowResolver();
            MessageBox.Show($"Result = {calc.Power(number, power, module)}");
        }
    }
}
