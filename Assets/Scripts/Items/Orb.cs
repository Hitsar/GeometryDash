using Player;
using UnityEngine;
using Zenject;

namespace Items
{
    public class Orb : MonoBehaviour
    {
        [SerializeField] private float _jumpForce;
        private PlayerStateManager _playerStateManager;
        private InputSystem _inputSystem;
        private bool _canJump = true;

        [Inject]
        private void Init(PlayerStateManager playerStateManager, InputSystem inputSystem)
        {
            _playerStateManager = playerStateManager;
            _inputSystem = inputSystem;
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (_canJump && _inputSystem.Player.Jump.WasPerformedThisFrame())
            {
                _playerStateManager.CurrentState.Jump(_jumpForce);
                _canJump = false;
            }
        }
    }
}