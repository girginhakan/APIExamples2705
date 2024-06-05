using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    opt.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        ValidIssuer = builder.Configuration["JwtTokenSettings:Issuer"],
        ValidAudience = builder.Configuration["JwtTokenSettings:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtTokenSettings:Key"]))

    });


// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(opt => opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

var securityScheme = new OpenApiSecurityScheme()
{
    Name = "Authentication",
    Type = SecuritySchemeType.Http,
    Scheme = "Bearer",
    BearerFormat = "JWT",
    In = ParameterLocation.Header,
    Description = "ANK16 JWT Token",

};

var securityReq = new OpenApiSecurityRequirement()
{
    {
         new OpenApiSecurityScheme
        {
            Reference= new OpenApiReference
            {
                Type=ReferenceType.SecurityScheme,
                Id="Bearer"
            }

        },
         new string[] { }
    }


};


var contact = new OpenApiContact()
{
    Name = "ANK16 Sınıfı",
    Email = "ank16@bilgeadam.com",
    Url = new Uri("https://www.bilgeadam.com")
};

var license = new OpenApiLicense()
{
    Name = "Free",
    Url = new Uri("https://www.bilgeadam.com")
};

var info = new OpenApiInfo()
{
    Version = "1.0",
    Title = "JWT uygulaması",
    Description = "ANK16 Grubu için JWT uygulamasi",
    TermsOfService = new Uri("https://www.bilgeadam.com"),
    Contact = contact,
    License = license,
};

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", info);
    opt.AddSecurityDefinition("Bearer", securityScheme);
    opt.AddSecurityRequirement(securityReq);

});

var app = builder.Build();

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