﻿using AzureDevopsService.Contracts.Internal.Interfaces;

namespace AzureDevopsService.Infrasructure.AzureDevopsExternalResourceService;

public class WebhookService(HttpClient httpClient, ILogger<WebhookService> logger) : IWebhookService
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly ILogger<WebhookService> _logger = logger;

    public async Task<OneOf<WebhookResponce, WebhookBadRequestResponce>> CreateWebhookSubscription(ServiceHookReques request)
    {
        HttpClientHelper.SetAuthHeader(_httpClient, request.Path);

        HttpResponseMessage webhookResponce = await _httpClient.PostAsJsonAsync($"{request.OrganizationName}{AzureUrlsEndPoint.Subscription}", request);
        if (webhookResponce.IsSuccessStatusCode)
        {
            return await webhookResponce.Content.ReadFromJsonAsync<WebhookResponce>();
        }

        WebhookBadRequestResponce? badRequestResponse = await webhookResponce.Content.ReadFromJsonAsync<WebhookBadRequestResponce>();
        _logger.LogError("fail to create webhook for user", request.Email, badRequestResponse);
        return badRequestResponse;
    }
}