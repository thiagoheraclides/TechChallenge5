
using Br.Com.FiapTC5.Application.Services;
using Br.Com.FiapTC5.Domain.Interfaces;
using Br.Com.FiapTC5.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Br.Com.FiapTC5.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Add EF Core
            builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

            //Dependency Injection
            builder.Services.AddScoped<IAtivoService, AtivoService>();
            builder.Services.AddScoped<IPerfilService, PerfilService>();
            builder.Services.AddScoped<IPortifolioService, PortfolioService>();
            builder.Services.AddScoped<ITransacaoService, TransacaoService>();
            builder.Services.AddScoped<IUsuarioService, UsuarioService>();

            // Add services to the container.

            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
        }
    }
}
