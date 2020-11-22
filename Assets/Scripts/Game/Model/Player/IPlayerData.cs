
namespace Game.Model.Player
{
    public interface IPlayerData
    {
        PlayerState State { get; set; }
    }

    public enum PlayerState
    {
        None,
        Scanning
    }
}
