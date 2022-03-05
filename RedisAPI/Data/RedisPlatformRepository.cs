using System.Text.Json;
using RedisAPI.Models;
using StackExchange.Redis;

namespace RedisAPI.Data
{
    public class RedisPlatformRepository : IPlatformRepository
    {
        private readonly IConnectionMultiplexer _redis;

        public RedisPlatformRepository(IConnectionMultiplexer redis)
        {
            _redis = redis;
        }
        public void CreatePlatform(Platform platform)
        {
            if (platform == null)
            {
                throw new ArgumentOutOfRangeException(nameof(platform));
            }
            var db = _redis.GetDatabase();

            var serializedPlatform = JsonSerializer.Serialize(platform);

            // db.StringSet(platform.Id, serializedPlatform);
            // db.SetAdd("PlatformSet", serializedPlatform);

            db.HashSetAsync("hashplatform", new HashEntry[]
                {new HashEntry(platform.Id, serializedPlatform)});
        }

        public async Task<IEnumerable<Platform?>?> GetAllPlatformsAsync()
        {
            var db = _redis.GetDatabase();

            // var completeSet = await db.SetMembersAsync("PlatformSet");
            var completedHash = await db.HashGetAllAsync("hashplatform");

            if (completedHash.Length > 0)
            {
                var res = Array.ConvertAll(completedHash, val => JsonSerializer.Deserialize<Platform>(val.Value)).ToList();
                return res;
            }
            return null;
        }

        public async Task<Platform?> GetPlatformByIdAsync(string id)
        {
            var db = _redis.GetDatabase();

            // var platform = await db.StringGetAsync(id);
            var platform = await db.HashGetAsync("hashplatform", id);

            if (!string.IsNullOrEmpty(platform))
            {
                return JsonSerializer.Deserialize<Platform?>(platform);
            }

            return null;
        }
    }
}