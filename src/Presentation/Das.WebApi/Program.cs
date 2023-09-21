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


#region Dependency Injection
builder.Services.AddCoreApplication();
builder.Services.AddInfrastructureData();

#endregion



#region Services Configuration
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Api versioning
builder.Services.AddApiVersioning(options =>
{
    options.ApiVersionReader = new UrlSegmentApiVersionReader();
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
});

builder.Services.AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
    options.SubstitutionFormat = "VVV";
});


builder.Services
    .AddControllers()
    .AddNewtonsoftJson();

// discard properties with null values.
builder.Services.Configure<MvcNewtonsoftJsonOptions>(opts =>
{
    opts.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHealthChecks();

builder.Services.AddSwaggerGen(options =>
{
    options.EnableAnnotations();
    options.EnableAnnotations(enableAnnotationsForInheritance: true, enableAnnotationsForPolymorphism: true);

    options.SwaggerDoc(
        "v1",
        new OpenApiInfo
        {
            Title = "Dashboard Starter",
            Description = "The backend .NET Web API for Dashboard Starter",
            Version = "v1.0",
            License = new OpenApiLicense
            {
                Name = "Use under MIT",
                Url = new Uri("https://opensource.org/license/mit/"),
            },
            Contact = new OpenApiContact
            {
                Name = "J1032",
                Email = string.Empty,
                Url = new Uri("https://github.com/j1032w/das-webapi-.NET"),
            },
        });

    options.IncludeXmlComments(Path.Combine(System.AppContext.BaseDirectory, "Das.WebApi.xml"));
    options.IncludeXmlComments(Path.Combine(System.AppContext.BaseDirectory, "Das.Application.xml"));
});

#endregion



var app = builder.Build();



#region Middleware

app.UseHttpsRedirection();
app.UseAuthorization();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint(
            $"/swagger/v1/swagger.json",
            $"Dashboard Starter v1");
    });

    app.UseDeveloperExceptionPage();
    app.MapGet("/", () => "Das WebApi!");
}
else
{
    // Once the first HTTPS secure DbConnection is established,
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



