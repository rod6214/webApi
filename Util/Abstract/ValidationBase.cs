using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util.Abstract
{
    public abstract class ValidationBase<TSource>
    {
        protected abstract bool DeleteValidation(TSource model);
        protected abstract bool RegisterValidation(TSource model);
        protected abstract bool UpdateValidation(TSource model);
        protected abstract bool ViewAllValidation(TSource model);
        protected abstract bool ViewOneValidation(TSource model);
    }
}
