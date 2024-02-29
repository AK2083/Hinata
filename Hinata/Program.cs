var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Logging.ClearProviders(); // Entfernt alle standardm��igen Logging-Provider
builder.Logging.AddConsole(); // F�gt den Konsolen-Logging-Provider hinzu

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.Logger.LogInformation("Das Passwort ist" + builder.Configuration["ConnectionString"]);

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
