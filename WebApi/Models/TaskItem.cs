using System;
using System.Collections.Generic;

namespace WebApi.Models;

public partial class TaskItem
{
    public int IdTask { get; set; }

    public int IdProject { get; set; }

    public int IdUser { get; set; }

    public string Title { get; set; } = null!;

    public DateOnly Deadline { get; set; }

    public string Status { get; set; } = null!;

    public virtual Project IdProjectNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}
