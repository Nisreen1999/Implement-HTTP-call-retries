using Polly.Extensions.Http;
using Polly;
using static System.Net.Mime.MediaTypeNames;
using ImplementHTTPCallRetries;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//////////////////
builder.Services.AddHttpClient<Test>()
    .SetHandlerLifetime(TimeSpan.FromSeconds(10))
    .AddTransientHttpErrorPolicy(
    p => p.WaitAndRetryAsync(3,
        retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt) * 1)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
