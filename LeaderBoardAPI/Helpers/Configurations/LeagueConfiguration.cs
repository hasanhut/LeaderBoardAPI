using LeaderBoardAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaderBoardAPI.Helpers.Configurations;

public class LeagueConfiguration : IEntityTypeConfiguration<League>
{
    public void Configure(EntityTypeBuilder<League> builder)
    {
        League[] leagues =
        {
            new() { LeagueName= "Altin" } ,
            new() { LeagueName= "gumus" } ,
            new() { LeagueName= "Bronz" } ,
        };

        builder.HasData(leagues);
    }
}