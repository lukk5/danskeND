using danskeND.Services;

var builder = WebApplication.CreateBuilder(args);
var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build() ?? throw new ArgumentNullException($"new ConfigurationBuilder().AddJsonFile(\"appsettings.json\").Build()");


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper();
// builder.Services.AddSql(config);
// builder.Services.AddRepoServices();
builder.Services.AddApplicationServices();


builder.Services.AddMemoryCache();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();