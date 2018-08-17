using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util.Interfaces
{
    public interface IMapper<TSource, SDest>
    {
        SDest MapNew(TSource src);
        void Map(TSource src, SDest dest);
    }
}
