using PMS_Net.Models;
using PMS_Net.Repo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Dependancy Injection
builder.Services.AddSingleton<IProjectRepo,ProjectRepo>();
builder.Services.AddSingleton<Connection>();

var app = builder.Build();

app.UsePathBase("/api");
app.UseRouting();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();
app.UseCors(
        options => options.WithOrigins("http://localhost").AllowAnyOrigin()
    );
app.Run();
