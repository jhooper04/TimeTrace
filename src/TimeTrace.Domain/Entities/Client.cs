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

    public Address BillingAddress { get; set; } = new();

    public ICollection<Project> Projects { get; } = new List<Project>();
    public ICollection<Contact> Contacts { get; } = new List<Contact>();
}
