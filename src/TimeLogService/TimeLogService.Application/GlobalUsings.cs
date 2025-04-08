﻿global using AutoMapper;
global using MediatR;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Logging;
global using Newtonsoft.Json;
global using System.Collections.Generic;
global using System.Collections.ObjectModel;
global using System.Reflection;
global using TimeLogService.Application.Events.IntegrationEvents.Events.Incoming.AzureDevopsIntegrationEvents;
global using TimeLogService.Application.Events.IntegrationEvents.Events.Outgoing.AzureDevopsIntegrationEvents;
global using TimeLogService.Application.Featurs.ProjectActions.Commands;
global using TimeLogService.Contracts.DTOs.Request;
global using TimeLogService.Domain.Interfaces.Repositories;
global using TimeLogService.Domain.Models.Dbo;
global using TunNetCom.AionTime.SharedKernel.EventBus.Abstractions;
global using TunNetCom.AionTime.SharedKernel.EventBus.Events;
