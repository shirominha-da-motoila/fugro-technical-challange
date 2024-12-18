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
    return new CalculateOffsetAndStationOutput
    {
        Offset = 1,
        Station = new PointDto
        {
            X = 1,
            Y = 2,
        },
    };
})
.WithName("CalculateOffsetAndStation")
.WithOpenApi();

app.MapDefaultEndpoints();

app.Run();