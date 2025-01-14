using cs_record_shop_project;
using cs_record_shop_project.Model;
using cs_record_shop_project.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var environment = builder.Environment.EnvironmentName;
if(environment == "Development")
{
    builder.Services.AddDbContext<RecordShopDbContext>(options => options.UseInMemoryDatabase("InMemoryDb")); 
}
else
{
    var connectionString = builder.Configuration.GetConnectionString("AdventurersDatabase");
    builder.Services.AddDbContext<RecordShopDbContext>(options => options.UseSqlServer(connectionString));
}

builder.Services.AddScoped<IAlbumService, AlbumService>();
builder.Services.AddScoped<IAlbumModel, AlbumModel>();

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
