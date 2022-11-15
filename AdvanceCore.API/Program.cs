using System.Text.Json.Serialization;
using AdvanceCore.Application;
using AdvanceCore.Infrastructure;
using AdvanceCore.Infrastructure.Persistence;


var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.
    builder.Services
        .AddInfrastructureService(builder.Configuration)
        .AddApplication();

    builder.Services.AddCors(options =>
    {
        options.AddPolicy(name: "mySpecificOrigins",
            builder =>
            {
                builder.WithOrigins("https://localhost:5000")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
            });
    });



    builder.Services.AddControllers().AddJsonOptions(options =>
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
}

var app = builder.Build();
{
    using (var scope = app.Services.CreateScope())
    {
        var initializer = scope.ServiceProvider.GetService<ApplicationDbContextInitializer>();
        if (initializer is not null)
        {
            await initializer.InitializeAsync();
            await initializer.SeedAsync();
        }
    }
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
    }
    app.UseCors("mySpecificOrigins");
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}


