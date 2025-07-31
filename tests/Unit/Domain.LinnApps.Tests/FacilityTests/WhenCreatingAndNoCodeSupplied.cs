namespace Linn.Service.Domain.LinnApps.Tests.FacilityTests
{
    using System;

    using FluentAssertions;

    using Linn.Service.Domain.LinnApps.Exceptions;

    using NUnit.Framework;

    public class WhenCreatingAndNoCodeSupplied
    {
        private Action act;

        [SetUp]
        public void SetUp()
        {
            this.act = () => new Facility(string.Empty, "blah", "blah", "blah", "blah");
        }

        [Test]
        public void ShouldThrow()
        {
            this.act.Should().Throw<InvalidEntityException>();
        }
    }
}
