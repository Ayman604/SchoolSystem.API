using Microsoft.EntityFrameworkCore;
using School.Domain.Contracts;
using School.Persistence.Data.DataSeed;
using School.Persistence.Data.DbContexts;
using School.Persistence.Repositories;
using School.Services.Abstraction;
using School.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region Register Services 
#region Controllers & API & CORS
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion
#region DataBase & DbContexts
builder.Services.AddDbContext<SchoolDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
#endregion
#region Data initializer
builder.Services.AddKeyedScoped<IDataInitializer, DataInitializer>("Default");
#endregion
#region Repositories & Unit Of Work 
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
#endregion
#region Application Services 
builder.Services.AddScoped<IGalleryService, GalleryService>();
builder.Services.AddScoped<INewsService, NewsService>();
builder.Services.AddScoped<IOurPrideService, OurPrideService>();
#endregion
#endregion
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
