using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Arrow : DamageThing
{
    [SerializeField] private float forceSpeed;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private Transform groundChecker;
    [SerializeField] private float checkGroundRadius = 0.4f;
    [SerializeField] private float velocity;
    [SerializeField] private Vector3 rotation;

    private new Rigidbody2D rigidbody2D;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamagePlayer(collision);
        gameObject.SetActive(false);
    }

    private void Update()
    {        
        if (IsOnGround())
        {
            gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        rigidbody2D.MovePosition(new Vector2(transform.position.x, transform.position.y + velocity));
        transform.rotation = Quaternion.Euler(rotation.x, rotation.y, rotation.z);
    }

    private bool IsOnGround()
    {
        bool result = Physics2D.OverlapCircle(groundChecker.position, checkGroundRadius, groundMask);
        return result;
    }
}
