using System;
using System.Collections.Generic;
using Pips.Models;
using Pips.Test.Extensions;
using Xunit;

namespace Pips.Test.ModelTests
{
    public class PipsResponseModelTests
    {
        readonly Type PipsResponseType = typeof(PipsResponse);

        [Fact]
        public void ValidatePipsResponseModelProperties()
        {
            Assert.Equal(2, PipsResponseType.GetProperties().Length);

            Assert.True(PipsResponseType.HasPropertyOfType<string>("Request"));
            Assert.True(PipsResponseType.HasPropertyOfType<IEnumerable<int>>("Rolls"));
        }
    }
}