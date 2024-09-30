using HexaVerticalSlice.Api.BuildingBlocks.Tenant;
using HexaVerticalSlice.BC.AccountManagement;
using HexaVerticalSlice.BC.FeedComputation;
using HexaVerticalSlice.BC.Networking;
using HexaVerticalSlice.Configuration.Authentication;
using HexaVerticalSlice.Configuration.Controllers;
using HexaVerticalSlice.Transaction;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen(x => x.CustomSchemaIds(type => type.ToString()))
    .AddAuthenticationServices(builder.Configuration)
    .AddControllerServices(builder.Configuration)
    .AddTenant();

Action<MediatRServiceConfiguration> configureUnitOfWork = options =>
    options.AddBehavior(typeof(IPipelineBehavior<,>), typeof(UnitOfWorkBehavior<,>));

services
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