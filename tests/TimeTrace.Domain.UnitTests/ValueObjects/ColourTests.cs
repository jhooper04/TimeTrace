using TimeTrace.Domain.Exceptions;
using TimeTrace.Domain.ValueObjects;
using FluentAssertions;
using NUnit.Framework;

namespace TimeTrace.Domain.UnitTests.ValueObjects;

public class ColourTests
{
    [Test]
    public void ShouldReturnCorrectColourCode()
    {
        var code = "#FFFFFF";

        var colour = Color.From(code);

        colour.Code.Should().Be(code);
    }

    [Test]
    public void ToStringReturnsCode()
    {
        var colour = Color.White;

        colour.ToString().Should().Be(colour.Code);
    }

    [Test]
    public void ShouldPerformImplicitConversionToColourCodeString()
    {
        string code = Color.White;

        code.Should().Be("#FFFFFF");
    }

    [Test]
    public void ShouldPerformExplicitConversionGivenSupportedColourCode()
    {
        var colour = (Color)"#FFFFFF";

        colour.Should().Be(Color.White);
    }

    [Test]
    public void ShouldThrowUnsupportedColourExceptionGivenNotSupportedColourCode()
    {
        FluentActions.Invoking(() => Color.From("##FF33CC"))
            .Should().Throw<UnsupportedColourException>();
    }
}
