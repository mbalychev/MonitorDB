using Microsoft.EntityFrameworkCore;
using MonitorDB.Readers;
using Pp.Common.FilesDb;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddDbContextFactory<Pp.Common.Db.DataContext>(cf => cf.UseNpgsql(builder.Configuration.GetConnectionString("H1")));
builder.Services.AddDbContextFactory<FilesDbContext>(cf => cf.UseNpgsql(builder.Configuration.GetConnectionString("FilesDbConnection")));

builder.Services.AddCors();

// Add services to the container.
builder.Services.AddSingleton<ReadXmlErrors>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
app.UseCors(builder => builder.AllowAnyOrigin());
app.UseRouting();
app.UseEndpoints(e =>
{
    e.MapControllers();
});

app.Run();
