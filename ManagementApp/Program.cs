using AutoMapper;
using ManagementApp.Data.Database;
using ManagementApp.Data.Interfaces;
using ManagementApp.Data.Repositories;
using ManagementApp.Presentation.Profiles;
using ManagementApp.Service.Interfaces;
using ManagementApp.Service.Profiles;
using ManagementApp.Service.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ManagementContext>(options => 
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var cfg = new MapperConfiguration(cfg =>
{
	cfg.AddProfile<MappingProfileService>();
	cfg.AddProfile<MappingProfilePresentation>();
});

IMapper mapper = cfg.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IBookingService, BookingService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
	endpoints.MapControllers();
});

app.Run();