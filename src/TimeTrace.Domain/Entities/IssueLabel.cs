using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTrace.Domain.Entities;
public class IssueLabel
{
    public int IssueId { get; set; }
    public Issue Issue { get; set; } = null!;
    public int LabelId { get; set; }
    public Label Label { get; set; } = null!;
}
