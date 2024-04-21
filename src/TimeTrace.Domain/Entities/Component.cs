using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTrace.Domain.Entities;
public class Component : BaseAuditableEntity
{
    public int ProjectId { get; set; }
    public Project Project { get; set; } = null!;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Color Color { get; set; } = Color.White;
    public int BudgetAmount { get; set; } 
    public int BudgetHours { get; set; }
}
