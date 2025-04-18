﻿namespace AzureDevopsService.Contracts.SharedModel;

public class ConsumerInputs
{
    [JsonProperty("url")]
    public required Uri Url { get; set; }

    [JsonProperty("httpHeaders")]
    public required string HttpHeaders { get; set; }

    [JsonProperty("resourceDetailsToSend")]
    public required string ResourceDetailsToSend { get; set; }
}