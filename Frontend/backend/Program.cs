using Microsoft.EntityFrameworkCore;
using Heroes.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure In-Memory Database
builder.Services.AddDbContext<HeroesContext>(options =>
    options.UseInMemoryDatabase("HeroesDb"));

// Configure Kestrel to listen on port 6969
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenLocalhost(6969);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// Ensure Swagger is always available for this task as requested, even if not in "Development" env technically, 
// though usually IsDevelopment is true for local runs. 
// The prompt URL is http://localhost:6969/swagger/index.html
app.UseSwagger();
app.UseSwaggerUI();

// app.UseHttpsRedirection(); // Disable HTTPS as requested/implied by localhost:6969 without https

app.UseAuthorization();

app.MapControllers();

// Seed the database
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<HeroesContext>();
    context.Database.EnsureCreated();
}

app.Run();
