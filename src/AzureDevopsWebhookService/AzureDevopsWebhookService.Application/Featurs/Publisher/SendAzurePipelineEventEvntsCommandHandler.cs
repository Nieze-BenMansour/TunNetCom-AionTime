﻿namespace AzureDevopsWebhookService.Application.Featurs.Publisher;

public class SendAzurePipelineEventEvntsCommandHandler(IPublishEndpoint publishEndpoint)
: IRequestHandler<AzureWebhookModelEvent<PipeLinesResource>, HttpStatusCode>
{
    private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;

    public async Task<HttpStatusCode> Handle(AzureWebhookModelEvent<PipeLinesResource> request, CancellationToken cancellationToken)
    {
        await _publishEndpoint.Publish(request, cancellationToken);
        return HttpStatusCode.OK;
    }
}