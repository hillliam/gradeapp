using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gradeapp
{
    class year
    {
        private List<subject> subjects;

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
    }
}
