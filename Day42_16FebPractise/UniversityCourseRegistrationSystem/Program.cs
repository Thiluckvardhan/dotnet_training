namespace UniversityCourseRegistrationSystem
{
    // Base constraints
    public interface IStudent
    {
        int StudentId { get; }
        string Name { get; }
        int Semester { get; }
    }

    public interface ICourse
    {
        string CourseCode { get; }
        string Title { get; }
        int MaxCapacity { get; }
        int Credits { get; }
    }

    // 1. Generic enrollment system
    public class EnrollmentSystem<TStudent, TCourse>
            where TStudent : IStudent
            where TCourse : ICourse
    {
        private Dictionary<TCourse, List<TStudent>> _enrollments = new();

        public bool EnrollStudent(TStudent student, TCourse course)
        {
            if (!_enrollments.ContainsKey(course))
                _enrollments[course] = new List<TStudent>();

            var students = _enrollments[course];

            if (students.Count >= course.MaxCapacity)
            {
                Console.WriteLine($"Enrollment failed: {course.Title} is full.");
                return false;
            }

            if (students.Contains(student))
            {
                Console.WriteLine($"Enrollment failed: {student.Name} already enrolled.");
                return false;
            }

            if (course is LabCourse labCourse)
            {
                if (student.Semester < labCourse.RequiredSemester)
                {
                    Console.WriteLine($"Enrollment failed: {student.Name} does not meet prerequisite.");
                    return false;
                }
            }

            students.Add(student);
            Console.WriteLine($"{student.Name} enrolled in {course.Title}");
            return true;
        }

        public IReadOnlyList<TStudent> GetEnrolledStudents(TCourse course)
{
    if (!_enrollments.ContainsKey(course))
        return new List<TStudent>();

    return new List<TStudent>(_enrollments[course]);
}


        public IEnumerable<TCourse> GetStudentCourses(TStudent student)
        {
            return _enrollments
                .Where(e => e.Value.Contains(student))
                .Select(e => e.Key);
        }

        public int CalculateStudentWorkload(TStudent student)
        {
            return _enrollments
                .Where(e => e.Value.Contains(student))
                .Sum(e => e.Key.Credits);
        }

        public bool IsStudentEnrolled(TStudent student, TCourse course)
        {
            return _enrollments.ContainsKey(course) &&
                   _enrollments[course].Contains(student);
        }
    }

    // 2. Specialized implementations
    public class EngineeringStudent : IStudent
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int Semester { get; set; }
        public string Specialization { get; set; }
    }

    public class LabCourse : ICourse
    {
        public string CourseCode { get; set; }
        public string Title { get; set; }
        public int MaxCapacity { get; set; }
        public int Credits { get; set; }
        public string LabEquipment { get; set; }
        public int RequiredSemester { get; set; } // Prerequisite
    }

    // 3. Generic gradebook
public class GradeBook<TStudent, TCourse>
    where TStudent : IStudent
    where TCourse : ICourse

    {
        private Dictionary<(TStudent, TCourse), double> _grades = new();
        private EnrollmentSystem<TStudent, TCourse> _enrollment;

        public GradeBook(EnrollmentSystem<TStudent, TCourse> enrollment)
        {
            _enrollment = enrollment;
        }

        public void AddGrade(TStudent student, TCourse course, double grade)
        {
            if (grade < 0 || grade > 100)
                throw new ArgumentException("Grade must be between 0 and 100");

            if (!_enrollment.IsStudentEnrolled(student, course))
                throw new InvalidOperationException("Student not enrolled in course");

            _grades[(student, course)] = grade;

            Console.WriteLine($"Grade {grade} added for {student.Name} in {course.Title}");
        }

        public double? CalculateGPA(TStudent student)
        {
            var studentGrades = _grades
                .Where(g => g.Key.Item1.Equals(student))
                .ToList();

            if (!studentGrades.Any())
                return null;

            double totalPoints = 0;
            int totalCredits = 0;

            foreach (var entry in studentGrades)
            {
                var course = entry.Key.Item2;
                var grade = entry.Value;

                totalPoints += grade * course.Credits;
                totalCredits += course.Credits;
            }

            return totalPoints / totalCredits;
        }

        public (TStudent student, double grade)? GetTopStudent(TCourse course)
        {
            var courseGrades = _grades
                .Where(g => g.Key.Item2.Equals(course))
                .ToList();

            if (!courseGrades.Any())
                return null;

            var top = courseGrades.OrderByDescending(g => g.Value).First();

            return (top.Key.Item1, top.Value);
        }
    }
    public class Program
    {
        public static void Main()
        {
            var enrollment = new EnrollmentSystem<EngineeringStudent, LabCourse>();
            var gradebook = new GradeBook<EngineeringStudent, LabCourse>(enrollment);

            var s1 = new EngineeringStudent { StudentId = 1, Name = "Alice", Semester = 3 };
            var s2 = new EngineeringStudent { StudentId = 2, Name = "Bob", Semester = 2 };
            var s3 = new EngineeringStudent { StudentId = 3, Name = "Charlie", Semester = 1 };

            var c1 = new LabCourse
            {
                CourseCode = "CS101",
                Title = "Programming Lab",
                MaxCapacity = 2,
                Credits = 4,
                RequiredSemester = 2
            };

            var c2 = new LabCourse
            {
                CourseCode = "CS201",
                Title = "Advanced Lab",
                MaxCapacity = 1,
                Credits = 5,
                RequiredSemester = 3
            };

            enrollment.EnrollStudent(s1, c1);
            enrollment.EnrollStudent(s2, c1);
            enrollment.EnrollStudent(s3, c1);

            enrollment.EnrollStudent(s1, c2);
            enrollment.EnrollStudent(s2, c2);

            gradebook.AddGrade(s1, c1, 90);
            gradebook.AddGrade(s2, c1, 80);

            gradebook.AddGrade(s1, c2, 95);

            Console.WriteLine($"Alice GPA: {gradebook.CalculateGPA(s1)}");
            Console.WriteLine($"Bob GPA: {gradebook.CalculateGPA(s2)}");

            var top = gradebook.GetTopStudent(c1);

            if (top != null)
                Console.WriteLine($"Top student in {c1.Title}: {top.Value.student.Name} ({top.Value.grade})");

            Console.WriteLine($"Alice workload: {enrollment.CalculateStudentWorkload(s1)} credits");
        }
    }
}