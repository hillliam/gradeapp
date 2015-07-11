using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gradeapp
{
    class corsework
    {
        private int overallvalue; // the vale of the exam in the subject
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

        public void setoverallvalue(int value)
        {
            overallvalue = value;
        }

        public int getoverallvalue()
        {
            return overallvalue;
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
        public DateTime getduedate()
        {
            return duedate;
        }
        public void setduedate(DateTime due)
        {
            duedate = due;
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

    }
}
