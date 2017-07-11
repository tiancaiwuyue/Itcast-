using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Itcast视频WinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string msg = textBox1.Text.Trim();
            //审核的
            StringBuilder sbMod = new StringBuilder();
            StringBuilder sbBanned = new StringBuilder();
            string[] lines = File.ReadAllLines("1.txt", Encoding.Default);

            for (int i = 0; i < lines.Length; i++)
            {   
                string[] parts = lines[i].Split('=');
                if (parts[1] == "{MOD}")
                {
                    sbMod.AppendFormat("{0}|", parts[0]);
                }
                else if (parts[1] == "BANNED")
                {
                    sbBanned.AppendFormat("{0}|",parts[0]);
                }
            }
            sbMod.Remove(sbMod.Length - 1, 1);
            sbBanned.Remove(sbBanned.Length - 1, 1);
            string userInput = textBox1.Text.Trim();
            if (Regex.IsMatch(userInput, sbBanned.ToString()))
            {
                MessageBox.Show("禁止发帖");
            }
            else if (Regex.IsMatch(userInput, sbMod.ToString()))
            {
                MessageBox.Show("需要审核");
            }
            else
            {
                MessageBox.Show("可以发帖。");
            }
        }

        private string ConvertUBBToHtml(string ubb)
        {
            ubb = Regex.Replace(ubb,@"\[b\](.+?)\[/b\]","<b>$1</b>",RegexOptions.IgnoreCase);
            return ubb;
        }
    }
}
