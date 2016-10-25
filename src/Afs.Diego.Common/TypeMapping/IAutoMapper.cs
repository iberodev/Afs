namespace Afs.Diego.Common.TypeMapping
{
    public interface IAutoMapper
    {
        TDestination Map<TDestination>(object source);

        TDestination Map<TSource, TDestination>(TSource source);

        TDestination Map<TSource, TDestination>(TSource source, TDestination dest);
    }
}
