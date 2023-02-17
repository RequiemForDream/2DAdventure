using UnityEngine;

namespace Assets.Scripts.Character.Interactive
{
    [RequireComponent(typeof(Collider2D))]
    public class LadderDetector : MonoBehaviour
    {
        public static bool isAbleToClimb { get; private set; }

        [SerializeField] private new Rigidbody2D rigidbody2D;

        private void Start()
        {
            rigidbody2D = GetComponentInParent<Rigidbody2D>();
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.gameObject.layer == 9)
            {
                isAbleToClimb = true;
                rigidbody2D.gravityScale = 0f;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.layer == 9)
            {
                isAbleToClimb = false;
                rigidbody2D.gravityScale = 1f;
            }
        }
    }
}

