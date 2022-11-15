using LeaderBoardAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaderBoardAPI.Helpers.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        User[] users =
        {
            new() { Username= "Guest_2001",Score =50} ,
            new() { Username="Guest_2010",Score =75 } ,
            new() { Username="Guest_2020",Score =67 } ,
            new() { Username="Guest_2030",Score = 100}
        };

        builder.HasData(users);
    }
}