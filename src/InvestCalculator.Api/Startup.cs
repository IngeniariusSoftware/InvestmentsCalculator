using AutoMapper;
using FluentValidation.AspNetCore;
using InvestCalculator.Api.Filters;
using InvestCalculator.Infrastructure;
using InvestCalculator.Infrastructure.DtoMaps;
using InvestCalculator.Infrastructure.Validators;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace InvestCalculator.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
                {
                    options.EnableEndpointRouting = false;
                    options.Filters.Add<ValidationFilter>();
                })
                .AddFluentValidation(fv =>
                    fv.RegisterValidatorsFromAssemblyContaining<LowLevelInvestmentInstrumentDtoValidator>());
            
            services.AddControllers().AddNewtonsoftJson();;
            services.AddSwaggerGen();
            // registerDb
            services.AddDbContext<LowLevelInvestmentInstrumentsDtoContext>(otions =>
                otions.UseSqlite("Data Source=../InvestCalculator.Infrastructure/investCalc.db"));

            // Automapper singletone
            var mapperConfig = new MapperConfiguration(mc => { mc.AddProfile(new AutoMappingProfile()); });

            var mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseSwagger();

            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"); });

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}