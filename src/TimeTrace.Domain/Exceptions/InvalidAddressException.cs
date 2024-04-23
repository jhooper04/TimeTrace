using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTrace.Domain.Exceptions;
public class InvalidAddressException : Exception
{
    public InvalidAddressException(string fullAddress)
        : base($"Address \"{fullAddress}\" is not a valid USPS address.")
    {
    }
}
