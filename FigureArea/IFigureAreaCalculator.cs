namespace FigureArea
{
    public interface IFigureAreaCalculator
    {
        const int _paramsCount = 1;
        Task<double?> CalcuateAsync(double[] parametres, Action<double[]>? notification = default);
        bool IsValidParametres(double[] parametres)
        {
            if (parametres.Length < _paramsCount)
                return false;

            if (parametres.Any(x => x <= 0))
                return false;

            return true;
        }

        static int GetParamsCount() => _paramsCount;
    }
}
