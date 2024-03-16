using System.Collections.Generic;

namespace ReignSystem
{
    internal static class ParametrizableReignExtensions
    {
        public static ParametrizableReign<IReadOnlyDictionary<TParameter, float>> WithAddedParameters<TReign, TParameter, T>(this TReign reign, T parameters)
            where TReign : IParametrizableReign<T>
            where T : IReadOnlyDictionary<TParameter, float>
        {
            var newParameters = new Dictionary<TParameter, float>(reign.Parameter);
            foreach (var (key, value) in parameters)
                newParameters[key] = newParameters.TryGetValue(key, out float oldValue) ? oldValue + value : value;

            return new ParametrizableReign<IReadOnlyDictionary<TParameter, float>>(newParameters);
        }

        //public static ParametrizableReign<IReadOnlyDictionary<TParameter, float>> WithParameters<TReign, TParameter, T>(this TReign reign, T parameters)
        //    where TReign : IParametrizableReign<T>
        //    where T : IReadOnlyDictionary<TParameter, float>
        //{

        //}
    }
}