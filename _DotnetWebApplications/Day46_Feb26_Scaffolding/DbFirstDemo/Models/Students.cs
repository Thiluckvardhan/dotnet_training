using System;
using System.Collections.Generic;

namespace DbFirstDemo.Models;

public partial class Students
{
    public int StudentId { get; set; }

    public string FullName { get; set; } = null!;

    public string City { get; set; } = null!;

    public int Marks { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedOn { get; set; }

    public virtual ICollection<Enrollments> Enrollments { get; set; } = new List<Enrollments>();
}
