using System;

namespace Game.Model.Game
{
    public interface IGameData 
    {
        int Level { get; set; }
        int HiddenTotalCount { get; }
        int HiddenFrontCount { get; }
        event Action<GameState> OnGameStateChanged;
        GameState State { get; set; }
    }

    public enum GameState
    {
        Started,
        Finished
    }
}
