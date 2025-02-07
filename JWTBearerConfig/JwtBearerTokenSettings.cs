﻿namespace WebApplication2.JWTBearerConfig;

public class JwtBearerTokenSettings
{
    public string? SecretKey { get; set; }
    public string? Audience { get; set; } 
    public string? Issuer { get; set; }
    public int ExpireTimeInSeconds { get; set; }
}