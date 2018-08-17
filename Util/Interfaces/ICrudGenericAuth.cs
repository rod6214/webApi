using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util.Interfaces
{
    public interface ICrudGenericAuth<TAthModel, TModel>
    {
        IEnumerable<TModel> GetAll(TAthModel athModel);
        TModel GetById(TAthModel athModel, int id);
        bool Register(TAthModel athModel, TModel src);
        bool Update(TAthModel athModel, TModel src);
        bool Delete(TAthModel athModel, int id);
    }
}
