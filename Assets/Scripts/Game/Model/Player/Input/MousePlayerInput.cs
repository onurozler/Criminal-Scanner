using System;
using UnityEngine;
using UnityInput = UnityEngine.Input;

namespace Game.Model.Player.Input
{
    public class MousePlayerInput : IPlayerInput
    {
        public event Action OnHoldingUp;
        public event Action OnHoldingDown;

        public Vector2 Position => UnityInput.mousePosition;

        public void Tick()
        {
            if (UnityInput.GetMouseButton(0))
            {
                OnHoldingDown?.Invoke();
            }
            else
            {
                OnHoldingUp?.Invoke();
            }
        }
    }
}
