﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureDevopsWebhookService.Contracts.EventModels.SharedModels.EventModels;

public record class Job(
    [property: JsonProperty(PropertyName = "_links", NullValueHandling = NullValueHandling.Ignore)]
    JobLink? Links,

    [property: JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
    string? Id,

    [property: JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)]
    string? Name,

    [property: JsonProperty(PropertyName = "state", NullValueHandling = NullValueHandling.Ignore)]
    string? State,

    [property: JsonProperty(PropertyName = "result", NullValueHandling = NullValueHandling.Ignore)]
    string? Result,

    [property: JsonProperty(PropertyName = "startTime", NullValueHandling = NullValueHandling.Ignore)]
    DateTime? StartTime,

    [property: JsonProperty(PropertyName = "finishTime", NullValueHandling = NullValueHandling.Ignore)]
    DateTime? FinishTime);