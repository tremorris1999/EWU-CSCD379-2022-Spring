using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Wordle.Api.Data;
using Wordle.Api.Identity;
using Wordle.Api.Services;

var builder = WebApplication.CreateBuilder(args);

//Change CORS policy

string allowance = "AllowAll";

var allowAll = builder.Services.AddCors(options => {
    options.AddPolicy(allowance, builder => 
        builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(config =>
{
    config.SwaggerDoc("v1", new OpenApiInfo { Title = "Wordle API", Version = "v1" });
    config.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer"
    });
    config.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new List<string>()
        }
    });
});

var connectionString = builder.Configuration.GetConnectionString("AzureConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<PlayersService>();
builder.Services.AddScoped<DateWordService>();
builder.Services.AddScoped<GameService>();
builder.Services.AddScoped<WordService>();

//Identity stuff
builder.Services.AddIdentityCore<AppUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>();

//JWT Token setup
JwtConfiguration jwtConfiguration = builder.Configuration.GetSection("Jwt").Get<JwtConfiguration>();
builder.Services.AddSingleton(jwtConfiguration);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtConfiguration.Issuer,
            ValidAudience = jwtConfiguration.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfiguration.Secret))
        };
    });

//Add Policies
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(Policies.RandomAdmin, Policies.RandomAdminPolicy);
    options.AddPolicy("IsGrantPolicy", policy => policy.RequireRole("Grant"));
});

var app = builder.Build();

//Create database
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.Migrate();
    PlayersService.Seed(context);
    Word.SeedWords(context);
    await IdentitySeed.SeedAsync(scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>(),
        scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>());
}
// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseCors(allowance);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
