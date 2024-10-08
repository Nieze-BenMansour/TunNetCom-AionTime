﻿global using MediatR;
global using Microsoft.AspNetCore.Diagnostics;
global using Microsoft.AspNetCore.Mvc;
global using Newtonsoft.Json;
global using OpenTelemetry.Instrumentation.AspNetCore;
global using OpenTelemetry.Logs;
global using OpenTelemetry.Metrics;
global using OpenTelemetry.Resources;
global using OpenTelemetry.Trace;
global using Serilog;
global using Serilog.Events;
global using System.Net;
global using TimeLogService.API;
global using TimeLogService.API.Middelware;
global using TimeLogService.Application;
global using TimeLogService.Contracts.DTOs.Request;
global using TimeLogService.Infrastructure;
global using TimeLogService.Infrastructure.AionTimeContext;