namespace FigureArea
{
    public interface IFigureArea
    {
        void AddFigureAreaCalculator<T>() where T : class, IFigureAreaCalculator;
        Task<double?> CalcuateAsync(double[] parametres, Action<double[]>? notifiaction = default);
        Task<double?> CalcuateAsync<T>(double[] parametres, Action<double[]>? notifiaction = default) where T : class, IFigureAreaCalculator, new();
    }
}
