using FluentAssertions;
using Xunit;

namespace DockerComposeTesting.Tests
{
    public class EmptyTest
    {
        [Fact]
        public void Test() => true.Should().BeTrue();
        public Task TestAsync()
        {
            true.Should().BeTrue();
            return Task.CompletedTask;
        }
    }
}
