[![](https://img.shields.io/nuget/v/soenneker.dnsimple.domains.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.dnsimple.domains/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.dnsimple.domains/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.dnsimple.domains/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.dnsimple.domains.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.dnsimple.domains/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.dnsimple.domains/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.dnsimple.domains/actions/workflows/codeql.yml)

# Soenneker.DNSimple.Domains

Provides focused operations for listing, retrieving, creating, and deleting DNSimple domains.

## Installation

```bash
dotnet add package Soenneker.DNSimple.Domains
```

## Configuration and registration

```json
{
  "DNSimple": {
    "AccountId": 12345,
    "Token": "your-api-token",
    "Test": false
  }
}
```

```csharp
using Soenneker.DNSimple.Domains.Registrars;

services.AddDNSimpleDomainsUtilAsScoped();
```

## Usage

```csharp
using Soenneker.DNSimple.Domains.Abstract;
using Soenneker.DNSimple.OpenApiClient.Models;

public sealed class DomainReader(IDNSimpleDomainsUtil domains)
{
    public ValueTask<IEnumerable<Domain>> Find(
        string name,
        CancellationToken cancellationToken)
    {
        return domains.List(
            nameLike: name,
            sort: "name:asc",
            cancellationToken: cancellationToken);
    }
}
```

Supported sort values are `id:asc`, `id:desc`, `name:asc`, `name:desc`, `expiration:asc`, and `expiration:desc`. `Get` accepts a domain name or DNSimple domain ID. `List` returns the domains in the API response; the generated request builder does not currently expose pagination controls, so the wrapper does not promise automatic traversal of additional pages.
