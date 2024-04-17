using Api.Extensions;
using Api.Middleware;
using Dal;
using Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
});
builder.Services.AddHttpClient();
builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>();

builder.Services.AddAutoMapperConfigurations(builder.Configuration);
builder.Services.AddAppServices();
builder.Services.AddConfigurationsModels(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Scraping 
var service = app.Services.CreateScope().ServiceProvider.GetRequiredService<IActorsScrapperService>();
service.ScrapActors();

app.UseMiddleware<GlobalExceptionMiddleware>();
app.MapControllers();
app.UsePathBase(new PathString("/api"));
app.Run();
