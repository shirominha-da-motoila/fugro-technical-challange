using Modules.CalculateOffsetAndStation;

namespace Web;

public class ApiClient(HttpClient httpClient)
{
    public async Task<CalculateOffsetAndStationOutput> CalculateOffsetAndStationAsync(CalculateOffsetAndStationInput input, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.PostAsJsonAsync("/CalculateOffsetAndStation", input, cancellationToken);
        var output = await response.Content.ReadFromJsonAsync<CalculateOffsetAndStationOutput>(cancellationToken);

        return output;
    }
}
