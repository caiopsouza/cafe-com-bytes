using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Take.Entities;

namespace Take.EntityTypes
{
    public class RateType : IEntityTypeConfiguration<Rate>
    {
        public void Configure(EntityTypeBuilder<Rate> builder)
        {
            builder.HasKey(o => new { o.UserId, o.MovieId });
        }
    }
}
