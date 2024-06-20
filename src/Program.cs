using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Mongo_API.Services;
using Mongo_API.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Mongo_API", Version = "v1" });
});

builder.Services.Configure<MongoAPIDatabaseSettings>(builder.Configuration.GetSection(nameof(MongoAPIDatabaseSettings)));

builder.Services.AddSingleton<IMongoApiDatabaseSettings>(sp =>
    sp.GetRequiredService<IOptions<MongoAPIDatabaseSettings>>().Value);

builder.Services.AddSingleton<PersonService>();

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