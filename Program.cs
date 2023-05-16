using hagnfireJob.Interface.Repository;
using hagnfireJob.Interface.Services;
using hagnfireJob.Repository;
using hagnfireJob.Services;
using Hangfire;
using hagnfireJob.Job;
using System.Data;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connection = builder.Configuration.GetConnectionString("defaultConnection");
builder.Services.AddTransient<IDbConnection>((sp) => new SqlConnection(connection));
builder.Services.AddHangfire(configuration =>
{
    
    configuration.UseSqlServerStorage(connection);
});

builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserServices, UserServices>();
builder.Services.AddTransient<BackgroundJobs>();


var app = builder.Build();
app.UseHangfireDashboard("/hangfire", new DashboardOptions
{
    DashboardTitle = "TESTE",
});
app.UseHangfireServer();

var serviceProvider = app.Services;

using (var scope = serviceProvider.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var jobs = services.GetRequiredService<BackgroundJobs>();
        jobs.MeuMetodoEmSegundoPlano();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred.");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
