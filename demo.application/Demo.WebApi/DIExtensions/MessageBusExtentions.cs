using Demo.Application.Boundaries.Configuration;
using Demo.Application.Boundaries.MessageBus;
using Demo.MessageBus.Email;
using Demo.MessageBus.Kafka;
using Demo.MessageBus.Services;

namespace Demo.WebApi.DIExtensions;

public static class MessageBusExtentions
{
    public static IServiceCollection AddMessageBusServices(this IServiceCollection services, IConfigurationService configurationService)
    {
        services.AddScoped<IMessageBus, MessageBus.MessageBus>();

        services.AddScoped<EmailService>();
        services.AddScoped<KafkaService>();

        services.AddTransient<MessageServiceResolver>(serviceProvider => key =>
        {
            var configuration = configurationService.Get<MessageConfiguration>(key);

            var resolvedServices = new List<IMessageService>();

            if (configuration.IsEmailEnabled)
            {
                var emailService = serviceProvider.GetRequiredService<EmailService>();

                resolvedServices.Add(emailService);
            }

            if (configuration.IsKafkaEnabled)
            {
                var kafkaService = serviceProvider.GetRequiredService<KafkaService>();

                resolvedServices.Add(kafkaService);
            }

            return resolvedServices;
        });

        return services;
    }
}
