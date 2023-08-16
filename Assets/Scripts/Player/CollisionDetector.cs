using Components;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
    public class CollisionDetector : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other) { if (other.gameObject.TryGetComponent(out Flor _)) SceneManager.LoadScene(0); }

        private void OnCollisionEnter2D(Collision2D other) { if (other.gameObject.TryGetComponent(out Spike _)) SceneManager.LoadScene(0); }
    }
}