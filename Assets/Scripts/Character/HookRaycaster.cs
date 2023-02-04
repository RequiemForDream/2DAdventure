using UnityEngine;

public class HookRaycaster : MonoBehaviour
{
    [SerializeField] private LayerMask hookableMask;

    public RaycastHit2D Raycast(Vector2 origin, Vector2 target, float distance)
    {
        return Physics2D.Raycast(origin, target - origin, distance, hookableMask);
    }
}
