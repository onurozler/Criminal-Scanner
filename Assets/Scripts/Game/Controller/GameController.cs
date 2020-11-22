using Game.Model.Game;
using Game.Model.Player;
using Zenject;

namespace Game.Controller
{
    public class GameController : IInitializable
    {
        private IPlayerData _playerData;
        private IGameData _gameData;
        
        public GameController(IPlayerData playerData,IGameData gameData)
        {
            _playerData = playerData;
            _gameData = gameData;
        }

        public void Initialize()
        {
            _gameData.State = GameState.Started;
        }
    }
}
