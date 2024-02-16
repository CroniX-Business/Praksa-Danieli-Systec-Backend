// <copyright file="Program.cs" company="Danieli Systec d.o.o.">
// Copyright (c) Danieli Systec d.o.o.. All rights reserved.
// CONFIDENTIAL; Property of Danieli Systec d.o.o.
// Unauthorized reproduction, copying, distribution or any other use of the whole or any part of this documentation/data/software is strictly prohibited.
// </copyright>

using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;

namespace WebApplication2
{
    /// <summary> This application is a basic ASP.NET Core web server configured to host RESTful APIs.
    /// It utilizes the WebApplication framework for building the application.</summary>
    public class Program
    {
        /// <summary>Defines the entry point of the application.</summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                
            }
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
