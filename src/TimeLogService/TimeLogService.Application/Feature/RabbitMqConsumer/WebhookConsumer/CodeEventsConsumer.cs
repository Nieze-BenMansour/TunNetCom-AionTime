﻿namespace TimeLogService.Application.Feature.RabbitMqConsumer.WebhookConsumer;

public class CodeEventsConsumer : IConsumer<AzureWebhookModelEvent<CodeResource>>
{
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
    public async Task Consume(ConsumeContext<AzureWebhookModelEvent<CodeResource>> context)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
    {
        string jsonMessage = JsonConvert.SerializeObject(context.Message);
        Console.WriteLine($"AzureWebhookModelEvent message: {jsonMessage}");
    }
}