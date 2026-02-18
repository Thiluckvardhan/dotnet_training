using System.Collections.Generic;
using Domain;
using Exceptions;

namespace Services
{
    public class ManagementService
    {
        private SortedDictionary<double, List<Student>> _data=new();
        private HashSet<Student>_seen=new();
        public void AddEntity(Student student)
        {
            // TODO: Validate entity
            // TODO: Handle duplicate entries
            // TODO: Add entity to SortedDictionary
            if (_seen.Contains(student))
            {
                throw new DuplicateStudentException("Cannot Add Student already Exists.");
            }
            _data.TryAdd(student.GPA,new());
            _data[student.GPA].Add(student);
            System.Console.WriteLine("Student Added Sucessfully");
        }

        public void UpdateEntity(string id,double gpa)
        {
            // TODO: Update entity logic
            if(gpa<0 || gpa > 10)
            {
                throw new InvalidGPAException("Invalid  GPA");
            }
            if()
        }

        public void RemoveEntity(int key)
        {
            // TODO: Remove entity logic
        }

        public IEnumerable<BaseEntity> GetAll()
        {
            // TODO: Return sorted entities
            return new List<BaseEntity>();
        }
    }
}
