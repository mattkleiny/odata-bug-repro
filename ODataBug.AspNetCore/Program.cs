using Microsoft.AspNetCore.OData;
using ODataBug.AspNetCore.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddOData(opt =>
        {
            opt.SetMaxTop(null);
            //opt.Expand(QueryOptionSetting.Disabled)
            opt.AddRouteComponents("v3", EdmModelBuilder.GetEdmModel());
        });

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseODataRouteDebug();

app.UseAuthorization();

app.MapControllers();

app.Run();
