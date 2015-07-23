﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace gradeapp
{
    class exam : List<exam>
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
        public DateTime startdate // the date the exam is begin
        {
            get
            {
                return startdate;
            }
            set
            {
                startdate = value;
            }
        }
        public TimeSpan duration // the duration of the exam
        {
            get
            {
                return duration;
            }
            set
            {
                duration = value;
            }
        }
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
    }
}