using Microsoft.Extensions.DependencyInjection;

namespace FigureArea.Tests.Tests
{
    internal class TriangleAreaCalculateTests
    {
        private IFigureArea _figureArea;
        private IServiceProvider serviceProvider = ContainerInit.BuildContainer();
        [SetUp]
        public void Setup()
        {
            _figureArea = serviceProvider.GetRequiredService<IFigureArea>();
        }

        [Test]
        public async Task ValidTriangleCalculate()
        {
            var paramatres = new double[] { 3, 4, 5 };
            var result = await _figureArea.CalcuateAsync(paramatres);

            Assert.That(result!, Is.EqualTo(6));
        }

        [Test]
        public async Task NegativeParametresTriangleCalculate()
        {
            var paramatres = new double[] { -10, 2, 4 };
            var result = await _figureArea.CalcuateAsync(paramatres);

            Assert.IsNull(result);
        }

        [Test]
        public async Task ZeroParametresTriangleCalculate()
        {
            var paramatres = new double[] { 0, 3, 5 };
            var result = await _figureArea.CalcuateAsync(paramatres);

            Assert.IsNull(result);
        }

        [Test]
        public async Task RightTriangleNotification()
        {
            var paramatres = new double[] { 3, 4, 5 };

            var result = await _figureArea.CalcuateAsync(paramatres, IsRightTriangleNotification);

            Assert.That(result!, Is.EqualTo(6));
        }

        private void IsRightTriangleNotification(double[] parametres)
        {
            parametres = parametres.OrderByDescending(x => x).ToArray();

            var hypotenuse = parametres[0];
            var catetusA = parametres[1];
            var catetusB = parametres[2];

            if (Math.Pow(catetusA, 2) + Math.Pow(catetusB, 2) == Math.Pow(hypotenuse, 2))
            {
                Console.WriteLine("Right-angled triangle");
            }
            else
            {
                Console.WriteLine("Not a right-angled triangle");
            }
        }
    }
}
