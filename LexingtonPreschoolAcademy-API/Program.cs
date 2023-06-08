using LexingtonPreschoolAcademy_Database;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Logging for debugging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();


var policyName = "AllowAll";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: policyName,
            builder =>
            {
                builder
                .AllowAnyOrigin()
                .WithMethods("GET", "POST", "PUT", "DELETE")
                .AllowAnyHeader();
            });
});




builder.Services.AddDbContext<LexingtonPreschoolAcademyDatabaseContext>(options =>
    options.UseSqlServer(
        @"Server=localhost;Database=LexingtonPreschoolAcademy;User=sa;Password=Scouter11#;encrypt=false;trustservercertificate=true;", 
        b => b.MigrationsAssembly("LexingtonPreschoolAcademy-API")
    )
);


builder.Services.AddDatabaseDeveloperPageExceptionFilter();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors(policyName);

app.UseAuthorization();

app.MapControllers();

app.Run();
