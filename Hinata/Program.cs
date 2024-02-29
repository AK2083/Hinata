using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Logging.ClearProviders(); // Entfernt alle standardmäßigen Logging-Provider
builder.Logging.AddConsole(); // Fügt den Konsolen-Logging-Provider hinzu

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

try
{
    using (var conn = new SqlConnection())
    {
        conn.Open();
        app.Logger.LogInformation("DB erfolgreich");
    }
}
catch (Exception ex)
{
    app.Logger.LogError($"Fehler beim Herstellen einer Datenbankverbindung: {ex.Message}");
}

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
