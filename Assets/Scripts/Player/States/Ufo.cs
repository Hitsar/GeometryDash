using UnityEngine;

namespace Player.States
{
    public class Ufo : PlayerMovement
    {
        [SerializeField] private float _jumpForce = 24;

        protected override void Action() { if (InputSystem.Player.Jump.WasPerformedThisFrame()) Jump(_jumpForce); }
    }
}