﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Day2.Models;

[Table("Department")]
public partial class Department
{
    [Key]
    public int Dept_Id { get; set; }

    [StringLength(50)]
    public string Dept_Name { get; set; }

    [StringLength(100)]
    public string Dept_Desc { get; set; }

    [StringLength(50)]
    public string Dept_Location { get; set; }

    public int? Dept_Manager { get; set; }

    public DateOnly? Manager_hiredate { get; set; }

    [InverseProperty("Dept")]
    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}