using AutoMapper;

namespace Afs.Diego.Common.TypeMapping
{
    public class AutoMapperAdapter : IAutoMapper
    {
        public TDestination Map<TDestination>(object source)
        {
            return Mapper.Map<TDestination>(source);
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return Mapper.Map<TSource, TDestination>(source);
        }

        public TDestination Map<TSource, TDestination>(TSource source, TDestination dest)
        {
            return Mapper.Map(source, dest);
        }
    }
}
