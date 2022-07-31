namespace FigureArea.Calculators
{
    public class CircleAreaCalculator : IFigureAreaCalculator
    {
        private const int _paramsCount = 1;
        public async Task<double?> CalcuateAsync(double[] parametres, Action<double[]>? notifiaction = default)
        {
            if (notifiaction != null)
                notifiaction(parametres);
            
            var radius = parametres[0];
            var area = radius * radius * Math.PI;
            return area;
        }
        public static int GetParamsCount() => _paramsCount;
    }
}