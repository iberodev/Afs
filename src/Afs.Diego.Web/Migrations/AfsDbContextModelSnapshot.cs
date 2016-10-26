using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Afs.Diego.Data.SqlServer.Storage.EF;

namespace Afs.Diego.Web.Migrations
{
    [DbContext(typeof(AfsDbContext))]
    partial class AfsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Afs.Diego.Data.Entities.ApiRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<int>("ApiRequestType");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<string>("Error")
                        .HasAnnotation("MaxLength", 2000);

                    b.Property<int>("HttpMethod");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime>("RequestBeginTime");

                    b.Property<DateTime?>("RequestEndTime");

                    b.Property<string>("RequestUrl")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 2000);

                    b.Property<int?>("ResponseCode")
                        .HasAnnotation("MaxLength", 3);

                    b.Property<string>("ResponseText")
                        .HasAnnotation("MaxLength", 2000);

                    b.HasKey("Id");

                    b.ToTable("ApiRequests");
                });
        }
    }
}
