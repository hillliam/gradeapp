using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gradeapp
{
    public partial class examedit : Form
    {
        private exam theexam;
        public examedit(ref exam it)
        {
            InitializeComponent();
            theexam = it;
            textBox1.Text = theexam.getname();
            numericUpDown1.Value = theexam.getoverallvalue();
            textBox2.Text = theexam.getmarks().ToString();
            numericUpDown2.Value = (decimal)theexam.gettotalmarks();
            dateTimePicker1.Value = theexam.getstartdate();

        }

        private void button1_Click(object sender, EventArgs e)
        {// save and close
            theexam.setname(textBox1.Text);
            theexam.setoverallvalue((int)numericUpDown1.Value);
            theexam.setmarks(float.Parse(textBox2.Text));
            theexam.settotalmarks((float)numericUpDown2.Value);
            theexam.setstartdate(dateTimePicker1.Value);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {//close
            this.Close();
        }
    }
}
