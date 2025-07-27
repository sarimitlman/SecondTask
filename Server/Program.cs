using Microsoft.EntityFrameworkCore;
using Dal.DBContext;
using Dal.Api;
using BL.Api;
using BL.Services;
using BL;
using Dal;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Server.Services; // הוסף את TokenService

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// DB Context
builder.Services.AddDbContext<CrmDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// DAL
builder.Services.AddScoped<IUser, UserService>();
builder.Services.AddScoped<IClient, ClientService>();
builder.Services.AddScoped<IInvoice, InvoiceService>();
builder.Services.AddScoped<IPayment, PaymentService>();
builder.Services.AddScoped<IProposal, ProposalService>();
builder.Services.AddScoped<ITransaction, TransactionService>();
builder.Services.AddScoped<IDal, DalManager>();

// BL
builder.Services.AddScoped<IBLUser, BLUserService>();
builder.Services.AddScoped<IBLClient, BLClientService>();
builder.Services.AddScoped<IBLInvoice, BLInvoiceService>();
builder.Services.AddScoped<IBLPayment, BLPaymentService>();
builder.Services.AddScoped<IBLProposal, BLProposalService>();
builder.Services.AddScoped<IBLTransaction, BLTransactionService>();
builder.Services.AddScoped<IBL, BLManager>();

// Token Service
builder.Services.AddScoped<TokenService>();

// JWT Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.WithOrigins("http://localhost:5173")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowFrontend");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();