using UnityEngine;
using Zenject;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class PlayerMovement : MonoBehaviour
    {
        private float _speed = 9;
        private Rigidbody2D _rigidbody;

        [Inject] protected InputSystem InputSystem { get; private set; }
        protected bool IsGround { get; private set; }

        private void Start()
        {
            InputSystem.Player.Enable();
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            transform.Translate(_speed * Time.deltaTime * Vector3.right);
            Action();
        }

        protected abstract void Action();

        public void Jump(float force)
        {
            _rigidbody.velocity = Vector2.zero;
            _rigidbody.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        }

        private void OnCollisionEnter2D(Collision2D other) => IsGround = true;

        private void OnCollisionExit2D(Collision2D other) => IsGround = false;
    }
}