using HexaVerticalSlice;
using HexaVerticalSlice.BC.AccountManagement;
using HexaVerticalSlice.BC.FeedDisplay;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .RegisterAccountManagement(options => options.AddBehavior(typeof(IPipelineBehavior<,>), typeof(UnitOfWorkBehavior<,>)))
    .RegisterFeedDisplay(options => options.AddBehavior(typeof(IPipelineBehavior<,>), typeof(UnitOfWorkBehavior<,>)))
    ;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthentication();
app.MapControllers();
app.UseAuthorization();
app.UseExceptionHandler("/internal/error");

app.UseHttpsRedirection();

app.Run();

namespace HexaVerticalSlice
{
    public class Program;
}
