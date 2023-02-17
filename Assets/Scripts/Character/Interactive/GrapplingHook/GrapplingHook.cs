using UnityEngine;

[RequireComponent(typeof(DistanceJoint2D))]
public class GrapplingHook : MonoBehaviour
{
    [SerializeField] private float maximalLength = 8;
    [SerializeField] private float displacementSpeed = 0.02f;   
    [SerializeField] private HookRaycaster raycaster;
    [SerializeField] private HookRenderer hookRenderer;
    [SerializeField] private new Rigidbody2D rigidbody2D;

    private Camera mainCamera;
    private RaycastHit2D hit;
    private DistanceJoint2D distanceJoint;
    
    public bool isOnHook { get; private set; }

    private void Start()
    {
        mainCamera = Camera.main;
        distanceJoint = GetComponent<DistanceJoint2D>();
        distanceJoint.enabled = false;
    }

    private void Update()
    {
        if (distanceJoint.enabled) 
        {
            hookRenderer.Render(transform.position, hit.point);
            isOnHook = true;
        }
        else
        {
            isOnHook = false;
        }       

        if (distanceJoint.distance > maximalLength)
        {
            distanceJoint.distance = maximalLength;
        }
    }

    public void Climb()
    {
        EditJointDistance(-displacementSpeed);
    }

    public void Descend()
    {
        EditJointDistance(displacementSpeed);
    }

    public void CreateHook()
    {
        Vector2 target = mainCamera.ScreenToWorldPoint(Input.mousePosition); 
        hit = raycaster.Raycast(transform.position, target, maximalLength);

        if (hit.collider != null)
        {           
            distanceJoint.enabled= true;
            distanceJoint.connectedAnchor = hit.point;

            distanceJoint.distance = Vector2.Distance(transform.position, hit.point);
            hookRenderer.Render(transform.position, hit.point);
        }
        else
        {
            distanceJoint.enabled = false;
            hookRenderer.Disable();
        }
    }

    public void Disable()
    {
        distanceJoint.enabled = false;
        hookRenderer.Disable();
    }

    private void EditJointDistance(float delta)
    {
        distanceJoint.distance += delta + Time.deltaTime;
    }
}
