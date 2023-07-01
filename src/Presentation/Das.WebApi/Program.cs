
var builder = WebApplication.CreateBuilder(args);




builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();





var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // middleware that generates the OpenAPI document
    app.UseSwaggerUI(); // Renders the Swagger UI web page
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
