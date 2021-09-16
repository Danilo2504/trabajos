using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Presencial
{
    public partial class Form1 : Form
    {

        Form2 f2;
        
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Title = "Guardar archivo";
            saveFileDialog1.FileName = "";
            saveFileDialog1.Filter = "Archivos txt (*.txt)|*.txt|Tdos los archivos (*.*)|*.*";
            saveFileDialog1.ShowDialog();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Abrir archivo";
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Archivos txt (*.txt)|*.txt|Archivos rtf (*.rtf)|*.rtf|Todos los archivos (*.*)|*.*";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog1.FileName.EndsWith("txt"))
                {
                    richTextBox1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                }
                else if (openFileDialog1.FileName.EndsWith("rtf"))
                {
                    richTextBox1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.RichText);
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Trim() != "")
            {
                DialogResult r = MessageBox.Show("¿ Desea guardar los cambios hechos ?", "Editor de texto", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (r == DialogResult.No)
                {
                    richTextBox1.Clear();
                }
                if (r == DialogResult.Yes) {
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Title = "Guardar archivo";
                    saveFileDialog1.FileName = "";
                    saveFileDialog1.Filter = "Archivos txt (*.txt)|*.txt|Tdos los archivos (*.*)|*.*";
                    grabar();
                }
            }   
        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            f2 = new Form2();
            f2.Show();
            

        }

        private void grabar()
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (System.IO.File.Exists(saveFileDialog1.FileName))
                {
                    string txt = saveFileDialog1.FileName;

                    System.IO.StreamWriter txtguardar = System.IO.File.CreateText(txt);
                    txtguardar.Write(richTextBox1.Text);
                    txtguardar.Flush();
                    txtguardar.Close();
                }
                else
                {
                    string txt = saveFileDialog1.FileName;

                    System.IO.StreamWriter txtguardar = System.IO.File.CreateText(txt);
                    txtguardar.Write(richTextBox1.Text);
                    txtguardar.Flush();
                    txtguardar.Close();
                }
            }

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Title = "Guardar archivo";
            saveFileDialog1.FileName = "";
            saveFileDialog1.Filter = "Archivos txt (*.txt)|*.txt|Tdos los archivos (*.*)|*.*";
            grabar();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            PrintDialog p1 = new PrintDialog();
            PrintDocument p2 = new PrintDocument();
            OpenFileDialog op1 = new OpenFileDialog();
            p1.Document = p2;
            p1.AllowSelection = true;
            p1.AllowSomePages = true;

            if (p1.ShowDialog() == DialogResult.OK)
            {
                p2.Print();
            }
        }
        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog1 = new FontDialog();
            fontDialog1.ShowDialog();

            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionFont = fontDialog1.Font;
            }
        }

        private void toolStripSplitButton2_ButtonClick(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog1 = new ColorDialog();
            colorDialog1.ShowDialog();

            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionColor = colorDialog1.Color;
            }
        }
    }
}
