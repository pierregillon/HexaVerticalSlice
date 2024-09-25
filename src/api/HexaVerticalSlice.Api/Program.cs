using HexaVerticalSlice;
using HexaVerticalSlice.Api.BuildingBlocks.Tenant;
using HexaVerticalSlice.BC.AccountManagement;
using HexaVerticalSlice.BC.Feeds;
using HexaVerticalSlice.BC.Networking;
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

Action<MediatRServiceConfiguration> configureUnitOfWork = options =>
    options.AddBehavior(typeof(IPipelineBehavior<,>), typeof(UnitOfWorkBehavior<,>));

builder.Services
    .RegisterAccountManagementBoundedContext(configureUnitOfWork)
    .RegisterNetworkingBoundedContext(configureUnitOfWork)
    .RegisterFeedComputationContext(configureUnitOfWork);

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