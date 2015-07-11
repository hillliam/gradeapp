using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gradeapp
{
    class exam
    {
        private int overallvalue; // the vale of the exam in the subject
        private float marks; // the marks the subject is worth
        private float totalmarks; // the total marks that can be earned
        private DateTime startdate; // the date the exam is begin
        private TimeSpan duration; // the duration of the exam

        public exam(int value = 0, float mark = 0, float totalmark = 0)
        {
            value = overallvalue;
            marks = mark;
            totalmarks = totalmark;
            startdate = DateTime.Now;
            duration = TimeSpan.Zero;
        }
        public exam(DateTime start, int value = 0, float mark = 0, float totalmark = 0)
        {
            startdate = start;
            value = overallvalue;
            marks = mark;
            totalmarks = totalmark;
        }
        public exam(TimeSpan time, int value = 0, float mark = 0, float totalmark = 0)
        {
            duration = time;
            value = overallvalue;
            marks = mark;
            totalmarks = totalmark;
        }
        public exam(DateTime start, TimeSpan time, int value = 0, float mark = 0, float totalmark = 0)
        {
            startdate = start;
            duration = time;
            value = overallvalue;
            marks = mark;
            totalmarks = totalmark;
        }
        public void setoverallvalue(int value)
        {
            overallvalue = value;
        }
        public void setmarks(float value)
        {
            marks = value;
        }

        public float getmarks()
        {
            return marks;
        }

        public void settotalmarks(float value)
        {
            totalmarks = value;
        }

        public float gettotalmarks()
        {
            return totalmarks;
        }

        public int getoverallvalue()
        {
            return overallvalue;
        }
        public DateTime getstartdate()
        {
            return startdate;
        }
        public void setstartdate(DateTime date)
        {
            startdate = date;
        }
        public TimeSpan getduration()
        {
            return duration;
        }
        public void setduration(TimeSpan time)
        {
            duration = time;
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
    }
}
