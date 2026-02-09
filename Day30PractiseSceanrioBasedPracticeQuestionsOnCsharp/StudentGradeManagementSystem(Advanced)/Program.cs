public class Student
{
    public int StudentId { get; set; }
    public string Name { get; set; }
    public string GradeLevel { get; set; }
    public Dictionary<string, double> Subjects { get; set; } = new();
}

public class SchoolManager
{
    List<Student> students = new();
    public void AddStudent(string name, string gradeLevel)
    {
        Student student = new Student
        {
            StudentId = students.Count + 1,
            Name = name,
            GradeLevel = gradeLevel
        };
        students.Add(student);
    }

    public void AddGrade(int studentId, string subject, double grade)
    {
        if (grade < 0 || grade > 100)
        {
            System.Console.WriteLine("Grade should be (0<=grade<=100).");
            return;
        }
        Student student = students.FirstOrDefault(s => s.StudentId == studentId);
        if (student == null)
        {
            System.Console.WriteLine("Student Not found");
            return;
        }
        if (!student.Subjects.TryAdd(subject, grade)) student.Subjects[subject] = grade;
        System.Console.WriteLine("Grade Added Successfully");
    }
    public SortedDictionary<string, List<Student>> GroupStudentsByGradeLevel()
    {
        return new SortedDictionary<string, List<Student>>(
    students
        .GroupBy(s => s.GradeLevel)
        .ToDictionary(g => g.Key, g => g.ToList())
);

    }

    public double CalculateStudentAverage(int studentId)
    {
        Student student = students.FirstOrDefault(s => s.StudentId == studentId);
        if (student == null) return 0;
        return student.Subjects.Values.DefaultIfEmpty(0).Average();
    }

    public Dictionary<string, double> CalculateSubjectAverages()
    {
        return students
            .SelectMany(s => s.Subjects)
            .GroupBy(s => s.Key)
            .ToDictionary(
                g => g.Key,
                g => g.Average(x => x.Value)
            );
    }

    public List<Student> GetTopPerformers(int count)
    {
        return students
            .OrderByDescending(s => s.Subjects.Count == 0 ? 0 : s.Subjects.Values.Average())
            .Take(count)
            .ToList();
    }
}

class Program
{
    static void Main()
    {
        SchoolManager school = new SchoolManager();
        int choice;

        do
        {
            Console.WriteLine("\n1.Add Student");
            Console.WriteLine("2.Add Grade");
            Console.WriteLine("3.Calculate Student Average");
            Console.WriteLine("4.Subject Averages");
            Console.WriteLine("5.Top Performers");
            Console.WriteLine("6.Group Students By Grade Level");
            Console.WriteLine("0.Exit");
            Console.Write("Enter Choice: ");

            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Grade Level: ");
                    string grade = Console.ReadLine();
                    school.AddStudent(name, grade);
                    break;

                case 2:
                    Console.Write("Student Id: ");
                    int sid = int.Parse(Console.ReadLine());
                    Console.Write("Subject: ");
                    string subject = Console.ReadLine();
                    Console.Write("Grade: ");
                    double marks = double.Parse(Console.ReadLine());
                    school.AddGrade(sid, subject, marks);
                    break;

                case 3:
                    Console.Write("Student Id: ");
                    int id = int.Parse(Console.ReadLine());
                    Console.WriteLine("Average: " + school.CalculateStudentAverage(id));
                    break;

                case 4:
                    var subAvg = school.CalculateSubjectAverages();
                    foreach (var s in subAvg)
                        Console.WriteLine(s.Key + " : " + s.Value);
                    break;

                case 5:
                    Console.Write("Top how many: ");
                    int count = int.Parse(Console.ReadLine());
                    foreach (var s in school.GetTopPerformers(count))
                        Console.WriteLine(s.StudentId + " " + s.Name);
                    break;

                case 6:
                    var grouped = school.GroupStudentsByGradeLevel();
                    foreach (var g in grouped)
                    {
                        Console.WriteLine("Grade " + g.Key);
                        foreach (var s in g.Value)
                            Console.WriteLine(s.StudentId + " " + s.Name);
                    }
                    break;

                case 0:
                    Console.WriteLine("Exited");
                    break;

                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }

        } while (choice != 0);
    }
}