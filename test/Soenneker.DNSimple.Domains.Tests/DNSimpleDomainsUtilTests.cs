using Soenneker.DNSimple.Domains.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.DNSimple.Domains.Tests;

[Collection("Collection")]
public class DNSimpleDomainsUtilTests : FixturedUnitTest
{
    private readonly IDnSimpleDomainsUtil _util;

    public DNSimpleDomainsUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _util = Resolve<IDnSimpleDomainsUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
