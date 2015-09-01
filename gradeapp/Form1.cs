// Copyright © Liam hill 2015
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
using Microsoft.VisualBasic;

namespace gradeapp
{
    public partial class Form1 : Form
    {
        private List<year> years;
        private int selectedyear;
        private int selectedsubject;
        private int selectedexam;
        private int selectedcoursework;
        private int lastyear;
        private int lastyear1;
        public Form1()
        {
            InitializeComponent();
            years = new List<year>();
            selectedyear = -1;
            selectedsubject = -1;
            selectedexam = -1;
            selectedcoursework = -1;
            lastyear = -1;
            lastyear1 = -1;
        }

        private void button5_Click(object sender, EventArgs e)
        {//load subjects of that year
            if (selectedyear != -1)
                years[selectedyear].setname(Interaction.InputBox("please enter a new name for year", "year name", years.Count.ToString()));
            else
                MessageBox.Show("please select a year");
        }

        private void button6_Click(object sender, EventArgs e)
        {// create new year
            year a = new year();
            a.setname(Interaction.InputBox("please enter a name for year", "year name", years.Count.ToString()));
            years.Add(a);
            updateyear();
        }

        private void button7_Click(object sender, EventArgs e)
        {// remove year
            if (selectedyear != -1)
            {
                years.RemoveAt(selectedyear);
                updateyear();
            }
            else
                MessageBox.Show("please select a year");
        }

        private void button8_Click(object sender, EventArgs e)
        {// load exams and coursework of that subject
            if (selectedsubject != -1)
            {
                years[selectedyear].getsubject(selectedsubject).setname(Interaction.InputBox("please enter a new name for subject", "subject name", years[selectedyear].getsize().ToString()));
            }
            else
                MessageBox.Show("please select a subject");
        }

        private void button9_Click(object sender, EventArgs e)
        {// add subject
            if (selectedyear != -1)
            {
                subject a = new subject();
                a.setname(Interaction.InputBox("please enter a name for subject", "subject name", years[selectedyear].getsize().ToString()));
                years[selectedyear].addsubject(a);
                updatesubjects();
            }
            else
                MessageBox.Show("please select a year");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (selectedsubject != -1)
            {
                years[selectedyear].removesubject(selectedsubject);
                updatesubjects();
            }
            else
                MessageBox.Show("please select a subject");
        }

        private void button11_Click(object sender, EventArgs e)
        {// edit coursework
            if (selectedcoursework != -1)
            {
                corsework a = years[selectedyear].getsubject(selectedsubject).getcoursework(selectedcoursework);
                corseworkedit b = new corseworkedit(ref a, selectedcoursework);
                var result = b.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.Cancel)// bad logic
                {
                    years[selectedyear].getsubject(selectedsubject).getcoursework(selectedcoursework).setduedate(b.thework.getduedate());
                    years[selectedyear].getsubject(selectedsubject).getcoursework(selectedcoursework).setmarks(b.thework.getmarks());
                    years[selectedyear].getsubject(selectedsubject).getcoursework(selectedcoursework).setname(b.thework.getname());
                    years[selectedyear].getsubject(selectedsubject).getcoursework(selectedcoursework).setoverallvalue(b.thework.getoverallvalue());
                    years[selectedyear].getsubject(selectedsubject).getcoursework(selectedcoursework).settotalmarks(b.thework.gettotalmarks());
                    updatecoursework();
                    updatesubjects();
                    updateyear();
                }
            }
            else
                MessageBox.Show("please select a coursework");
        }

        private void button13_Click(object sender, EventArgs e)
        {// add coursework
            if (selectedsubject != -1)
            {
                corsework a = new corsework();
                years[selectedyear].getsubject(selectedsubject).addcoursework(a);
                updatecoursework();
            }
            else
                MessageBox.Show("please select a subject");
        }

        private void button14_Click(object sender, EventArgs e)
        { // remove coursework
            if (selectedcoursework != -1)
            {
                years[selectedyear].getsubject(selectedsubject).removecoursework(selectedcoursework);
                updatecoursework();
            }
            else
                MessageBox.Show("please select a coursework");
        }

        private void button12_Click(object sender, EventArgs e)
        { // edit exam
            if (selectedexam != -1)
            {
                exam a = years[selectedyear].getsubject(selectedsubject).getexam(selectedexam);
                examedit b = new examedit(ref a, selectedexam);
                var result = b.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.Cancel)
                {
                    years[selectedyear].getsubject(selectedsubject).getexam(selectedexam).setname(b.theexam.getname());
                    years[selectedyear].getsubject(selectedsubject).getexam(selectedexam).setduration(b.theexam.getduration());
                    years[selectedyear].getsubject(selectedsubject).getexam(selectedexam).setmarks(b.theexam.getmarks());
                    years[selectedyear].getsubject(selectedsubject).getexam(selectedexam).setoverallvalue(b.theexam.getoverallvalue());
                    years[selectedyear].getsubject(selectedsubject).getexam(selectedexam).settotalmarks(b.theexam.gettotalmarks());
                    years[selectedyear].getsubject(selectedsubject).getexam(selectedexam).setstartdate(b.theexam.getstartdate());
                }
                updateexams();
                updatesubjects();
                updateyear();
            }
            else
                MessageBox.Show("please select a exam");
        }

        private void button15_Click(object sender, EventArgs e)
        { // add exam
            if (selectedsubject != -1)
            {
                exam a = new exam();
                years[selectedyear].getsubject(selectedsubject).addexam(a);
                updateexams();
            }
            else
                MessageBox.Show("please select a subject");
        }

        private void button16_Click(object sender, EventArgs e)
        { // remove exam
            if (selectedexam != -1)
            {
                years[selectedyear].getsubject(selectedsubject).removeexam(selectedexam);
                updateexams();
            }
            else
                MessageBox.Show("please select a exam");
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0 && listBox1.SelectedIndex < years.Count)
            {
                selectedyear = listBox1.SelectedIndex;
                updatesubjects();
            }
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
            if (selectedyear != -1)
                for (int i = 0; i != years[selectedyear].getsize(); i++)
                    listBox2.Items.Add(years[selectedyear].getsubject(i).print());
        }
        private void updateexams()
        {
            listBox4.Items.Clear();
            if (selectedyear !=-1 && selectedsubject != -1)
                for (int i = 0; i != years[selectedyear].getsubject(selectedsubject).examssize(); i++)
                    listBox4.Items.Add(years[selectedyear].getsubject(selectedsubject).getexam(i).print());
        }
        private void updatecoursework()
        {
            listBox3.Items.Clear();
            if (selectedyear != -1 && selectedsubject != -1)
                for (int i = 0; i != years[selectedyear].getsubject(selectedsubject).courseworksize(); i++)
                    listBox3.Items.Add(years[selectedyear].getsubject(selectedsubject).getcoursework(i).print());
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex >= 0 && listBox2.SelectedIndex < years[selectedyear].getsize())
            {
                selectedsubject = listBox2.SelectedIndex;
                updateexams();
                updatecoursework();
            }
            else
                selectedsubject = -1;
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox3.SelectedIndex >= 0 && listBox3.SelectedIndex < years[selectedyear].getsubject(selectedsubject).courseworksize())
                selectedcoursework = listBox3.SelectedIndex;
            else
                selectedcoursework = -1;
        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox4.SelectedIndex >= 0 && listBox4.SelectedIndex < years[selectedyear].getsubject(selectedsubject).examssize())
                selectedexam = listBox4.SelectedIndex;
            else
                selectedexam = -1;
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
                a.Close();
                updateyear();
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
                b.Close();
            }
        }

        public void updateexam(exam item, int index)
        {
            exam a = years[selectedyear].getsubject(selectedsubject).getexam(index);
            a.setduration(item.getduration());
            a.setmarks(item.getmarks());
            a.setname(item.getname());
            a.setoverallvalue(item.getoverallvalue());
            a.setstartdate(item.getstartdate());
            a.settotalmarks(item.gettotalmarks());
            updateexams();
        }
        public void updatecorsework(corsework item, int index)
        {
            corsework a = years[selectedyear].getsubject(selectedsubject).getcoursework(index);
            a.setduedate(item.getduedate());
            a.setmarks(item.getmarks());
            a.setname(item.getname());
            a.setoverallvalue(item.getoverallvalue());
            a.settotalmarks(item.gettotalmarks());
            updatecoursework();
        }
        private void updategrade()
        {
            float[] grades = new float[6];
            for (int i = 0; i != grades.Length; i++)
                grades[i] = 0;
            for (int i = 0; i != years[lastyear].getsize(); i++)
            {
                for (int j = 0; j != grades.Length; j++)
                {
                    if (grades[j] <= years[lastyear].getsubject(i).calculatepercentage())
                    {
                        grades[j] = years[lastyear].getsubject(i).calculatepercentage();
                        break;
                    }
                }
            }
            for (int i = 0; i != years[lastyear1].getsize(); i++)
            {
                for (int j = 0; j != grades.Length; j++)
                {
                    if (grades[j] <= years[lastyear1].getsubject(i).calculatepercentage())
                    {
                        grades[j] = years[lastyear1].getsubject(i).calculatepercentage();
                        break;
                    }
                }
            }
            float avrage = 0;
            for (int i = 0; i != grades.Length; i++)
                avrage += grades[i];
            avrage /= 6;
            label2.Text = avrage.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (selectedyear != -1)
            {
                lastyear = selectedyear;
                if (lastyear != -1 && lastyear1 != -1)
                    updategrade();
            }
            else
                MessageBox.Show("please select a year");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (selectedyear != -1)
            {
                lastyear1 = selectedyear;
                if (lastyear != -1 && lastyear1 != -1)
                    updategrade();
            }
            else
                MessageBox.Show("please select a year");
        }
    }
}
