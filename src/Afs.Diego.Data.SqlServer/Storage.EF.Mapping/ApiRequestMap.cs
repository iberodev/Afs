using Afs.Diego.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Afs.Diego.Data.SqlServer.Storage.EF.Mapping
{
    public class ApiRequestMap
    {
        public ApiRequestMap(EntityTypeBuilder<ApiRequest> entityBuilder)
        {
            entityBuilder.HasKey(a => a.Id);

            entityBuilder.Property(a => a.Id)
                .HasDefaultValueSql("newsequentialid()");

            entityBuilder.Property(a => a.HttpMethod);

            entityBuilder.Property(a => a.ApiRequestType);

            entityBuilder.Property(a => a.IsDeleted)
                .IsRequired(true);

            entityBuilder.Property(a => a.RequestUrl)
                .HasMaxLength(2000)
                .IsRequired(true);

            entityBuilder.Property(a => a.ResponseText)
                .HasMaxLength(2000)
                .IsRequired(false);

            entityBuilder.Property(a => a.ResponseCode)
                .HasMaxLength(3)
                .IsRequired(false);

            entityBuilder.Property(a => a.Error)
                .HasMaxLength(2000)
                .IsRequired(false);

            entityBuilder.Property(a => a.CreatedOn)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("getutcdate()")
                .IsRequired(true);
            
            entityBuilder.Property(a => a.RequestBeginTime)
                .IsRequired(true);

            entityBuilder.Property(a => a.RequestEndTime)
                .IsRequired(false);
        }
    }
}
