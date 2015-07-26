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
        public string name // the name of the coursework for the user
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
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
        public float marks // the marks the subject is worth
        {
            get
            {
                return marks;
            }
            set
            {
                marks = value;
            }
        }
        public float totalmarks // the total marks that can be earned
        {
            get
            {
                return totalmarks;
            }
            set
            {
                totalmarks = value;
            }
        }
        public DateTime duedate // the date the exam is begin
        {
            get
            {
                return duedate;
            }
            set
            {
                duedate = value;
            }
        }
        public corsework(string name = "", int value = 0, float mark = 0, float totalmark = 0)
        {
            value = overallvalue;
            marks = mark;
            totalmarks = totalmark;
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
    }
}
