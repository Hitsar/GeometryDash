using UnityEngine;

namespace Items
{
    public class TriggerItem : ItemsActions
    {
        private void OnTriggerEnter2D(Collider2D other) => Action();
    }
}