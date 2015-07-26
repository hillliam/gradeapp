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
    public partial class Form1 : Form
    {
        private List<year> years;
        public Form1()
        {
            InitializeComponent();
            years = new List<year>();
        }

        private void button5_Click(object sender, EventArgs e)
        {//load subjects of that year
            if (listBox1.SelectedIndex != 0)
            {
                listBox2.Items.Clear();
                for (int i = 0; i != years[listBox1.SelectedIndex].getsize();i++)
                {
                    listBox2.Items.Add(years[listBox1.SelectedIndex].getsubject(i).name);
                }
            }
            else
                MessageBox.Show("please select a year");
        }

        private void button6_Click(object sender, EventArgs e)
        {// create new year
            years.Add(new year());
        }

        private void button7_Click(object sender, EventArgs e)
        {// remove year
            if (listBox1.SelectedIndex != 0)
                years.RemoveAt(listBox1.SelectedIndex);
            else
                MessageBox.Show("please select a year");
        }

        private void button8_Click(object sender, EventArgs e)
        {// load exams and coursework of that subject
            
        }

        private void button9_Click(object sender, EventArgs e)
        {// add subject
            years[listBox1.SelectedIndex].addsubject(new subject());
        }

        private void button10_Click(object sender, EventArgs e)
        {
            years[listBox1.SelectedIndex].removesubject(listBox2.SelectedIndex);
        }

        private void button11_Click(object sender, EventArgs e)
        {// edit coursework

        }

        private void button13_Click(object sender, EventArgs e)
        {// add coursework

        }

        private void button14_Click(object sender, EventArgs e)
        { // remove coursework

        }

        private void button12_Click(object sender, EventArgs e)
        { // edit exam

        }

        private void button15_Click(object sender, EventArgs e)
        { // add exam

        }

        private void button16_Click(object sender, EventArgs e)
        { // remove exam

        }

    }
}
