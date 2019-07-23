using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RedSpark.Thot.Api.Domain.Core.Entities;

namespace RedSpark.Thot.Api.Infra.Data.EF.MapConfig.Extensions
{
    public static class EntityTypeBuilderGenericExtentions
    {

        public static void ConfigMapDefaultFields<TEntity>(this EntityTypeBuilder<TEntity> builder) where TEntity : Entity
        {

            builder
               .Property(l => l.CreateDate)
               .HasColumnType("datetime")
               .HasField("_createDate"); // Nome da variavel privada.

            builder
                .Property(l => l.UpdateDate)
                .HasColumnType("datetime")
                .HasField("_updateDate");
        }

    }
}
