using Game.Model.Criminal.State;
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
        
        public void OnCurrentCriminalStateChanged(CriminalState criminalState)
        {
            switch (criminalState)
            {
                case CriminalState.Scanning:
                    _playerData.State = PlayerState.Scanning;
                    break;
                case CriminalState.MoveToCenter:
                case CriminalState.Rotate:
                case CriminalState.GoOut:
                    _playerData.State = PlayerState.None;
                    break;
            }
        }
    }
}
