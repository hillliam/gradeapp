using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace gradeapp
{
    class exam : List<exam>
    {
        private string name; // the name of the exam for the user
        private int overallvalue; // the vale of the exam in the subject
        private float marks; // the marks the subject is worth
        private float totalmarks; // the total marks that can be earned
        private DateTime startdate; // the date the exam is begin
        private TimeSpan duration; // the duration of the exam
        public exam(string name = "", int value = 0, float mark = 0, float totalmark = 0)
        {
            value = overallvalue;
            marks = mark;
            totalmarks = totalmark;
            startdate = DateTime.Now;
            duration = TimeSpan.Zero;
        }
        public exam(DateTime start, string name = "", int value = 0, float mark = 0, float totalmark = 0)
        {
            startdate = start;
            value = overallvalue;
            marks = mark;
            totalmarks = totalmark;
        }
        public exam(TimeSpan time, string name = "", int value = 0, float mark = 0, float totalmark = 0)
        {
            duration = time;
            value = overallvalue;
            marks = mark;
            totalmarks = totalmark;
        }
        public exam(DateTime start, TimeSpan time, string name = "", int value = 0, float mark = 0, float totalmark = 0)
        {
            startdate = start;
            duration = time;
            value = overallvalue;
            marks = mark;
            totalmarks = totalmark;
        }
        public float calculateexampercentage()
        {
            if (totalmarks != 0)
                return marks / totalmarks;
            else
                return marks;
        }
        public float calculateoverallpercentage()
        {
            return (calculateexampercentage() / 100) * overallvalue;
        }
        public void load(ref StreamReader reader)
        {
            overallvalue = int.Parse(reader.ReadLine());
            marks = float.Parse(reader.ReadLine());
            totalmarks = float.Parse(reader.ReadLine());
            startdate = DateTime.Parse(reader.ReadLine());
            duration = TimeSpan.Parse(reader.ReadLine());
        }
        public void save(ref StreamWriter writer)
        {
            writer.WriteLine(overallvalue);
            writer.WriteLine(marks);
            writer.WriteLine(totalmarks);
            writer.WriteLine(startdate.ToString());
            writer.WriteLine(duration.ToString());
        }
        public string print()
        {
            if (startdate > DateTime.Now)
                return name + " " + overallvalue + " " + startdate + " " + duration;
            else
                return name + " " + overallvalue + " " + startdate + " " + calculateexampercentage() + calculateoverallpercentage();
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
        public DateTime getstartdate()
        {
            return startdate;
        }
        public void setstartdate(DateTime newstart)
        {
            startdate = newstart;
        }
        public TimeSpan getduration()
        {
            return duration;
        }
        public void setduration(TimeSpan newduration)
        {
            duration = newduration;
        }
    }
}