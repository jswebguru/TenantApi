﻿using System.ComponentModel.DataAnnotations;

public class TenantModel
{
    [Key]
    public int Id { get; set; }
    public string TenantId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}