using Assets.Scripts.Character.Colliders;
using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlatformChecker : MonoBehaviour, IPlatformable
{   
    public bool isOnPlatform { get => _isOnPlatform; }

    public float time;
    private GameObject currentOneWayPlatform;
    private bool _isOnPlatform;
    private Collider2D checkPlatformCollider;

    private void Start()
    {
        checkPlatformCollider = GetComponent<Collider2D>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlatformEffector2D>())
        {
            currentOneWayPlatform = collision.gameObject;
            _isOnPlatform = true;                 
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlatformEffector2D>())
        {
            currentOneWayPlatform = null;
            _isOnPlatform = false;
        }
    }

    public void TurnOffTrigger()
    {
        StartCoroutine(TriggerRoutine());
    }

    private IEnumerator TriggerRoutine()
    {
        var platformCollider = currentOneWayPlatform.GetComponent<TilemapCollider2D>();

        Physics2D.IgnoreCollision(checkPlatformCollider, platformCollider);
        yield return new WaitForSeconds(time);
        Physics2D.IgnoreCollision(checkPlatformCollider, platformCollider, false);
    }
}
