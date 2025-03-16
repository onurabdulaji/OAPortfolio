using Microsoft.OpenApi.Models;
using OAPortfolio.Infastructure.Extensions;
using OAPortfolio.Persistence.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddPersistenceLayer(builder.Configuration);
builder.Services.AddInfastructureLayer(builder.Configuration);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen
(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Web Portfolio", Version = "v1", Description = "Web Portfolio swagger client." });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "'Bearer' yazýp boþluk býraktýktan sonra Token'ý Girebilirsiniz \r\n\r\n Örneðin: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\""
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
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
            Array.Empty<string>()
        }

});
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    await app.Services.UseIdentityDatabaseSeederAsync();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseAuthorization();
app.MapControllers();
app.Run();
