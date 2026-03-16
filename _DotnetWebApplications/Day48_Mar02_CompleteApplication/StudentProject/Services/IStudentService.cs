using StudentProject.Models;
using StudentProject.ViewModels;

namespace StudentProject.Services
{
    public interface IStudentService
    {
        Task<List<Student>> SearchAsync(string q = null);
        Task<List<StudentDto>> GetStudentListAsync(string q = null);
        Task<Student?> GetByIdAsync(int id);
        Task AddAsync(Student student);
        Task UpdateAsync(Student student);
        Task DeleteAsync(int id);
        Task<bool> EmailExistsAsync(string email, int? ignoreStudentId = null);
    }
}
