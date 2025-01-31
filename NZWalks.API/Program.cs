using NZWalks.API.Common;

var builder = WebApplication.CreateBuilder(args);

/***** DEMO need to add HTTP logging *****/
builder.Services.AddHttpLogging((o) => { });

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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