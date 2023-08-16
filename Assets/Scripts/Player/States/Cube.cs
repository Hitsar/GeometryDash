using UnityEngine;

namespace Player.States
{
    public class Cube : PlayerMovement
    {
        [SerializeField] private float _jumpForce = 24;

        protected override void Action() { if (IsGround && InputSystem.Player.Jump.IsPressed()) Jump(_jumpForce); }
    }
}