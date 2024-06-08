using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__HW_modul_09_part_03_ua
{
    public class StudentGrades
    {
        public string StudentName { get; set; }
        public int Math { get; set; }
        public int English { get; set; }
        public int Science { get; set; }

        public StudentGrades(string studentName, int math, int english, int science)
        {
            StudentName = studentName;
            Math = math;
            English = english;
            Science = science;
        }

        public double AverageGrade()
        {
            return (Math + English + Science) / 3.0;
        }
    }

}
