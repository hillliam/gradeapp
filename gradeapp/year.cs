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
        public string name
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
                }
                return avrage;
            }
            else
                return 0;
        }
        public string print()
        {
            return name + " " + calculatepercentage();
        }

    }
}
