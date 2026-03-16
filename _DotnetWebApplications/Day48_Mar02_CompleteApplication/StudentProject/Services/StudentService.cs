using StudentProject.Models;
using StudentProject.Repositries;
using StudentProject.ViewModels;

namespace StudentProject.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repo;

        public StudentService(IStudentRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<Student>> SearchAsync(string q = null) => await _repo.GetAllAsync(q);

        public async Task<List<StudentDto>> GetStudentListAsync(string q = null)
        {
            var students = await _repo.GetAllAsync(q);
            return students.Select(s => new StudentDto
            {
                StudentId = s.StudentId,
                FullName = s.FullName,
                Email = s.Email,
                Phone = s.Phone,
                JoinDate = s.JoinDate,
                CreatedAt = s.CreatedAt
            }).ToList();
        }

        public async Task<Student?> GetByIdAsync(int id) => await _repo.GetByIdAsync(id);

        public async Task AddAsync(Student student) => await _repo.AddAsync(student);

        public async Task UpdateAsync(Student student) => await _repo.UpdateAsync(student);

        public async Task DeleteAsync(int id) => await _repo.DeleteAsync(id);

        public async Task<bool> EmailExistsAsync(string email, int? ignoreStudentId = null) => await _repo.EmailExistsAsync(email, ignoreStudentId);
    }
}
