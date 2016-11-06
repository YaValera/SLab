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
        IRSAEncryptor encryptor;

        public Form1(IRSAEncryptor en)
        {
            InitializeComponent();
            encrypEnable();
            encryptor = en;
        }        

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = encryptor.Encryp(textBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                encryptor.CreateKey();
                gloKeytBox.Text = encryptor.GlobalKey.ToString();
                prKeytBox.Text = encryptor.PrivateKey.ToString();
                puKeytBox.Text = encryptor.PublicKey.ToString();
            }
            else
            {
                encryptor.GlobalKey = Int32.Parse(gloKeytBox.Text);
                encryptor.PrivateKey = Int32.Parse(prKeytBox.Text);
                encryptor.PublicKey = Int32.Parse(puKeytBox.Text);
            }

            encrypEnable(true);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = encryptor.Decryp(textBox1.Text);
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
