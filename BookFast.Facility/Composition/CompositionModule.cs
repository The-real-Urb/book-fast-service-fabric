using BookFast.Facility.Controllers;
using BookFast.Facility.Mappers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BookFast.SeedWork;
using BookFast.Security.AspNetCore.Authentication;
using BookFast.Security;
using Microsoft.Extensions.Options;

namespace BookFast.Facility.Composition
{
    internal class CompositionModule : ICompositionModule
    {
        public void AddServices(IServiceCollection services, IConfiguration configuration)
        {
            AddAuthentication(services, configuration);

            services.AddMvc();

            RegisterAuthorizationPolicies(services);
            RegisterMappers(services);
        }

        private static void AddAuthentication(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AuthenticationOptions>(configuration.GetSection("Authentication:AzureAd"));
            var serviceProvider = services.BuildServiceProvider();
            var authOptions = serviceProvider.GetService<IOptions<AuthenticationOptions>>();

            services.AddAuthentication(Constants.OrganizationalAuthenticationScheme)
                .AddJwtBearer(Constants.OrganizationalAuthenticationScheme, options =>
                {
                    options.Authority = authOptions.Value.Authority;
                    options.Audience = authOptions.Value.Audience;

                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidIssuers = authOptions.Value.ValidIssuersAsArray
                    };
                });
        }

        private static void RegisterAuthorizationPolicies(IServiceCollection services)
        {
            services.AddAuthorization(
                options =>
                {
                    options.AddPolicy("Facility.Write", config =>
                                                        {
                                                            config.RequireRole(InteractorRole.FacilityProvider.ToString(), InteractorRole.ImporterProcess.ToString());
                                                        });
                });
        }

        private static void RegisterMappers(IServiceCollection services)
        {
            services.AddScoped<IFacilityMapper, FacilityMapper>();
            services.AddScoped<IAccommodationMapper, AccommodationMapper>();
        }
    }
}