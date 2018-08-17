using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util.Interfaces
{
    public interface ICrud<TSource>
    {
        IEnumerable<TSource> GetAll();
        TSource GetById(int id);
        TSource Register(TSource src);
        void Update(TSource src);
        void Delete(int id);
    }
}
