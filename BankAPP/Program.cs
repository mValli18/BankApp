using BankAPP.Interfaces;
using BankAPP.Models;
using BankAPP.Repositories;
using BankAPP.Services;
using BankAPP.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace BankAPP
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //builder.Services.AddControllersWithViews();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            #region Swagger
            

                
            #endregion

            #region CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("reactApp", opts =>
                {
                    opts.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
                });
            });
            #endregion
            #region Utilities

           
            builder.Services.AddDbContext<BankContext>(opts =>
            {
                opts.UseSqlServer(builder.Configuration.GetConnectionString("conn"));
            });

            builder.Services.AddScoped<IRepository<int, Account>, AccountRepository>();
            

            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddScoped<ITransferService, TransferService>();
            builder.Services.AddScoped<ITransferLogService, TransferLogService>();
            
            #endregion
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseStaticFiles();

            app.UseAuthorization();

            

            app.MapControllers();
            app.Run();
        }
    }
}