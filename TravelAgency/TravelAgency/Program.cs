using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TravelAgency.ApplicationServices.API.Domain;
using TravelAgency.ApplicationServices.API.Validators;
using TravelAgency.ApplicationServices.Mappings;
using TravelAgency.DataAccess;
using TravelAgency.DataAccess.CQRS;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using NLog;
using NLog.Web;
using Microsoft.AspNetCore.Authentication;
using MagazynEdu.Authentication;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<TravelAgencyContex>(
    opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("AzureDB")));
builder.Services.AddControllers();
builder.Services.AddAuthentication("BasicAuthentication")
    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
builder.Services.AddMediatR(cfg=>cfg.RegisterServicesFromAssembly(typeof(ResponseBase<>).Assembly));
builder.Services.AddMvcCore().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddOpinionRequestValidator>());
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});
//builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddTransient<IQueryExecutor,QueryExecutor>();
builder.Services.AddTransient<ICommandExecutor, CommandExecutor>();
builder.Services.AddAutoMapper(typeof(OpinionsProfile).Assembly);
builder.Services.AddCors(options => options.AddDefaultPolicy(z => z.AllowAnyOrigin()
                                                               .AllowAnyHeader()
                                                               .AllowAnyMethod());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Logging.ClearProviders();
builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
builder.Host.UseNLog();
    
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
