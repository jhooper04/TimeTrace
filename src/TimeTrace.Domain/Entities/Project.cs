using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTrace.Domain.Entities;
public class Project : BaseAuditableEntity
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int ClientId { get; set; }
    public Client Client { get; set; } = null!;
    public Color Color { get; set; } = Color.White;
    public string? ProjectNumber { get; set; }

    public string? OrderNumber { get; set; }
    public DateTimeOffset OrderDate { get; set; }
    public DateTime ProjectBegin { get; set; }
    public DateTime ProjectEnd { get; set; }
    public int? BudgetAmount { get; set; }
    public int? BudgetHours { get; set; }

    public ICollection<Component> Components { get; set; } = new List<Component>();
    public ICollection<Label> SpecificLabels { get; set; } = new List<Label>();
    public ICollection<Activity> SpecificActivities { get; set; } = new List<Activity>();
}
