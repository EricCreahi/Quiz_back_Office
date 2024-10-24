
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using System.Reflection;
using WebAppGedQuestionnaire.Helpers;
using WebAppGedQuestionnaire.Interfaces;
using WebAppGedQuestionnaire.Persistences;
using WebAppGedQuestionnaire.Repositories;


namespace WebAppGedQuestionnaire
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

           

            services.AddControllersWithViews().AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                    );


            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });

            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);


            services.AddHttpContextAccessor();

            services.TryAddSingleton<IActionContextAccessor, ActionContextAccessor>();



            #region //--------- depend Services for Db_Ged_Questionnaire_Context ----------------//
            services.AddDbContext<Db_Ged_Questionnaire_Context>(options => options.UseSqlServer(Configuration.GetConnectionString("SQLServer")));
                       
                services.AddScoped<IEmploye, EmployeService>();
                services.AddScoped<IChoix, ChoixService>();
                services.AddScoped<IQuestion, QuestionService>();
                services.AddScoped<ICocherTampon, CocherTamponService>();
                services.AddScoped<ICocher, CocherService>();            
                services.AddScoped<IUtilisateur, UtilisateurService>();
                services.AddScoped<ISousQuestion, SousQuestionService>();

            #endregion

           //services.AddCors(options => {
           //     options.AddDefaultPolicy(
           //            builder => {
           //                builder.WithOrigins("http://gedformtest.sucafci.lan/",
           //                                    "https://gedformtest.sucafci.lan/", "http://localhost:5000/")
           //               .AllowAnyMethod()
           //               .AllowAnyHeader();
           //            });
           // });

            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost:4001/");
                                  });
            });

            

            services.AddControllersWithViews();
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
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
