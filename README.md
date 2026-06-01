# Firefly C# API Library

The Firefly C# SDK provides convenient access to the [Firefly REST API](https://firefly-iii.org) from applications written in C#.

It is generated with [Stainless](https://www.stainless.com/).

The REST API documentation can be found on [firefly-iii.org](https://firefly-iii.org).

## Installation

```bash
git clone git@github.com:stainless-sdks/emcees-prod-testing-5-csharp.git
dotnet add reference emcees-prod-testing-5-csharp/src/Firefly
```

## Requirements

This library requires .NET Standard 2.0 or later.

## Usage

See the [`examples`](examples) directory for complete and runnable examples.

```csharp
using System;
using Firefly;
using Firefly.Models.Autocomplete;

FireflyClient client = new();

AutocompleteListAccountsParams parameters = new();

var response = await client.Autocomplete.ListAccounts(parameters);

Console.WriteLine(response);
```

## Client configuration

Configure the client using environment variables:

```csharp
using Firefly;

// Configured using the FIREFLY_BEARER_TOKEN and FIREFLY_BASE_URL environment variables
FireflyClient client = new();
```

Or manually:

```csharp
using Firefly;

FireflyClient client = new();
```

Or using a combination of the two approaches.

See this table for the available options:

| Property      | Environment variable   | Required | Default value                        |
| ------------- | ---------------------- | -------- | ------------------------------------ |
| `BearerToken` | `FIREFLY_BEARER_TOKEN` | false    | -                                    |
| `BaseUrl`     | `FIREFLY_BASE_URL`     | true     | `"https://demo.firefly-iii.org/api"` |

### Modifying configuration

To temporarily use a modified client configuration, while reusing the same connection and thread pools, call `WithOptions` on any client or service:

```csharp
using System;

var response = await client
    .WithOptions(options =>
        options with
        {
            BaseUrl = "https://example.com",
            Timeout = TimeSpan.FromSeconds(42),
        }
    )
    .Autocomplete.ListAccounts(parameters);

Console.WriteLine(response);
```

Using a [`with` expression](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/with-expression) makes it easy to construct the modified options.

The `WithOptions` method does not affect the original client or service.

## Requests and responses

To send a request to the Firefly API, build an instance of some `Params` class and pass it to the corresponding client method. When the response is received, it will be deserialized into an instance of a C# class.

For example, `client.Autocomplete.ListAccounts` should be called with an instance of `AutocompleteListAccountsParams`, and it will return an instance of `Task<List<AutocompleteListAccountsResponse>>`.

## Binary responses

The SDK defines methods that return binary responses, which are used for API responses that shouldn't necessarily be parsed, like non-JSON data.

These methods return `HttpResponse`:

```csharp
using System;
using Firefly.Models.Data.Export;

ExportExportAccountsParams parameters = new();

var response = await client.Data.Export.ExportAccounts(parameters);

Console.WriteLine(response);
```

To save the response content to a file, or any [`Stream`](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream?view=net-9.0), use the [`CopyToAsync`](<https://learn.microsoft.com/en-us/dotnet/api/system.io.stream.copytoasync?view=net-9.0#system-io-stream-copytoasync(system-io-stream)>) method:

```csharp
using System.IO;

using var response = await client.Data.Export.ExportAccounts();
using var contentStream = await response.ReadAsStream();
using var fileStream = File.Open(path, FileMode.OpenOrCreate);
await contentStream.CopyToAsync(fileStream); // Or any other Stream
```

## Raw responses

The SDK defines methods that deserialize responses into instances of C# classes. However, these methods don't provide access to the response headers, status code, or the raw response body.

To access this data, prefix any HTTP method call on a client or service with `WithRawResponse`:

```csharp
var response = await client.WithRawResponse.Autocomplete.ListAccounts();
var statusCode = response.StatusCode;
var headers = response.Headers;
```

The raw `HttpResponseMessage` can also be accessed through the `RawMessage` property.

For non-streaming responses, you can deserialize the response into an instance of a C# class if needed:

```csharp
using System;
using System.Collections.Generic;
using Firefly.Models.Autocomplete;

var response = await client.WithRawResponse.Autocomplete.ListAccounts();
List<AutocompleteListAccountsResponse> deserialized = await response.Deserialize();
Console.WriteLine(deserialized);
```

## Error handling

The SDK throws custom unchecked exception types:

- `FireflyApiException`: Base class for API errors. See this table for which exception subclass is thrown for each HTTP status code:

| Status | Exception                              |
| ------ | -------------------------------------- |
| 400    | `FireflyBadRequestException`           |
| 401    | `FireflyUnauthorizedException`         |
| 403    | `FireflyForbiddenException`            |
| 404    | `FireflyNotFoundException`             |
| 422    | `FireflyUnprocessableEntityException`  |
| 429    | `FireflyRateLimitException`            |
| 5xx    | `Firefly5xxException`                  |
| others | `FireflyUnexpectedStatusCodeException` |

Additionally, all 4xx errors inherit from `Firefly4xxException`.

- `FireflyIOException`: I/O networking errors.

- `FireflyInvalidDataException`: Failure to interpret successfully parsed data. For example, when accessing a property that's supposed to be required, but the API unexpectedly omitted it from the response.

- `FireflyException`: Base class for all exceptions.

## Network options

### Retries

The SDK automatically retries 2 times by default, with a short exponential backoff between requests.

Only the following error types are retried:

- Connection errors (for example, due to a network connectivity problem)
- 408 Request Timeout
- 409 Conflict
- 429 Rate Limit
- 5xx Internal

The API may also explicitly instruct the SDK to retry or not retry a request.

To set a custom number of retries, configure the client using the `MaxRetries` method:

```csharp
using Firefly;

FireflyClient client = new() { MaxRetries = 3 };
```

Or configure a single method call using [`WithOptions`](#modifying-configuration):

```csharp
using System;

var response = await client
    .WithOptions(options =>
        options with { MaxRetries = 3 }
    )
    .Autocomplete.ListAccounts(parameters);

Console.WriteLine(response);
```

### Timeouts

Requests time out after 1 minute by default.

To set a custom timeout, configure the client using the `Timeout` option:

```csharp
using System;
using Firefly;

FireflyClient client = new() { Timeout = TimeSpan.FromSeconds(42) };
```

Or configure a single method call using [`WithOptions`](#modifying-configuration):

```csharp
using System;

var response = await client
    .WithOptions(options =>
        options with { Timeout = TimeSpan.FromSeconds(42) }
    )
    .Autocomplete.ListAccounts(parameters);

Console.WriteLine(response);
```

### Proxies

To route requests through a proxy, configure your client with a custom [`HttpClient`](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient?view=net-10.0):

```csharp
using System.Net;
using System.Net.Http;
using Firefly;

var httpClient = new HttpClient
(
    new HttpClientHandler
    {
        Proxy = new WebProxy("https://example.com:8080")
    }
);

FireflyClient client = new() { HttpClient = httpClient };
```

### Environments

The SDK sends requests to the production environment by default. To send requests to a different environment, configure the client like so:

```csharp
using Firefly;
using Firefly.Core;

FireflyClient client = new() { BaseUrl = EnvironmentUrl.Environment1 };
```

## Undocumented API functionality

The SDK is typed for convenient usage of the documented API. However, it also supports working with undocumented or not yet supported parts of the API.

### Parameters

To set undocumented parameters, a constructor exists that accepts dictionaries for additional header, query, and body values. If the method type doesn't support request bodies (e.g. `GET` requests), the constructor will only accept a header and query dictionary.

```csharp
using System.Collections.Generic;
using System.Text.Json;
using Firefly.Models.Autocomplete;

AutocompleteListAccountsParams parameters = new
(
    rawHeaderData: new Dictionary<string, JsonElement>()
    {
        { "Custom-Header", JsonSerializer.SerializeToElement(42) }
    },

    rawQueryData: new Dictionary<string, JsonElement>()
    {
        { "custom_query_param", JsonSerializer.SerializeToElement(42) }
    }
)
{
    // Documented properties can still be added here.
    // In case of conflict, these parameters take precedence over the custom parameters.
    Limit = 0
};
```

The raw parameters can also be accessed through the `RawHeaderData`, `RawQueryData`, and `RawBodyData` (if available) properties.

This can also be used to set a documented parameter to an undocumented or not yet supported _value_, as long as the parameter is optional. If the parameter is required, omitting its `init` property will result in a compile-time error. To work around this, the `FromRawUnchecked` method can be used:

```csharp
using System.Collections.Generic;
using System.Text.Json;
using Firefly.Models.Chart.Account;

var parameters = AccountRetrieveOverviewParams.FromRawUnchecked
(

    rawHeaderData: new Dictionary<string, JsonElement>(),
    rawQueryData: new Dictionary<string, JsonElement>
    {
        {
            "end",
            JsonSerializer.SerializeToElement("custom value")
        }
    }
);
```

### Response properties

To access undocumented response properties, the `RawData` property can be used:

```csharp
using System.Text.Json;

var response = client.Autocomplete.ListAccounts()
if (response.RawData.TryGetValue("my_custom_key", out JsonElement value))
{
    // Do something with `value`
}
```

`RawData` is a `IReadonlyDictionary<string, JsonElement>`. It holds the full data received from the API server.

### Response validation

In rare cases, the API may return a response that doesn't match the expected type. For example, the SDK may expect a property to contain a `string`, but the API could return something else.

By default, the SDK will not throw an exception in this case. It will throw `FireflyInvalidDataException` only if you directly access the property.

If you would prefer to check that the response is completely well-typed upfront, then either call `Validate`:

```csharp
var accountSingle = client.Accounts.Create(parameters);
accountSingle.Validate();
```

Or configure the client using the `ResponseValidation` option:

```csharp
using Firefly;

FireflyClient client = new() { ResponseValidation = true };
```

Or configure a single method call using [`WithOptions`](#modifying-configuration):

```csharp
using System;

var accountSingle = await client
    .WithOptions(options =>
        options with { ResponseValidation = true }
    )
    .Accounts.Create(parameters);

Console.WriteLine(accountSingle);
```

## Semantic versioning

This package generally follows [SemVer](https://semver.org/spec/v2.0.0.html) conventions, though certain backwards-incompatible changes may be released as minor versions:

1. Changes to library internals which are technically public but not intended or documented for external use. _(Please open a GitHub issue to let us know if you are relying on such internals.)_
2. Changes that we do not expect to impact the vast majority of users in practice.

We take backwards-compatibility seriously and work hard to ensure you can rely on a smooth upgrade experience.

We are keen for your feedback; please open an [issue](https://www.github.com/stainless-sdks/emcees-prod-testing-5-csharp/issues) with questions, bugs, or suggestions.
