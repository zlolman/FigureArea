using Microsoft.Extensions.DependencyInjection;

namespace FigureArea.Tests.Tests
{
    internal class FigureAreaTests
    {
        private IFigureArea _figureArea;
        private IServiceProvider serviceProvider = ContainerInit.BuildContainer();
        [SetUp]
        public void Setup()
        {
            _figureArea = serviceProvider.GetRequiredService<IFigureArea>();
            _figureArea.AddFigureAreaCalculator<QuadrangleAreaCalculator>();
        }

        [Test]
        public async Task AddNewCalculatorTest()
        {
            var paramatres = new double[] { 5 , 5, 90};
            var result = await _figureArea.CalcuateAsync<QuadrangleAreaCalculator>(paramatres);

            Assert.That(result!, Is.EqualTo(12.5));
        }

        [Test]
        public async Task NotImplementedCalculatorTest()
        {
            var paramatres = new double[] { 1, 2, 3, 4};
            var result = await _figureArea.CalcuateAsync(paramatres);

            Assert.IsNull(result);
        }
    }
}
