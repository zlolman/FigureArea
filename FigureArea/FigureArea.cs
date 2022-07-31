using FigureArea.Calculators;

namespace FigureArea
{
    public class FigureArea : IFigureArea
    {
        private static List<Type> _types = new List<Type>()
        {
            typeof(CircleAreaCalculator),
            typeof(TriangleAreaCalculator)
        };

        public FigureArea()
        {
        }

        public void AddFigureAreaCalculator<T>() where T : class, IFigureAreaCalculator
        {            
            if (!_types.Contains(typeof(T)))
                _types.Add(typeof(T));
        }

        public async Task<double?> CalcuateAsync(double[] parametres, Action<double[]>? notifiaction = default)
        {
            var paramCount = parametres.Length;

            var calculatorType = _types.FirstOrDefault(x => (int)x.GetMethod("GetParamsCount")!.Invoke(null, null)! == parametres.Length);

            if (calculatorType != null)
            {
                var calculator = Activator.CreateInstance(calculatorType) as IFigureAreaCalculator;

                if (!calculator!.IsValidParametres(parametres))
                    return null;

                var result = await calculator!.CalcuateAsync(parametres, notifiaction);
                return result;
            }
            else
            {
                return null;
            }
        }

        public async Task<double?> CalcuateAsync<T>(double[] parametres, Action<double[]>? notifiaction = default) where T : class, IFigureAreaCalculator, new()
        {
            var calculator = new T();

            if (!calculator!.IsValidParametres(parametres))
                return null;

            var result = await calculator!.CalcuateAsync(parametres, notifiaction);
            return result;
        }
    }
}
