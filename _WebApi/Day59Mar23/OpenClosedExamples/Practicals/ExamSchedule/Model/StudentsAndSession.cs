namespace ExamSchedule.Model
{
    public class StudentsAndSession
    {
        public StudentsAndSession() 
        { 
        
        }
        public StudentSession Session { get; set; }

        public List<Student> SessionStudents { get; set; }
    }
}
