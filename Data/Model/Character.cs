﻿namespace RickAndMorty.Data.Model;
public class Character
{
    public int Id { get; set; }
    public string? Name { get; set; } = string.Empty;
    public string? Status { get; set; } = string.Empty;
    public string? Species { get; set; } = string.Empty;
    public string? Gender { get; set; } = string.Empty;
    public string? Image { get; set; } = string.Empty;
}
