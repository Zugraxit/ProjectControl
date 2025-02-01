using System;
using System.Collections.Generic;

namespace WebApi.Models;

public partial class User
{
    public int IdUser { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? ImagePath { get; set; }

    public virtual ICollection<Project> ProjectsNavigation { get; set; } = new List<Project>();

    public virtual ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}
