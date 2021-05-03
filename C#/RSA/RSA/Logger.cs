using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSA
{
    class Logger
    {
        private RichTextBox textBoxStream;
        private FileStream fileStream;
        private LoggerType type;

        enum LoggerType
        {
            MessageBox,
            TextBox,
            File
        };

        public Logger()
        {
            type = LoggerType.MessageBox;
        }


        public Logger(RichTextBox outStream)
        {
            textBoxStream = outStream;
            type = LoggerType.TextBox;
        }


        public void Log(string info)
        {
            switch (type)
            {
                case LoggerType.TextBox:
                    textBoxStream.Text += info;
                    break;
                case LoggerType.MessageBox:
                    MessageBox.Show(info);
                    break;
            }
        }
    }
}
