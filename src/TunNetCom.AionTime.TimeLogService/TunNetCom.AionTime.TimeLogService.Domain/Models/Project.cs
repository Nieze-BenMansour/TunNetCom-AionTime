﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TunNetCom.AionTime.TimeLogService.Domain.Models;

[Table("Project")]
public partial class Project
{
    [Key]
    public int Id { get; set; }

    public int OrganisationId { get; set; }

    [ForeignKey("OrganisationId")]
    [InverseProperty("Projects")]
    public virtual Organisation Organisation { get; set; }

    [InverseProperty("Project")]
    public virtual ICollection<WorkItem> WorkItems { get; set; } = new List<WorkItem>();
}