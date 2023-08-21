using UnityEngine;
using Zenject;

namespace Items
{
    public class Orb : ItemsActions
    {
        [Inject] private InputSystem _inputSystem;
        private bool _canTouch = true;

        private void OnTriggerStay2D(Collider2D other)
        {
            if (_canTouch && _inputSystem.Player.Jump.WasPerformedThisFrame())
            {
                _canTouch = false;
                Action();
            }
        }
    }
}