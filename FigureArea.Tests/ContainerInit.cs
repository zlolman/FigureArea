using Microsoft.Extensions.DependencyInjection;

namespace FigureArea.Tests
{
    internal class ContainerInit
    {
        public static IServiceProvider BuildContainer()
        {
            var services = new ServiceCollection();

            services.AddFigureAreaCalculators();

            return services.BuildServiceProvider();
        }
    }
}
