using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Logging (you can uncomment and configure Serilog if needed)
// builder.Host.UseSerilog((context, services, configuration) => 
//     configuration.WriteTo.File("C:\\Logs\\log-.txt", rollingInterval: RollingInterval.Day));

// Add services

builder.Services.AddDbContext<CollegeApp.Data.CollegeDBContext>(options =>
   {
       options.UseSqlServer(builder.Configuration.GetConnectionString("CollegeAppDBConnection"));
       });
builder.Services.AddControllers()
    .AddNewtonsoftJson()
    .AddXmlDataContractSerializerFormatters();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "College API", Version = "v1" });
});

var app = builder.Build();

// Configure middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
