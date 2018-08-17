

namespace Util.Enums
{
    public enum AccountAccess
    {
        ADMIN = 4,
        USER = 2,
        ROOT = 8,
        ALL = ADMIN | USER | ROOT,
        UNDEFINED
    }
}
