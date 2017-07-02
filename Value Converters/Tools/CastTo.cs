using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AgentFire.Wpf.ValueConverters.Tools
{
    /// <summary>
    /// Class to cast to type <see cref="T"/>
    /// </summary>
    /// <typeparam name="T">Target type</typeparam>
    public static class CastTo<T>
    {
        /// <summary>
        /// Casts <see cref="S"/> to <see cref="T"/>. 
        /// This does not cause boxing for value types. 
        /// Useful in generic methods
        /// </summary>
        /// <typeparam name="S">Source type to cast from. Usually a generic type.</typeparam>
        public static T From<S>(S s)
        {
            Type type;

            if ((typeof(S).IsInterface || typeof(S) == typeof(object)) && s != null && (type = s.GetType()).IsValueType)
            {
                if (!Cache<S>.UnboxingCasters.TryGetValue(type, out Func<S, T> caster))
                {
                    Cache<S>.UnboxingCasters[type] = caster = Cache<S>.GetUnboxing(type);
                }

                return caster(s);
            }

            return Cache<S>.Caster(s);
        }

        private static class Cache<S>
        {
            public static readonly Func<S, T> Caster = Get();
            public static readonly Dictionary<Type, Func<S, T>> UnboxingCasters = new Dictionary<Type, Func<S, T>>();

            private static Func<S, T> Get()
            {
                ParameterExpression p = Expression.Parameter(typeof(S), "source");
                UnaryExpression c = Expression.ConvertChecked(p, typeof(T));
                return Expression.Lambda<Func<S, T>>(c, p).Compile();
            }
            public static Func<S, T> GetUnboxing(Type type)
            {
                ParameterExpression p = Expression.Parameter(typeof(S), "source");
                UnaryExpression u = Expression.Unbox(p, type);
                UnaryExpression c = Expression.ConvertChecked(u, typeof(T));
                return Expression.Lambda<Func<S, T>>(c, p).Compile();
            }
        }
    }
}
