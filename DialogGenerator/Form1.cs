using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DialogGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.AddRange(new object[]
            {
                MessageBoxIcon.None,
                MessageBoxIcon.Error,
                MessageBoxIcon.Question,
                MessageBoxIcon.Warning,
                MessageBoxIcon.Information
            });
            comboBox1.SelectedIndex = 0;
            comboBox2.Items.AddRange(new object[]
            {
                MessageBoxButtons.OK,
                MessageBoxButtons.OKCancel,
                MessageBoxButtons.AbortRetryIgnore,
                MessageBoxButtons.YesNoCancel,
                MessageBoxButtons.YesNo,
                MessageBoxButtons.RetryCancel
            });
            comboBox2.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(textBox2.Text, textBox1.Text, (MessageBoxButtons)comboBox2.SelectedItem, (MessageBoxIcon)comboBox1.SelectedItem);
        }
    }
}
