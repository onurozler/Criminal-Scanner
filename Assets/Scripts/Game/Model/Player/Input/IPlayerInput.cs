using System;
using UnityEngine;
using Zenject;

namespace Game.Model.Player.Input
{
    public interface IPlayerInput : ITickable
    {
        event Action OnHoldingUp;
        event Action OnHoldingDown;
        Vector2 Position { get; }
    }
}
