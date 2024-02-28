﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TunNetCom.AionTime.TimeLogService.Domain.Models;

namespace TunNetCom.AionTime.TimeLogService.Infrastructure.AionTimeContext;

public partial class TunNetComAionTimeTimeLogServiceDataBaseContext : DbContext
{
    public TunNetComAionTimeTimeLogServiceDataBaseContext(DbContextOptions<TunNetComAionTimeTimeLogServiceDataBaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Organisation> Organisations { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<TicketHistory> TicketHistories { get; set; }

    public virtual DbSet<TicketTimeLog> TicketTimeLogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Organisation>(entity =>
        {
            entity.Property(e => e.OrganisationId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.Property(e => e.ProjectId).ValueGeneratedNever();

            entity.HasOne(d => d.Organisation).WithMany(p => p.Projects).HasConstraintName("FKOrganisationProject");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.Property(e => e.TicketId).ValueGeneratedNever();

            entity.HasOne(d => d.Project).WithMany(p => p.Tickets).HasConstraintName("FKProjectTicket");
        });

        modelBuilder.Entity<TicketHistory>(entity =>
        {
            entity.Property(e => e.TicketHistoryId).ValueGeneratedNever();

            entity.HasOne(d => d.Ticket).WithMany(p => p.TicketHistories).HasConstraintName("FKTicketHistory");
        });

        modelBuilder.Entity<TicketTimeLog>(entity =>
        {
            entity.Property(e => e.TicketTimeLogId).ValueGeneratedNever();

            entity.HasOne(d => d.Ticket).WithMany(p => p.TicketTimeLogs).HasConstraintName("FKProjectTicketLog");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}