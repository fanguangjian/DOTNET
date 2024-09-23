var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors((options)=> {
    options.AddPolicy("DevCors", (corsBuilder) => {
        corsBuilder.WithOrigins("Http://localhost:4200", "Http://localhost:3000" ,"Http://localhost:8000")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
    });

    options.AddPolicy("ProdCors", (corsBuilder) => {
        corsBuilder.WithOrigins("Http://mysite.com")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{   
    app.UseCors("DevCors");
    app.UseSwagger();
    app.UseSwaggerUI();
} else {
    app.UseCors("ProdCors");
    app.UseHttpsRedirection();
}


app.MapControllers();

// app.MapGet("/weatherforecast", () =>
// {
   
// })
// .WithName("GetWeatherForecast")
// .WithOpenApi();

app.Run();


