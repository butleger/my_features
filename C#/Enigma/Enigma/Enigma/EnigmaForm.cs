using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rotors = Enigma.EnigmaMachine.RotorTypes;
using Reflectors = Enigma.EnigmaMachine.ReflectorTypes;


namespace Enigma
{
    public partial class EnigmaForm : Form
    {
        public EnigmaForm()
        {
            InitializeComponent();

        }

        private void cipherButton_Click(object sender, EventArgs e)
        {
            int firstRotorOffset, secondRotorOffset, thirdRotorOffset;
            int firstRotorNumber, secondRotorNumber, thirdRotorNumber;
            int reflectorNumber;
            string commutatorsString;

            try
            {
                firstRotorNumber    = (int)firstRotorPicker.Value;
                firstRotorOffset    = (int)firstRotorPositionInput.Value;
                
                secondRotorNumber   = (int)secondRotorPicker.Value;
                secondRotorOffset   = (int)secondRotorPositionInput.Value;
                
                thirdRotorNumber    = (int)thirdRotorPicker.Value;
                thirdRotorOffset    = (int)thirdRotorPositionInput.Value;

                reflectorNumber     = (int)reflectorPicker.Value;

                commutatorsString   = commutatorInput.Text;
            }
            catch (InvalidCastException exception)
            {
                MessageBox.Show("You input bad values in the settings!");
                return;
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Internal error: {exception.Message}");
                return;
            }

            EnigmaMachine cipherer = new EnigmaMachine(
                (Rotors)firstRotorNumber,
                firstRotorOffset,
                (Rotors)secondRotorNumber,
                secondRotorOffset,
                (Rotors)thirdRotorNumber,
                thirdRotorOffset,
                (Reflectors)reflectorNumber,
                commutatorsString
            );

            cipheredText.Text = cipherer.CipherText(uncipheredText.Text);
        }

        private void uncipherButton_Click(object sender, EventArgs e)
        {
            int firstRotorOffset, secondRotorOffset, thirdRotorOffset;
            int firstRotorNumber, secondRotorNumber, thirdRotorNumber;
            int reflectorNumber;
            string commutatorsString;

            try
            {
                firstRotorNumber    = (int)firstRotorPicker.Value;
                firstRotorOffset    = (int)firstRotorPositionInput.Value;
                
                secondRotorNumber   = (int)secondRotorPicker.Value;
                secondRotorOffset   = (int)secondRotorPositionInput.Value;
                
                thirdRotorNumber    = (int)thirdRotorPicker.Value;
                thirdRotorOffset    = (int)thirdRotorPositionInput.Value;

                reflectorNumber     = (int)reflectorPicker.Value;

                commutatorsString   = commutatorInput.Text;
            }
            catch (InvalidCastException exception)
            {
                MessageBox.Show("You input bad values in the settings!");
                return;
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Internal error: {exception.Message}");
                return;
            }

            EnigmaMachine uncipherer = new EnigmaMachine(
                (Rotors)firstRotorNumber,
                firstRotorOffset,
                (Rotors)secondRotorNumber,
                secondRotorOffset,
                (Rotors)thirdRotorNumber,
                thirdRotorOffset,
                (Reflectors)reflectorNumber,
                commutatorsString
            );

            uncipheredText.Text = uncipherer.UncipherText(cipheredText.Text);
        }

        private void thirdRotorPositionInput_ValueChanged(object sender, EventArgs e)
        {
            // just put new value to label
            thirdRotorPositionTranslator.Text = 
                new string(EnigmaMachine.Alphabet[((int)thirdRotorPositionInput.Value)], 1);
        }

        private void secondRotorPositionInput_ValueChanged(object sender, EventArgs e)
        {
            // just put new value to label
            secondRotorPositionTranslator.Text =
                new string(EnigmaMachine.Alphabet[((int)secondRotorPositionInput.Value)], 1);
        }

        private void firstRotorPositionInput_ValueChanged(object sender, EventArgs e)
        {
            // just put new value to label
            firstRotorPositionTranslator.Text =
                new string(EnigmaMachine.Alphabet[((int)firstRotorPositionInput.Value)], 1);
        }
    }
}

