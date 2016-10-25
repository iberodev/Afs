using Afs.Diego.Common.Extensions;
using Afs.Diego.Common.TypeMapping;
using Afs.Diego.Web.Model;
using AutoMapper;

namespace Afs.Diego.Web.AutoMappingConfiguration
{
    public class ApiRequestEntityToApiRequestTypeConfigurator : IAutoMapperTypeConfigurator
    {
        public void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Data.Entities.ApiRequest, ApiRequest>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(a => a.Id))
                .ForMember(dest => dest.ApiRequestType, opt => opt.MapFrom(a => a.ApiRequestType))
                .ForMember(dest => dest.ApiRequestTypeText, opt => opt.ResolveUsing(a => a.ApiRequestType.GetDisplayName()))
                .ForMember(dest => dest.HttpMethod, opt => opt.MapFrom(a => a.HttpMethod))
                .ForMember(dest => dest.HttpMethodText, opt => opt.ResolveUsing(a => a.HttpMethod.GetDisplayName()))
                .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(a => a.CreatedOn))
                .ForMember(dest => dest.Error, opt => opt.MapFrom(a => a.Error))
                .ForMember(dest => dest.RequestBeginTime, opt => opt.MapFrom(a => a.RequestBeginTime))
                .ForMember(dest => dest.RequestEndTime, opt => opt.MapFrom(a => a.RequestEndTime))
                .ForMember(dest => dest.RequestUrl, opt => opt.MapFrom(a => a.RequestUrl))
                .ForMember(dest => dest.ResponseCode, opt => opt.MapFrom(a => a.ResponseCode))
                .ForMember(dest => dest.ResponseText, opt => opt.MapFrom(a => a.ResponseText));
        }
    }
}
