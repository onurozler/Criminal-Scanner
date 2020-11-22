using System;
using UnityEngine;
using UnityInput = UnityEngine.Input;

namespace Game.Model.Player.Input
{
    public class MousePlayerInput : IPlayerInput
    {
        public event Action OnClicked;
        public event Action OnHoldingDown;

        public Vector2 Position => UnityInput.mousePosition;

        public void Tick()
        {
            if (UnityInput.GetMouseButton(0))
            {
                OnHoldingDown?.Invoke();
            }
            if (UnityInput.GetMouseButtonUp(0))
            {
                OnClicked?.Invoke();
            }
        }
    }
}
