namespace StudentProject.ViewModels
{
    public class StudentDto
    {
        public int StudentId { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Phone { get; set; }
        public DateOnly JoinDate { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
