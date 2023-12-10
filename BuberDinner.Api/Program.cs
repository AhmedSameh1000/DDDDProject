using BuberDinner.Api.Common.Mapping;
using BuberDinner.Api.DependcyInjection;
using BuberDinner.Api.Filters;
using BuberDinner.Api.MiddleWares;
using BuberDinner.Application.DependcyInjection;
using BuberDinner.Domain.Models;
using BuberDinner.Infrastructure.Data;
using BuberDinner.Infrastructure.DependcyInjection;
using BuberDinner.Infrastructure.Seeds;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
builder
    .Services
    .AddPresentation()
    .AddApplicationSerivces(builder.Configuration)
    .AddInfrastructureSerivces(builder.Configuration)
    .AddAuth(builder.Configuration)
    .AddSwagger()
    .AddMapping();

var app = builder.Build();
app.UseMiddleware<ErrorhandlingMiddleWare>();
using var Scope = app.Services.CreateScope();
var roleManeger = Scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
var userManeger = Scope.ServiceProvider.GetRequiredService<UserManager<User>>();
await SeedRoles.Seed(roleManeger);
await SeedAdmin.Seed(userManeger);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
