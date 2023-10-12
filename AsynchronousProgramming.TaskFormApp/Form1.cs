using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsynchronousProgramming.TaskFormApp
{
    public partial class Form1 : Form
    {
        public int counter { get; set; } = 0;
        public Form1()
        {
            InitializeComponent();
        }
        //private void BtnReadFile_Click(object sender, EventArgs e)
        //{
        //    string data = readFile();
        //    richTextBox1.Text = data;
        //}
        private async void BtnReadFile_Click(object sender, EventArgs e)
        {
            string data =await readFileAsync();
            richTextBox1.Text = data;
        }

        private void BtnCounter_Click(object sender, EventArgs e)
        {
            counter++;
            textBox1.Text = counter.ToString();

        }
        private string readFile()
        {
            string data=string.Empty;
            using (StreamReader s = new StreamReader("file.txt"))
            {
                Thread.Sleep(5000);

                data = s.ReadToEnd();   
            }
            return data;
        }
        private async Task<string> readFileAsync()
        {
            string data = string.Empty;
            using (StreamReader s = new StreamReader("file.txt"))
            {
               Task<string> myTask =  s.ReadToEndAsync();
                await Task.Delay(5000);
                data=await myTask;
            }
            return data;
        }
    }
}
