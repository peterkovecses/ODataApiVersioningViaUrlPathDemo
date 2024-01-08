using Asp.Versioning;
using Microsoft.AspNetCore.OData;
using ODataURLSegmentRoutingDemo.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddOData(options => options.Select().Filter().OrderBy().Expand().Count().SetMaxTop(null));
builder.Services
    .AddApiVersioning(options =>
    {
        options.ReportApiVersions = true;
        options.DefaultApiVersion = new ApiVersion(1);
        options.AssumeDefaultVersionWhenUnspecified = true;
    })
    .AddOData(options =>
    {
        options.ModelBuilder.DefaultModelConfiguration = (builder, apiVersion, routePrefix) =>
        {
            builder.EntitySet<Person>("People");
        };
        options.AddRouteComponents("api/v{version:apiVersion}");
    })
    .AddODataApiExplorer(options =>
    {
        options.GroupNameFormat = "'v'VVV";
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
