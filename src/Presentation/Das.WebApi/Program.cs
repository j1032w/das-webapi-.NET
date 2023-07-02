using Das.Application;
using Das.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.OpenApi.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Serilog
using var log = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).CreateLogger();
Log.Logger = log;


// Add services to the container.
builder.Services.AddCoreApplication();
builder.Services.AddInfrastructureData();



// Api versioning
builder.Services.AddApiVersioning(options => {
    options.ApiVersionReader = new UrlSegmentApiVersionReader();
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
});

builder.Services.AddVersionedApiExplorer(options => {
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
    options.SubstitutionFormat = "VVV";
});


builder.Services.AddControllers();



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHealthChecks();

builder.Services.AddSwaggerGen(options => {
    options.SwaggerDoc(
        "v1",
        new OpenApiInfo { Title = "Dashboard Starter", Version = "v1.0" });
});


var app = builder.Build();


#region Middleware

app.UseHttpsRedirection();
app.UseAuthorization();


if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    
    app.UseSwaggerUI(options => {
        options.SwaggerEndpoint(
            $"/swagger/v1/swagger.json",
            $"Dashboard Starter v1");
    });

    app.UseDeveloperExceptionPage();
    app.MapGet("/", () => "Das WebApi!");
}
else {
    // Once the first HTTPS secure connection is established,
    // the strict-security header prevents future redirections that might be used to perform man -in-the - middle attacks.
    app.UseHsts();
    app.UseExceptionHandler("/error");
}


app.UseDefaultFiles(); // index.xhtml, default.xhtml, and so on
app.UseStaticFiles();
app.MapControllers();


Log.Information("Das WebApi .NET started");

#endregion

app.Run();