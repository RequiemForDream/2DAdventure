using UnityEngine;

namespace Assets.Scripts.Character.Colliders
{
    public class GemController : MonoBehaviour
    {
        [SerializeField] private GemModel gemModel;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Gem gem))
            {

            }
        }
    }
}