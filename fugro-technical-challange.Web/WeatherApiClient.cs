namespace fugro_technical_challange.Web;

public class ApiClient(HttpClient httpClient)
{
    public async Task<CalculateOffsetAndStationOutput> CalculateOffsetAndStationAsync(CalculateOffsetAndStationInput input, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.PostAsJsonAsync("/CalculateOffsetAndStation", input, cancellationToken);
        var output = await response.Content.ReadFromJsonAsync<CalculateOffsetAndStationOutput>(cancellationToken);

        return output;
    }
}

public record CalculateOffsetAndStationInput(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

public record CalculateOffsetAndStationOutput(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
