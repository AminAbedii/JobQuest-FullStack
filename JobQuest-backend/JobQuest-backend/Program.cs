using JobQuest.Core.Services.Interfaces;
using JobQuest.Core.Services;
using JobQuest.DataLayer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




#region DbContext

builder.Services.AddDbContext<JobQuestContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("JobQuestConnection"));

});
#endregion

#region AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
#endregion

#region JWT
//builder.Services.AddAuthentication("Bearer").AddJwtBearer(option =>
//{
//    option.TokenValidationParameters = new()
//    {
//        ValidateIssuer = true,
//        ValidateIssuerSigningKey = true,
//        ValidateAudience = true,
//        ValidIssuer = builder.Configuration["Authentication:Issuer"],
//        ValidAudience = builder.Configuration["Authentication:Audience"],
//        IssuerSigningKey = new SymmetricSecurityKey(
//            Encoding.ASCII.GetBytes(builder.Configuration["Authentication:SecretForKey"]))
//    };
//});
//builder.Services
//    .AddAuthentication(options =>
//    {
//        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
//        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//    })
//    .AddJwtBearer(options =>
//    {
//        options.SaveToken = true;
//        options.RequireHttpsMetadata = false;
//        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
//        {
//            ValidateIssuer = true,
//            ValidateAudience = true,
//            ValidIssuer = builder.Configuration["Authentication:Issuer"],
//            ValidAudience = builder.Configuration["Authentication:Audience"],
//            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Authentication:SecretForKey"]))
//        };
//    });
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Authentication:SecretForKey"])),
            ValidateIssuer = true, // set to false for testing
            ValidateAudience = true, // set to false for testing
            ValidIssuer = builder.Configuration["Authentication:Issuer"],
            ValidAudience = builder.Configuration["Authentication:Audience"]
        };
    });
#endregion

#region DE

builder.Services.AddScoped<IUserService, UserService>();

#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(options =>
{
    options
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowAnyOrigin();
});

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
