using System;
using AutoMapper;
using Enterprise.API.Helpers;
using Enterprise.Infrastructure.Data.Extensions;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;

namespace Enterprise.API
{
	public class Startup
	{
		public IConfiguration Configuration { get; }

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services
				.AddControllers(options =>
				{
					options.ReturnHttpNotAcceptable = true;
					options.Conventions.Add(new RouteTokenTransformerConvention(new SlugifyParameterTransformer()));
				})
				.AddXmlDataContractSerializerFormatters()
				.AddFluentValidation(configExpression =>
				{
					configExpression.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
				})
				.ConfigureApiBehaviorOptions(setupAction =>
				{
					setupAction.InvalidModelStateResponseFactory = InvalidModelStateResponseFactory.FactoryFunction;
				});
			services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
			services.AddDataAccess(Configuration.GetConnectionString("EnterpriseDb"));
			services.AddSwaggerGen(options =>
			{
				options.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
				options.AddFluentValidationRules();
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler(appBuilder =>
				{
					appBuilder.Run(async context =>
					{
						context.Response.StatusCode = 500;
						await context.Response.WriteAsync("An unexpected fault happened. Try again later.");
					});
				});
			}

			app.UseSwagger();
			app.UseSwaggerUI(options =>
			{
				options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
			});

			app.UseHttpsRedirection();
			app.UseRouting();
			app.UseAuthorization();
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
