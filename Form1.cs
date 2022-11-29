using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace Editor_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox obj = richTextBox;
            obj.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox obj = richTextBox;
            obj.Redo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox obj = richTextBox;
            obj.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox obj = richTextBox;
            obj.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox obj = richTextBox;
            obj.Paste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox obj = richTextBox;
            obj.SelectAll();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "txt files(*.txt)|*.txt ";
            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                try
                {
                    string[] lines = File.ReadAllLines(openFileDialog.FileName);
                    foreach (string line in lines)
                    {
                        richTextBox.Text += line + "\n";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.Message);
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "txt files(*.txt)| *.txt ";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                String filename = saveFileDialog.FileName;
                File.WriteAllText(filename, richTextBox.Text);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox.SelectionFont = fontDialog.Font;
            }
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.AllowFullOpen = true;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox.SelectionColor = colorDialog.Color;
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.Text = " ";
        }
    }
}
