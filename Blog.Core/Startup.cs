using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Core.AuthHelper.OverWrite;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;

namespace Blog.Core
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            #region Swagger
            services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new Info()
                    {
                        Version = "v0.1.0",
                        Title = "Blog.Core API",
                        Description = "框架说明文档",
                        TermsOfService = "None",
                        Contact = new Swashbuckle.AspNetCore.Swagger.Contact()
                        {
                            Name = "Blog.Core",
                            Email = "Blog.Core@xxx.com",
                            Url = "https://www.jianshu.com/u/94102b59cc2a"
                        }
                    });

                    #region 读取xml信息
                    var basePath = Microsoft.DotNet.PlatformAbstractions.ApplicationEnvironment.ApplicationBasePath;
                    var xmlPath = Path.Combine(basePath, "Blog.Core.xml");
                    c.IncludeXmlComments(xmlPath, true);

                    var modelXmlPath = Path.Combine(basePath, "Blog.Core.Model.xml");

                    c.IncludeXmlComments(modelXmlPath);
                    #endregion

                    #region Token绑定到ConfigureServices
                    var security = new Dictionary<string, IEnumerable<string>>()
                    {
                        {"Blog.Core",new string[]{} }
                    };
                    c.AddSecurityRequirement(security);
                    c.AddSecurityDefinition("Blog.Core", new ApiKeyScheme
                    {
                        Description = "JWT授权(数据将在请求头中进行传输) 直接在下框中输入Bearer {token}（注意两者之间是一个空格）\"",
                        Name = "Authorization",//jwt默认的参数名称
                        In = "header",//jwt默认存放Authorization信息的位置(请求头中)
                        Type = "apiKey"
                    });
                    #endregion
                });

            #region Token服务注册
            services.AddSingleton<IMemoryCache>(factory =>
                {
                    var cache = new MemoryCache(new MemoryCacheOptions());
                    return cache;
                });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Client", p => p.RequireRole("Client").Build());
                options.AddPolicy("Admin", p => p.RequireRole("Admin").Build());
                options.AddPolicy("AdminOrClient", p => p.RequireRole("Admin", "Client").Build());
            });
            #endregion
            #endregion

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(p =>
            {
                p.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,//是否验证Issuer
                    ValidateAudience = true,//是否验证Audience 
                    ValidateIssuerSigningKey = true,//是否验证IssuerSigningKey 
                    ValidIssuer = "Blog.Core",
                    ValidAudience = "wr",
                    ValidateLifetime = true,//是否验证超时  当设置exp和nbf时有效 同时启用ClockSkew 
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JwtHelper.secretKey)),
                    //注意这是缓冲过期时间，总的有效时间等于这个时间加上jwt的过期时间，如果不配置，默认是5分钟
                    ClockSkew = TimeSpan.FromSeconds(30)
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            #region Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiHelp V1"); });
            #endregion

            //  app.UseMiddleware<JwtTokenAuth>();//注意此授权方法已经放弃，请使用下边的官方授权方法。这里仅仅是授权方法的替换

            app.UseAuthentication();


            app.UseMvc();
        }
    }
}
