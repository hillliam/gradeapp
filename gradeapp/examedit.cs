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
        public exam theexam;
        private int i;
        public examedit(ref exam it, int index)
        {
            InitializeComponent();
            i = index;
            theexam = it;
            textBox1.Text = theexam.getname();
            numericUpDown1.Value = theexam.getoverallvalue();
            textBox2.Text = theexam.getmarks().ToString();
            numericUpDown2.Value = (decimal)theexam.gettotalmarks();
            dateTimePicker1.Value = theexam.getstartdate();
            dateTimePicker2.Value = theexam.getstartdate() + theexam.getduration();
        }

        private void button1_Click(object sender, EventArgs e)
        {// save and close
            theexam.setname(textBox1.Text);
            theexam.setoverallvalue((int)numericUpDown1.Value);
            theexam.setmarks(float.Parse(textBox2.Text));
            theexam.settotalmarks((float)numericUpDown2.Value);
            theexam.setstartdate(dateTimePicker1.Value);
            theexam.setduration(dateTimePicker1.Value - dateTimePicker2.Value);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {//close
            this.Close();
        }
    }
}
