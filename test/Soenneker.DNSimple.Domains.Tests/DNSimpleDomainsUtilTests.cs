using Soenneker.DNSimple.Domains.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.DNSimple.Domains.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public class DNSimpleDomainsUtilTests : HostedUnitTest
{
    private readonly IDNSimpleDomainsUtil _util;

    public DNSimpleDomainsUtilTests(Host host) : base(host)
    {
        _util = Resolve<IDNSimpleDomainsUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
