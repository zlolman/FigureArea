using Microsoft.Extensions.DependencyInjection;

namespace FigureArea.Tests.Tests
{
    internal class CircleAreaCalculateTests
    {
        private IFigureArea _figureArea;
        private IServiceProvider serviceProvider = ContainerInit.BuildContainer();
        [SetUp]
        public void Setup()
        {
            _figureArea = serviceProvider.GetRequiredService<IFigureArea>();
        }

        [Test]
        public async Task ValidCircleCalculate()
        {
            var paramatres = new double[] { 1 };
            var result = await _figureArea.CalcuateAsync(paramatres);

            Assert.That(result!, Is.EqualTo(Math.PI));
        }

        [Test]
        public async Task EmptyParametresCircleCalculate()
        {
            var paramatres = new double[] { };
            var result = await _figureArea.CalcuateAsync(paramatres);

            Assert.IsNull(result);
        }

        [Test]
        public async Task NegativeParametresCircleCalculate()
        {
            var paramatres = new double[] { -10 };
            var result = await _figureArea.CalcuateAsync(paramatres);

            Assert.IsNull(result);
        }

        [Test]
        public async Task ZeroParametresCircleCalculate()
        {
            var paramatres = new double[] { 0 };
            var result = await _figureArea.CalcuateAsync(paramatres);

            Assert.IsNull(result);
        }
    }
}
