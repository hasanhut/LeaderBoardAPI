namespace LeaderBoardAPI.Entities;

public class User : BaseEntity
{
    public int Id { get; set; }
    public string Username { get; set; }
    public int Score { get; set; }
    public int? LeagueId { get; set; }
}