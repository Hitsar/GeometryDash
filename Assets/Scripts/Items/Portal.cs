using Player;
using Player.States;
using UnityEngine;
using Zenject;

namespace Items
{
    public class Portal : MonoBehaviour
    {
        [SerializeField] private PlayerStates _portalState;
        [Inject] private PlayerStateManager _playerStateManager;

        private void OnTriggerEnter2D(Collider2D other) => _playerStateManager.ChangeState(_portalState);
    }
}