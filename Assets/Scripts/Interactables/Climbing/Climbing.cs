using UnityEngine;

public class Climbing : MonoBehaviour
{
    public static bool isAbleToClimb { get; private set; }

    [SerializeField] private LayerMask ladderMask;
    
    private new Rigidbody2D rigidbody2D;   

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
