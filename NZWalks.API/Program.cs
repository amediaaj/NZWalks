using Microsoft.EntityFrameworkCore;
using NZWalks.API.Common;
using NZWalks.API.Data;

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
builder.Services.AddDbContext<NZWalksDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("NZWalksConnectionString")));

/***** DEMO dependency injection w/ IEnumerable Interface *****/
builder.Services.AddSingleton<IMyService, EnumerableDemo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

/***** DEMO need to add this to use logging *****/
app.UseHttpLogging();
/***** DEMO IEnumerable Interface as middleware *****/
app.Use(async (context, next) => {
    var myService = context.RequestServices.GetRequiredService<IMyService>();
    myService.LogCreation("IEnumerable Middleware");
    myService.ExecuteDemo();
    await next.Invoke();
});

app.MapControllers();


app.Run();