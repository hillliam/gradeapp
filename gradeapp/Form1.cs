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

namespace gradeapp
{
    public partial class Form1 : Form
    {
        private List<year> years;
        private int selectedyear;
        private int selectedsubject;
        private int selectedexam;
        private int selectedcoursework;
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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != 0)
                selectedyear = listBox1.SelectedIndex;
            else
                selectedyear = -1;
        }
        private void updateyear()
        {
            listBox1.Items.Clear();
            for (int i = 0; i != years.Count; i++)
                listBox1.Items.Add(years[i].print());
        }
        private void updatesubjects()
        {
            listBox2.Items.Clear();
            for (int i = 0; i != years[selectedyear].getsize(); i++)
                listBox2.Items.Add(years[selectedyear].getsubject(i));
        }
        private void updateexams()
        {
            listBox4.Items.Clear();
            for (int i = 0; i != years[selectedyear].getsubject(selectedsubject).examssize(); i++)
                listBox4.Items.Add(years[selectedyear].getsubject(selectedsubject).getexam(i));
        }
        private void updatecoursework()
        {
            listBox3.Items.Clear();
            for (int i = 0; i != years[selectedyear].getsubject(selectedsubject).courseworksize(); i++)
                listBox3.Items.Add(years[selectedyear].getsubject(selectedsubject).getcoursework(i));
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex != 0)
                selectedsubject = listBox2.SelectedIndex;
            else
                selectedsubject = -1;
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        { // load
            OpenFileDialog b = new OpenFileDialog();
            if (b.ShowDialog() == DialogResult.OK)
            {
                StreamReader a = new StreamReader(b.FileName);
                int numofyears = int.Parse(a.ReadLine());
                for (int i = 0; i != numofyears; i++)
                {
                    year c = new year();
                    c.loadsubjects(ref a);
                    years.Add(c);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        { // save
            SaveFileDialog a = new SaveFileDialog();
            if (a.ShowDialog() == DialogResult.OK)
            {
                StreamWriter b = new StreamWriter(a.FileName);
                b.WriteLine(years.Count);
                for (int i = 0; i != years.Count; i++ )
                {
                    years[i].savesubject(ref b);
                }
            }
        }
    }
}
