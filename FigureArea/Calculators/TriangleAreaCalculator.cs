namespace FigureArea.Calculators
{
    public class TriangleAreaCalculator : IFigureAreaCalculator
    {
        private const int _paramsCount = 3;
        public async Task<double?> CalcuateAsync(double[] parametres, Action<double[]>? notifiaction = default)
        {
            if (notifiaction != null)
            {
                notifiaction(parametres);
            }
            else
            {
                notifiaction = IsRightTriangleNotification;
                notifiaction(parametres);
            }

            var a = parametres[0];
            var b = parametres[1];
            var c = parametres[2];

            var semiPerimeter = (a + b + c) / 2;
            var area = Math.Sqrt(semiPerimeter * (semiPerimeter - a) * (semiPerimeter - b) * (semiPerimeter - c));

            return area;
        }
        public static int GetParamsCount() => _paramsCount;
        public bool IsValidParametres(double[] parametres)
        {
            if (parametres.Length < _paramsCount)
                return false;

            if (parametres.Any(x => x <= 0))
                return false;

            parametres = parametres.OrderByDescending(x => x).ToArray();

            var maxEdge = parametres[0];
            var edgeA = parametres[1];
            var edgeB = parametres[2];

            if (maxEdge > edgeA + edgeB)
                return false; 

            return true;
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
