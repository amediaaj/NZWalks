using Microsoft.EntityFrameworkCore;
using NZWalks.API.Demo;
using NZWalks.API.Data;
using NZWalks.API.Mappings;
using NZWalks.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

/***** DEMO need to add HTTP logging *****/
builder.Services.AddHttpLogging((o) => { });

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency injection of the NZWalksDbContext class and providing
// of the connection string from appsettings.json
// builder.Services.AddDbContext<NZWalksDbContext>(options => 
//     options.UseSqlServer(builder.Configuration.GetConnectionString("NZWalksConnectionString")));

// Dependency injection of in-memory database
builder.Services.AddDbContext<NZWalksDbContext>(options => 
    options.UseInMemoryDatabase(builder.Configuration.GetConnectionString("TestDB")));

// Inject implementations of IRegionRepository
builder.Services.AddScoped<IRegionRepository, SQLRegionRepository>();
builder.Services.AddScoped<IWalkRepository, SQLWalkRepository>();

// Inject AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

/***** DEMO dependency injection *****/
builder.Services.AddSingleton<IMyService, ExtensionsDemo>();
//builder.Services.AddSingleton<NZWalks.API.Demo.ILogger, Logger>();


var app = builder.Build();

// Seed in-memory database
using(var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<NZWalksDbContext>();
    var seeder = new DataSeeder(context);
    seeder.SeedData();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

/***** Demos need to add this to use logging *****/
app.UseHttpLogging();
/***** Demos as middleware *****/
app.Use(async (context, next) => {
    var myService = context.RequestServices.GetRequiredService<IMyService>();
    myService.LogCreation("Testing Properties Demo Middleware");
    myService.ExecuteDemo();
    await next.Invoke();
});

app.MapControllers();
app.Run();