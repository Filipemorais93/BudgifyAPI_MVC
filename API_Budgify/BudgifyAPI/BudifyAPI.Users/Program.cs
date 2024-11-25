using BudifyAPI.Users.Models.DB;
using BudifyAPI.Users.Models.TransactionsModel.DBTransactions;
using BudifyAPI.Users.Models.WalletModel.DBWallet;
using BudifyAPI.Users.Services;
using BudifyAPI.Users.Services.Wallets;
using BudifyAPI.Users.Services.Wallets.InerfaceWallet;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUsersService, UsersService>();
builder.Services.AddScoped<IWalletService,WalletService>()

builder.Services.AddDbContext<UsersContext>(
    options =>
    {
        var connectionString = options.UseNpgsql(builder.Configuration.GetConnectionString("BD"));
    });

builder.Services.AddDbContext<WalletContext>(
    options =>
    {
        var connectionString = options.UseNpgsql(builder.Configuration.GetConnectionString("BDWallet"));
    });

builder.Services.AddDbContext<TransactionsContext>(
    options=>
    {
    var connectionString = options.UseNpgsql(builder.Configuration.GetConnectionString("BDTransactions"));
            
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
