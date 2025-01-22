using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Serilog;
using System.Text;
using WebMail.Application.DependencyInjection;
using WebMail.Application.Helper;
using WebMail.Application.Mappings;
using WebMail.Infrastructure.Data;
using WebMail.Infrastructure.DependencyInjection;
using System.IdentityModel.Tokens.Jwt;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, config) =>
{
	config.ReadFrom.Configuration(context.Configuration);
});

builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.RegisterServices();
builder.Services.AddRepositories();

builder.Services.AddScoped(provider =>
			  new MapperConfiguration(cfg =>
			  {
				  cfg.AddProfile(new MappingGonfig());
			  })
		  .CreateMapper());

// Add services to the container.

builder.Services.AddAuthentication(options =>
{
	options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
	var jwtSettings = builder.Configuration.GetSection("Authentication");
	options.IncludeErrorDetails = true;
	options.SaveToken = true;
	options.TokenValidationParameters = new TokenValidationParameters
	{
		ValidateIssuer = false,
		ValidIssuer = "https://codingfactory.aueb.gr",
		ValidateAudience = false,
		ValidAudience = "https://api.codingfactory.aueb.gr",
		ValidateLifetime = true,
		ValidateIssuerSigningKey = true,
		IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
		.GetBytes(jwtSettings["SecretKey"]!))
	};
});


builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowAll",
		b => b.AllowAnyMethod()
		.AllowAnyHeader()
		.AllowAnyOrigin());
});

builder.Services.AddCors(options =>
{
	options.AddPolicy("AngularClient",
		b => b.WithOrigins("http://localhost:4200")
			  .AllowAnyMethod()
			  .AllowAnyHeader());
});

builder.Services.AddControllers()
				.AddNewtonsoftJson(options =>
				{
					options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
					options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;
					options.SerializerSettings.Converters.Add(new StringEnumConverter());
				});

builder.Services.AddControllers()
				.AddNewtonsoftJson(options =>
				{
					options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
					options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;
					options.SerializerSettings.Converters.Add(new StringEnumConverter());
				});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
	options.SwaggerDoc("v1", new OpenApiInfo { Title = "School API", Version = "v1" });
	
	options.SupportNonNullableReferenceTypes();
	options.OperationFilter<AuthorizeOperationFilter>();
	options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme,
		new OpenApiSecurityScheme
		{
			Description = "JWT Authorization header using the Bearer scheme.",
			Name = "Authorization",
			In = ParameterLocation.Header,
			Type = SecuritySchemeType.Http,
			Scheme = JwtBearerDefaults.AuthenticationScheme,
			BearerFormat = "JWT"
		});
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseMiddleware<GlobalExceptionHandler>();

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
