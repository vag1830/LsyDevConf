namespace Demo.Application.Boundaries.Configuration;

public interface IConfigurationService
{
    T Get<T>(string key);
}
