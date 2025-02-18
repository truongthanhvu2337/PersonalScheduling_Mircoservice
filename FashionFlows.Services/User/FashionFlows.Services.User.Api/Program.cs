using FashionFlows.BuildingBlock.Application.Configuration;
using FashionFlows.BuildingBlock.Infrastructure.GenericInstaller;
using FashionFlows.Services.Account.Infrastructure.Installers;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureSerilog();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "FashionFlows", Version = "v1" });
    c.EnableAnnotations();
});


builder.Services.InstallServicesInAssembly<IUserAssembly>(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.UseHttpsRedirection();

app.Run();
