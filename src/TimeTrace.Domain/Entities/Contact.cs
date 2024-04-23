using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTrace.Domain.Entities;
public class Contact : BaseAuditableEntity
{
    public int ClientId { get; set; }
    public Client Client { get; set; } = null!;

    public string FirstName { get; set; } = string.Empty;
    public string ?LastName { get; set; }

    public Address Address { get; set; } = new();

    public string ?Mobile { get; set; }
    public string ?Phone { get; set; }
    public string ?Fax { get; set; }
    public string ?Email { get; set; }
}
