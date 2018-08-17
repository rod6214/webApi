using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util.Converters.Generic
{
    public class ListParser<TResult, TParam>
    {
        public static ICollection<TResult> ToCollection(ICollection<TParam> list, 
            Func<TParam, TResult> converter)
        {
            ICollection<TResult> result = new List<TResult>();
            if(list != null)
                foreach (var element in list)
                    result.Add(converter(element));
            return result;
        }

        public static List<TResult> ToList(ICollection<TParam> list, 
            Func<TParam, TResult> converter)
        {
            return ToCollection(list, converter) as List<TResult>;
        }
    }
}
