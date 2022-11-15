namespace LeaderBoardAPI.Entities;

public class League : BaseEntity
{
    public string LeagueName { get; set; }
    public virtual ICollection<User>? Users { get; set; }
}