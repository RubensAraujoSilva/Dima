
using Dima.Api.Common.Endpoints;
using Dima.Api.Data;
using Dima.Api.Handlers;
using Dima.Api.Models;
using Dima.Core.Handlers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


var cnnString = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;

builder.Services.AddDbContext<AppDbContext>(x => { x.UseSqlServer(cnnString); });

builder.Services.AddIdentityCore<User>()
    .AddRoles<IdentityRole<long>>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddApiEndpoints();



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x => { x.CustomSchemaIds(n => n.FullName); });

//Adicione Autenticação e Autorização
builder.Services.AddAuthentication(IdentityConstants.ApplicationScheme)
                .AddIdentityCookies();

builder.Services.AddAuthorization();

//Serviços  DI
builder.Services.AddTransient<ICategoryHandler, CategoryHandler>();
builder.Services.AddTransient<ITransactionHandler, TransactionHandler>();

var app = builder.Build();

//Use a Autenticação e Autorização
app.UseAuthentication();
app.UseAuthorization();

//Interface do Swagger
app.UseSwagger();
app.UseSwaggerUI();

//Rotas da API 
app.MapGet("/", () => new { message = "OK" });

app.MapEndpoints();

app.MapGroup("v1/identity")
   .WithTags("Identity")
   .MapIdentityApi<User>();

app.Run();
