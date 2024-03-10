﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using TunNetCom.AionTime.TimeLogService.Infrastructure.AionTimeContext;

#nullable disable

namespace TunNetCom.AionTime.TimeLogService.Infrastructure.AionTimeContext.Configurations
{
    public partial class WorkItemTimeLogConfiguration : IEntityTypeConfiguration<WorkItemTimeLog>
    {
        public void Configure(EntityTypeBuilder<WorkItemTimeLog> entity)
        {
            entity.HasOne(d => d.WorkItem).WithMany(p => p.WorkItemTimeLogs).HasConstraintName("FKProjectTicketLog");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<WorkItemTimeLog> entity);
    }
}
