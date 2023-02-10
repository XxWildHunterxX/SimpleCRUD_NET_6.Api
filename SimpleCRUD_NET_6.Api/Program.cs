using System.Reflection;
using MediatR;
using SimpleCRUD_NET_6.Api.Domains;
using SimpleCRUD_NET_6.Api.EFCoreInMemoryDbDemo;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using SimpleCRUD.Api.Helpers;
using SimpleCRUD_NET_6.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

var configuration = builder.Configuration;
var environment = builder.Environment;

var uiUrl = configuration.GetSection("AppSettings:UiUrl").Value;

builder.Services.AddCors(options =>
{
    options.AddPolicy("UiAccess",
        builder =>
        {
            builder.WithOrigins(uiUrl)
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
        });
});

builder.Services.AddScoped<ICalculateAgeService, CalculateAgeService>();
builder.Services.AddScoped<ApiContext>();


builder.Services.AddFluentValidation(conf =>
{
    conf.RegisterValidatorsFromAssembly(typeof(Program).Assembly);
    conf.AutomaticValidationEnabled = true;
});

builder.Services.AddMvc().ConfigureApiBehaviorOptions(options =>
{
    options.InvalidModelStateResponseFactory =
        c => new BadRequestObjectResult(c.ModelState.ToErrorDictionary());
});

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

app.UseCors("UiAccess");

AddUsers();

void AddUsers()
{
    using (var context = new ApiContext())
    {
        var users = new List<User>
        {
            new User
            {
                Username = "Joydip",
                Name = "Kanjilal",
                PhoneNumber = "123",
                CountryCode = "+60",
                BirthDate = new DateTime(2000, 09, 24),
                IsActive = true
    },
            new User
            {
                Username ="Yashavanth",
                Name ="Kanetkar",
                PhoneNumber = "1234",
                CountryCode = "+60",
                BirthDate = new DateTime(2005, 10, 11),
                IsActive = false
            }
        };
        context.Users.AddRange(users);
        context.SaveChanges();
    }
}

app.Run();



