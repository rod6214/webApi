using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util.Interfaces
{
    public interface ILogin<UserModel, HashModel>
    {
        bool ValidateUser(UserModel usr);
        HashModel GetHashToken();
    }
}
