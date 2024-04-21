using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTrace.Domain.Entities;
public class Issue : BaseAuditableEntity
{
    public int ProjectId { get; set; }
    public Project Project { get; set; } = null!;
    public string? AssignedTo { get; set; }
    public int? ComponentId { get; set; }
    public Component? Component { get; set; }
    public IssueStatus IssueStatus { get; set; }
    public PriorityLevel PriorityLevel { get; set; }
    public DateTimeOffset ClosedOn { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Color Color { get; set; } = Color.White;
    public ICollection<Label> Labels { get; set; } = new List<Label>();
}
