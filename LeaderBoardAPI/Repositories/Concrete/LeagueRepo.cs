using LeaderBoardAPI.Entities;
using LeaderBoardAPI.Helpers;
using LeaderBoardAPI.Repositories.Abstract;

namespace LeaderBoardAPI.Repositories.Concrete;

public class LeagueRepo : Repository<League>,ILeagueRepo
{
    public LeagueRepo(DataContext context) : base(context)
    {
    }
}