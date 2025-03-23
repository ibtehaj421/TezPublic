using Microsoft.EntityFrameworkCore;
using TEZ.DbContext;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TEZ.Repositories.Interfaces;
using TEZ.Repositories.Implementations;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddScoped<IOrganizationService,OrganizationService>();
builder.Services.AddScoped<IOrganizationRepository,OrganizationRepository>();
builder.Services.AddScoped<JwtServices>();
var jwtKey = builder.Configuration["Jwt:Key"];
var jwtIssuer = builder.Configuration["Jwt:Issuer"];
var key = Convert.FromHexString(jwtKey!); // i know its not null niga.
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//authentication for jwts on logins.
builder.Services.AddAuthentication ( options => {
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer( options => {
    options.RequireHttpsMetadata = false; //for now 
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {   
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = true,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidIssuer = jwtIssuer
    };
    options.Events = new JwtBearerEvents
        {
            OnAuthenticationFailed = context =>
            {
                Console.WriteLine("Auth Failed: " + context.Exception.ToString());
                return Task.CompletedTask;
            },
            OnChallenge = context =>
            {
                Console.WriteLine("OnChallenge: " + context.AuthenticateFailure?.ToString());
                return Task.CompletedTask;
            },
            OnMessageReceived = context =>
            {
                Console.WriteLine("Token received: " + context.Token?.Substring(0, Math.Min(10, context.Token?.Length ?? 0)));
                return Task.CompletedTask;
            }
        };
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<TezDbContext>(options =>
    options.UseNpgsql(connectionString)
);
builder.Services.AddAuthorization();
builder.Services.AddControllers();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();


