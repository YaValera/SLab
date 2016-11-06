using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Slab5
{
    public partial class Form1 : Form
    {
        Change ch;

        public Form1()
        {
            InitializeComponent();
            encrypEnable();
        }        

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = ch.encryp(textBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ch = new Change();

            if (radioButton1.Checked)
            {                
                ch.CreateKey();
                gloKeytBox.Text = ch.glKey.ToString();
                prKeytBox.Text = ch.prKey.ToString();
                puKeytBox.Text = ch.pubKey.ToString();
            }
            else
            {
                ch.glKey = Int32.Parse(gloKeytBox.Text);
                ch.prKey = Int32.Parse(prKeytBox.Text);
                ch.pubKey = Int32.Parse(puKeytBox.Text);
            }

            encrypEnable(true);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = ch.decryp(textBox1.Text);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        public void encrypEnable(bool a = false)
        {
            textBox1.Enabled = a;
            textBox2.Enabled = a;
            button2.Enabled = a;
            button3.Enabled = a;            
        }
    }
}
