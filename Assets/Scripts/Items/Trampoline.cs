using Player;
using UnityEngine;
using Zenject;

namespace Items
{
    public class Trampoline : MonoBehaviour
    {
        [SerializeField] private float _jumpForce;
        [Inject] private PlayerStateManager _playerStateManager;

        private void OnTriggerEnter2D(Collider2D other) => _playerStateManager.CurrentState.Jump(_jumpForce);
    }
}