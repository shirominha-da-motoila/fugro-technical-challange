using ApiService.Domain;
using Modules.CalculateOffsetAndStation;

var builder = WebApplication.CreateBuilder(args);
builder.AddServiceDefaults();
builder.Services.AddProblemDetails();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();
app.UseExceptionHandler();
app.UseSwagger();
app.UseSwaggerUI();

app.MapPost("/CalculateOffsetAndStation", (CalculateOffsetAndStationInput input) =>
{
    var polyline = new Polyline(input.Polyline.Select(p => new Point(p.X, p.Y)));
    var point = new Point(input.Point.X, input.Point.Y);
    var offsetsAndStations = polyline.CalculateOffsetsAndStations(point);

    return new CalculateOffsetsAndStationsOutput
    {
        OffsetsAndStations = offsetsAndStations.Select(os => new OffSetAndStation { Offset = os.Item1, Station = os.Item2 }),
    };
})
.WithName("CalculateOffsetAndStation")
.WithOpenApi();

app.MapDefaultEndpoints();

app.Run();