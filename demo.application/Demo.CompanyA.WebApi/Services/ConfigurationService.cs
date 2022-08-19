using Demo.Application.Boundaries.Configuration;

namespace Demo.WebApi.Services;

public class ConfigurationService : IConfigurationService
{
    private readonly IConfiguration configuration;

    public ConfigurationService(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public T Get<T>(string key)
    {
        return configuration.GetSection(key).Get<T>();
    }
}
