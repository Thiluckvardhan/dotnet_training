using ExamSchedule.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSchedule.Data
{
    public static class DataBank
    {
        public static List<Student> Students = new List<Student>();

        static DataBank()
        {
            Students.Add(new Student() { Id=1, Name="Anu" });
            Students.Add(new Student() { Id=2, Name="Babu" });
            Students.Add(new Student() { Id = 3, Name = "Chitra" });
            Students.Add(new Student() { Id = 4, Name = "Devi" });

        }
        public static List<Student>  GetStudents()
        {
            return Students;
        }

    }
}
