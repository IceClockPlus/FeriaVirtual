using FeriaVirtual.API.Authorization;
using FeriaVirtual.API.Helpers;
using FeriaVirtual.API.Repositories;
using FeriaVirtual.API.Services;
using FeriaVirtual.Database;
using System.Linq;

var builder = WebApplication.CreateBuilder(args);

{
    var services = builder.Services;
    var env = builder.Environment;

    services.AddDbContext<FeriaVirtualContext>();

    services.AddCors();

    services.AddAutoMapper(typeof(Program));
    services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));

    services.AddScoped<IUserService, UserService>();
    services.AddScoped<IProductRepository, ProductRepository>();
    services.AddScoped<IJwtUtils, JwtUtils>();
}
// Add services to the container.


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

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
