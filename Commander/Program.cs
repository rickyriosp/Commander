using Commander.Data;
using Commander.Services;
using Commander.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var provider = builder.Configuration.GetValue("DatabaseProvider", "SqlServer");
switch (provider)
{
    case "SqlServer":
        builder.Services.AddDbContext<CommanderContext, SqlServerContext>();
        break;
    case "PostgreSql":
        builder.Services.AddDbContext<CommanderContext, PostgreSqlContext>();
        break;
}

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICmdrRepository, SqlCmdrRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

//app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
