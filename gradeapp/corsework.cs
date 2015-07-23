using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace gradeapp
{
    class corsework
    {
        public int overallvalue // the vale of the exam in the subject
        {
            get
            {
                return overallvalue;
            }
            set
            {
                overallvalue = value;
            }
        }
        private float marks; // the marks the subject is worth
        private float totalmarks; // the total marks that can be earned
        private DateTime duedate; // the date the exam is begin
        public corsework(int value = 0, float mark = 0, float totalmark = 0)
        {
            value = overallvalue;
            marks = mark;
            totalmarks = totalmark;
        }
        public corsework(DateTime due,int value = 0, float mark = 0, float totalmark = 0)
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
    }
}
