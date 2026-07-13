using Microsoft.EntityFrameworkCore;
using SampleApi.Data;
using SampleApi.ML;
using SampleApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<TodoService>();


var app = builder.Build();

// ComplaintModelTrainer.Train();  // Train the ML model when the application starts for once. You can comment this line after the first run to avoid retraining the model every time the application starts.

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
