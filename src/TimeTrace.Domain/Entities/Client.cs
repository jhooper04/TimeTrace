using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTrace.Domain.Entities;
public class Client : BaseAuditableEntity
{
    public required string Name { get; set; }
    public Color Color { get; set; } = Color.White;
    public string? BillingStreet { get; set; }
    public string? BillingCity { get; set; }
    public string? BillingState { get; set; }
    public string? BillingZip { get; set; }
    public ICollection<Contact> Contacts { get; } = new List<Contact>();
}
