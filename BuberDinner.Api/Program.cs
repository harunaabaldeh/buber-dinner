using BuberDinner.Api;
using BuberDinner.Application;
using BuberDinner.Infrastracture;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddPresentation()
        .AddApplication()
        .AddInfrastracture(builder.Configuration);

}

var app = builder.Build();
{
    app.UseExceptionHandler("/error");
    app.UseAuthentication();
    app.UseAuthorization();
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}

