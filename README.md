# .NET-6-Redis
Redis as a Primary Db

In this template:
    we're not making use of DTOs;
    we're using:
        IConnectionMultiplexer: all datatypes available.
    you could use:
        IDistributedCache: restricted datatypes. 

## References

- [Redis as a Primary DB using a .NET 6 API](https://www.youtube.com/watch?v=GgyizgXwXAg) by Les Jackson
- [Les Jackson's Blog: Redis as a Primary DB](https://dotnetplaybook.com/redis-as-a-primary-database/)
- [Redis Persistence](https://redis.io/topics/persistence)
- [Redis data types](https://redis.io/topics/data-types-intro)
- [Nullable Reference Types](https://docs.microsoft.com/en-us/dotnet/csharp/nullable-references)
- [Using SCAN](https://redis.io/commands/scan)
- [Stack Exchange Key Scan](https://stackexchange.github.io/StackExchange.Redis/KeysScan.html)

## End Points

| Description                | Verb  | Route                |
| :---:                      | :---: | :---:                |
| Retrieve a single resource | GET   | api/v1/platform/{id} |
| Create a resource          | POST  | api/v1/platform      |
| Retrieve all resources     | GET   | api/v1/platform      |

## Packages
Stack Exchange Redis
    Microsoft.Extensions.Caching.StackExchangeRedis
