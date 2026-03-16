using System;
using System.Collections.Generic;

namespace DbFirstDemo.Models;

public partial class Courses
{
    public int CourseId { get; set; }

    public string CourseName { get; set; } = null!;

    public virtual ICollection<Enrollments> Enrollments { get; set; } = new List<Enrollments>();
}
