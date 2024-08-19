﻿using System.Text.Json.Serialization;

namespace WebAPICoreTask1.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string? ProductName { get; set; }

    public string? Description { get; set; }

    public string? Price { get; set; }

    public int? CategoryId { get; set; }

    public string? ProductImage { get; set; }

    [JsonIgnore]
    public virtual Category? Category { get; set; }
}
