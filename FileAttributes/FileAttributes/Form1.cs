using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;

namespace FileAttributes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, System.EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;

                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                        richTextBox1.Text = fileContent;
                    }
                }
            }

            MessageBox.Show(fileContent, "File Content at path: " + filePath, MessageBoxButtons.OK);
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            StreamWriter SW;
            SaveFileDialog SFD = new SaveFileDialog();
            SFD.FileName = richTextBox1.Text;
            SFD.FileName = "MyTXT";
            SFD.Filter = "TXT (*.txt)|*.txt|RTF (*.rtf)|*.rtf";

            if (SFD.ShowDialog() == DialogResult.OK)
            {
                SW = new StreamWriter(SFD.FileName);
                SW.Write(richTextBox1.Text.ToString());
                SW.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
        }
    }
}
