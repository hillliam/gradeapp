using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace gradeapp
{
    public class corsework
    {
        private string name; // the name of the coursework for the user
        private int overallvalue; // the vale of the exam in the subject
        private float marks; // the marks the subject is worth
        private float totalmarks; // the total marks that can be earned
        private DateTime duedate; // the date the exam is begin
        public corsework(string name = "", int value = 0, float mark = 0, float totalmark = 0)
        {
            value = overallvalue;
            marks = mark;
            totalmarks = totalmark;
            duedate = DateTime.Now;
        }
        public corsework(DateTime due, string name = "", int value = 0, float mark = 0, float totalmark = 0)
        {
            duedate = due;
            value = overallvalue;
            marks = mark;
            totalmarks = totalmark;
        }
        public TimeSpan calculateremaningtime()
        {
            return (duedate - DateTime.Now);
        }
        public float calculatecorseworkpercentage() 
        {
            if (totalmarks != 0)
                return marks / totalmarks;
            else
                return marks;
        }
        public float calculateoverallpercentage()
        {
                return (calculatecorseworkpercentage() / 100) * overallvalue;
        }
        public void load(ref StreamReader reader)
        {
            overallvalue = int.Parse(reader.ReadLine());
            marks = float.Parse(reader.ReadLine());
            totalmarks = float.Parse(reader.ReadLine());
            duedate = DateTime.Parse(reader.ReadLine());
        }
        public void save(ref StreamWriter writer)
        {
            writer.WriteLine(overallvalue);
            writer.WriteLine(marks);
            writer.WriteLine(totalmarks);
            writer.WriteLine(duedate.ToString());
        }
        public string print()
        {
            if (duedate > DateTime.Now)
                return name + " " + overallvalue + " " + calculateremaningtime();
            else
                return name + " " + overallvalue + " " + calculatecorseworkpercentage() + " " + calculateoverallpercentage();
        }
        public void setname(string newname)
        {
            name = newname;
        }
        public string getname()
        {
            return name;
        }
        public void setoverallvalue(int newmark)
        {
            overallvalue = newmark;
        }
        public int getoverallvalue()
        {
            return overallvalue;
        }
        public void settotalmarks(float newmarks)
        {
            totalmarks = newmarks;
        }
        public float gettotalmarks()
        {
            return totalmarks;
        }
        public float getmarks()
        {
            return marks;
        }
        public void setmarks(float newmarks)
        {
            marks = newmarks;
        }
        public DateTime getduedate()
        {
            return duedate;
        }
        public void setduedate(DateTime newduedate)
        {
            duedate = newduedate;
        }
    }
}
