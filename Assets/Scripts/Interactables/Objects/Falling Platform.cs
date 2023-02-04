using Assets.Scripts.MainCharacterController;
using DG.Tweening;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class FallingPlatform : MonoBehaviour
{
    [SerializeField] private float timeToFalling = 3f;

    private new Rigidbody2D rigidbody2D;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IControllable controllable))
        {
            StartCoroutine(PlatformFalling());
        }
    }

    private IEnumerator PlatformFalling()
    {
        yield return new WaitForSeconds(timeToFalling);
        rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
    }
}
