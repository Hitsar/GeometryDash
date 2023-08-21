using Player;
using Player.States;
using UnityEngine;
using Zenject;

namespace Items
{
    public abstract class ItemsActions : MonoBehaviour
    {
        [SerializeField] private float _jumpForce;
        
        [SerializeField] private bool _isGravity;
        
        [SerializeField] private bool _isState;
        [SerializeField] private PlayerStates _playerStates;

        [SerializeField] private Transform _position;

        [Inject] private PlayerStateManager _playerStateManager;

        protected void Action()
        {
            Teleportation();
            ChangeState();
            ChangeGravity();
            Jump();
        }
        
        private void Jump() { if (_jumpForce != 0) _playerStateManager.CurrentState.Jump(_jumpForce); }

        private void ChangeState() { if (_isState) _playerStateManager.ChangeState(_playerStates); }
        
        private void ChangeGravity()
        {
        }

        private void Teleportation() { if (_position != null) _playerStateManager.CurrentState.transform.position = _position.position; }
    }
}