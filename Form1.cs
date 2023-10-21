using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ksuTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Length != 8)
            {
                MessageBox.Show("输入序列号");
                return;
            }

            string serial = textBox1.Text.ToLower();

            OpenFileDialog openFileDialog = new OpenFileDialog();

            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName; // 你的文件路径
                long offset = 0x1AD8106; // 要修改的偏移地址
                string str = serial;// "2ddab6cb";
                byte[] newData = System.Text.Encoding.UTF8.GetBytes(str);

                using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Write))
                {
                    fileStream.Seek(offset, SeekOrigin.Begin);
                    fileStream.Write(newData, 0, newData.Length);

                    fileStream.Close();

                    MessageBox.Show("修改完成");
                }
            }
        }
    }
}
