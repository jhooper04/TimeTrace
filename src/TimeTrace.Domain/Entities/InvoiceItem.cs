using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTrace.Domain.Entities;
public class InvoiceItem : BaseAuditableEntity
{
    public int InvoiceId { get; set; }
    public Invoice Invoice { get; set; } = null!;
    public int ActivityId { get; set; }
    public Activity? Activity { get; set; } = null!;
    public string Description { get; set; } = string.Empty;
    public decimal Hours {  get; set; } 
    public decimal Price {  get; set; }
}
