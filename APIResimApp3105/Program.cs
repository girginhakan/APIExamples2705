using APIResimApp3105.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//builder.Services.AddDbContext<ResimDbContext>(opt =>
//{
//    opt.UseSqlServer(builder.Configuration.GetConnectionString("ResimConStr"));
//});

builder.Services.AddDbContext<ResimDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("ResimConStr"));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddCors(opt => opt
    .AddDefaultPolicy(p =>
        p.AllowAnyHeader()
          .AllowAnyMethod()
          .AllowAnyOrigin()));


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
