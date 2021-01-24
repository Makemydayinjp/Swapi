using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SwapiRater.DAL.Models;

namespace SwapiRater.DAL.ModeConfig
{
    public class MovieConfig : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.ToTable(nameof(Movie));
            builder.HasKey(i => i.Id);
            builder.Property(i => i.EpisodeId).IsRequired();
            builder.Property(i => i.Grade).IsRequired(); ;
        }
    }
}
