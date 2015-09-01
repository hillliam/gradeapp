// Copyright © Liam hill 2015
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gradeapp
{
    class year
    {
        private List<subject> subjects;
        private string name;
        public year()
        {
            subjects = new List<subject>();
        }
        public void addsubject(subject item)
        {
            subjects.Add(item);
        }
        public void removesubject(int index)
        {
            subjects.RemoveAt(index);
        }
        public int getsize()
        {
            return subjects.Count;
        }
        public subject getsubject(int index)
        {
            return subjects[index];
        }
        public void loadsubjects(ref StreamReader reader)
        {
            int numberofsubjets = int.Parse(reader.ReadLine());
            for (int i = 0; i != numberofsubjets; i++)
            {
                subject a = new subject();
                a.loadname(ref reader);
                a.loadexams(ref reader);
                a.locadcoursework(ref reader);
                subjects.Add(a);
            }
        }
        public void savesubject(ref StreamWriter writer)
        {
            writer.WriteLine(subjects.Count);
            for (int i = 0; i != subjects.Count; i++)
            {
                subjects[i].savename(ref writer);
                subjects[i].saveexams(ref writer);
                subjects[i].savecoursework(ref writer);
            }
        }
        public float calculatepercentage()
        {
            int total = subjects.Count;
            if (total != 0)
            {
                float avrage = 0;
                for (int i = 0; i != subjects.Count; i++)
                {
                    avrage += subjects[i].calculatepercentage();
                }
                return avrage / total;
            }
            else
                return 0;
        }
        public string getgrade()
        {
            if (calculatepercentage() > 0.70)
                return "1";
            else if (calculatepercentage() > 0.60)
                return "2 1";
            else if (calculatepercentage() > 0.50)
                return "2 2";
            else if (calculatepercentage() > 0.40)
                return "pass";
            else
                return "fail";
        }
        public string print()
        {
            return name + " " + calculatepercentage()+ " " + getgrade();
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
