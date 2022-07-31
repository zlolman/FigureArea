using Microsoft.Extensions.DependencyInjection;

namespace FigureArea
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddFigureAreaCalculators(this IServiceCollection services)
        {
            services.AddTransient<IFigureArea, FigureArea>();
            return services;
        }
    }
}
