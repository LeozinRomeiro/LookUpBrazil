using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using LookUpBrazil.Api.Data;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using LookUpBrazil.Api.Services;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using LookUpBrazil.Api;
using System.Net.Mail;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.ResponseCompression;
using System.IO.Compression;
using LookUpBrazil.Api.Handler;
using LookUpBrazil.Core.Handler;

var builder = WebApplication.CreateBuilder(args);

ConfigureAutentication(builder);
ConfigureMVC(builder);
ConfigureServices(builder);

// Add services to the container.
//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

//builder.Services.Configure<RequestLocalizationOptions>(options =>
//{
//    options.DefaultRequestCulture = new RequestCulture(CultureInfo.InvariantCulture);
//});

var app = builder.Build();

LoadConfiguration(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.UseResponseCompression();
app.UseStaticFiles();
app.MapControllers();

app.Run();

void LoadConfiguration(WebApplication app)
{
    Configuration.KeyApi = app.Configuration.GetValue<string>("KeyApi");
    Configuration.NameApi = app.Configuration.GetValue<string>("NameApi");
    Configuration.JwtKey = app.Configuration.GetValue<string>("JwtKey");

    //var smtp = new Configuration.SmtpConfiguration();
    //app.Configuration.GetSection("Smtp").Bind(smtp);
    //Configuration.Smtp = smtp;
}

void ConfigureAutentication(WebApplicationBuilder builder)
{
    var key = Encoding.ASCII.GetBytes(Configuration.JwtKey);
    builder.Services.AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(x =>
    {
        x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });
}

void ConfigureMVC(WebApplicationBuilder builder)
{
    builder.Services.AddMemoryCache();
    builder.Services.AddResponseCompression(options =>
    {
        // options.Providers.Add<BrotliCompressionProvider>();
        options.Providers.Add<GzipCompressionProvider>();
        // options.Providers.Add<CustomCompressionProvider>();
    });
    builder.Services.Configure<GzipCompressionProviderOptions>(options =>
    {
        options.Level = CompressionLevel.Optimal;
    });
    builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressModelStateInvalidFilter = true;
    })
    .AddJsonOptions(x =>
    {
        x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });
}

void ConfigureServices(WebApplicationBuilder builder)
{
    builder.Services.AddDbContext<LookUpBrazilApiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string n�o informada.")));

    builder.Services.AddTransient<TokenService>();
    builder.Services.AddTransient<EmailService>();
    builder.Services.AddTransient<ICityHandler,CityHandler>();

    // Learn more about configuring Swagger/OpenApi at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}