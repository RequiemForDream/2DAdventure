using UnityEngine;

public class Trampoline : MonoBehaviour
{
    [SerializeField] private float bounce = 20f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var bounceObject = collision.gameObject.GetComponent<Rigidbody2D>();
        if (bounceObject)
        {
            bounceObject.AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
        }
    }
}
