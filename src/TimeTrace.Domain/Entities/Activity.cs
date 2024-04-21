using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTrace.Domain.Entities;
public class Activity :BaseAuditableEntity
{
    public int? ClientId { get; set; }
    public Client? Client { get; set; }
    public int? ProjectId { get; set; }
    public Project? Project { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Color Color { get; set; } = Color.White;
    public string? ActivityNumber { get; set; }
    public int? BudgetAmount { get; set; }
    public int? BudgetHours { get; set; }
    public string? InvoiceText { get; set; }
    public ICollection<TimeEntry> TimeEntries { get; set; } = new List<TimeEntry>();
}
