using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cesaar
{
    public class XorStringGenerator
    {
        static private double ones_quantity = 0.5;


        static public byte[] generate_random_sequence(int string_size)
        {
            int bits_in_string = get_amount_of_bits_in_str(string_size);
            int ones_in_string = get_amount_of_ones_in_str(bits_in_string);
            

            bool[] proxy_array = new bool[bits_in_string];

            for (int i = 0; i < proxy_array.Length; ++i)
                proxy_array[i] = false;

            for (int i = 0; i < ones_in_string; ++i) // init true only part of array
                proxy_array[i] = true;

            shuffle_array(proxy_array);


            alert_about_key(proxy_array);


            return convert_bools_to_bytes(proxy_array);
        }


        static void alert_about_key(bool[] generated_key)
        {
            string message = "Generated key: \n";


            for (int i = 0; i < generated_key.Length; ++i)
            {
                if (i % 8 == 0 && i != 0)
                    message += ' ';
                message += generated_key[i] ? '1' : '0';
            }

            MessageBox.Show(message);
        }


        static private int get_amount_of_bits_in_str(int size)
        {
            return size * 8; // 8 bits in byte
        }

        static private int get_amount_of_ones_in_str(int bits)
        {
            return (int)(bits * ones_quantity);
        }


        static private bool[] shuffle_array(bool[] arr)
        {
            Random rand = new Random();

            for (int i = arr.Length - 1; i >= 1; i--)
            {
                int j = rand.Next(i + 1);

                bool tmp = arr[j];
                arr[j] = arr[i];
                arr[i] = tmp;
            }

            return arr;
        }


        static private byte[] convert_bools_to_bytes(bool[] array)
        {
            byte[] result = new byte[array.Length/8];
            byte symbol;


            for (int i = 0; i < array.Length; i+=8)
            {
                symbol = convert_bool_to_byte(array, i);
                result[i/8] = symbol;
            }
            return result;
        }


        static private void print_array(byte[] arr)
        {
            string message = "Generated array in generator:\n";

            foreach (var b in arr)
                message += $"{b} ";

            MessageBox.Show(message);
        }


        static private byte convert_bool_to_byte(bool[] array, int start_index = 0)
        {
            byte result = (byte)0;

            for (int i = 7; i >= 0; --i)
                if (array[i + start_index])
                    result += (byte)((byte)1 << (7 - i)); // convert bool to its bytes


            return result;
        }

    }
}
