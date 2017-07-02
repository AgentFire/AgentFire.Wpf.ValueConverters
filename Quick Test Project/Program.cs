using AgentFire.Wpf.ValueConverters.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Quick_Test_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            object o = (int)1234;
            var v = CastTo<byte>.From(o);

            //int r = o as int;

            Expression<Func<object, int>> e = T => (int)T;

            ParameterExpression p = Expression.Parameter(typeof(object), "source");
            var u = Expression.Unbox(p, typeof(int));
            var c = Expression.ConvertChecked(u, typeof(int));
            var l = Expression.Lambda<Func<object, int>>(c, p).Compile();
            //int v = l(o);
            //Expression.Unbox(p,
        }
    }
}
