using System;
using System.Collections.Generic;

namespace WebApi.Models;

public partial class Project
{
    public int IdProject { get; set; }

    public int IdAdmin { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public virtual User IdAdminNavigation { get; set; } = null!;

    public virtual ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();

    public virtual ICollection<User> IdUsers { get; set; } = new List<User>();
}
