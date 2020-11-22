using System;

namespace Game.Model.Game
{
    public interface IGameData 
    {
        event Action<GameState> OnGameStateChanged;
        GameState State { get; set; }
    }

    public enum GameState
    {
        Started,
        Playing,
        Finished
    }
}
