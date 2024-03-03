﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TunNetCom.AionTime.TimeLogService.Domain.Models;

[Table("Organisation")]
public partial class Organisation
{
    [Key]
    public int OrganisationId { get; set; }

    [Required]
    [StringLength(50)]
    [Unicode(false)]
    public string OrganisationName { get; set; }

    [InverseProperty("Organisation")]
    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}