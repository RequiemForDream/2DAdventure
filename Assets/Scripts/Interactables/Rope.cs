using UnityEngine;

public class Rope : MonoBehaviour
{
    [SerializeField] private Transform ropeChecker;
    [SerializeField] private float checkRopeRadius;
    [SerializeField] private LayerMask ropeMask;

    [SerializeField] private new Rigidbody2D rigidbody2D;

    private void FixedUpdate()
    {
        if (IsOnRope())
        {
            rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
        }
    }

    private bool IsOnRope()
    {
        bool result = Physics2D.OverlapCircle(ropeChecker.position, checkRopeRadius, ropeMask);
        return result;
    }
}
