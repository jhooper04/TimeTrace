using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTrace.Domain.ValueObjects;
public class Address : ValueObject
{
    public string Street { get; private set; }
    public string City { get; private set; } 
    public string State { get; private set; }
    public string Zip { get; private set; }

    public Address(string street, string city, string state, string zip)
    {
        Street = street;
        City = city;
        State = state;
        Zip = zip;
    }

    public Address(string fullAddress)
    {
        var address = From(fullAddress);
        Street = address.Street;
        City = address.City;
        State = address.State;
        Zip = address.Zip;
    }

    public Address()
    {
        Street = string.Empty;
        City = string.Empty;
        State = string.Empty;
        Zip = string.Empty;
    }

    public static Address From(string fullAddress)
    {
        if (string.IsNullOrEmpty(fullAddress)) return new Address();

        var parts = fullAddress.Split(",", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

        if (parts.Length < 3)
        {
            throw new InvalidAddressException(fullAddress);
        }

        var stateZip = parts[2].Split(' ');

        if (parts.Length != 2)
        {
            throw new InvalidAddressException(fullAddress);
        }

        return new Address(parts[0], parts[1], stateZip[0], stateZip[1]);
    }

    public bool IsEmpty()
    {
        return this == new Address();
    }

    //public static implicit operator string(Address address)
    //{
    //    return address.ToString();
    //}

    //public static explicit operator Address(string fullAddress)
    //{
    //    return From(fullAddress);
    //}

    public override string ToString()
    {
        if (IsEmpty()) return string.Empty;
        return $"{Street}, {City}, {State} {Zip}";
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Street;
        yield return City;
        yield return State;
        yield return Zip;
    }
}
