namespace Util.Interfaces
{
    public interface IValidation<TSource>
    {
        bool DeleteValidation(TSource model);
        bool RegisterValidation(TSource model);
        bool UpdateValidation(TSource model);
        bool ViewOneValidation(TSource model);
        bool ViewAllValidation(TSource model);
    }
}
