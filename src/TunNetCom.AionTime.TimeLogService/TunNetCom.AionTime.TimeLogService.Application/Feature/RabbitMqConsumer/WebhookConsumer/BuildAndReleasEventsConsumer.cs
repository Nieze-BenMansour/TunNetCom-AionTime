﻿using MassTransit;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TunNetCom.AionTime.TimeLogService.Application.Feature.RabbitMqConsumer.WebhookConsumer;

public class BuildAndReleasEventsConsumer : IConsumer<AzureWebhookModelEvent<BuildAndReleaseResource>>
{
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
    public async Task Consume(ConsumeContext<AzureWebhookModelEvent<BuildAndReleaseResource>> context)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
    {
        string jsonMessage = JsonConvert.SerializeObject(context.Message);
        Console.WriteLine($"AzureWebhookModelEvent message: {jsonMessage}");
    }
}