using DotNet8.AuditLogMiniProject.Domain.Features.Blog;
using DotNet8.AuditLogMiniProject.Infrastructure;
using DotNet8.AuditLogMiniProject.Infrastructure.Features.Blog;
using DotNet8.AuditLogMiniProject.Infrastructure.Interceptors;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
    opt.AddInterceptors(new AuditInterceptor());
}, ServiceLifetime.Transient, ServiceLifetime.Transient);

builder.Services.AddScoped<IBlogService, BlogService>();

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
