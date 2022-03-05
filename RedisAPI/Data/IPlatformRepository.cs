using RedisAPI.Models;

namespace RedisAPI.Data
{
    public interface IPlatformRepository
    {
        void CreatePlatform(Platform platform);
        Task<Platform?> GetPlatformByIdAsync(string id);
        Task<IEnumerable<Platform?>?> GetAllPlatformsAsync();
    }
}