﻿namespace WebhookService.Contracts.EventModels.SharedModels.EventModels;

public record PushedBy(
    [property: JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
    string? Id,

    [property: JsonProperty(PropertyName = "displayName", NullValueHandling = NullValueHandling.Ignore)]
    string? DisplayName,

    [property: JsonProperty(PropertyName = "uniqueName", NullValueHandling = NullValueHandling.Ignore)]
    string? UniqueName);