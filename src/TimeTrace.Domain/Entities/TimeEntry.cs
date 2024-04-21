using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTrace.Domain.Entities;
public class TimeEntry : BaseAuditableEntity
{
    public int ProjectId { get; set; }
    public Project Project { get; set; } = null!;
    public int ActivityId { get; set; }
    public Activity Activity { get; set; } = null!;

    public int? IssueId { get; set; }
    public Issue? Issue { get; set; } = null!;
    public DateTimeOffset Begin { get; set; }
    public DateTimeOffset End { get; set; }
    public string Details { get; set; } = string.Empty;
    public decimal? Price { get; set; }
    public decimal? InternalPrice { get; set; }
}
