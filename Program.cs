using LearnAdoDotnet.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var ConnectionStrings = new ConnectionStrings();

builder.Configuration.Bind(nameof(ConnectionStrings), ConnectionStrings);
builder.Services.AddSingleton(ConnectionStrings);
builder.Services.AddTransient<DataAccessService>();
builder.Services.AddTransient<StudentsService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}
else
{
    app.UseHttpsRedirection();
    app.UseAuthorization();
}

app.MapControllers();

app.Run();
