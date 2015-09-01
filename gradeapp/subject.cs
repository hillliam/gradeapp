// Copyright © Liam hill 2015
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace gradeapp
{
    class subject
    {
        private string name;
        private List<corsework> corseworks;
        private List<exam> exams;
        public subject()
        {
            corseworks = new List<corsework>();
            exams = new List<exam>();
        }
        public void addexam(exam item)
        {
            exams.Add(item);
        }
        public void addcoursework(corsework item)
        {
            corseworks.Add(item);
        }
        public void removecoursework(int index)
        {
            corseworks.RemoveAt(index);
        }
        public void removeexam(int index)
        {
            exams.RemoveAt(index);
        }
        public exam getexam(int index)
        {
            return exams[index];
        }
        public corsework getcoursework(int index)
        {
            return corseworks[index];
        }
        public void loadexams(ref StreamReader reader)
        {
            int numofexams = int.Parse(reader.ReadLine());
            for (int i = 0; i != numofexams; i++)
            {
                exam a = new exam();
                a.load(ref reader);
                exams.Add(a);
            }
        }
        public void locadcoursework(ref StreamReader reader)
        {
            int numofcorsework = int.Parse(reader.ReadLine());
            for (int i = 0; i != numofcorsework; i++)
            {
                corsework a = new corsework();
                a.load(ref reader);
                corseworks.Add(a);
            }
        }
        public void loadname(ref StreamReader reader)
        {
            name = reader.ReadLine();
        }
        public void saveexams(ref StreamWriter writer)
        {
            writer.WriteLine(name);
            writer.WriteLine(exams.Count);
            for (int i = 0; i != exams.Count; i++)
                exams[i].save(ref writer);
        }
        public void savename(ref StreamWriter writer)
        {
            writer.WriteLine(name);
        }
        public void savecoursework(ref StreamWriter writer)
        {
            writer.WriteLine(corseworks.Count);
            for (int i = 0; i != corseworks.Count; i++)
                corseworks[i].save(ref writer);
        }
        public int examssize()
        {
            return exams.Count;
        }
        public int courseworksize()
        {
            return corseworks.Count;
        }
        public float calculatepercentage()
        {
            int total = exams.Count + corseworks.Count;
            if (total != 0)
            {
                float avrage = 0;
                for (int i = 0; i != exams.Count; i++)
                {
                    avrage += exams[i].calculateoverallpercentage();
                }
                for (int i = 0; i != corseworks.Count; i++)
                {
                    avrage += corseworks[i].calculateoverallpercentage();
                }
                return avrage / total;
            }
            else
                return 0;
        }
        public string print()
        {
            return name + " " + calculatepercentage();
        }
        public string[] printexam()
        {
            string[] a = new string[exams.Count];
            for (int i = 0; i != exams.Count; i++)
            {
                a[i] = exams[i].print();
            }
            return a;
        }
        public string[] printcoursework()
        {
            string[] a = new string[corseworks.Count];
            for (int i = 0; i != corseworks.Count; i++)
            {
                a[i] = corseworks[i].print();
            }
            return a;
        }
        public void setname(string newname)
        {
            name = newname;
        }
        public string getname()
        {
            return name;
        }
    }
}
