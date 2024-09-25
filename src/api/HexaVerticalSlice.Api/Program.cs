using HexaVerticalSlice;
using HexaVerticalSlice.Api.BuildingBlocks.Tenant;
using HexaVerticalSlice.BC.AccountManagement;
using HexaVerticalSlice.BC.FeedDisplay;
using HexaVerticalSlice.Configuration.Authentication;
using HexaVerticalSlice.Configuration.Controllers;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTenant();

builder.Services
    .AddAuthenticationServices(builder.Configuration)
    .AddControllerServices(builder.Configuration);

builder.Services
    .RegisterAccountManagement(options =>
        options.AddBehavior(typeof(IPipelineBehavior<,>), typeof(UnitOfWorkBehavior<,>))
    )
    .RegisterFeedDisplay(options => options.AddBehavior(typeof(IPipelineBehavior<,>), typeof(UnitOfWorkBehavior<,>)))
    ;

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureControllers();
app.Run();

namespace HexaVerticalSlice
{
    public class Program;
}