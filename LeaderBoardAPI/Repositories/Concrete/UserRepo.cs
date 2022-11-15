using LeaderBoardAPI.Entities;
using LeaderBoardAPI.Helpers;
using LeaderBoardAPI.Repositories.Abstract;

namespace LeaderBoardAPI.Repositories.Concrete;

public class UserRepo : Repository<User>,IUserRepo
{
    public UserRepo(DataContext context) : base(context)
    {
        
    }
}