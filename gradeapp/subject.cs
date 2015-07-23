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

        }
        public void saveexams(ref StreamWriter writer)
        {
            writer.WriteLine(exams.Count);
            for (int i = 0; i != exams.Count; i++)
                exams[i].save(ref writer);
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
    }
}
