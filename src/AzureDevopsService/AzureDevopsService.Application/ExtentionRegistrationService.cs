﻿using AzureDevopsService.Application.Events.IntegrationEvents.EventsHandlers;

namespace AzureDevopsService.Application;

public static class ExtentionRegistrationService
{
    public static IServiceCollection AddApplicationService(this IServiceCollection services)
    {
        _ = services.AddMassTransit(x =>
        {
            x.SetDefaultEndpointNameFormatter();
            _ = x.AddConsumer<AzureDevopsIntegrationEventsHandlers>();
            x.SetDefaultEndpointNameFormatter();

            x.UsingRabbitMq((context, cfg) =>
            {
                RabbitMqSettings rabbitMqSettings = context.GetRequiredService<IOptions<RabbitMqSettings>>().Value;

                cfg.Host(rabbitMqSettings.ServiceName, "/", h =>
                {
                    h.Username(rabbitMqSettings.UserName);
                    h.Password(rabbitMqSettings.Password);
                });
                cfg.UseNewtonsoftJsonSerializer();
                cfg.ReceiveEndpoint("AzureDevops", e =>
                {
                    e.SetQueueArgument("x-message-ttl", 60000);
                    e.ConfigureConsumer<AzureDevopsIntegrationEventsHandlers>(context);
                });
            });
        });
        _ = services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

        return services;
    }
}