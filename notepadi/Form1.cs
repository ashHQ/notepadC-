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

namespace notepadi
{
    public partial class Notepad : Form
    {

        private OpenFileDialog openFileDialog;
        private SaveFileDialog saveFileDialog;
        private FontDialog fontDialog;
        public Notepad()
        {
            InitializeComponent();
        }

        private void Notepad_Load(object sender, EventArgs e)
        {

        }
        private void NewFile()
        {
            try
            {
                if (! string.IsNullOrEmpty(this.richTextBox1.Text))
                {
                    MessageBox.Show("you should Save file");
                }
                else
                {
                    this.richTextBox1.Text = string.Empty;
                    this.Text = "untitled";
                }
            }
            catch (Exception ex) 
            {

            }
            finally
            {

            }

        }
        private void OpenFile()
        {
            try
            {
                openFileDialog = new OpenFileDialog();
                if(openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.richTextBox1.Text = File.ReadAllText(openFileDialog.FileName);
                    this.Text = openFileDialog.FileName;
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Error wile trying to open file");
            }
            finally
            {
                openFileDialog = null;
            }
        }
        private void SaveFile()
        {
            try
            {
                if (!string.IsNullOrEmpty(this.richTextBox1.Text))
                {


                    saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Text File (*.txt) | *.txt";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(saveFileDialog.FileName, this.richTextBox1.Text);
                        this.Text = saveFileDialog.FileName;
                    }
                }
                else
                {
                    MessageBox.Show("the file is empty");
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }
        private void SaveFileAs()
        {
            try
            {
                if (!string.IsNullOrEmpty(this.richTextBox1.Text))
                {


                    saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Text File (*.txt) | *.txt! All Files(*.*)| *.*";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(saveFileDialog.FileName, this.richTextBox1.Text);
                        this.Text = saveFileDialog.FileName;
                    }
                }
                else
                {
                    MessageBox.Show("the file is empty");
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewFile();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileAs();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch(Exception ex) 
            { 

            }
            finally 
            {
                
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                fontDialog = new FontDialog();
                if (fontDialog.ShowDialog() == DialogResult.OK)
                {
                    this.richTextBox1.Font = fontDialog.Font;
                }
            }
            catch(Exception ex)
            {
                
            }
            finally
            {

            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = "";
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (wordWrapToolStripMenuItem.Checked == true)
            {
                wordWrapToolStripMenuItem.Checked = false;
                richTextBox1.WordWrap = false;
            
            }
            else
            {
                wordWrapToolStripMenuItem.Checked = true;
                richTextBox1.WordWrap = true;
            }
        }

        private void highlightTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionBackColor = Color.Yellow;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(richTextBox1.Text, richTextBox1.Font, Brushes.Black, 12, 10);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length > 0)
            {
                copyToolStripMenuItem.Enabled = true;
                cutToolStripMenuItem.Enabled = true;
            }
            else
            {
                copyToolStripMenuItem.Enabled = false;
                cutToolStripMenuItem.Enabled = false;
            }
        }
    }
}
