using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class4Stat.Model
{
    public class Student
    {
        public int Id {  get; set; }

        public string Lastname { get; set; }

        public string Initials { get; set; }

        public int Hours { get; set; }

        public int Questions { get; set; }

        public int DoneTasks { get; set; }

        public List<Situation> Situations { get; set; }
    }
}
