namespace FigureArea.Tests
{
    internal class QuadrangleAreaCalculator : IFigureAreaCalculator
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
                notifiaction = IsSquareNotification;
                notifiaction(parametres);
            }

            var d1 = parametres[0];
            var d2 = parametres[1];
            var angle = Math.PI * parametres[2] / 180.0;

            var area = d1 * d2 * Math.Sin(angle) / 2.0;

            return area;
        }

        public static int GetParamsCount() => _paramsCount;

        public bool IsValidParametres(double[] parametres)
        {
            if (parametres.Length < 3)
                return false;

            if (parametres.Any(x => x <= 0))
                return false;

            return true;
        }

        private void IsSquareNotification(double[] parametres)
        {
            if (parametres[0] == parametres[1] && parametres[2] == 90)
            {
                Console.WriteLine("Square");
            }
            else
            {
                Console.WriteLine("Not a square");
            }
        }
    }
}
