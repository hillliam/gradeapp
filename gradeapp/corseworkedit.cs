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
    public partial class corseworkedit : Form
    {
        public corsework thework;
        private int i;
        public corseworkedit(ref corsework it,int index)
        {
            InitializeComponent();
            i = index;
            thework = it;
            textBox1.Text = thework.getname();
            numericUpDown1.Value = thework.getoverallvalue();
            textBox2.Text = thework.getmarks().ToString();
            numericUpDown2.Value = (decimal)thework.gettotalmarks();
            dateTimePicker1.Value = thework.getduedate();
        }

        private void button1_Click(object sender, EventArgs e)
        {// save and close
            thework.setname(textBox1.Text);
            thework.setoverallvalue((int)numericUpDown1.Value);
            thework.setmarks(float.Parse(textBox2.Text));
            thework.settotalmarks((float)numericUpDown2.Value);
            thework.setduedate(dateTimePicker1.Value);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox3.Text = thework.calculateremaningtime().ToString();
        }
    }
}
