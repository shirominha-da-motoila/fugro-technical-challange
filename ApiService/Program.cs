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
    var (offset, station) = polyline.CalculateOffsetAndStation(point);

    return new CalculateOffsetAndStationOutput
    {
        Offset = offset,
        Station = station,
    };
})
.WithName("CalculateOffsetAndStation")
.WithOpenApi();

app.MapDefaultEndpoints();

app.Run();