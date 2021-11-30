using Serilog;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .Enrich.FromLogContext()
    .WriteTo.Async(c => c.Console())
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

builder.Host.AddAppSettingsSecretsJson()
    .UseAutofac()
    .UseSerilog();
builder.Services.ReplaceConfiguration(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApplication<SampleModule>();
var app = builder.Build();
app.InitializeApplication();
app.Run();
