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
builder.Services.AddAuthentication("Bearer").AddJwtBearer(option =>
{
    option.TokenValidationParameters = new()
    {
        ValidateIssuer = true,
        ValidateIssuerSigningKey = true,
        ValidateAudience = true,
        ValidIssuer = builder.Configuration["Authentication:Issuer"],
        ValidAudience = builder.Configuration["Authentication:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.ASCII.GetBytes(builder.Configuration["Authentication:SecretForKey"]))
    };
});

#endregion

#region DE

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAdvertisementService, AdvertisementService>();
builder.Services.AddScoped<IAdminService, AdminService>();
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
