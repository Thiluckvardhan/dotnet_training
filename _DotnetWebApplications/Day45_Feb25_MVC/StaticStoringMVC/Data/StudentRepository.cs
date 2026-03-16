using StaticStoringMVC.Models;

namespace StaticStoringMVC.Data
{
    public class StudentRepository
    {
        public static List<Student> Students = new List<Student>();
    }
}
