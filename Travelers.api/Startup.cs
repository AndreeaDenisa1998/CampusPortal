using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Campus.Persistence;
using Travelers.Business.Mappings;
using Travelers.Business.Travelers.Services.CommentS;
using Travelers.Business.Travelers.Services.NotificationS;
using Travelers.Business.Travelers.Services.PostS;
using Travelers.Business.Travelers.Services.ReviewS;
using Travelers.Business.Travelers.Services.UserS;
using Travelers.persistance;
using Travelers.Persistence;

namespace Travelers.api
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {

                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Travelers.api", Version = "v1" });
            });
            services.AddAutoMapper(config => { config.AddProfile<TravelersMappingsProfile>(); });


            services.AddDbContext<TravelersContext>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<INotificationRepository, NotificationRepository>();

            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IReviewService, ReviewService>();
            services.AddScoped<IPostsService, PostsService>();
            services.AddScoped<INotificationService, NotificationService>();

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Travelers.api v1"));
            }

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
