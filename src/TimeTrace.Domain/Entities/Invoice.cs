using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTrace.Domain.Entities;
public class Invoice : BaseAuditableEntity
{
    public int? ClientId { get; set; }
    public Client? Client { get; set; }
    public int? ProjectId { get; set; }
    public Project? Project { get; set; }
    public string Description { get; set; } = string.Empty;

    public DateTime DueDate { get; set; }
    public string BusinessName { get; set; } = string.Empty;
    public string BillingAddress { get; set; } = string.Empty;
    public string BillingContact { get; set; } = string.Empty;

    public ICollection<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>();
}
