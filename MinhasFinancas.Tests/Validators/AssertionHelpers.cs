using System;
using System.Threading.Tasks;
using FluentAssertions;

namespace MinhasFinancas.Tests.Validators;

public static class AssertionHelpers
{
    public static void ShouldBe<T>(T actual, T expected, string? because = null, params object[] becauseArgs)
    {
        actual.Should().Be(expected, because, becauseArgs);
    }

    public static void ShouldBeTrue(bool condition, string? because = null, params object[] becauseArgs)
    {
        condition.Should().BeTrue(because, becauseArgs);
    }

    public static void ShouldBeFalse(bool condition, string? because = null, params object[] becauseArgs)
    {
        condition.Should().BeFalse(because, becauseArgs);
    }

    public static void ShouldNotBeNull(object? value, string? because = null, params object[] becauseArgs)
    {
        value.Should().NotBeNull(because, becauseArgs);
    }

    public static async Task ShouldThrowExceptionContainingAsync<T>(Func<Task> action, string expectedMessage) where T : Exception
    {
        var exception = await Assert.ThrowsAsync<T>(action);
        exception.Message.Should().Contain(expectedMessage);
    }
}