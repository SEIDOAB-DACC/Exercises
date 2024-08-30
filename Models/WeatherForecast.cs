﻿using Configuration;
using Seido.Utilities.SeedGenerator;

namespace Models;

public record WeatherForecast(DateOnly Date, int TemperatureC, string Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    public string Author => csAppConfig.Author;
}