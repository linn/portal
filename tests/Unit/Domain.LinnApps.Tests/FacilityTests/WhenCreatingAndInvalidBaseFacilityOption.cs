namespace Linn.Service.Domain.LinnApps.Tests.FacilityTests
{
    using System;

    using FluentAssertions;

    using Linn.Service.Domain.LinnApps.Exceptions;

    using NUnit.Framework;

    public class WhenCreatingAndInvalidBaseFacilityOption
    {
        private Action act;

        [SetUp]
        public void SetUp()
        {
            this.act = () => new Facility("CODE", "blah", "O", "blah", "blah");
        }

        [Test]
        public void ShouldThrow()
        {
            this.act.Should().Throw<InvalidEntityException>().WithMessage("Base Facility must be Y or N");
        }
    }
}
