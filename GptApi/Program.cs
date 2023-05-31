using GptApi.Services.Implementation;
using GptApi.Services.Interface;
using Microsoft.AspNetCore.Rewrite;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IOpenAiService, OpenAiService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

var option = new RewriteOptions();
option.AddRedirect("^$", "swagger");
app.UseRewriter(option);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
