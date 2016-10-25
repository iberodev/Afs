using AutoMapper;

namespace Afs.Diego.Common.TypeMapping
{
    public interface IAutoMapperTypeConfigurator
    {
        void Configure(IMapperConfigurationExpression cfg);
    }
}
